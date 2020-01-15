using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using UFIDA.U9.Base.Organization;
using UFIDA.U9.Base.Organization.Proxy;
using UFIDA.U9.CBO.SCM.Item;
using UFIDA.U9.CBO.SCM.Item.Proxy;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.DBLog;
using UFIDA.U9.Cust.Pub.WS.TestService.Interfaces;
using UFIDA.U9.Cust.Pub.WS.TestService.Models;

namespace UFIDA.U9.Cust.Pub.WS.TestService.Services
{
    /// <summary>
    ///     无法激活服务，因为它不支持 ASP.NET 兼容性。已为此应用程序启用了 ASP.NET 兼容性。
    ///     请在 web.config 中关闭 ASP.NET 兼容性模式，
    ///     或将 AspNetCompatibilityRequirements 特性添加到服务类型且同时将 RequirementsMode 设置为“Allowed”或“Required”。
    /// </summary>
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

        [WSLog("测试BP")]
        public ReturnMessage<OrganizationData> DoBP(GetOrgInfoProxy proxy)
        {
            if (proxy == null)
                throw new ArgumentException("proxy is null");
            var ret = new ReturnMessage<OrganizationData>();
            ret.Result = proxy.Do();
            return ret;
        }

        [WSLog("测试SV")]
        public ReturnMessage<List<ItemMasterDTOData>> DoSV(BatchQueryItemByDTOSRVProxy proxy)
        {
            if (proxy == null)
                throw new ArgumentException("proxy is null");
            var ret = new ReturnMessage<List<ItemMasterDTOData>>();
            ret.Result = proxy.Do();
            return ret;
        }
    }
}