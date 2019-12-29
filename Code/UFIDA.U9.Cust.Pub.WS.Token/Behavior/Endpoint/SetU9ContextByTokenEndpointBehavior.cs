using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Base.Behavior.Endpoint;
using UFIDA.U9.Cust.Pub.WS.Base.Context;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.Token.Behavior.Endpoint
{
    /// <summary>
    /// 通过Token设置U9上下文
    /// </summary>
    public class SetU9ContextByTokenEndpointBehavior : IDispatchMessageInspector, IEndpointBehavior
    {
        private static readonly ILogger Logger = LoggerManager.GetLogger(typeof (SetU9ContextByTokenEndpointBehavior));

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            if (WebOperationContext.Current == null)
            {
                throw new WebFaultException(HttpStatusCode.BadRequest);
            }
            string tokenStr =
                WebOperationContext.Current.IncomingRequest.Headers[TokenConstant.HeaderAccessTokenName];
            if (string.IsNullOrWhiteSpace(tokenStr))
                throw new TokenException("未认证身份信息");
            Token token = TokenManagement.Instance.Get(tokenStr);
            if (token == null)
                throw new TokenException("认证失败或认证已失效");
            ContextInfo contextInfo = TokenHelper.GetContextInfo(token);
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