using System;
using System.Text;

namespace UFIDA.U9.Cust.Pub.WS.U9Context.Auth
{
    public class BasicAuth
    {
        private const string Prefix = "Basic ";
        private readonly string _enterpriseID;
        private readonly string _orgCode;
        private readonly string _userCode;
        private readonly string _password;
        private readonly string _culture;
        private readonly string _supportCultureNameList;
        private Credentials _creds;

        public Credentials Creds
        {
            get
            {
                return _creds ??
                       (_creds =
                           new Credentials
                           {
                               EnterpriseID = _enterpriseID,
                               OrgCode = _orgCode,
                               UserCode = _userCode,
                               Password = _password,
                               Culture=_culture,
                               SupportCultureNameList = _supportCultureNameList
                           });
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
                _orgCode = credArray[1];
            if (credArray.Length > 2)
                _userCode = credArray[2];
            if (credArray.Length >3)
                _password = credArray[3];
            if (credArray.Length > 4)
                _culture = credArray[4];
            if (credArray.Length > 5)
                _supportCultureNameList = credArray[5];
        }

        public BasicAuth(string enterpriseID, string orgCode, string userCode, string password,string culture,string supportCultureNameList)
            : this(enterpriseID, orgCode, userCode, password,culture,supportCultureNameList, Encoding.UTF8)
        {
        }

        public BasicAuth(string enterpriseID, string orgCode, string userCode, string password, string culture, string supportCultureNameList, Encoding encoding)
        {
            _enterpriseID = enterpriseID;
            _orgCode = orgCode;
            _userCode = userCode;
            _password = password;
            _culture = culture;
            _supportCultureNameList = supportCultureNameList;
            HeaderValue = Prefix +
                          Convert.ToBase64String(
                              encoding.GetBytes(string.Format("{0}:{1}:{2}:{3}:{4}:{5}", _enterpriseID, _orgCode, _userCode,
                                  _password,_culture,_supportCultureNameList)));
        }

        #endregion
    }
}