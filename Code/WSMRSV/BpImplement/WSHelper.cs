using UFIDA.U9.Base.Profile;
using UFIDA.U9.Base.Profile.Proxy;

namespace UFIDA.U9.Cust.Pub.WSM.WSMRSV
{
    /// <summary>
    /// </summary>
    public static class WSHelper
    {
        /// <summary>
        ///     获取Token操时时间
        /// </summary>
        /// <returns></returns>
        public static int GetTokenTimeoutSecond()
        {
            GetProfileValueProxy getProfileValue = new GetProfileValueProxy();
            getProfileValue.ProfileCode = "Cust_WS_TokenTimeout";
            getProfileValue.IsThrowException = true;
            PVDTOData pV = getProfileValue.Do();
            return int.Parse(pV.ProfileValue);
        }
    }
}