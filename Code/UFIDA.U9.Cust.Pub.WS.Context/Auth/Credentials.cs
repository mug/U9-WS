using System.Runtime.Serialization;
using System.Security.Authentication;
using UFIDA.U9.Base.UserRole;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFIDA.UBF.SystemManage;
using Organization = UFIDA.U9.Base.Organization.Organization;

namespace UFIDA.U9.Cust.Pub.WS.U9Context.Auth
{
    [DataContract]
    public class Credentials
    {
        /// <summary>
        ///     企业ID
        /// </summary>
        [DataMember]
        public string EnterpriseID { get; set; }

        /// <summary>
        ///     组织编码
        /// </summary>
        [DataMember]
        public string OrgCode { get; set; }

        /// <summary>
        ///     用户编码
        /// </summary>
        [DataMember]
        public string UserCode { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        ///     语言
        /// </summary>
        [DataMember]
        public string Culture { get; set; }

        /// <summary>
        ///     语言列表
        /// </summary>
        [DataMember]
        public string SupportCultureNameList { get; set; }

        /// <summary>
        ///     获取上下文环境信息
        /// </summary>
        public ContextInfo GetContextInfo()
        {
            if (string.IsNullOrWhiteSpace(this.EnterpriseID))
                throw new U9ContextException("企业ID不能为空");
            if (string.IsNullOrWhiteSpace(this.OrgCode))
                throw new U9ContextException("组织不能为空");
            if (string.IsNullOrWhiteSpace(this.UserCode))
                throw new U9ContextException("用户不能为空");
            Enterprise enterprise = ContextObject.GetEnterprise(this.EnterpriseID);
            if (enterprise == null)
                throw new U9ContextException(string.Format("企业:{0}不存在!", this.EnterpriseID));
            using (ContextObject contextObject = new ContextObject(enterprise))
            {
                if (string.IsNullOrWhiteSpace(this.OrgCode))
                    throw new U9ContextException("组织编码不能为空");
                Organization org = Organization.FindByCode(this.OrgCode);
                if (org == null)
                    throw new U9ContextException(string.Format("组织:{0}不存在", this.OrgCode));
                User user = User.FindByCode(this.UserCode);
                if (user == null)
                    throw new U9ContextException("用户不存在或密码不正确");
                string encryptPassword = ContextHelper.EncryptPassword(this.Password);
                if (encryptPassword != user.Password)
                {
                    throw new U9ContextException("用户不存在或密码不正确");
                }
                if (!user.IsAlive)
                    throw new U9ContextException("用户已失效");
                return ContextInfo.GetContext(enterprise, org, user, this.Culture,
                    this.SupportCultureNameList);
            }
        }
    }
}