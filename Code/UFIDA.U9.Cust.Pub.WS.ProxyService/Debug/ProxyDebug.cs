using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using Harmony;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;
using UFIDA.U9.Cust.Pub.WS.ProxyService.Models;
using UFIDA.U9.Cust.Pub.WS.ProxyService.Utils;
using UFSoft.UBF.Service.Base;
using UFSoft.UBF.Services.Session;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Debug
{
    /// <summary>
    ///     代理调试
    /// </summary>
    public class ProxyDebug
    {
        private static readonly ILogger Logger = LoggerManager.GetLogger(typeof (ProxyDebug));

        #region Service

        /// <summary>
        ///     是否开启调试
        /// </summary>
        /// <param name="proxyType"></param>
        /// <returns></returns>
        public static bool IsSetupDebug(ProxyType proxyType)
        {
            Type loadType = ProxyHelper.GetType(proxyType);
            if (loadType == null)
                throw new ProxyServiceException(string.Format("proxyType {0},{1} is not exist", proxyType.FullName,
                    proxyType.AssemblyName));
            string debugID = GetDebugID(loadType.FullName);
            HarmonyInstance instance = HarmonyInstance.Create(debugID);
            return instance.HasAnyPatches(debugID);
        }

        /// <summary>
        ///     启用调试
        /// </summary>
        /// <param name="proxyType"></param>
        /// <returns></returns>
        public static bool SetupDebug(ProxyType proxyType)
        {
            Type loadType = ProxyHelper.GetType(proxyType);
            if (loadType == null)
                throw new ProxyServiceException(string.Format("proxyType {0},{1} is not exist", proxyType.FullName,
                    proxyType.AssemblyName));
            AddConfig(proxyType);
            string debugID = GetDebugID(loadType.FullName);
            var instance = HarmonyInstance.Create(debugID);
            if (instance.HasAnyPatches(debugID)) return true;
            var doMethods = GetDoMethods(loadType);
            if (doMethods.Count == 0)
                throw new ProxyServiceException(string.Format("proxyType {0},{1} no find Do method", proxyType.FullName,
                    proxyType.AssemblyName));
            Type debugClass = typeof (ProxyDebug);
            MethodInfo realPrefix = debugClass.GetMethod("BeforeDo");
            HarmonyMethod prefixHarmonyMethod = new HarmonyMethod(realPrefix);
            HarmonyMethod postfixHarmonyMethod = null;
            Type returnType = AccessTools.GetReturnedType(doMethods[0]);
            if (returnType != typeof (void))
            {
                MethodInfo realPostfix = debugClass.GetMethod("AfterDo");
                if (realPostfix != null)
                {
                    //获取泛型方法
                    MethodInfo realPostfixGenericMethod = realPostfix.MakeGenericMethod(returnType);
                    postfixHarmonyMethod = new HarmonyMethod(realPostfixGenericMethod);
                }
            }
            PatchProcessor patcher = new PatchProcessor(instance, doMethods,
                prefixHarmonyMethod, postfixHarmonyMethod, null);
            patcher.Patch();
            return true;
        }

        /// <summary>
        ///     停止调试
        /// </summary>
        /// <param name="proxyType"></param>
        /// <returns></returns>
        public static bool StopDebug(ProxyType proxyType)
        {
            Type loadType = ProxyHelper.GetType(proxyType);
            if (loadType == null)
                throw new ProxyServiceException(string.Format("proxyType {0},{1} is not exist", proxyType.FullName,
                    proxyType.AssemblyName));
            string debugID = GetDebugID(loadType.FullName);
            var instance = HarmonyInstance.Create(debugID);
            if (instance.HasAnyPatches(debugID))
            {
                var doMethods = GetDoMethods(loadType);
                foreach (var doMethod in doMethods)
                {
                    instance.Unpatch(doMethod, HarmonyPatchType.All, debugID);
                }
            }
            RemoveConfig(proxyType);
            return true;
        }

        /// <summary>
        ///     获取代理调试标识ID
        /// </summary>
        /// <param name="typeFullName"></param>
        /// <returns></returns>
        private static string GetDebugID(string typeFullName)
        {
            return string.Format("{0}-{1}", typeof (ProxyDebug).FullName, typeFullName);
        }

        /// <summary>
        ///     获取Do方法集合
        /// </summary>
        /// <param name="loadType"></param>
        /// <returns></returns>
        private static List<MethodBase> GetDoMethods(Type loadType)
        {
            List<MethodBase> methodList = new List<MethodBase>();
            MethodInfo doMethod1 = loadType.GetMethod("Do", new Type[] {});
            if (doMethod1 != null)
                methodList.Add(doMethod1);
            MethodInfo doMethod2 = loadType.GetMethod("Do", new[] {typeof (long)});
            if (doMethod2 != null)
                methodList.Add(doMethod2);
            MethodInfo doMethod3 = loadType.GetMethod("Do", new[] {typeof (string)});
            if (doMethod3 != null)
                methodList.Add(doMethod3);
            return methodList;
        }

        #endregion

        #region Debug

        public static bool BeforeDo(ProxyBase __instance)
        {
            try
            {
                if (__instance == null) return true;
                Type type = __instance.GetType();
                Logger.Error(type.FullName + "-BeforeDo-SessionID:" + ServiceSession.SessionID);
                ProxyType proxyType = null;
                if (!string.IsNullOrEmpty(type.FullName))
                    ProxyTypeDict.TryGetValue(type.FullName, out proxyType);
                Logger.Error("PostData:" + (proxyType == null
                    ? ProxyJsonHelper.ProxyObjectToJsonString(__instance)
                    : ProxyJsonHelper.ProxyObjectToJsonString(__instance, false, proxyType.UseDataMemberTransData,
                        proxyType.InMaxExpandDepth)));
                //输出调用堆栈
                Logger.Error("StackTrace:\r\n" + StackTraceHelper.GetCurrentStackTraceString(3));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            return true;
        }

        public static void AfterDo<T>(ProxyBase __instance, T __result)
        {
            try
            {
                if (__result == null) return;
                Type type = __instance.GetType();
                Logger.Error(type.FullName + "-AfterDo-SessionID:" + ServiceSession.SessionID);
                ProxyType proxyType = null;
                if (!string.IsNullOrEmpty(type.FullName))
                    ProxyTypeDict.TryGetValue(type.FullName, out proxyType);
                Logger.Error("ReturnData:" + (proxyType == null
                    ? ProxyJsonHelper.ProxyResultToJsonString(__result)
                    : ProxyJsonHelper.ProxyResultToJsonString(__result, proxyType.UseDataMemberTransData,
                        proxyType.OutMaxExpandDepth)));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        #endregion

        #region Config

        private static readonly ConcurrentDictionary<string, ProxyType> ProxyTypeDict =
            new ConcurrentDictionary<string, ProxyType>();

        private static void AddConfig(ProxyType proxyType)
        {
            ProxyTypeDict.AddOrUpdate(proxyType.FullName, proxyType, (oldType, oldProxyType) => proxyType);
        }

        private static void RemoveConfig(ProxyType proxyType)
        {
            ProxyTypeDict.TryRemove(proxyType.FullName, out proxyType);
        }

        #endregion

        #region Other

        #endregion
    }
}