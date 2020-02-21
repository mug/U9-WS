using System;
using System.ServiceModel.Configuration;

namespace UFIDA.U9.Cust.Pub.WS.U9Context.Behavior.Endpoint
{
    /// <summary>
    ///     设置U9上下文扩展
    /// </summary>
    public class SetU9ContextByAuthEndpointBehaviorExtension : BehaviorExtensionElement
    {
        #region BehaviorExtensionElement

        public override Type BehaviorType
        {
            get { return typeof (SetU9ContextByAuthEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new SetU9ContextByAuthEndpointBehavior();
        }

        #endregion
    }
}