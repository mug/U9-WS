using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace UFIDA.U9.Cust.Pub.WCFService.Behavior.WebHttp
{
    public class FaultHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            //if (error is FaultException<ValidationFault>)
            //{
            //    var action = OperationContext.Current.IncomingMessageHeaders.Action;
            //    var operations = OperationContext.Current.EndpointDispatcher.DispatchRuntime.Operations;
            //    var operation = operations.Where(d => d.Action == action).FirstOrDefault();
            //    if (operation != null)
            //    {
            //        var method = TypeDescriptor.GetProperties(operation.Invoker)["Method"].GetValue(operation.Invoker);
            //        var returnType = (Type) TypeDescriptor.GetProperties(method)["ReturnType"].GetValue(method);
            //        var details = (error as FaultException<ValidationFault>).Detail.Details;
            //        if (returnType.GetConstructor(new[] {typeof (IList<ValidationDetail>)}) != null)
            //        {
            //            var value = Activator.CreateInstance(returnType, details);
            //            fault = operation.Formatter.SerializeReply(version, new object[] {}, value);
            //        }
            //    }
            //}
        }
    }
}