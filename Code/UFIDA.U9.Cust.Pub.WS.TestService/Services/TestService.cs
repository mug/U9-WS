using System.ServiceModel.Activation;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.DBLog;
using UFIDA.U9.Cust.Pub.WS.TestService.Interfaces;
using UFIDA.U9.Cust.Pub.WS.TestService.Models;

namespace UFIDA.U9.Cust.Pub.WS.TestService.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TestService : ITestService
    {
        /// <summary>
        ///     测试
        /// </summary>
        /// <returns></returns>
        [WSLog("测试基本类型")]
        public ReturnMessage<TestDTO> DoTest(TestDTO testDTO)
        {
            var ret = new ReturnMessage<TestDTO>();
            ret.Result = testDTO;
            return ret;
        }
    }
}