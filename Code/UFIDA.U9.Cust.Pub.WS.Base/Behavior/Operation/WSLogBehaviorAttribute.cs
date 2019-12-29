using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace UFIDA.U9.Cust.Pub.WCFService.Behavior.Operation
{
    public class WSLogBehaviorAttribute : Attribute, IOperationBehavior
    {
        public WSLogBehaviorAttribute(string methodDescription)
        {
            MethodDescription = methodDescription;
        }

        public string MethodDescription { get; set; }

        public void Validate(OperationDescription operationDescription)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            IOperationBehavior behavior = new WSLogOperationBehavior();
            operationDescription.Behaviors.Add(behavior);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void AddBindingParameters(OperationDescription operationDescription,
            BindingParameterCollection bindingParameters)
        {
        }
    }
}