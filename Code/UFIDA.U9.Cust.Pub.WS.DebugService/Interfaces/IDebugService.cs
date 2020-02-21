using System.ServiceModel;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.DebugService.Models;

namespace UFIDA.U9.Cust.Pub.WS.DebugService.Interfaces
{
    [ServiceContract]
    internal interface IDebugService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<bool> IsSetupSQLDebug();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<bool> SetupSQLDebug(SQLDebugConfig debugConfig);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<bool> StopSQLDebug();
    }
}