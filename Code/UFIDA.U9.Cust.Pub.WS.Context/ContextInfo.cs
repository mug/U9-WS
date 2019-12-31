using System.Runtime.Serialization;
using UFIDA.U9.Base.UserRole;
using UFIDA.U9.Cust.Pub.WS.U9Context;
using UFIDA.UBF.SystemManage;
using Organization = UFIDA.U9.Base.Organization.Organization;

namespace UFIDA.U9.Cust.Pub.WS.Context
{
    /// <summary>
    ///     上下文信息
    /// </summary>
    [DataContract]
    public class ContextInfo
    {
        public const string DefaultCulture = "zh-CN";
        private string _culture = string.Empty;
        private string _supportCultureNameList = string.Empty;

        /// <summary>
        ///     企业ID
        /// </summary>
        [DataMember]
        public string EnterpriseID { get; set; }

        [DataMember]
        public string EnterpriseName { get; set; }

        [DataMember]
        public string OrgID { get; set; }

        [DataMember]
        public string OrgCode { get; set; }

        [DataMember]
        public string OrgName { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string UserCode { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Culture
        {
            get { return string.IsNullOrEmpty(_culture) ? DefaultCulture : _culture; }
            set { _culture = value; }
        }

        [DataMember]
        public string SupportCultureNameList
        {
            get { return string.IsNullOrEmpty(_supportCultureNameList) ? Culture : _supportCultureNameList; }
            set { _supportCultureNameList = value; }
        }

        /// <summary>
        ///     创建
        /// </summary>
        /// <param name="enterpriseID"></param>
        /// <param name="enterpriseName"></param>
        /// <param name="orgID"></param>
        /// <param name="orgCode"></param>
        /// <param name="orgName"></param>
        /// <param name="userID"></param>
        /// <param name="userCode"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static ContextInfo Create(string enterpriseID, string enterpriseName, string orgID, string orgCode,
            string orgName, string userID, string userCode, string userName)
        {
            return Create(enterpriseID, enterpriseName, orgID, orgCode, orgName, userID, userCode, userName);
        }

        /// <summary>
        ///     创建
        /// </summary>
        /// <param name="enterpriseID"></param>
        /// <param name="enterpriseName"></param>
        /// <param name="orgID"></param>
        /// <param name="orgCode"></param>
        /// <param name="orgName"></param>
        /// <param name="userID"></param>
        /// <param name="userCode"></param>
        /// <param name="userName"></param>
        /// <param name="culture"></param>
        /// <param name="supportCultureNameList"></param>
        /// <returns></returns>
        public static ContextInfo Create(string enterpriseID, string enterpriseName, string orgID, string orgCode,
            string orgName, string userID, string userCode, string userName, string culture,
            string supportCultureNameList)
        {
            ContextInfo contextInfo = new ContextInfo();
            if (string.IsNullOrEmpty(enterpriseID))
                throw new U9ContextException("enterpriseID is empty");
            contextInfo.EnterpriseID = enterpriseID;
            contextInfo.EnterpriseName = enterpriseName;
            contextInfo.OrgID = orgID;
            if (string.IsNullOrEmpty(orgID))
                throw new U9ContextException("orgID is empty");
            contextInfo.OrgCode = orgCode;
            if (string.IsNullOrEmpty(orgCode))
                throw new U9ContextException("orgCode is empty");
            contextInfo.OrgName = orgName;
            contextInfo.UserID = userID;
            if (string.IsNullOrEmpty(userID))
                throw new U9ContextException("userID is empty");
            contextInfo.UserCode = userCode;
            if (string.IsNullOrEmpty(userCode))
                throw new U9ContextException("userCode is empty");
            contextInfo.UserName = userName;
            contextInfo.Culture = string.IsNullOrEmpty(culture)
                ? DefaultCulture
                : culture;
            contextInfo.SupportCultureNameList =
                string.IsNullOrEmpty(supportCultureNameList)
                    ? contextInfo.Culture
                    : supportCultureNameList;
            return contextInfo;
        }

        /// <summary>
        ///     获取上下文信息
        /// </summary>
        /// <param name="enterprise"></param>
        /// <param name="org"></param>
        /// <param name="user"></param>
        /// <param name="culture"></param>
        /// <param name="supportCultureNameList"></param>
        /// <returns></returns>
        public static ContextInfo GetContext(Enterprise enterprise, Organization org, User user, string culture,
            string supportCultureNameList)
        {
            return Create(enterprise.Code, enterprise.Name, org.ID.ToString(), org.Code, org.Name, user.ID.ToString(),
                user.Code, user.Name, culture, supportCultureNameList);
        }
    }
}