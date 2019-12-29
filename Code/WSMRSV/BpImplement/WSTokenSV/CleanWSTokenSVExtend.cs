using System;
using UFIDA.U9.Cust.Pub.WSM.WSMRSV;
using UFIDA.U9.Cust.Pub.WSM.WSTokenBE;
using UFSoft.UBF.AopFrame;
using UFSoft.UBF.Business;

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenSV
{
    /// <summary>
    ///     CleanWSTokenSV partial
    /// </summary>
    public partial class CleanWSTokenSV
    {
        internal BaseStrategy Select()
        {
            return new CleanWSTokenSVImpementStrategy();
        }
    }

    #region  implement strategy	

    /// <summary>
    ///     Impement Implement
    /// </summary>
    internal class CleanWSTokenSVImpementStrategy : BaseStrategy
    {
        public override object Do(object obj)
        {
            CleanWSTokenSV bpObj = (CleanWSTokenSV) obj;
            WSToken.EntityList wsTokenList = WSToken.Finder.FindAll("IsAlive = 1 order by LastUpdateTime");
            if (wsTokenList.Count == 0) return null;
            int timeoutSecond = WSHelper.GetTokenTimeoutSecond();
            TimeSpan timeout = TimeSpan.FromSeconds(timeoutSecond);
            DateTime now = DateTime.Now;
            using (ISession s = Session.Open())
            {
                foreach (WSToken wsToken in wsTokenList)
                {
                    DateTime d = wsToken.LastUpdateTime;
                    bool isExpired = now - d > timeout;
                    if (!isExpired) break;
                    wsToken.IsAlive = false;
                    wsToken.InvalidTime = now;
                    s.InList(wsToken);
                }
                s.Commit();
            }
            return null;
        }
    }

    #endregion
}