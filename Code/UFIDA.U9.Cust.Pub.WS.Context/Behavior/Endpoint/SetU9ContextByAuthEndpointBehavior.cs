using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFIDA.U9.Cust.Pub.WS.U9Context.Auth;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.U9Context.Behavior.Endpoint
{
    /// <summary>
    ///     通过认证设置U9上下文
    /// </summary>
    public class SetU9ContextByAuthEndpointBehavior : IDispatchMessageInspector, IEndpointBehavior
    {
        private static readonly ILogger Logger =
            LoggerManager.GetLogger(typeof (SetU9ContextByAuthEndpointBehavior));

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            if (WebOperationContext.Current == null)
            {
                throw new WebFaultException(HttpStatusCode.BadRequest);
            }
            string authorization =
                WebOperationContext.Current?.IncomingRequest.Headers[ContextConstant.HeaderAuthorizationName];
            if (string.IsNullOrWhiteSpace(authorization))
            {
                throw new U9ContextException("用户未认证或认证已超时失效");
            }
            BasicAuth basicAuth = new BasicAuth(authorization);
            ContextInfo contextInfo = basicAuth.Creds.GetContextInfo();
            return new ContextObject(contextInfo);
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            try
            {
                ContextObject obj = correlationState as ContextObject;
                if (obj == null) return;
                //清空上下文
                obj.ClearContext();
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