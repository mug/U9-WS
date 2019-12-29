using System.ServiceModel;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.TestService.Models;

namespace UFIDA.U9.Cust.Pub.WS.TestService.Interfaces
{
    [ServiceContract]
    internal interface ITestService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<TestDTO> DoTest(TestDTO testDTO);
    }
}