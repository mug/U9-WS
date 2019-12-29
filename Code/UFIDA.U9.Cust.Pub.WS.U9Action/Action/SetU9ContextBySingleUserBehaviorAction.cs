using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Base.Context;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;

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
            if (ContextInfoManager.Instance.IsMultiEnterprise)
            {
                string enterpriseID =
                    WebOperationContext.Current.IncomingRequest.Headers[ServiceConstant.HeaderEnterpriseIDName];
                if (string.IsNullOrWhiteSpace(enterpriseID))
                    throw new Exception("请求头未指定EnterpriseID");
                contextInfo = ContextInfoManager.Instance.GetContextInfo(enterpriseID);
            }
            else
            {
                contextInfo = ContextInfoManager.Instance.GetContextInfo();
            }
            object obj = new object();
            //初始化上下文
            ContextHelper.InitContext(obj);
            //设置上下文
            ContextHelper.SetContext(contextInfo);
            return obj;
        }

        public void AfterDo(ref Message reply, object beforeReturnObj, U9ActionCorrelationState u9ActionCorrelationState)
        {
            //清空上下文
            ContextHelper.ClearContext(beforeReturnObj);
        }
    }
}