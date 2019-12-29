using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.U9Action.Action;
using UFIDA.U9.Cust.Pub.WS.U9Action.Configuration;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.U9Action.Behavior.Endpoint
{
    public class U9ActionEndpointBehavior : IDispatchMessageInspector, IEndpointBehavior
    {
        private static readonly ILogger Logger = LoggerManager.GetLogger(typeof(U9ActionEndpointBehavior));
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            if (WebOperationContext.Current == null)
            {
                throw new WebFaultException(HttpStatusCode.BadRequest);
            }
            U9ActionCorrelationState correlationState = new U9ActionCorrelationState();
            U9ActionSectionGroup group = U9ActionSectionGroup.GetConfig();
            for (int i = 0; i < group.Actions.Count; i++)
            {
                U9ActionSection section = group.Actions[i];
                IU9BehaviorAction action = Activator.CreateInstance(section.LoadType) as IU9BehaviorAction;
                if (action == null)
                    throw new Exception("u9Action must inherit IU9BehaviorAction");
                object result = action.BeforeDo(ref request, channel, instanceContext, correlationState);
                correlationState.AddAction(action, result);
            }
            return correlationState;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            U9ActionCorrelationState u9ActionCorrelationState = correlationState as U9ActionCorrelationState;
            if (u9ActionCorrelationState == null) return;
            for (int i = u9ActionCorrelationState.Actions.Count - 1; i >= 0; i--)
            {
                try
                {
                    IU9BehaviorAction action = u9ActionCorrelationState.Actions[i];
                    object beforeReturnObj = u9ActionCorrelationState.GetActionCorrelationState(action);
                    action.AfterDo(ref reply, beforeReturnObj, u9ActionCorrelationState);
                }
                catch (Exception ex)
                {
                    Logger.Debug("执行U9 Action后事件失败:{0}",i);
                    Logger.Debug(ex);
                }
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