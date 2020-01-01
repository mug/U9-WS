using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel.Activation;
using UFIDA.U9.BS.Job.RequestClient;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.CommService.Interfaces;
using UFIDA.U9.Cust.Pub.WS.CommService.Json;
using UFIDA.U9.Cust.Pub.WS.CommService.Models;
using UFIDA.U9.Cust.Pub.WS.CommService.Utils;
using UFIDA.U9.Cust.Pub.WS.DBLog;
using UFIDA.U9.Cust.Pub.WS.Json;
using UFSoft.UBF;
using UFSoft.UBF.Service.Base;

namespace UFIDA.U9.Cust.Pub.WS.CommService.Services
{
    /// <summary>
    ///     通用服务
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CommService : ICommService
    {
        private const int DefaultMaxWritingDepth = 4;
        private const int MaxMaxWritingDepth = 6;

        /// <summary>
        ///     获取代理请求对象
        /// </summary>
        /// <param name="proxyType"></param>
        /// <returns></returns>
        [WSLog("获取代理请求对象")]
        public ReturnMessage<RequestProxyObject> GetRequestProxyObject(RequestProxyType proxyType)
        {
            ProxyBase proxyBase = GetProxyBaseObject(proxyType);
            if (proxyBase == null)
                throw new CommServiceException(string.Format("type:{0},{1} is not proxy base object",
                    proxyType.TypeName,
                    proxyType.AssemblyName));
            if (proxyType.MaxExpandDepth <= 0)
                proxyType.MaxExpandDepth = DefaultMaxWritingDepth;
            if (proxyType.MaxExpandDepth > MaxMaxWritingDepth)
                throw new CommServiceException(string.Format("MaxExpandDepth is max value is {0}", MaxMaxWritingDepth));
            ReturnMessage<RequestProxyObject> ret = new ReturnMessage<RequestProxyObject>();
            RequestProxyObject proxyObject = new RequestProxyObject();
            proxyObject.RequestProxyType = proxyType;
            proxyObject.ProxyObjectJsonString = ProxyObjectToJsonString(proxyBase, proxyType.MaxExpandDepth);
            ret.Result = proxyObject;
            return ret;
        }

        /// <summary>
        ///     执行请求
        /// </summary>
        /// <param name="proxyObject"></param>
        /// <returns></returns>
        [WSLog("执行代理请求")]
        public ReturnMessage<string> ProxyDo(RequestProxyObject proxyObject)
        {
            if (proxyObject == null)
                throw new CommServiceException("ProxyRequestObject is null");
            var requestType = proxyObject.RequestProxyType;
            Type proxyBaseType = GetProxyBaseType(requestType);
            if (string.IsNullOrEmpty(proxyObject.ProxyObjectJsonString))
                throw new CommServiceException("ProxyObjectJsonString is empty");
            if (requestType.MaxExpandDepth <= 0)
                requestType.MaxExpandDepth = DefaultMaxWritingDepth;
            if (requestType.MaxExpandDepth > MaxMaxWritingDepth)
                throw new CommServiceException(string.Format("MaxExpandDepth is max value is {0}", MaxMaxWritingDepth));
            ProxyBase proxyBase = ObjectFromJsonString(proxyObject.ProxyObjectJsonString, proxyBaseType) as ProxyBase;
            if (proxyBase == null)
                throw new CommServiceException(string.Format("type:{0},{1} is not proxy base object",
                    requestType.TypeName,
                    requestType.AssemblyName));
            MethodInfo methodInfo = proxyBase.GetType().GetMethod("Do", new Type[] {});
            if (methodInfo == null)
                throw new CommServiceException(string.Format("no find Do() method in type:{0},{1}", requestType.TypeName,
                    requestType.AssemblyName));
            object result = methodInfo.Invoke(proxyBase, null);
            ReturnMessage<string> ret = new ReturnMessage<string>();
            ret.IsSuccess = true;
            ret.Result = result == null ? string.Empty : ProxyResultToJsonString(result, requestType.MaxExpandDepth);
            return ret;
        }

        [WSLog("Job执行代理请求")]
        public ReturnMessage<bool> ProxyDoByJob(RequestProxyObject proxyObject)
        {
            if (proxyObject == null)
                throw new CommServiceException("ProxyRequestObject is null");
            var requestType = proxyObject.RequestProxyType;
            Type proxyBaseType = GetProxyBaseType(requestType);
            if (string.IsNullOrEmpty(proxyObject.ProxyObjectJsonString))
                throw new CommServiceException("ProxyObjectJsonString is empty");
            ProxyBase proxyBase = ObjectFromJsonString(proxyObject.ProxyObjectJsonString, proxyBaseType) as ProxyBase;
            if (proxyBase == null)
                throw new CommServiceException(string.Format("type:{0},{1} is not proxy base object",
                    requestType.TypeName,
                    requestType.AssemblyName));
            string[] arrTypeName = proxyObject.RequestProxyType.TypeName.Split('.');
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
        ///     获取请求代理对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static ProxyBase GetProxyBaseObject(RequestProxyType type)
        {
            Type loadType = GetProxyBaseType(type);
            if (loadType == null)
                throw new CommServiceException(string.Format("type {0},{1} is not exist", type.TypeName,
                    type.AssemblyName));
            return Activator.CreateInstance(loadType) as ProxyBase;
        }

        /// <summary>
        ///     获取请求代理对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Type GetProxyBaseType(RequestProxyType type)
        {
            if (type == null)
                throw new CommServiceException("requestType is null");
            if (string.IsNullOrEmpty(type.TypeName))
                throw new CommServiceException("requestType.TypeName is empty");
            if (string.IsNullOrEmpty(type.AssemblyName))
                throw new CommServiceException("requestType.AssemblyName is empty");
            return TypeManager.TypeLoader.LoadType(type.TypeName, type.AssemblyName);
        }

        /// <summary>
        ///     ProxyBase对象转为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="maxExpandDepth"></param>
        /// <returns></returns>
        private static string ProxyObjectToJsonString(object obj, int maxExpandDepth)
        {
            if (obj == null) return string.Empty;
            JsonSerializerSettings settings =
                CommServiceJsonHelper.GetJsonSerializerSettings(new ProxyBaseContractResolver());
            settings.IsAutoCreateMemberValue = true;
            settings.MaxWritingDepth = maxExpandDepth > 0 ? maxExpandDepth : DefaultMaxWritingDepth;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        /// <summary>
        ///     对象转为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="maxExpandDepth"></param>
        /// <returns></returns>
        private static string ProxyResultToJsonString(object obj, int maxExpandDepth)
        {
            if (obj == null) return string.Empty;
            var settings = CommServiceJsonHelper.GetJsonSerializerSettings(new ProxyBaseContractResolver());
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        /// <summary>
        ///     Json字符串转为对象
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object ObjectFromJsonString(string jsonString, Type type)
        {
            if (string.IsNullOrEmpty(jsonString)) return null;
            JsonSerializerSettings settings = CommServiceJsonHelper.GetDefaultJsonSerializerSettings();
            return JsonConvert.DeserializeObject(jsonString, type, settings) as ProxyBase;
        }
    }
}