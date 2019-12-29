using System.ServiceModel;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.CommService.Models;

namespace UFIDA.U9.Cust.Pub.WS.CommService.Interfaces
{
    [ServiceContract]
    internal interface ICommService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<ProxyRequestObject> GetProxyRequestObject(ProxyRequestType requestType);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<string> ProxyDo(ProxyRequestObject requestObject);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<bool> ProxyDoByJob(ProxyRequestObject requestObject);
    }
}