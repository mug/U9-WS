using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace UFIDA.U9.Cust.Pub.WS.Base.Services
{
    public class IISHostFactory : ServiceHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return this.CreateServiceHost(Type.GetType(constructorString), baseAddresses);
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new IISHost(serviceType, baseAddresses);
        }
    }
}