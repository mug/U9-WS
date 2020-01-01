using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFIDA.U9.Cust.Pub.WS.U9Context;

namespace UFIDA.U9.Cust.Pub.WS.U9Action.Action
{
    /// <summary>
    ///     通过单一用户设置U9上下文动作
    /// </summary>
    public class SetU9ContextBySingleUserBehaviorAction : IU9BehaviorAction
    {
        public object BeforeDo(ref Message request, IClientChannel channel, InstanceContext instanceContext,
            U9ActionCorrelationState u9ActionCorrelationState)
        {
            if (WebOperationContext.Current == null)
                throw new WebFaultException(HttpStatusCode.BadRequest);
            ContextInfo contextInfo;
            if (ContextInfoManager.Instance.MultiEnterprise)
            {
                string enterpriseID =
                    WebOperationContext.Current.IncomingRequest.Headers[ContextConstant.HeaderEnterpriseIDName];
                if (string.IsNullOrWhiteSpace(enterpriseID))
                    throw new U9ContextException("配置中指定为多企业，请求Headers需指定EnterpriseID");
                contextInfo = ContextInfoManager.Instance.GetContext(enterpriseID);
                if (contextInfo == null)
                    throw new U9ContextException(string.Format("EnterpriseID:{0} no exists", enterpriseID));
            }
            else
            {
                contextInfo = ContextInfoManager.Instance.GetContext();
                if (contextInfo == null)
                    throw new U9ContextException("no default enterprise exists");
            }
            return new ContextObject(contextInfo);
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