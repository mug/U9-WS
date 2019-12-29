using System.ServiceModel;
using System.ServiceModel.Channels;

namespace UFIDA.U9.Cust.Pub.WS.U9Action.Action
{
    /// <summary>
    ///     U9形为动作接口
    /// </summary>
    public interface IU9BehaviorAction
    {
        object BeforeDo(ref Message request, IClientChannel channel, InstanceContext instanceContext,
            U9ActionCorrelationState u9ActionCorrelationState);

        void AfterDo(ref Message reply, object beforeReturnObj, U9ActionCorrelationState u9ActionCorrelationState);
    }
}