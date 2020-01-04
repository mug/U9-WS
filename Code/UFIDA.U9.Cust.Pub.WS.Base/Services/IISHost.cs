using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace UFIDA.U9.Cust.Pub.WS.Base.Services
{
    public class IISHost : ServiceHost
    {
        public IISHost(string constructorString, Uri[] baseAddresses) : base(constructorString, baseAddresses)
        {
        }

        public IISHost(Type serviceType, Uri[] baseAddresses) : base(serviceType, baseAddresses)
        {
        }

        protected override void ApplyConfiguration()
        {
            base.ApplyConfiguration();
            foreach (ServiceEndpoint endpoint in Description.Endpoints)
            {
                endpoint.Binding.CloseTimeout = new TimeSpan(1, 0, 0);
                endpoint.Binding.OpenTimeout = new TimeSpan(1, 0, 0);
                endpoint.Binding.ReceiveTimeout = new TimeSpan(1, 0, 0);
                endpoint.Binding.SendTimeout = new TimeSpan(1, 0, 0);
                BasicHttpBinding basicHttpBinding = endpoint.Binding as BasicHttpBinding;
                if (basicHttpBinding != null)
                {
                    basicHttpBinding.MaxReceivedMessageSize = int.MaxValue;
                    basicHttpBinding.MaxBufferSize = int.MaxValue;
                    basicHttpBinding.MaxBufferPoolSize = int.MaxValue;
                    basicHttpBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                }
                WebHttpBinding webHttpBinding = endpoint.Binding as WebHttpBinding;
                if (webHttpBinding != null)
                {
                    webHttpBinding.MaxReceivedMessageSize = int.MaxValue;
                    webHttpBinding.MaxBufferSize = int.MaxValue;
                    webHttpBinding.MaxBufferPoolSize = int.MaxValue;
                    webHttpBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                }
            }
            if (Description.Behaviors.Find<ServiceThrottlingBehavior>() == null)
            {
                ServiceThrottlingBehavior item = new ServiceThrottlingBehavior
                {
                    MaxConcurrentCalls = int.MaxValue,
                    MaxConcurrentSessions = int.MaxValue
                };
                Description.Behaviors.Add(item);
            }
        }
    }
}