using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using UFIDA.U9.Base.Language;
using UFIDA.U9.Base.Language.Proxy;
using UFIDA.U9.Base.UserRole;
using UFIDA.U9.Base.UserRole.Proxy;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.LoginService.Interfaces;
using UFIDA.U9.Cust.Pub.WS.LoginService.Models;
using UFIDA.U9.Cust.Pub.WS.U9Context;
using UFIDA.U9.Cust.Pub.WS.U9Context.Auth;
using UFIDA.UBF.SystemManage;
using UFIDA.UBF.SystemManage.Agent;
using UFSoft.UBF.Util.Context;

namespace UFIDA.U9.Cust.Pub.WS.LoginService.Services
{
    /// <summary>
    ///     系统服务
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SysService : ISysService
    {
        /// <summary>
        ///     获取所有企业
        /// </summary>
        /// <returns></returns>
        public ReturnMessage<List<CodeNameDTO>> GetEnterprises()
        {
            ReturnMessage<List<CodeNameDTO>> ret = new ReturnMessage<List<CodeNameDTO>>();
            List<CodeNameDTO> dtoList = new List<CodeNameDTO>();
            EnterpriseInfo enterpriseInfo = new EnterpriseInfo();
            List<Enterprise> allEnterpriseForPortal = enterpriseInfo.GetAllEnterpriseForPortal();
            foreach (Enterprise enterprise in allEnterpriseForPortal)
            {
                CodeNameDTO codeNameDTO = new CodeNameDTO();
                codeNameDTO.Code = enterprise.Code;
                codeNameDTO.Name = enterprise.Name;
                dtoList.Add(codeNameDTO);
            }
            ret.Result = dtoList;
            return ret;
        }

        /// <summary>
        ///     获取语言
        /// </summary>
        /// <returns></returns>
        public ReturnMessage<List<CodeNameDTO>> GetLanguages(Credentials credentials)
        {
            ReturnMessage<List<CodeNameDTO>> ret = new ReturnMessage<List<CodeNameDTO>>();
            Enterprise enterprise = ContextObject.GetEnterprise(credentials.EnterpriseID);
            using (new SystemWritablePolicy())
            {
                PlatformContext.Current.EnterpriseID = enterprise.Code;
                PlatformContext.Current.EnterpriseName = enterprise.Name;
                GetLanguageInfoProxy getLanguageInfoProxy = new GetLanguageInfoProxy();
                List<LanguageInfoDataTransferObjectData> dataList = getLanguageInfoProxy.Do();
                List<CodeNameDTO> dtoList = new List<CodeNameDTO>();
                foreach (LanguageInfoDataTransferObjectData languageInfoDataTransferObjectData in dataList)
                {
                    if (languageInfoDataTransferObjectData.Code == "EffectiveCount") continue;
                    if (!languageInfoDataTransferObjectData.IsSystem) continue;
                    CodeNameDTO codeNameDTO = new CodeNameDTO();
                    codeNameDTO.Code = languageInfoDataTransferObjectData.Code;
                    codeNameDTO.Name = languageInfoDataTransferObjectData.Name;
                    dtoList.Add(codeNameDTO);
                }
                ret.Result = dtoList;
            }
            return ret;
        }

        /// <summary>
        ///     获取组织
        /// </summary>
        /// <returns></returns>
        public ReturnMessage<List<CodeNameDTO>> GetOrgsByUserCode(Credentials credentials)
        {
            ReturnMessage<List<CodeNameDTO>> ret = new ReturnMessage<List<CodeNameDTO>>();
            ret.Result = new List<CodeNameDTO>();
            if (string.IsNullOrEmpty(credentials.EnterpriseID) || string.IsNullOrEmpty(credentials.Culture)) return ret;
            Enterprise enterprise = ContextObject.GetEnterprise(credentials.EnterpriseID);
            if (enterprise == null)
                throw new Exception(string.Format("企业:{0} 不存在!", credentials.EnterpriseID));
            using (new SystemWritablePolicy())
            {
                PlatformContext.Current.EnterpriseID = enterprise.Code;
                PlatformContext.Current.EnterpriseName = enterprise.Name;
                PlatformContext.Current.Culture = credentials.Culture;
                PlatformContext.Current.Default_Culture = credentials.Culture;
                GetOrgsByUserCodeProxy getOrgsByUserCodeProxy = new GetOrgsByUserCodeProxy();
                getOrgsByUserCodeProxy.UserCode = credentials.UserCode;
                List<OrganizationDataTransferObjectData> dataList = getOrgsByUserCodeProxy.Do();
                if (dataList != null && dataList.Count > 0)
                {
                    foreach (OrganizationDataTransferObjectData objectData in dataList)
                    {
                        CodeNameDTO codeNameDTO = new CodeNameDTO();
                        codeNameDTO.Code = objectData.OrgCode;
                        codeNameDTO.Name = objectData.Name;
                        ret.Result.Add(codeNameDTO);
                    }
                }
            }
            return ret;
        }
    }
}