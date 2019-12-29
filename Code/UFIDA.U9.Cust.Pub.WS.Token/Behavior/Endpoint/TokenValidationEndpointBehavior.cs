using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.Token.Services;

namespace UFIDA.U9.Cust.Pub.WS.Token.Behavior.Endpoint
{
    public class TokenValidationEndpointBehavior : IDispatchMessageInspector, IEndpointBehavior
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // Return BadRequest if request is null
            if (WebOperationContext.Current == null)
            {
                throw new WebFaultException(HttpStatusCode.BadRequest);
            }
            // Get Token from header
            string tokenStr = WebOperationContext.Current.IncomingRequest.Headers[TokenConstant.HeaderAccessTokenName];
            if (!string.IsNullOrWhiteSpace(tokenStr))
            {
                ValidateToken(tokenStr);
            }
            else
            {
                ValidateBasicAuthentication();
            }
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        private static void ValidateToken(string tokenStr)
        {
            Token token = TokenManagement.Instance.Get(tokenStr);
            if (token == null || TokenManagement.Instance.IsExpired(token))
            {
                throw new TokenException("用户未认证或认证已超时失效");
            }
            else
            {
                //更新Token日期
                TokenManagement.Instance.UpdateExpire(token);
            }
            // Add User ids to the header so the service has them if needed
            string headerToken =
                WebOperationContext.Current?.IncomingRequest.Headers[TokenConstant.HeaderAccessTokenName];
            if (string.IsNullOrWhiteSpace(headerToken))
                WebOperationContext.Current?.IncomingRequest.Headers.Add(TokenConstant.HeaderAccessTokenName, tokenStr);
            //WebOperationContext.Current?.IncomingRequest.Headers.Add("User", validator.Token.User.Username);
            //WebOperationContext.Current?.IncomingRequest.Headers.Add("UserId", validator.Token.User.Id.ToString());
        }

        private static void ValidateBasicAuthentication()
        {
            string authorization =
                WebOperationContext.Current?.IncomingRequest.Headers[TokenConstant.HeaderAuthorizationName];
            if (string.IsNullOrWhiteSpace(authorization))
            {
                throw new TokenException("用户未认证或认证已超时失效");
                //throw new WebFaultException(HttpStatusCode.Forbidden);
            }
            BasicAuth basicAuth = new BasicAuth(authorization);
            ReturnMessage<string> ret = new AuthTokenService().Authenticate(basicAuth.Creds);
            ValidateToken(ret.Result);
        }
    }
}