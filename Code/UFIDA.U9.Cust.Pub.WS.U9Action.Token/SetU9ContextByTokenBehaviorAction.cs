using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Token;
using UFIDA.U9.Cust.Pub.WS.U9Action.Action;
using UFIDA.U9.Cust.Pub.WS.U9Context;

namespace UFIDA.U9.Cust.Pub.WS.U9Action.Token
{
    /// <summary>
    ///     通过Token设置U9上下文动作
    /// </summary>
    public class SetU9ContextByTokenBehaviorAction : IU9BehaviorAction
    {
        public object BeforeDo(ref Message request, IClientChannel channel, InstanceContext instanceContext,
            U9ActionCorrelationState u9ActionCorrelationState)
        {
            if (WebOperationContext.Current == null)
                throw new WebFaultException(HttpStatusCode.BadRequest);
            string tokenStr =
                WebOperationContext.Current.IncomingRequest.Headers[TokenConstant.HeaderAccessTokenName];
            if (string.IsNullOrWhiteSpace(tokenStr))
                throw new UnauthorizedTokenException("未认证身份信息");
            WS.Token.Token token = TokenManagement.Instance.Get(tokenStr);
            if (token == null)
                throw new ForbiddenTokenException("认证失败或认证已失效");
            return new ContextObject(token);
        }

        public void AfterDo(ref Message reply, object beforeReturnObj, U9ActionCorrelationState u9ActionCorrelationState)
        {
            ContextObject obj = beforeReturnObj as ContextObject;
            if (obj == null) return;
            //清空上下文
            obj.ClearContext();
        }
    }
}