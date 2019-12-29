using System;
using System.ServiceModel.Configuration;

namespace UFIDA.U9.Cust.Pub.WS.Token.Behavior.Endpoint
{
    /// <summary>
    /// Token校验扩展
    /// </summary>
    public class TokenValidationEndpointBehaviorExtension : BehaviorExtensionElement
    {
        #region BehaviorExtensionElement

        public override Type BehaviorType
        {
            get { return typeof(TokenValidationEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new TokenValidationEndpointBehavior();
        }

        #endregion
    }
}
