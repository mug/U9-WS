using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.ProxyService.Models;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Interfaces
{
    [ServiceContract]
    internal interface IProxyService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<List<BPSVType>> QueryBPSVType(BPSVTypeQuery bpsvTypeQuery);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<ProxyType> GetProxyType(BPSVType bpsvType);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<Proxy> GetProxy(ProxyType proxyType);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<Proxy> ReLoadProxy(Proxy proxy);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<string> ProxyDo(Proxy proxy);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<bool> ProxyDoByJob(Proxy proxy);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<bool> IsSetupDebug(ProxyType proxyType);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<bool> SetupDebug(ProxyType proxyType);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<bool> StopDebug(ProxyType proxyType);
    }
}