using System.ServiceModel.Activation;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.LoginService.Interfaces;
using UFIDA.U9.Cust.Pub.WS.Token.Services;
using UFIDA.U9.Cust.Pub.WS.U9Context.Auth;

namespace UFIDA.U9.Cust.Pub.WS.LoginService.Services
{
    /// <summary>
    ///     登录服务
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LoginService : ILoginService
    {
        public ReturnMessage<string> Login(Credentials cred)
        {
            AuthTokenService authTokenService = new AuthTokenService();
            return authTokenService.Authenticate(cred);
        }

        public ReturnMessage<bool> Logout()
        {
            ReturnMessage<bool> ret = new ReturnMessage<bool>();
            ret.Result = true;
            return ret;
        }
    }
}