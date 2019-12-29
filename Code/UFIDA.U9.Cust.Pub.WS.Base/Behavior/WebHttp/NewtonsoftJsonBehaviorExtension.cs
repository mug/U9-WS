using System;
using System.ServiceModel.Configuration;

namespace UFIDA.U9.Cust.Pub.WS.Base.Behavior.WebHttp
{
    public class NewtonsoftJsonBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof (NewtonsoftJsonBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new NewtonsoftJsonBehavior();
        }
    }
}