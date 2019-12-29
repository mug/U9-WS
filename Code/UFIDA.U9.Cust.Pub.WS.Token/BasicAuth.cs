using System;
using System.Text;
using UFIDA.U9.Cust.Pub.WS.Token.Models;

namespace UFIDA.U9.Cust.Pub.WS.Token
{
    public class BasicAuth
    {
        private const string Prefix = "Basic ";
        private readonly string _enterpriseID;
        private readonly string _password;
        private readonly string _userCode;
        private Credentials _creds;

        public Credentials Creds
        {
            get
            {
                return _creds ??
                       (_creds =
                           new Credentials {EnterpriseID = _enterpriseID, UserCode = _userCode, Password = _password});
            }
        }

        public string HeaderValue { get; }

        #region Constructors

        public BasicAuth(string encodedHeader)
            : this(encodedHeader, Encoding.UTF8)
        {
        }

        public BasicAuth(string encodedHeader, Encoding encoding)
        {
            HeaderValue = encodedHeader;
            var decodedHeader = encodedHeader.StartsWith(Prefix, StringComparison.OrdinalIgnoreCase)
                ? encoding.GetString(Convert.FromBase64String(encodedHeader.Substring(Prefix.Length)))
                : encoding.GetString(Convert.FromBase64String(encodedHeader));
            var credArray = decodedHeader.Split(':');
            if (credArray.Length > 0)
                _enterpriseID = credArray[0];
            if (credArray.Length > 1)
                _userCode = credArray[1];
            if (credArray.Length > 2)
                _password = credArray[2];
        }

        public BasicAuth(string enterpriseID, string user, string password)
            : this(enterpriseID, user, password, Encoding.UTF8)
        {
        }

        public BasicAuth(string enterpriseID, string user, string password, Encoding encoding)
        {
            _enterpriseID = enterpriseID;
            _userCode = user;
            _password = password;
            HeaderValue = Prefix +
                          Convert.ToBase64String(encoding.GetBytes(string.Format("{0}:{1}", _userCode, _password)));
        }

        #endregion
    }
}