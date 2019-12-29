using System;
using System.ServiceModel.Configuration;

namespace UFIDA.U9.Cust.Pub.WS.Base.Behavior.Endpoint
{
    /// <summary>
    ///     用于记录日志扩展
    /// </summary>
    public class Log4NetEndpointBehaviorExtension : BehaviorExtensionElement
    {
        #region BehaviorExtensionElement

        public override Type BehaviorType
        {
            get { return typeof (Log4NetEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new Log4NetEndpointBehavior();
        }

        #endregion
    }
}