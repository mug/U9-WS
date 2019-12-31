using System;
using System.Collections.Specialized;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFIDA.U9.Cust.Pub.WS.Token.Configuration;
using UFIDA.U9.Cust.Pub.WS.Token.Models;
using UFIDA.U9.Cust.Pub.WS.U9Context;
using UFIDA.U9.Cust.Pub.WSM.WSTokenBE;
using UFIDA.U9.Cust.Pub.WSM.WSTokenSV;
using UFIDA.U9.Cust.Pub.WSM.WSTokenSV.Proxy;
using UFIDA.UBF.SystemManage;
using UFSoft.UBF.PL;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.Token.DBProvider
{
    /// <summary>
    ///     服务Token数据库提供者
    /// </summary>
    public class WSTokenDBProvider : TokenProvider
    {
        #region 属性

        private const int DefaultTokenSize = 200;
        private const char TokenStrSplitSymbol = '#';
        private static ILogger _logger = LoggerManager.GetLogger(typeof (WSTokenDBProvider));
        private bool _isSameCredentialsOneToken;
        private int _tokenSize = -1;

        /// <summary>
        ///     Token串长度
        /// </summary>
        private int TokenSize
        {
            get { return _tokenSize; }
        }

        /// <summary>
        ///     相同证书同一个Token
        /// </summary>
        private bool IsSameCredentialsOneToken
        {
            get { return _isSameCredentialsOneToken; }
        }

        /// <summary>
        ///     是否内存缓存
        /// </summary>
        public override bool IsMemoryCache
        {
            get { return false; }
        }

        #endregion

        #region 重写虚方法

        /// <summary>
        ///     加载配置
        /// </summary>
        /// <param name="name"></param>
        /// <param name="config"></param>
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
            _tokenSize = config["tokenSize"] == null ? DefaultTokenSize : Convert.ToInt32(config["tokenSize"]);
            _isSameCredentialsOneToken = config["isSameCredentialsOneToken"] == null || Convert.ToBoolean(config["isSameCredentialsOneToken"]);
        }

        /// <summary>
        ///     创建Token
        /// </summary>
        /// <param name="creds"></param>
        /// <returns></returns>
        public override Token Create(Credentials creds)
        {
            ContextInfo contextInfo = TokenHelper.GetContextInfo(creds);
            Token token;
            using (ContextObject contextObject = new ContextObject(contextInfo))
            {
                if (IsSameCredentialsOneToken)
                {
                    WSToken wsToken =
                        WSToken.Finder.Find(@"EnterpriseID = @EnterpriseID and UserCode = @UserCode 
                    and OrgCode = @OrgCode and IsAlive = 1 order by LastUpdateTime desc",
                            new OqlParam("EnterpriseID", contextInfo.EnterpriseID),
                            new OqlParam("UserCode", contextInfo.UserCode), new OqlParam("OrgCode", contextInfo.OrgCode));
                    if (wsToken != null)
                    {
                        token = TransToToken(wsToken);
                        token.LastUpdateTime = DateTime.Now;
                        //更新有效期
                        UpdateExpireImpl(token);
                        return token;
                    }
                }
                //创建Token
                string tokenStr = BuildTokenStr(contextInfo.EnterpriseID, this.TokenSize);
                token = TokenHelper.CreateToken(tokenStr, contextInfo);
                //保存Token
                SaveWSTokenSVProxy proxy = new SaveWSTokenSVProxy();
                proxy.WSTokenDTO = TransToWSTokenDTOData(token);
                proxy.Do();
            }
            return token;
        }

        /// <summary>
        ///     获取Token
        /// </summary>
        /// <param name="tokenStr"></param>
        /// <returns></returns>
        public override Token Get(string tokenStr)
        {
            if (string.IsNullOrEmpty(tokenStr)) return null;
            string[] tokenArr = tokenStr.Split(TokenStrSplitSymbol);
            if (tokenArr.Length <= 1) return null;
            string enterpriseID = tokenArr[0];
            Enterprise enterprise = ContextObject.GetEnterprise(enterpriseID);
            if (enterprise == null)
                throw new TokenException(string.Format("企业:{0} 不存在!", enterpriseID));
            using (ContextObject contextObject = new ContextObject(enterprise))
            {
                WSToken wsToken =
                    WSToken.Finder.Find(@"TokenStr = @TokenStr and IsAlive = 1",
                        new OqlParam("TokenStr", tokenStr));
                return wsToken == null ? null : TransToToken(wsToken);
            }
        }

        /// <summary>
        ///     是否有效
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsExpired(Token token)
        {
            using (ContextObject contextObject = new ContextObject(token))
            {
                WSTokenIsExpiredSVProxy proxy = new WSTokenIsExpiredSVProxy();
                proxy.WSTokenDTO = TransToWSTokenDTOData(token);
                return proxy.Do();
            }
        }

        /// <summary>
        ///     更新有效期
        /// </summary>
        /// <param name="token"></param>
        public override void UpdateExpire(Token token)
        {
            using (ContextObject contextObject = new ContextObject(token))
            {
                UpdateExpireImpl(token);
            }
        }

        /// <summary>
        ///     更新有效期
        /// </summary>
        /// <param name="token"></param>
        private void UpdateExpireImpl(Token token)
        {
            token.LastUpdateTime = DateTime.Now;
            UpdateWSTokenExpireSVProxy proxy = new UpdateWSTokenExpireSVProxy();
            proxy.WSTokenDTO = TransToWSTokenDTOData(token);
            proxy.Do();
        }

        /// <summary>
        ///     清除Token
        /// </summary>
        public override void Clean()
        {
            //由于无法获取上下文，无法在此处清除Token
        }

        #endregion

        #region 其它

        /// <summary>
        ///     转换Token
        /// </summary>
        /// <param name="wsToken"></param>
        /// <returns></returns>
        private static Token TransToToken(WSToken wsToken)
        {
            Token token = new Token();
            token.TokenStr = wsToken.TokenStr;
            token.EnterpriseID = wsToken.EnterpriseID;
            token.EnterpriseName = wsToken.EnterpriseName;
            token.UserID = wsToken.UserID;
            token.UserCode = wsToken.UserCode;
            token.UserName = wsToken.UserName;
            token.OrgID = wsToken.OrgID;
            token.OrgCode = wsToken.OrgCode;
            token.OrgName = wsToken.OrgName;
            token.Culture = wsToken.Culture;
            token.SupportCultureNameList = wsToken.SupportCultureNameList;
            token.CreateTime = wsToken.CreateTime;
            token.LastUpdateTime = wsToken.LastUpdateTime;
            return token;
        }

        /// <summary>
        ///     转换WSTokenDTOData
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private static WSTokenDTOData TransToWSTokenDTOData(Token token)
        {
            WSTokenDTOData tokenDTO = new WSTokenDTOData();
            tokenDTO.TokenStr = token.TokenStr;
            tokenDTO.EnterpriseID = token.EnterpriseID;
            tokenDTO.EnterpriseName = token.EnterpriseName;
            tokenDTO.UserID = token.UserID;
            tokenDTO.UserCode = token.UserCode;
            tokenDTO.UserName = token.UserName;
            tokenDTO.OrgID = token.OrgID;
            tokenDTO.OrgCode = token.OrgCode;
            tokenDTO.OrgName = token.OrgName;
            tokenDTO.Culture = token.Culture;
            tokenDTO.SupportCultureNameList = token.SupportCultureNameList;
            tokenDTO.CreateTime = token.CreateTime;
            tokenDTO.LastUpdateTime = token.LastUpdateTime;
            return tokenDTO;
        }

        /// <summary>
        ///     创建Token串
        /// </summary>
        /// <param name="enterpriseID"></param>
        /// <param name="tokenSize"></param>
        /// <returns></returns>
        private static string BuildTokenStr(string enterpriseID, int tokenSize)
        {
            return string.Format("{0}{1}{2}", enterpriseID, TokenStrSplitSymbol,
                TokenHelper.BuildSecureTokenStr(tokenSize));
        }

        #endregion
    }
}