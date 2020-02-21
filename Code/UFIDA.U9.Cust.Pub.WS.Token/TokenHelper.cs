using System;
using System.Security.Cryptography;
using UFIDA.U9.Cust.Pub.WS.Context;

namespace UFIDA.U9.Cust.Pub.WS.Token
{
    /// <summary>
    ///     Token帮助类
    /// </summary>
    public static class TokenHelper
    {
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