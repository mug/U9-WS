using System;
using System.Collections.Generic;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;

namespace UFIDA.U9.Cust.Pub.WS.Base.Context
{
    /// <summary>
    ///     上下文信息
    /// </summary>
    public class ContextInfo
    {
        private const string SysMLFlag = "zh-CN";

        /// <summary>
        ///     企业ID
        /// </summary>
        public string EnterpriseID { get; set; }

        public string EnterpriseName { get; set; }
        public string OrgID { get; set; }
        public string OrgCode { get; set; }
        public string OrgName { get; set; }
        public string UserID { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }

        public string LanguageCode
        {
            get { return SysMLFlag; }
        }
    }

    /// <summary>
    ///     webservice上下文
    /// </summary>
    public sealed class ContextInfoManager
    {
        public const string IsMultiEnterpriseName = "IsMultiEnterprise";
        public const string EnterpriseIDKeyName = "EnterpriseID";
        public const string EnterpriseNameKeyName = "EnterpriseName";
        public const string OrgIDKeyName = "OrgID";
        public const string OrgCodeKeyName = "OrgCode";
        public const string OrgNameKeyName = "OrgName";
        public const string UserIDKeyName = "UserID";
        public const string UserCodeKeyName = "UserCode";
        public const string UserNameKeyName = "UserName";
        private static ContextInfoManager _instance;
        private static readonly object Lock = new object();
        private List<ContextInfo> _contextInfos;
        private bool? _isMultiEnterprise;

        private ContextInfoManager()
        {
        }

        public static ContextInfoManager Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ContextInfoManager();
                        _instance.Init();
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        ///     是否多企业
        /// </summary>
        public bool IsMultiEnterprise
        {
            get
            {
                if (_isMultiEnterprise.HasValue) return _isMultiEnterprise.Value;
                string strIsMultiEnterprise = ConfigurationHelper.GetAppSettingValue(IsMultiEnterpriseName);
                _isMultiEnterprise = strIsMultiEnterprise.ToLower() == "true";
                return _isMultiEnterprise.Value;
            }
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            string strEnterpriseID = ConfigurationHelper.GetAppSettingValue(EnterpriseIDKeyName);
            if (string.IsNullOrEmpty(strEnterpriseID))
                throw new Exception("企业配置异常,企业ID不能为空");
            string strEnterpriseName = ConfigurationHelper.GetAppSettingValue(EnterpriseNameKeyName);
            string strOrgID = ConfigurationHelper.GetAppSettingValue(OrgIDKeyName);
            if (string.IsNullOrEmpty(strOrgID))
                throw new Exception("企业配置异常,组织ID不能为空");
            string strOrgCode = ConfigurationHelper.GetAppSettingValue(OrgCodeKeyName);
            string strOrgName = ConfigurationHelper.GetAppSettingValue(OrgNameKeyName);
            string strUserID = ConfigurationHelper.GetAppSettingValue(UserIDKeyName);
            if (string.IsNullOrEmpty(strOrgID))
                throw new Exception("企业配置异常,用户ID不能为空");
            string strUserCode = ConfigurationHelper.GetAppSettingValue(UserCodeKeyName);
            string strUserName = ConfigurationHelper.GetAppSettingValue(UserNameKeyName);
            string[] arrEnterpriseID = strEnterpriseID.Split(',');
            string[] arrEnterpriseName = strEnterpriseName.Split(',');
            string[] arrOrgID = strOrgID.Split(',');
            string[] arrOrgCode = strOrgCode.Split(',');
            string[] arrOrgName = strOrgName.Split(',');
            string[] arrUserID = strUserID.Split(',');
            string[] arrUserCode = strUserCode.Split(',');
            string[] arrUserName = strUserName.Split(',');
            if ((arrEnterpriseName.Length > 0 && arrEnterpriseID.Length != arrEnterpriseName.Length) ||
                (arrEnterpriseID.Length != arrOrgID.Length) ||
                (arrEnterpriseID.Length != arrOrgCode.Length) ||
                (arrOrgName.Length > 0 && arrEnterpriseID.Length != arrOrgName.Length) ||
                (arrEnterpriseID.Length != arrUserID.Length) ||
                (arrEnterpriseID.Length != arrUserCode.Length) ||
                (arrUserName.Length > 0 && arrEnterpriseID.Length != arrUserName.Length))
            {
                throw new Exception("企业配置异常,请检查后修改!");
            }
            _contextInfos = new List<ContextInfo>();
            for (int i = 0; i < arrEnterpriseID.Length; i++)
            {
                string enterpriseID = arrEnterpriseID[i];
                ContextInfo contextInfo = new ContextInfo();
                contextInfo.EnterpriseID = enterpriseID.Trim();
                if (arrEnterpriseName.Length > 0)
                    contextInfo.EnterpriseName = arrEnterpriseName[i].Trim();
                contextInfo.OrgID = arrOrgID[i].Trim();
                contextInfo.OrgCode = arrOrgCode[i].Trim();
                if (arrOrgName.Length > 0)
                    contextInfo.OrgName = arrOrgName[i].Trim();
                contextInfo.UserID = arrUserID[i].Trim();
                contextInfo.UserCode = arrUserCode[i].Trim();
                if (arrUserName.Length > 0)
                    contextInfo.UserName = arrUserName[i].Trim();
                _contextInfos.Add(contextInfo);
            }
        }

        /// <summary>
        ///     获取上下文信息
        /// </summary>
        /// <returns></returns>
        public ContextInfo GetContextInfo()
        {
            return _contextInfos[0];
        }

        /// <summary>
        ///     获取上下文信息
        /// </summary>
        /// <param name="enterpriseID"></param>
        /// <returns></returns>
        public ContextInfo GetContextInfo(string enterpriseID)
        {
            foreach (ContextInfo contextInfo in _contextInfos)
            {
                if (contextInfo.EnterpriseID == enterpriseID) return contextInfo;
            }
            return null;
        }
    }
}