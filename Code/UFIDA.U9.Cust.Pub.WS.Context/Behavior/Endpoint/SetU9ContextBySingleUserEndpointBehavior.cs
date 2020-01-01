using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.U9Context.Behavior.Endpoint
{
    /// <summary>
    ///     通过单一用户设置U9上下文
    /// </summary>
    public class SetU9ContextBySingleUserEndpointBehavior : IDispatchMessageInspector, IEndpointBehavior
    {
        private static readonly ILogger Logger =
            LoggerManager.GetLogger(typeof (SetU9ContextBySingleUserEndpointBehavior));

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            if (WebOperationContext.Current == null)
            {
                throw new WebFaultException(HttpStatusCode.BadRequest);
            }
            // Get Token from header
            ContextInfo contextInfo;
            //是否指定上下文
            if (ContextInfoManager.Instance.MultiEnterprise)
            {
                string enterpriseID =
                    WebOperationContext.Current.IncomingRequest.Headers[ContextConstant.HeaderEnterpriseIDName];
                if (string.IsNullOrWhiteSpace(enterpriseID))
                    throw new U9ContextException("配置中指定多企业，请求Headers需指定EnterpriseID");
                contextInfo = ContextInfoManager.Instance.GetContext(enterpriseID);
                if (contextInfo == null)
                    throw new U9ContextException(string.Format("EnterpriseID:{0} no exists", enterpriseID));
            }
            else
            {
                contextInfo = ContextInfoManager.Instance.GetContext();
                if (contextInfo == null)
                    throw new U9ContextException("no default enterprise exists");
            }
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