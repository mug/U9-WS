using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Base.Context;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.Base.Behavior.Endpoint
{
    /// <summary>
    /// 通过单一用户设置U9上下文
    /// </summary>
    public class SetU9ContextBySingleUserEndpointBehavior : IDispatchMessageInspector, IEndpointBehavior
    {
        private static readonly ILogger Logger = LoggerManager.GetLogger(typeof (SetU9ContextBySingleUserEndpointBehavior));

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            if (WebOperationContext.Current == null)
            {
                throw new WebFaultException(HttpStatusCode.BadRequest);
            }
            // Get Token from header
            ContextInfo contextInfo;
            //是否指定上下文
            if (ContextInfoManager.Instance.IsMultiEnterprise)
            {
                string enterpriseID =
                    WebOperationContext.Current.IncomingRequest.Headers[ServiceConstant.HeaderEnterpriseIDName];
                if (string.IsNullOrWhiteSpace(enterpriseID))
                    throw new Exception("请求头未指定EnterpriseID");
                contextInfo = ContextInfoManager.Instance.GetContextInfo(enterpriseID);
            }
            else
            {
                contextInfo = ContextInfoManager.Instance.GetContextInfo();
            }
            object obj = new object();
            //初始化上下文
            ContextHelper.InitContext(obj);
            //设置上下文
            ContextHelper.SetContext(contextInfo);
            return obj;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            try
            {
                object obj = correlationState;
                //清空上下文
                ContextHelper.ClearContext(obj);
            }
            catch (Exception ex)
            {
                Logger.Debug("清空上下文异常,错误信息:");
                Logger.Debug(ex);
            }
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }
    }
}