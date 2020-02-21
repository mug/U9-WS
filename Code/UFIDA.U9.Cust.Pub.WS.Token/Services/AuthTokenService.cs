using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFIDA.U9.Cust.Pub.WS.Token.Interfaces;
using UFIDA.U9.Cust.Pub.WS.U9Context.Auth;

namespace UFIDA.U9.Cust.Pub.WS.Token.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AuthTokenService : IAuthTokenService
    {
        /// <summary>
        ///     校验
        /// </summary>
        /// <param name="creds"></param>
        /// <returns></returns>
        public ReturnMessage<string> Authenticate(Credentials creds)
        {
            ReturnMessage<string> ret = new ReturnMessage<string>();
            if (creds == null && WebOperationContext.Current != null)
            {
                string basicAuthHeader =
                    WebOperationContext.Current.IncomingRequest.Headers[ContextConstant.HeaderAuthorizationName];
                if (!string.IsNullOrWhiteSpace(basicAuthHeader))
                    creds = new BasicAuth(basicAuthHeader).Creds;
            }
            Token token = TokenManagement.Instance.Create(creds);
            if (token == null)
                throw new TokenException("获取Token失败,请确认配置是否正确");
            ret.Result = token.TokenStr;
            return ret;
        }

        /// <summary>
        ///     Token是否有效
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ReturnMessage<bool> TokenIsValid(Token token)
        {
            ReturnMessage<bool> ret = new ReturnMessage<bool>();
            ret.Result = false;
            token = TokenManagement.Instance.Get(token.TokenStr);
            if (token == null || TokenManagement.Instance.IsExpired(token)) return ret;
            TokenManagement.Instance.UpdateExpire(token);
            ret.Result = true;
            return ret;
        }
    }
}