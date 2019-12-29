using System;
using System.ServiceModel.Configuration;

namespace UFIDA.U9.Cust.Pub.WS.U9Action.Behavior.Endpoint
{
    /// <summary>
    ///     U9动作扩展
    /// </summary>
    public class U9ActionEndpointBehaviorExtension : BehaviorExtensionElement
    {
        #region BehaviorExtensionElement

        public override Type BehaviorType
        {
            get { return typeof (U9ActionEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new U9ActionEndpointBehavior();
        }

        #endregion
    }
}