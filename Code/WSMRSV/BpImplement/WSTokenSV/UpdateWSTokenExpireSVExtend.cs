using UFIDA.U9.Base;
using UFIDA.U9.Cust.Pub.WSM.WSTokenBE;
using UFSoft.UBF.AopFrame;
using UFSoft.UBF.Business;
using UFSoft.UBF.PL;

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenSV
{
    /// <summary>
    ///     UpdateWSTokenExpireSV partial
    /// </summary>
    public partial class UpdateWSTokenExpireSV
    {
        internal BaseStrategy Select()
        {
            return new UpdateWSTokenExpireSVImpementStrategy();
        }
    }

    #region  implement strategy	

    /// <summary>
    ///     Impement Implement
    /// </summary>
    internal class UpdateWSTokenExpireSVImpementStrategy : BaseStrategy
    {
        public override object Do(object obj)
        {
            UpdateWSTokenExpireSV bpObj = (UpdateWSTokenExpireSV) obj;
            if (bpObj.WSTokenDTO == null)
                throw new BpParameterException("UpdateWSTokenExpireSV", "WSTokenDTO");
            WSTokenDTOData wsTokenDTO = bpObj.WSTokenDTO;
            WSToken wsToken = WSToken.Finder.Find("TokenStr = @TokenStr", new OqlParam("TokenStr", wsTokenDTO.TokenStr));
            if (wsToken == null) return false;
            if (!wsToken.IsAlive) return false;
            using (ISession s = Session.Open())
            {
                wsToken.LastUpdateTime = wsTokenDTO.LastUpdateTime;
                s.InList(wsToken);
                s.Commit();
            }
            return true;
        }
    }

    #endregion
}