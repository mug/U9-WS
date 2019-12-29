using System;
using UFIDA.U9.Base.UserRole;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.UBF.SystemManage;
using UFIDA.UBF.SystemManage.Agent;
using UFSoft.UBF.Services.Session;
using UFSoft.UBF.Util.Context;
using Organization = UFIDA.U9.Base.Organization.Organization;

namespace UFIDA.U9.Cust.Pub.WS.Base.Context
{
    /// <summary>
    ///     上下文帮助类
    /// </summary>
    public static class ContextHelper
    {
        public static void InitContext(object bp)
        {
            if (ServiceSession.Context != null) return;
            ServiceSession.InitinalSession(null);
            ServiceSession.EnterOperator(bp);
        }

        public static ContextInfo GetContext(Enterprise enterprise, Organization org, User user)
        {
            ContextInfo contextInfo = new ContextInfo();
            contextInfo.EnterpriseID = enterprise.Code;
            contextInfo.EnterpriseName = enterprise.Name;
            contextInfo.OrgID = org.ID.ToString();
            contextInfo.OrgCode = org.Code;
            contextInfo.OrgName = org.Name;
            contextInfo.UserID = user.ID.ToString();
            contextInfo.UserCode = user.Code;
            contextInfo.UserName = user.Name;
            return contextInfo;
        }

        /// <summary>
        /// 获取企业信息
        /// </summary>
        /// <param name="enterpriseID"></param>
        /// <returns></returns>
        public static Enterprise GetEnterprise(string enterpriseID)
        {
            EnterpriseInfo enterpriseInfo = new EnterpriseInfo();
            return enterpriseInfo.GetEnterpriseByCode(enterpriseID);
        }

        public static void SetContext(ContextInfo contextInfo)
        {
            using (new SystemWritablePolicy())
            {
                PlatformContext.Current[PlatformContext.ENTERPRISE_ID] = contextInfo.EnterpriseID;
                PlatformContext.Current[PlatformContext.ENTERPRISE_NAME] = contextInfo.EnterpriseName;
                PlatformContext.Current[PlatformContext.CULTURE] = contextInfo.LanguageCode;
                PlatformContext.Current[PlatformContext.SUPPORT_CULTURENAME_LIST] = contextInfo.LanguageCode;
                PlatformContext.Current[PlatformContext.DATETIME] = DateTime.Now;
                PlatformContext.Current[PlatformContext.ORG_ID] = contextInfo.OrgID;
                PlatformContext.Current[PlatformContext.LOGINORG_ID] = contextInfo.OrgID;
                PlatformContext.Current[PlatformContext.OPERATINGORG_ID] = contextInfo.OrgID;
                PlatformContext.Current[PlatformContext.ORG_CODE] = contextInfo.OrgCode;
                PlatformContext.Current[PlatformContext.ORG_NAME] = contextInfo.OrgName;
                PlatformContext.Current[PlatformContext.USER_ID] = contextInfo.UserID;
                PlatformContext.Current[PlatformContext.USER_CODE] = contextInfo.UserCode;
                PlatformContext.Current[PlatformContext.USER_NAME] = contextInfo.UserName;
            }
        }

        public static void ClearContext(object bp)
        {
            if (ServiceSession.Context == null || ServiceSession.Context.Operator != bp) return;
            try
            {
                ServiceSession.Context.Dispose();
                ServiceSession.ExitOperator(bp);
            }
            finally
            {
                ServiceSession.ReleaseSession();
            }
        }
    }
}