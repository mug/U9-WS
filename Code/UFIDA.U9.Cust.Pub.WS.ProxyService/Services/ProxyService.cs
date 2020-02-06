using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Activation;
using System.Text;
using UFIDA.U9.BS.Job.RequestClient;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.Json;
using UFIDA.U9.Cust.Pub.WS.Json.Serialization;
using UFIDA.U9.Cust.Pub.WS.ProxyService.Interfaces;
using UFIDA.U9.Cust.Pub.WS.ProxyService.Json;
using UFIDA.U9.Cust.Pub.WS.ProxyService.Models;
using UFIDA.U9.Cust.Pub.WS.ProxyService.Utils;
using UFSoft.UBF;
using UFSoft.UBF.Service.Base;
using UFSoft.UBF.Sys.Database;
using UFSoft.UBF.Util.DataAccess;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Services
{
    /// <summary>
    ///     代理服务
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProxyService : IProxyService
    {
        private const int DefaultInMaxWritingDepth = 4;
        private const int MaxInMaxWritingDepth = 8;
        private const int DefaultOutMaxWritingDepth = 4;
        private const int MaxOutMaxWritingDepth = 8;

        /// <summary>
        ///     查询服务信息
        /// </summary>
        /// <param name="bpsvTypeQuery"></param>
        /// <returns></returns>
        public ReturnMessage<List<BPSVType>> QueryBPSVType(BPSVTypeQuery bpsvTypeQuery)
        {
            if (bpsvTypeQuery == null)
                throw new ArgumentException("bpsvTypeQuery is null");
            if (string.IsNullOrWhiteSpace(bpsvTypeQuery.QueryStr))
                throw new ArgumentException("bpsvTypeQuery.QueryStr is empty");
            string[] arrQueryStr = bpsvTypeQuery.QueryStr.Split(' ');
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT B.DisplayName,
                       A.FullName,
                       C.AssemblyName,
                       C.Kind
                FROM UBF_MD_Class AS A
                    LEFT JOIN UBF_MD_Class_Trl AS B
                        ON A.Local_ID = B.Local_ID
                    LEFT JOIN UBF_MD_Component AS C
                        ON A.MD_Component_ID = C.ID
                    LEFT JOIN UBF_MD_Component_Trl AS D
                        ON C.Local_ID = D.Local_ID
                WHERE (
                          C.Kind = 'SV'
                          OR C.Kind = 'BP'
                      )
                      AND (");
            StringBuilder fullNameSb = new StringBuilder();
            StringBuilder displayNameSb = new StringBuilder();
            fullNameSb.Append("(");
            displayNameSb.Append("(");
            bool isFirst = true;
            DataParamList dataParams = new DataParamList();
            for (int i = 0; i < arrQueryStr.Length; i++)
            {
                string str = arrQueryStr[i];
                string paramName = "param" + i;
                if (string.IsNullOrWhiteSpace(str)) continue;
                if (!isFirst)
                {
                    fullNameSb.Append(" AND ");
                    displayNameSb.Append(" AND ");
                }
                fullNameSb.AppendFormat("A.FullName LIKE @{0}", paramName);
                displayNameSb.AppendFormat("B.DisplayName LIKE @{0}", paramName);
                dataParams.Add(DataParamFactory.CreateInput(paramName, string.Format("%{0}%", str), DbType.String));
                isFirst = false;
            }
            fullNameSb.Append(")");
            displayNameSb.Append(")");
            sb.Append(fullNameSb + " OR " + displayNameSb);
            sb.Append(")");
            DataSet dataSet;
            DataAccessor.RunSQL(DatabaseManager.GetCurrentConnection(), sb.ToString(), dataParams, out dataSet);
            List<BPSVType> list = new List<BPSVType>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    BPSVType bpsv = new BPSVType();
                    bpsv.DisplayName = AsString(row, "DisplayName");
                    bpsv.FullName = AsString(row, "FullName");
                    bpsv.AssemblyName = AsString(row, "AssemblyName");
                    bpsv.Kind = AsString(row, "Kind");
                    list.Add(bpsv);
                }
            }
            ReturnMessage<List<BPSVType>> ret = new ReturnMessage<List<BPSVType>>();
            ret.Result = list;
            ret.IsSuccess = true;
            return ret;
        }

        /// <summary>
        ///     获取代理请求对象
        /// </summary>
        /// <param name="proxyType"></param>
        /// <returns></returns>
        public ReturnMessage<Proxy> GetProxy(ProxyType proxyType)
        {
            ProxyBase proxyBase = GetProxyBaseObject(proxyType);
            if (proxyBase == null)
                throw new ProxyServiceException(string.Format("proxyType:{0},{1} is not proxy base object",
                    proxyType.FullName,
                    proxyType.AssemblyName));
            if (proxyType.InMaxExpandDepth <= 0)
                proxyType.InMaxExpandDepth = DefaultInMaxWritingDepth;
            if (proxyType.InMaxExpandDepth > MaxInMaxWritingDepth)
                throw new ProxyServiceException(string.Format("inMaxExpandDepth max value is {0}", MaxInMaxWritingDepth));
            ReturnMessage<Proxy> ret = new ReturnMessage<Proxy>();
            Proxy proxy = new Proxy();
            proxy.ProxyType = proxyType;
            proxy.ProxyJsonString = ProxyObjectToJsonString(proxyBase, proxyType.UseDataMemberTransData,
                proxyType.InMaxExpandDepth);
            ret.Result = proxy;
            return ret;
        }

        /// <summary>
        ///     重新加载代理对象
        /// </summary>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public ReturnMessage<Proxy> ReLoadProxy(Proxy proxy)
        {
            if (proxy == null)
                throw new ProxyServiceException("proxy is null");
            if (proxy.ProxyType == null)
                throw new ProxyServiceException("proxy.ProxyType is null");
            if (string.IsNullOrEmpty(proxy.ProxyJsonString))
                throw new ProxyServiceException("proxy.ProxyJsonString is empty");
            ProxyType proxyType = proxy.ProxyType;
            if (proxyType.InMaxExpandDepth <= 0)
                proxyType.InMaxExpandDepth = DefaultInMaxWritingDepth;
            if (proxyType.InMaxExpandDepth > MaxInMaxWritingDepth)
                throw new ProxyServiceException(string.Format("inMaxExpandDepth max value is {0}", MaxInMaxWritingDepth));
            Type loadType = GetType(proxyType);
            if (loadType == null)
                throw new ProxyServiceException(string.Format("proxyType {0},{1} is not exist", proxyType.FullName,
                    proxyType.AssemblyName));
            ProxyBase proxyBase =
                ProxyObjectFromJsonString(proxy.ProxyJsonString, proxyType.UseDataMemberTransData, loadType) as
                    ProxyBase;
            if (proxyBase == null)
                throw new ProxyServiceException(string.Format("proxyType:{0},{1} is not proxy base object",
                    proxyType.FullName,
                    proxyType.AssemblyName));
            ReturnMessage<Proxy> ret = new ReturnMessage<Proxy>();
            proxy.ProxyJsonString = ProxyObjectToJsonString(proxyBase, proxyType.UseDataMemberTransData,
                proxyType.InMaxExpandDepth);
            ret.Result = proxy;
            return ret;
        }

        /// <summary>
        ///     执行请求
        /// </summary>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public ReturnMessage<string> ProxyDo(Proxy proxy)
        {
            if (proxy == null)
                throw new ProxyServiceException("proxy is null");
            var proxyType = proxy.ProxyType;
            Type proxyBaseType = GetType(proxyType);
            if (string.IsNullOrEmpty(proxy.ProxyJsonString))
                throw new ProxyServiceException("proxy.ProxyJsonString is empty");
            if (proxyType.OutMaxExpandDepth <= 0)
                proxyType.OutMaxExpandDepth = DefaultOutMaxWritingDepth;
            if (proxyType.OutMaxExpandDepth > MaxOutMaxWritingDepth)
                throw new ProxyServiceException(string.Format("outMaxExpandDepth is max value is {0}",
                    MaxOutMaxWritingDepth));
            ProxyBase proxyBase =
                ProxyObjectFromJsonString(proxy.ProxyJsonString, proxyType.UseDataMemberTransData, proxyBaseType) as
                    ProxyBase;
            if (proxyBase == null)
                throw new ProxyServiceException(string.Format("proxyType:{0},{1} is not proxy base object",
                    proxyType.FullName,
                    proxyType.AssemblyName));
            MethodInfo methodInfo = proxyBase.GetType().GetMethod("Do", new Type[] {});
            if (methodInfo == null)
                throw new ProxyServiceException(string.Format("no find Do() method in proxyType:{0},{1}",
                    proxyType.FullName,
                    proxyType.AssemblyName));
            object result = methodInfo.Invoke(proxyBase, null);
            ReturnMessage<string> ret = new ReturnMessage<string>();
            ret.IsSuccess = true;
            ret.Result = result == null
                ? string.Empty
                : ProxyResultToJsonString(result, proxyType.UseDataMemberTransData, proxyType.OutMaxExpandDepth);
            return ret;
        }

        /// <summary>
        ///     Job执行代理请求
        /// </summary>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public ReturnMessage<bool> ProxyDoByJob(Proxy proxy)
        {
            if (proxy == null)
                throw new ProxyServiceException("proxy is null");
            var proxyType = proxy.ProxyType;
            Type proxyBaseType = GetType(proxyType);
            if (string.IsNullOrEmpty(proxy.ProxyJsonString))
                throw new ProxyServiceException("proxy.ProxyJsonString is empty");
            ProxyBase proxyBase =
                ProxyObjectFromJsonString(proxy.ProxyJsonString, proxyType.UseDataMemberTransData, proxyBaseType) as
                    ProxyBase;
            if (proxyBase == null)
                throw new ProxyServiceException(string.Format("proxyType:{0},{1} is not a proxy base object",
                    proxyType.FullName,
                    proxyType.AssemblyName));
            string[] arrTypeName = proxy.ProxyType.FullName.Split('.');
            string requestCode = arrTypeName[arrTypeName.Length - 1];
            string requestName = requestCode;
            string bpFullName = string.Join(".",
                new List<string>(arrTypeName).GetRange(0, arrTypeName.Length - 2).ToArray());
            bpFullName += "." + requestCode.Substring(0, requestCode.Length - 5);
            RequestSubmit rs = new RequestSubmit();
            //参数applicaiton表示应用模块的代号.
            rs.Application = 3000;
            //参数priority表示调度执行的优先级,1表示最高优先级
            rs.Priority = 1;
            //参数bpfullname表示服务的全名,包括命名空间
            rs.BPFullName = bpFullName;
            //表示需要调度执行的应用,及调度具体执行的应用
            rs.BPAgentObj = proxyBase;
            //表示请求执行的应用代码,即具体的服务名称
            rs.RequestCode = requestCode;
            //在表示请求执行的服务名称,即在请求监控中看到的进程名称
            rs.RequestName = requestName;
            //任何语言都可以的描述
            rs.RequestDescription = requestName;
            // 是否成功执行不能重新执行
            rs.IsSuccessCanNotReStart = true;
            //表示任务执行的时限,以秒为单位,即指定秒后开始进行调度执行
            rs.SchedulerProject = new PatternRunOnce().PatternInstant();
            //参数表示 提交到job进程里,可以保证在设定时间进行应用程序的执行
            rs.Submit();
            ReturnMessage<bool> ret = new ReturnMessage<bool>();
            ret.IsSuccess = true;
            ret.Result = true;
            return ret;
        }

        /// <summary>
        ///     通过BPSV类型对象获取代理类型对象
        /// </summary>
        /// <param name="bpsvType"></param>
        /// <returns></returns>
        public ReturnMessage<ProxyType> GetProxyType(BPSVType bpsvType)
        {
            if (bpsvType == null)
                throw new ProxyServiceException("bpsvType is null");
            if (string.IsNullOrEmpty(bpsvType.AssemblyName))
                throw new ProxyServiceException("bpsvType.AssemblyName is empty");
            if (string.IsNullOrEmpty(bpsvType.FullName))
                throw new ProxyServiceException("bpsvType.FullName is empty");
            //代理类dll
            string proxyAssemblyName = (bpsvType.AssemblyName.ToLower().EndsWith(".dll")
                ? bpsvType.AssemblyName.Substring(0, bpsvType.AssemblyName.Length - 4)
                : bpsvType.AssemblyName)
                                       + ".Agent.dll";
            Assembly assembly = TypeManager.TypeLoader.ProbeAssembly(proxyAssemblyName);
            if (assembly == null)
                throw new ProxyServiceException(string.Format("Assembly {0} is not exist", proxyAssemblyName));
            string[] arrFullName = bpsvType.FullName.Split('.');
            string proxyClassName = arrFullName[arrFullName.Length - 1] + "Proxy";
            string agentTypeFullName = string.Join(".", arrFullName.Take(arrFullName.Length - 1)) + ".Proxy." +
                                       proxyClassName;
            Type agentType = null;
            List<Type> types = new List<Type>();
            foreach (Type searchType in assembly.GetTypes())
            {
                if (searchType.FullName == agentTypeFullName)
                {
                    agentType = searchType;
                    break;
                }
                if (searchType.Name == proxyClassName && searchType.IsSubclassOf(typeof (ProxyBase)))
                    types.Add(searchType);
            }
            if (agentType == null)
            {
                if (types.Count == 0)
                    throw new ProxyServiceException(string.Format("className: {0} in {1} no exist", proxyClassName,
                        proxyAssemblyName));
                if (types.Count > 1)
                    throw new ProxyServiceException(string.Format("className: {0} in {1} no only one", proxyClassName,
                        proxyAssemblyName));
                agentType = types[0];
            }
            ProxyType proxyType = new ProxyType();
            proxyType.AssemblyName = proxyAssemblyName;
            proxyType.FullName = agentType.FullName;
            proxyType.InMaxExpandDepth = DefaultInMaxWritingDepth;
            proxyType.OutMaxExpandDepth = DefaultOutMaxWritingDepth;
            ReturnMessage<ProxyType> ret = new ReturnMessage<ProxyType>();
            ret.Result = proxyType;
            ret.IsSuccess = true;
            return ret;
        }

        /// <summary>
        ///     获取请求代理对象
        /// </summary>
        /// <param name="proxyType"></param>
        /// <returns></returns>
        private static ProxyBase GetProxyBaseObject(ProxyType proxyType)
        {
            Type loadType = GetType(proxyType);
            if (loadType == null)
                throw new ProxyServiceException(string.Format("proxyType {0},{1} is not exist", proxyType.FullName,
                    proxyType.AssemblyName));
            return Activator.CreateInstance(loadType) as ProxyBase;
        }

        /// <summary>
        ///     获取请求代理对象
        /// </summary>
        /// <param name="proxyType"></param>
        /// <returns></returns>
        private static Type GetType(ProxyType proxyType)
        {
            if (proxyType == null)
                throw new ProxyServiceException("proxyType is null");
            if (string.IsNullOrEmpty(proxyType.FullName))
                throw new ProxyServiceException("proxyType.FullName is empty");
            if (string.IsNullOrEmpty(proxyType.AssemblyName))
                throw new ProxyServiceException("proxyType.AssemblyName is empty");
            return TypeManager.TypeLoader.LoadType(proxyType.FullName, proxyType.AssemblyName);
        }

        /// <summary>
        ///     Proxy对象转为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="useDataContractTransData"></param>
        /// <param name="maxExpandDepth"></param>
        /// <returns></returns>
        private static string ProxyObjectToJsonString(object obj, bool useDataContractTransData, int maxExpandDepth)
        {
            if (obj == null) return string.Empty;
            IContractResolver resolver = new ProxyBaseContractResolver(useDataContractTransData);
            JsonSerializerSettings settings =
                ProxyServiceJsonHelper.GetJsonSerializerSettings(resolver);
            settings.IsAutoCreateMemberValue = true;
            settings.MaxWritingDepth = maxExpandDepth > 0 ? maxExpandDepth : DefaultInMaxWritingDepth;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        /// <summary>
        ///     Proxy对象执行结果转为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="useDataContractTransData"></param>
        /// <param name="maxExpandDepth"></param>
        /// <returns></returns>
        private static string ProxyResultToJsonString(object obj, bool useDataContractTransData,
            int maxExpandDepth = DefaultInMaxWritingDepth)
        {
            if (obj == null) return string.Empty;
            IContractResolver resolver = new ProxyBaseContractResolver(useDataContractTransData);
            JsonSerializerSettings settings = ProxyServiceJsonHelper.GetJsonSerializerSettings(resolver);
            settings.MaxWritingDepth = maxExpandDepth > 0 ? maxExpandDepth : DefaultInMaxWritingDepth;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        /// <summary>
        ///     Json字符串转为Proxy对象
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="useDataContractTransData"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object ProxyObjectFromJsonString(string jsonString, bool useDataContractTransData, Type type)
        {
            if (string.IsNullOrEmpty(jsonString)) return null;
            IContractResolver resolver = new ProxyBaseContractResolver(useDataContractTransData);
            JsonSerializerSettings settings = ProxyServiceJsonHelper.GetJsonSerializerSettings(resolver);
            return JsonConvert.DeserializeObject(jsonString, type, settings) as ProxyBase;
        }

        private static string AsString(DataRow dataRow, string columnName)
        {
            return AsString(dataRow, columnName, string.Empty);
        }

        private static string AsString(DataRow dataRow, string columnName, string defaultValue)
        {
            object value = dataRow[columnName];
            return Convert.IsDBNull(value) ? defaultValue : value.ToString();
        }
    }
}