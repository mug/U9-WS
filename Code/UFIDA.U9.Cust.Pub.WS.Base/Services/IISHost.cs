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
                    basicHttpBinding.MaxReceivedMessageSize = 2147483647L;
                    basicHttpBinding.MaxBufferSize = 2147483647;
                    basicHttpBinding.MaxBufferPoolSize = 2147483647L;
                    basicHttpBinding.ReaderQuotas.MaxStringContentLength = 2147483647;
                }
                WebHttpBinding webHttpBinding = endpoint.Binding as WebHttpBinding;
                if (webHttpBinding != null)
                {
                    webHttpBinding.MaxReceivedMessageSize = 2147483647L;
                    webHttpBinding.MaxBufferSize = 2147483647;
                    webHttpBinding.MaxBufferPoolSize = 2147483647L;
                    webHttpBinding.ReaderQuotas.MaxStringContentLength = 2147483647;
                }
            }
            if (Description.Behaviors.Find<ServiceThrottlingBehavior>() == null)
            {
                ServiceThrottlingBehavior item = new ServiceThrottlingBehavior
                {
                    MaxConcurrentCalls = 2147483647,
                    MaxConcurrentSessions = 2147483647
                };
                Description.Behaviors.Add(item);
            }
        }
    }
}