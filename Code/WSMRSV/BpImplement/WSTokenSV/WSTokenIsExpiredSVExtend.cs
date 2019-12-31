using System;
using UFIDA.U9.Base;
using UFIDA.U9.Cust.Pub.WSM.WSMRSV;
using UFIDA.U9.Cust.Pub.WSM.WSTokenBE;
using UFSoft.UBF.AopFrame;
using UFSoft.UBF.Business;
using UFSoft.UBF.PL;

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenSV
{
    /// <summary>
    ///     WSTokenIsExpiredSV partial
    /// </summary>
    public partial class WSTokenIsExpiredSV
    {
        internal BaseStrategy Select()
        {
            return new WSTokenIsExpiredSVImpementStrategy();
        }
    }

    #region  implement strategy	

    /// <summary>
    ///     Impement Implement
    /// </summary>
    internal class WSTokenIsExpiredSVImpementStrategy : BaseStrategy
    {
        public override object Do(object obj)
        {
            WSTokenIsExpiredSV bpObj = (WSTokenIsExpiredSV) obj;
            if (bpObj.WSTokenDTO == null)
                throw new BpParameterException("WSTokenIsExpiredSV", "WSTokenDTO");
            WSTokenDTOData wsTokenDTO = bpObj.WSTokenDTO;
            WSToken wsToken = WSToken.Finder.Find("TokenStr = @TokenStr", new OqlParam("TokenStr", wsTokenDTO.TokenStr));
            if (wsToken == null) return true;
            if (!wsToken.IsAlive) return true;
            //Token操时秒数
            int timeoutSecond = WSHelper.GetTokenTimeoutSecond();
            TimeSpan timeout = TimeSpan.FromSeconds(timeoutSecond);
            DateTime now = DateTime.Now;
            DateTime d = wsToken.LastUpdateTime;
            bool isExpired = now - d > timeout;
            if (!isExpired) return false;
            using (ISession s = Session.Open())
            {
                wsToken.IsAlive = false;
                wsToken.InvalidTime = DateTime.Now;
                s.InList(wsToken);
                s.Commit();
            }
            return true;
        }
    }

    #endregion
}