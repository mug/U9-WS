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
        ReturnMessage<RequestProxyObject> GetRequestProxyObject(RequestProxyType proxyType);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<string> ProxyDo(RequestProxyObject proxyObject);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<bool> ProxyDoByJob(RequestProxyObject proxyObject);
    }
}