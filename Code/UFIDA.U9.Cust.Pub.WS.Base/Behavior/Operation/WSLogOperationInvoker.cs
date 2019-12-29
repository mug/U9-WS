using System;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using UFIDA.U9.Cust.Pub.WCFService.Interfaces;
using UFIDA.U9.Cust.Pub.WCFService.Log;
using UFIDA.U9.Cust.Pub.WCFService.Utils;
using UFSoft.UBF.Util.Context;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WCFService.Behavior.Operation
{
    /// <summary>
    ///     日志操作
    /// </summary>
    public class WSLogOperationInvoker : IOperationInvoker
    {
        private static readonly ILogger Logger = LoggerManager.GetLogger("WSLogOperationInvoker");
        private readonly DispatchOperation _dispatchOperation;
        private readonly IOperationInvoker _invoker;
        private readonly OperationDescription _operationDescription;

        public WSLogOperationInvoker(IOperationInvoker baseInvoker, OperationDescription operationDescription,
            DispatchOperation dispatchOperation)
        {
            _invoker = baseInvoker;
            _operationDescription = operationDescription;
            _dispatchOperation = dispatchOperation;
        }

        public object[] AllocateInputs()
        {
            return _invoker.AllocateInputs();
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            WSLog wsLog = new WSLog();
            Logger.Debug("请求执行方法开始:{0}", _dispatchOperation.Name);
            OperationContext operationContext = OperationContext.Current;
            //operationContext.RequestContext.RequestMessage
            //MemoryStream ms1 = new MemoryStream(bodyBytes);
            //StreamReader sr = new StreamReader(ms1);
            //JsonSerializer serializer = JsonHelper.GetJsonSerializer();
            //var obj = serializer.Deserialize(sr, typeof(ReturnMessage<object>));
            //string messageBody = Encoding.UTF8.GetString(bodyBytes);
            string logID = WebOperationContext.Current?.IncomingRequest.Headers[ServiceConstant.HeaderLogIDName];
            if (!string.IsNullOrWhiteSpace(logID))
                wsLog.LogID = long.Parse(logID);
            Uri serviceUri = operationContext.Channel.LocalAddress.Uri;
            wsLog.RequestUrl = serviceUri.AbsoluteUri;
            wsLog.ClassName = _operationDescription.SyncMethod.DeclaringType?.FullName;
            wsLog.MethodName = _operationDescription.SyncMethod.Name;
            //记录方法描述
            WSLogBehaviorAttribute attribute =
                _operationDescription.SyncMethod.GetCustomAttribute(typeof (WSLogBehaviorAttribute)) as
                    WSLogBehaviorAttribute;
            wsLog.MethodDescription = attribute == null ? string.Empty : attribute.MethodDescription;
            wsLog.EnterpriseID = PlatformContext.Current.EnterpriseID;
            wsLog.RequestContent = inputs.Length > 0 ? JsonHelper.ToJsonString(inputs[0]) : string.Empty;
            wsLog.StartTime = DateTime.Now;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            object result = null;
            try
            {
                result = _invoker.Invoke(instance, inputs, out outputs);
                if (result == null) return null;
                IReturnMessage returnMessage = result as IReturnMessage;
                if (returnMessage == null)
                    throw new Exception("返回参数类型必须实现接口:IReturnMessage");
                returnMessage.IsSuccess = true;
                returnMessage.ErrMsg = string.Empty;
            }
            catch (Exception ex)
            {
                wsLog.Exception = ex.InnerException ?? ex;
                wsLog.ErrorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                Logger.Error("触发异常: {0}", ex);
                outputs = new object[] {};
                throw ex;
            }
            finally
            {
                watch.Stop();
                wsLog.ResponseContent = JsonHelper.ToJsonString(result);
                wsLog.EndTime = DateTime.Now;
                wsLog.ElapsedSecond = Math.Round(watch.ElapsedMilliseconds/1000M, 3);
                //记录日志
                //WSLogHelper.CreateWSLog(wsLog);
                Logger.Debug("请求执行方法结束:{0} 历时:{1}", _dispatchOperation.Name, wsLog.ElapsedSecond);
            }
            return result;
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            throw new Exception("The operation invoker is not asynchronous.");
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            throw new Exception("The operation invoker is not asynchronous.");
        }

        /// <summary>
        ///     是否同步执行
        /// </summary>
        public bool IsSynchronous
        {
            get { return true; }
        }
    }
}