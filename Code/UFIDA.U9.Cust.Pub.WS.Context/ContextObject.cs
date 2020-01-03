using System;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFIDA.UBF.SystemManage;
using UFIDA.UBF.SystemManage.Agent;
using UFSoft.UBF.Services.Session;
using UFSoft.UBF.Util.Context;

namespace UFIDA.U9.Cust.Pub.WS.U9Context
{
    /// <summary>
    ///     上下文对象
    ///     需要注意
    /// </summary>
    public class ContextObject : IDisposable
    {
        public ContextObject(IEnterprise enterprise)
        {
            if (enterprise == null)
                throw new ArgumentException("enterprise is null");
            //Context=null时,说明没有初始化过，如果有初始化过，不再初始化
            if (ServiceSession.Context == null)
            {
                using (new SystemWritablePolicy())
                {
                    PlatformContext.Current.EnterpriseID = enterprise.Code;
                    PlatformContext.Current.EnterpriseName = enterprise.Name;
                }
            }
            else
            {
                if (PlatformContext.Current.EnterpriseID != enterprise.Code)
                    throw new U9ContextException("同一个请求中，不允许切换不同的企业");
            }
            //初始化上下文
            InitContext();
        }

        public ContextObject(ContextInfo contextInfo)
        {
            if (contextInfo == null)
                throw new ArgumentException("contextInfo is null");
            //初始化上下文
            InitContext();
            //设置上下文
            SetContext(contextInfo);
        }

        public void Dispose()
        {
            //清空上下文
            ClearContext();
        }

        /// <summary>
        ///     初始化上下文
        /// </summary>
        public void InitContext()
        {
            if (ServiceSession.Context != null) return;
            ServiceSession.InitinalSession(null);
            ServiceSession.EnterOperator(this);
        }

        /// <summary>
        ///     设置上下文
        /// </summary>
        /// <param name="contextInfo"></param>
        public static void SetContext(ContextInfo contextInfo)
        {
            using (new SystemWritablePolicy())
            {
                PlatformContext.Current[PlatformContext.ENTERPRISE_ID] = contextInfo.EnterpriseID;
                PlatformContext.Current[PlatformContext.ENTERPRISE_NAME] = contextInfo.EnterpriseName;
                PlatformContext.Current[PlatformContext.ORG_ID] = contextInfo.OrgID;
                PlatformContext.Current[PlatformContext.LOGINORG_ID] = contextInfo.OrgID;
                PlatformContext.Current[PlatformContext.OPERATINGORG_ID] = contextInfo.OrgID;
                PlatformContext.Current[PlatformContext.ORG_CODE] = contextInfo.OrgCode;
                PlatformContext.Current[PlatformContext.ORG_NAME] = contextInfo.OrgName;
                PlatformContext.Current[PlatformContext.USER_ID] = contextInfo.UserID;
                PlatformContext.Current[PlatformContext.USER_CODE] = contextInfo.UserCode;
                PlatformContext.Current[PlatformContext.USER_NAME] = contextInfo.UserName;
                PlatformContext.Current[PlatformContext.DEFAULT_CULTURE] = contextInfo.Culture;
                PlatformContext.Current[PlatformContext.CULTURE] = contextInfo.Culture;
                PlatformContext.Current[PlatformContext.SUPPORT_CULTURENAME_LIST] = contextInfo.SupportCultureNameList;
                PlatformContext.Current[PlatformContext.DATETIME] = DateTime.Now;
            }
        }

        /// <summary>
        ///     清除上下文
        /// </summary>
        public void ClearContext()
        {
            if (ServiceSession.Context == null || ServiceSession.Context.Operator != this) return;
            try
            {
                ServiceSession.Context.Dispose();
                ServiceSession.ExitOperator(this);
            }
            finally
            {
                ServiceSession.ReleaseSession();
            }
        }

        /// <summary>
        ///     获取企业信息
        /// </summary>
        /// <param name="enterpriseID"></param>
        /// <returns></returns>
        public static Enterprise GetEnterprise(string enterpriseID)
        {
            EnterpriseInfo enterpriseInfo = new EnterpriseInfo();
            return enterpriseInfo.GetEnterpriseByCode(enterpriseID);
        }
    }
}