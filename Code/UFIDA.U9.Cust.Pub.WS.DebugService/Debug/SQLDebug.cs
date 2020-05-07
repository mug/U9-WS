using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Transactions;
using Harmony;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;
using UFIDA.U9.Cust.Pub.WS.DebugService.Models;
using UFSoft.UBF.AopFrame;
using UFSoft.UBF.Transactions;
using UFSoft.UBF.Util.Context;
using UFSoft.UBF.Util.DataAccess;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.DebugService.Debug
{
    /// <summary>
    ///     SQL调试
    /// </summary>
    public class SQLDebug
    {
        private static readonly ILogger Logger = LoggerManager.GetLogger(typeof (SQLDebug));
        private static readonly string DebugID = typeof (SQLDebug).FullName;
        private static string DebugGuid = string.Empty;
        private static readonly object LockObject = new object();
        private static SQLDebugConfig _debugConfig;

        #region Other

        /// <summary>
        ///     设置配置
        /// </summary>
        /// <param name="debugConfig"></param>
        private static void SetConfig(SQLDebugConfig debugConfig)
        {
            if (debugConfig == null)
                throw new ArgumentException("debugConfig is null");
            lock (LockObject)
            {
                _debugConfig = debugConfig;
            }
        }

        /// <summary>
        ///     是否记录日志
        /// </summary>
        /// <param name="enterpriseID"></param>
        /// <param name="orgCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        private static bool IsLog(string enterpriseID, string orgCode, string userCode)
        {
            if (_debugConfig == null) return false;
            if (!string.IsNullOrWhiteSpace(_debugConfig.EnterpriseID) &&
                enterpriseID != _debugConfig.EnterpriseID) return false;
            if (!string.IsNullOrWhiteSpace(_debugConfig.OrgCode) &&
                orgCode != _debugConfig.OrgCode) return false;
            if (!string.IsNullOrWhiteSpace(_debugConfig.UserCode) &&
                userCode != _debugConfig.UserCode) return false;
            return true;
        }

        /// <summary>
        ///     是否记录日志
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="commandText"></param>
        /// <param name="dataParamsString"></param>
        /// <param name="commandType"></param>
        /// <param name="enterpriseID"></param>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        private static bool IsLog(string enterpriseID, string orgCode, string userCode, string commandText,
            string dataParamsString, CommandType commandType)
        {
            if (_debugConfig == null) return false;
            if (!IsLog(enterpriseID, orgCode, userCode)) return false;
            commandText = commandText.ToLower().Trim();
            //换掉回车
            commandText = commandText.Replace("\r\n", "");
            bool isInsert = commandText.StartsWith("insert");
            bool isUpdate = commandText.StartsWith("update");
            bool isDelete = commandText.StartsWith("delete");
            bool isSelect = !isInsert && !isUpdate & !isDelete;
            if (!_debugConfig.IsContainInsert && isInsert) return false;
            if (!_debugConfig.IsContainUpdate && isUpdate) return false;
            if (!_debugConfig.IsContainDelete && isDelete) return false;
            if (!_debugConfig.IsContainSelect && isSelect) return false;
            if (_debugConfig.CommandType > 0)
            {
                if (_debugConfig.CommandType == 1 && commandType != CommandType.Text) return false;
                if (_debugConfig.CommandType == 2 && commandType != CommandType.StoredProcedure) return false;
                if (_debugConfig.CommandType == 3 && commandType != CommandType.TableDirect) return false;
            }
            if (!string.IsNullOrWhiteSpace(_debugConfig.SQLFilterString))
            {
                //多个空格替换成一个空格
                //commandText = new Regex("[\\s]+").Replace(commandText, " ");
                dataParamsString = string.IsNullOrEmpty(dataParamsString) ? string.Empty : dataParamsString.ToLower();
                string[] arrSQLFilter = _debugConfig.SQLFilterString.Split(new[] {"\r\n"}, StringSplitOptions.None);
                foreach (string sqlFilter in arrSQLFilter)
                {
                    if (commandText.IndexOf(sqlFilter.ToLower(), StringComparison.Ordinal) < 0 &&
                        dataParamsString.IndexOf(sqlFilter.ToLower(), StringComparison.Ordinal) < 0) return false;
                }
            }
            return true;
        }

        private static string GetTableParamsValuesStr(SqlParameter tableParam)
        {
            DataTable dataTable = tableParam.Value as DataTable;
            string result;
            if (dataTable != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    foreach (DataColumn dataColumn in dataTable.Columns)
                    {
                        stringBuilder.Append(",");
                        stringBuilder.Append(dataColumn.ColumnName + ":" +
                                             (dataRow[dataColumn] == null ? "" : dataRow[dataColumn].ToString()));
                    }
                }
                if (stringBuilder.Length > 1)
                {
                    stringBuilder.Remove(0, 1);
                }
                result = stringBuilder.ToString();
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }

        /// <summary>
        ///     写入日志
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="enterpriseID"></param>
        /// <param name="orgCode"></param>
        /// <param name="userCode"></param>
        /// <param name="cmdType"></param>
        /// <param name="commandText"></param>
        /// <param name="dataParamsString"></param>
        private static void WriteSQLLog(string methodName, string enterpriseID, string orgCode, string userCode,
            CommandType cmdType, string commandText, string dataParamsString)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine().Append("   ").AppendFormat("SQL语句:{0}", commandText);
            sb.AppendLine().Append("   ").AppendFormat("SQL参数:{0}", dataParamsString);
            sb.AppendLine()
                .Append("   ")
                .AppendFormat("上下文信息:企业ID:{0} 组织编码:{1} 用户编码:{2} ", enterpriseID, orgCode, userCode);
            sb.AppendLine().Append("   ").AppendFormat("调用方法:{0} 命令类型:{1}", methodName, cmdType);
            if (_debugConfig.IsOutputSQLStack)
            {
                sb.AppendLine().Append("   ").Append("调用堆栈:");
                sb.AppendLine().AppendFormat("{0}", StackTraceHelper.GetCurrentStackTraceString(4));
            }
            Logger.Debug(sb.ToString());
        }

        /// <summary>
        ///     获取认证用户名称
        /// </summary>
        /// <returns></returns>
        private static string GetIdentityName()
        {
            string identity = string.Empty;
            if ((Thread.CurrentPrincipal != null) && (Thread.CurrentPrincipal.Identity != null) &&
                (Thread.CurrentPrincipal.Identity.Name != null))
            {
                identity = Thread.CurrentPrincipal.Identity.Name;
            }
            return identity;
        }

        #endregion

        #region Service

        /// <summary>
        ///     是否开启调试
        /// </summary>
        /// <returns></returns>
        public static bool IsSetupDebug()
        {
            HarmonyInstance instance = HarmonyInstance.Create(DebugID);
            return instance.HasAnyPatches(DebugID);
        }

        /// <summary>
        ///     启用调试
        /// </summary>
        /// <returns></returns>
        public static bool SetupDebug(SQLDebugConfig debugConfig)
        {
            //设置参数
            SetConfig(debugConfig);
            HarmonyInstance instance = HarmonyInstance.Create(DebugID);
            if (instance.HasAnyPatches(DebugID)) instance.UnpatchAll(DebugID);
            DebugGuid = Guid.NewGuid().ToString();
            try
            {
                if (debugConfig.IsContainInsert || debugConfig.IsContainDelete || debugConfig.IsContainUpdate ||
                    debugConfig.IsContainSelect)
                {
                    //启用SQL调试
                    Logger.Debug("启用SQL追踪:{0}", DebugGuid);
                    SetupSQLDebug(instance);
                }
                if (debugConfig.IsTraceBPSVTransaction || debugConfig.IsTraceCustomizeTransaction)
                {
                    //启用事务追踪
                    Logger.Debug("启用事务追踪:{0}", DebugGuid);
                    SetupTransactionScopeDebug(instance);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    Logger.Debug("开启调试异常:{0}", DebugGuid);
                    Logger.Debug(ex);
                    //停止追踪
                    StopDebug();
                }
                catch (Exception)
                {
                }
                throw;
            }
            return true;
        }

        /// <summary>
        ///     启用SQL调试
        /// </summary>
        /// <param name="instance"></param>
        private static void SetupSQLDebug(HarmonyInstance instance)
        {
            var patchClass = typeof (SQLDebug);
            Assembly assembly = typeof (DataAccessor).Assembly;
            Type msSqlAccessorType = assembly.GetType("UFSoft.UBF.Util.DataAccess.MsSqlAccessor");
            //Object
            var queryObectMethod = AccessTools.Method(msSqlAccessorType, "Query",
                new[]
                {
                    typeof (IDbConnection), typeof (string), typeof (DataParamList), typeof (object).MakeByRefType(),
                    typeof (CommandType)
                });
            var prefixQueryObjectMethod = patchClass.GetMethod("PrefixQueryObject");
            var postQueryObjectMethod = patchClass.GetMethod("PostfixQueryObject");
            var patcherQueryObject = new PatchProcessor(instance, new List<MethodBase> {queryObectMethod},
                new HarmonyMethod(prefixQueryObjectMethod), new HarmonyMethod(postQueryObjectMethod));
            patcherQueryObject.Patch();
            //DataSet
            var queryDataSetMethod = AccessTools.Method(msSqlAccessorType, "Query",
                new[]
                {
                    typeof (IDbConnection), typeof (string), typeof (DataParamList),
                    typeof (DataSet).MakeByRefType(),
                    typeof (CommandType)
                });
            var prefixQueryDataSetMethod = patchClass.GetMethod("PrefixQueryDataSet");
            var postQueryDataSetMethodMethod = patchClass.GetMethod("PostfixQueryDataSet");
            var patcherQueryDataSet = new PatchProcessor(instance, new List<MethodBase> {queryDataSetMethod},
                new HarmonyMethod(prefixQueryDataSetMethod), new HarmonyMethod(postQueryDataSetMethodMethod));
            patcherQueryDataSet.Patch();
            //DataReader
            var queryDataReaderMethod = AccessTools.Method(msSqlAccessorType, "Query",
                new[]
                {
                    typeof (IDbConnection), typeof (string), typeof (DataParamList),
                    typeof (IDataReader).MakeByRefType(),
                    typeof (CommandType)
                });
            var prefixQueryDataReaderMethod = patchClass.GetMethod("PrefixQueryDataReader");
            var postQueryDataReaderMethod = patchClass.GetMethod("PostfixQueryDataReader");
            var patcherQueryDataReader = new PatchProcessor(instance, new List<MethodBase> {queryDataReaderMethod},
                new HarmonyMethod(prefixQueryDataReaderMethod), new HarmonyMethod(postQueryDataReaderMethod));
            patcherQueryDataReader.Patch();
            //ExecuteWithTableParam
            var executeWithTableParamMethod = AccessTools.Method(msSqlAccessorType, "ExecuteWithTableParam",
                new[]
                {
                    typeof (IDbConnection), typeof (string), typeof (SqlParameter)
                });
            var prefixExecuteWithTableParamMethod = patchClass.GetMethod("PrefixExecuteWithTableParam");
            var postExecuteWithTableParamMethod = patchClass.GetMethod("PostfixExecuteWithTableParam");
            var patcherExecuteWithTableParam = new PatchProcessor(instance,
                new List<MethodBase> {executeWithTableParamMethod},
                new HarmonyMethod(prefixExecuteWithTableParamMethod),
                new HarmonyMethod(postExecuteWithTableParamMethod));
            patcherExecuteWithTableParam.Patch();
            //Execute
            var executeMethod = AccessTools.Method(msSqlAccessorType, "Execute",
                new[]
                {
                    typeof (IDbConnection), typeof (string), typeof (DataParamList),
                    typeof (CommandType)
                });
            var prefixExecuteMethod = patchClass.GetMethod("PrefixExecute");
            var postExecuteMethod = patchClass.GetMethod("PostfixExecute");
            var patcherExecute = new PatchProcessor(instance, new List<MethodBase> {executeMethod},
                new HarmonyMethod(prefixExecuteMethod), new HarmonyMethod(postExecuteMethod));
            patcherExecute.Patch();
            //UpdateBatch
            var updateBatchMethod = AccessTools.Method(msSqlAccessorType, "UpdateBatch",
                new[]
                {
                    typeof (IDbConnection), typeof (string), typeof (DataParamList),
                    typeof (CommandType)
                });
            var prefixUpdateBatchMethod = patchClass.GetMethod("PrefixUpdateBatch");
            var postUpdateBatchMethod = patchClass.GetMethod("PostfixUpdateBatch");
            var patcherUpdateBatch = new PatchProcessor(instance, new List<MethodBase> {updateBatchMethod},
                new HarmonyMethod(prefixUpdateBatchMethod), new HarmonyMethod(postUpdateBatchMethod));
            patcherUpdateBatch.Patch();
        }

        /// <summary>
        ///     启用事务追踪
        /// </summary>
        /// <param name="instance"></param>
        private static void SetupTransactionScopeDebug(HarmonyInstance instance)
        {
            var patchClass = typeof (SQLDebug);
            if (_debugConfig == null) return;
            if (_debugConfig.IsTraceCustomizeTransaction)
            {
                Type ubfTransactionScopeType = typeof (UBFTransactionScope);
                ConstructorInfo ubfTransactionScopeConstructor = AccessTools.DeclaredConstructor(
                    ubfTransactionScopeType, new[]
                    {
                        typeof (TransactionOption)
                    });
                var prefixUBFTransactionScopeConstructorMethod =
                    patchClass.GetMethod("PrefixUBFTransactionScopeConstructor");
                var PostfixUBFTransactionScopeConstructorMethod =
                    patchClass.GetMethod("PostfixUBFTransactionScopeConstructor");
                var patcherUBFTransactionScopeConstructor = new PatchProcessor(instance,
                    new List<MethodBase> {ubfTransactionScopeConstructor},
                    new HarmonyMethod(prefixUBFTransactionScopeConstructorMethod),
                    new HarmonyMethod(PostfixUBFTransactionScopeConstructorMethod));
                patcherUBFTransactionScopeConstructor.Patch();
            }
            if (_debugConfig.IsTraceBPSVTransaction)
            {
                Type transactionAttributeType = typeof (TransactionAttribute);
                var transactionAttributeProcessMethod = AccessTools.Method(transactionAttributeType, "Process",
                    new[]
                    {
                        typeof (object)
                    });
                var prefixTransactionAttributeProcessMethod = patchClass.GetMethod("PrefixTransactionAttributeProcess");
                var postfixTransactionAttributeProcessMethod =
                    patchClass.GetMethod("PostfixTransactionAttributeProcess");
                var patcherTransactionAttributeProcess = new PatchProcessor(instance,
                    new List<MethodBase> {transactionAttributeProcessMethod},
                    new HarmonyMethod(prefixTransactionAttributeProcessMethod),
                    new HarmonyMethod(postfixTransactionAttributeProcessMethod));
                patcherTransactionAttributeProcess.Patch();
            }
        }

        /// <summary>
        ///     停止追踪
        /// </summary>
        /// <returns></returns>
        public static bool StopDebug()
        {
            var instance = HarmonyInstance.Create(DebugID);
            if (instance.HasAnyPatches(DebugID))
            {
                Logger.Debug("关闭事务追踪:{0}", DebugGuid);
                instance.UnpatchAll(DebugID);
            }
            return true;
        }

        #endregion

        #region Debug

        public static void PrefixQueryObject(object __instance, IDbConnection con,
            string commandText,
            DataParamList dataParams,
            CommandType cmdType)
        {
            if (_debugConfig == null) return;
            const string methodName = "QueryObject";
            string enterpriseID = PlatformContext.Current.EnterpriseID;
            string orgCode = PlatformContext.Current.OrgCode;
            string userCode = PlatformContext.Current.UserCode;
            string dataParamsString = DataParamList.GetParamsValuesStr(dataParams);
            if (!IsLog(enterpriseID, orgCode, userCode, commandText, dataParamsString, cmdType)) return;
            //写入日志
            WriteSQLLog(methodName, enterpriseID, orgCode, userCode, cmdType, commandText, dataParamsString);
        }

        public static void PostfixQueryObject(object __instance, int __result, IDbConnection con,
            string commandText,
            DataParamList dataParams, CommandType cmdType)
        {
        }

        public static void PrefixQueryDataSet(object __instance, IDbConnection con, string commandText,
            DataParamList dataParams,
            DataSet ds, CommandType cmdType)
        {
            if (_debugConfig == null) return;
            const string methodName = "QueryDataSet";
            string enterpriseID = PlatformContext.Current.EnterpriseID;
            string orgCode = PlatformContext.Current.OrgCode;
            string userCode = PlatformContext.Current.UserCode;
            string dataParamsString = DataParamList.GetParamsValuesStr(dataParams);
            if (!IsLog(enterpriseID, orgCode, userCode, commandText, dataParamsString, cmdType)) return;
            //写入日志
            WriteSQLLog(methodName, enterpriseID, orgCode, userCode, cmdType, commandText, dataParamsString);
        }

        public static void PostfixQueryDataSet(object __instance, int __result, IDbConnection con, string commandText,
            DataParamList dataParams, DataSet ds, CommandType cmdType)
        {
        }

        public static void PrefixQueryDataReader(object __instance, IDbConnection con, string commandText,
            DataParamList dataParams,
            IDataReader dr, CommandType cmdType)
        {
            if (_debugConfig == null) return;
            const string methodName = "QueryDataReader";
            string enterpriseID = PlatformContext.Current.EnterpriseID;
            string orgCode = PlatformContext.Current.OrgCode;
            string userCode = PlatformContext.Current.UserCode;
            string dataParamsString = DataParamList.GetParamsValuesStr(dataParams);
            if (!IsLog(enterpriseID, orgCode, userCode, commandText, dataParamsString, cmdType)) return;
            //写入日志
            WriteSQLLog(methodName, enterpriseID, orgCode, userCode, cmdType, commandText, dataParamsString);
        }

        public static void PostfixQueryDataReader(object __instance, int __result, IDbConnection con, string commandText,
            DataParamList dataParams, IDataReader dr, CommandType cmdType)
        {
        }

        public static void PrefixExecuteWithTableParam(object __instance, IDbConnection sqlserver_conn,
            string commandText, SqlParameter tableParam)
        {
            if (_debugConfig == null) return;
            const string methodName = "ExecuteWithTableParam";
            string enterpriseID = PlatformContext.Current.EnterpriseID;
            string orgCode = PlatformContext.Current.OrgCode;
            string userCode = PlatformContext.Current.UserCode;
            string dataParamsString = GetTableParamsValuesStr(tableParam);
            if (!IsLog(enterpriseID, orgCode, userCode, commandText, dataParamsString, CommandType.Text)) return;
            //写入日志
            WriteSQLLog(methodName, enterpriseID, orgCode, userCode, CommandType.Text, commandText, dataParamsString);
        }

        public static void PostfixExecuteWithTableParam(object __instance, int __result, IDbConnection sqlserver_conn,
            string commandText,
            SqlParameter tableParam)
        {
        }

        public static void PrefixExecute(object __instance, IDbConnection con, string commandText,
            DataParamList dataParams, CommandType cmdType)
        {
            if (_debugConfig == null) return;
            const string methodName = "Execute";
            string enterpriseID = PlatformContext.Current.EnterpriseID;
            string orgCode = PlatformContext.Current.OrgCode;
            string userCode = PlatformContext.Current.UserCode;
            string dataParamsString = DataParamList.GetParamsValuesStr(dataParams);
            if (!IsLog(enterpriseID, orgCode, userCode, commandText, dataParamsString, CommandType.Text)) return;
            //写入日志
            WriteSQLLog(methodName, enterpriseID, orgCode, userCode, cmdType, commandText, dataParamsString);
        }

        public static void PostfixExecute(object __instance, int __result, IDbConnection con, string commandText,
            DataParamList dataParams, CommandType cmdType)
        {
        }

        public static void PrefixUpdateBatch(object __instance, IDbConnection con, string commandText,
            DataParamList dataParams, CommandType cmdType)
        {
            if (_debugConfig == null) return;
            const string methodName = "UpdateBatch";
            string enterpriseID = PlatformContext.Current.EnterpriseID;
            string orgCode = PlatformContext.Current.OrgCode;
            string userCode = PlatformContext.Current.UserCode;
            string dataParamsString = DataParamList.GetParamsValuesStr(dataParams);
            if (!IsLog(enterpriseID, orgCode, userCode, commandText, dataParamsString, CommandType.Text)) return;
            //写入日志
            WriteSQLLog(methodName, enterpriseID, orgCode, userCode, cmdType, commandText, dataParamsString);
        }

        public static void PostfixUpdateBatch(object __instance, IDbConnection con, string commandText,
            DataParamList dataParams, CommandType cmdType)
        {
        }

        #region 事务追踪

        public static void PrefixUBFTransactionScopeConstructor(TransactionOption option)
        {
        }

        public static void PostfixUBFTransactionScopeConstructor(UBFTransactionScope __instance,
            TransactionOption option)
        {
            if (_debugConfig == null) return;
            string enterpriseID = PlatformContext.Current.EnterpriseID;
            string orgCode = PlatformContext.Current.OrgCode;
            string userCode = PlatformContext.Current.UserCode;
            if (!IsLog(enterpriseID, orgCode, userCode)) return;
            StringBuilder sb = new StringBuilder();
            StackTrace stackTrace = new StackTrace(true);
            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                StackFrame frame = stackTrace.GetFrame(i);
                MethodBase method = frame.GetMethod();
                if (method.DeclaringType == null) continue;
                if (method.DeclaringType == typeof (SQLDebug)) continue;
                string assemblyFullName = method.DeclaringType.Assembly.FullName;
                sb.AppendFormat("自定义事务:");
                if (!string.IsNullOrEmpty(assemblyFullName))
                {
                    sb.Append(assemblyFullName.Split(',')[0]);
                    sb.Append("!");
                }
                sb.AppendFormat("{0}.{1} 事务类型:{2} 事务ID:{3}",
                    method.DeclaringType.FullName,
                    method.Name, option, Transaction.Current == null
                        ? string.Empty
                        : Transaction.Current.TransactionInformation.LocalIdentifier);
                break;
            }
            if (_debugConfig.IsOutputTransactionStack)
            {
                sb.AppendLine();
                sb.Append(StackTraceHelper.GetCurrentStackTraceString(4));
            }
            Logger.Debug(sb.ToString());
        }

        public static void PrefixTransactionAttributeProcess(TransactionAttribute __instance, object obj)
        {
        }

        public static void PostfixTransactionAttributeProcess(TransactionAttribute __instance, object obj)
        {
            if (_debugConfig == null) return;
            string enterpriseID = PlatformContext.Current.EnterpriseID;
            string orgCode = PlatformContext.Current.OrgCode;
            string userCode = PlatformContext.Current.UserCode;
            if (!IsLog(enterpriseID, orgCode, userCode)) return;
            StringBuilder sb = new StringBuilder();
            StackTrace stackTrace = new StackTrace(true);
            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                StackFrame frame = stackTrace.GetFrame(i);
                MethodBase method = frame.GetMethod();
                if (method.DeclaringType == null) continue;
                var transactionAttribute = Attribute.GetCustomAttribute(method, typeof (TransactionAttribute));
                if (transactionAttribute == null) continue;
                string assemblyFullName = method.DeclaringType.Assembly.FullName;
                sb.AppendFormat("BPSV事务:");
                if (!string.IsNullOrEmpty(assemblyFullName))
                {
                    sb.Append(assemblyFullName.Split(',')[0]);
                    sb.Append("!");
                }
                sb.AppendFormat("{0}.{1} 事务类型:{2} 事务ID:{3}",
                    method.DeclaringType.FullName,
                    method.Name, __instance.TransactionOption, Transaction.Current == null
                        ? string.Empty
                        : Transaction.Current.TransactionInformation.LocalIdentifier);
                break;
            }
            if (_debugConfig.IsOutputTransactionStack)
            {
                sb.AppendLine();
                sb.Append(StackTraceHelper.GetCurrentStackTraceString(4));
            }
            Logger.Debug(sb.ToString());
        }

        #endregion

        #endregion
    }
}