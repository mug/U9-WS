using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace UFIDA.U9.Cust.Pub.WCFService.Behavior.Operation
{
    public class WSLogOperationBehavior : IOperationBehavior
    {
        public void Validate(OperationDescription operationDescription)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            // Here we have added our invoker to the dispatch operation   
            dispatchOperation.Invoker = new WSLogOperationInvoker(dispatchOperation.Invoker, operationDescription,
                dispatchOperation);
            //dispatchOperation.Invoker = new WSLogOperationInvoker(dispatchOperation.Invoker, dispatchOperation);
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