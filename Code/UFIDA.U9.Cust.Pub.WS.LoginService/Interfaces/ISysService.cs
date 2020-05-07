using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFIDA.U9.Cust.Pub.WS.LoginService.Models;
using UFIDA.U9.Cust.Pub.WS.U9Context.Auth;

namespace UFIDA.U9.Cust.Pub.WS.LoginService.Interfaces
{
    [ServiceContract]
    internal interface ISysService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<List<CodeNameDTO>> GetEnterprises();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<List<CodeNameDTO>> GetLanguages(Credentials credentials);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<List<CodeNameDTO>> GetOrgsByUserCode(Credentials credentials);
    }
}