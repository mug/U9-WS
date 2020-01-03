using System;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using UFIDA.U9.Base.UserRole;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFIDA.U9.Cust.Pub.WS.Token.Models;
using UFIDA.U9.Cust.Pub.WS.U9Context;
using UFIDA.UBF.SystemManage;
using Organization = UFIDA.U9.Base.Organization.Organization;

namespace UFIDA.U9.Cust.Pub.WS.Token
{
    /// <summary>
    ///     Token帮助类
    /// </summary>
    public static class TokenHelper
    {
        /// <summary>
        ///     获取上下文环境信息
        /// </summary>
        /// <param name="creds"></param>
        public static ContextInfo GetContextInfo(Credentials creds)
        {
            if (creds == null)
                throw new ArgumentException("身份认证信息不能为空");
            if (string.IsNullOrWhiteSpace(creds.EnterpriseID))
                throw new AuthenticationException("企业ID不能为空");
            if (string.IsNullOrWhiteSpace(creds.OrgCode))
                throw new AuthenticationException("组织不能为空");
            if (string.IsNullOrWhiteSpace(creds.UserCode))
                throw new AuthenticationException("用户不能为空");
            Enterprise enterprise = ContextObject.GetEnterprise(creds.EnterpriseID);
            if (enterprise == null)
                throw new TokenException(string.Format("企业:{0}不存在!", creds.EnterpriseID));
            using (ContextObject contextObject = new ContextObject(enterprise))
            {
                if (string.IsNullOrWhiteSpace(creds.OrgCode))
                    throw new AuthenticationException("组织编码不能为空");
                Organization org = Organization.FindByCode(creds.OrgCode);
                if (org == null)
                    throw new TokenException(string.Format("组织:{0}不存在", creds.OrgCode));
                User user = User.FindByCode(creds.UserCode);
                if (user == null)
                    throw new AuthenticationException("用户不存在或密码不正确");
                string encryptPassword = EncryptPassword(creds.Password);
                if (encryptPassword != user.Password)
                {
                    throw new AuthenticationException("用户不存在或密码不正确");
                }
                if (!user.IsAlive)
                    throw new AuthenticationException("用户已失效");
                return ContextInfo.GetContext(enterprise, org, user, creds.Culture,
                    creds.SupportCultureNameList);
            }
        }

        /// <summary>
        ///     根据上下文信息创建Token
        /// </summary>
        /// <param name="tokenStr"></param>
        /// <param name="contextInfo"></param>
        /// <returns></returns>
        public static Token CreateToken(string tokenStr, ContextInfo contextInfo)
        {
            Token token = new Token();
            token.TokenStr = tokenStr;
            token.EnterpriseID = contextInfo.EnterpriseID;
            token.EnterpriseName = contextInfo.EnterpriseName;
            token.UserID = contextInfo.UserID;
            token.UserCode = contextInfo.UserCode;
            token.UserName = contextInfo.UserName;
            token.OrgID = contextInfo.OrgID;
            token.OrgCode = contextInfo.OrgCode;
            token.OrgName = contextInfo.OrgName;
            token.Culture = contextInfo.Culture;
            token.SupportCultureNameList = contextInfo.SupportCultureNameList;
            token.CreateTime = DateTime.Now;
            token.LastUpdateTime = DateTime.Now;
            return token;
        }

        /// <summary>
        ///     加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptPassword(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = new UnicodeEncoding().GetBytes(password);
            return Convert.ToBase64String(md5.ComputeHash(bytes));
        }

        /// <summary>
        ///     创建安全Token串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string BuildSecureTokenStr(int length)
        {
            byte[] buffer = new byte[length];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetNonZeroBytes(buffer);
            }
            return Convert.ToBase64String(buffer);
        }
    }
}