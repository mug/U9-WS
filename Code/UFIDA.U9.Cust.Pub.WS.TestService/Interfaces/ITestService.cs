using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using UFIDA.U9.Base.Organization;
using UFIDA.U9.Base.Organization.Proxy;
using UFIDA.U9.CBO.SCM.Item;
using UFIDA.U9.CBO.SCM.Item.Proxy;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.TestService.Models;

namespace UFIDA.U9.Cust.Pub.WS.TestService.Interfaces
{
    [ServiceContract]
    internal interface ITestService
    {
        /// <summary>
        /// BodyStyle = WebMessageBodyStyle.Bare:
        /// 客户端传来的json对象参数，会被服务器当成一个参数来对待，所以Bare情况下服务端只能有一个参数，Bare返回值就是你需要的对象
        /// </summary>
        /// <param name="testDTO"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<TestDTO> DoTest(TestDTO testDTO);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<OrganizationData> DoBP(GetOrgInfoProxy proxy);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ReturnMessage<List<ItemMasterDTOData>> DoSV(BatchQueryItemByDTOSRVProxy proxy);

    }
}