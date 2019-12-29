using UFIDA.U9.Base;
using UFIDA.U9.Cust.Pub.WSM.WSTokenBE;
using UFSoft.UBF.AopFrame;
using UFSoft.UBF.Business;

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenSV
{
    /// <summary>
    ///     SaveWSTokenSV partial
    /// </summary>
    public partial class SaveWSTokenSV
    {
        internal BaseStrategy Select()
        {
            return new SaveWSTokenSVImpementStrategy();
        }
    }

    #region  implement strategy	

    /// <summary>
    ///     Impement Implement
    /// </summary>
    internal class SaveWSTokenSVImpementStrategy : BaseStrategy
    {
        public override object Do(object obj)
        {
            var bpObj = (SaveWSTokenSV) obj;
            if (bpObj.WSTokenDTO == null)
                throw new BpParameterException("SaveWSTokenSV", "WSTokenDTO");
            WSTokenDTOData wsTokenDTO = bpObj.WSTokenDTO;
            using (ISession s = Session.Open())
            {
                WSToken wsToken = WSToken.Create();
                //TokenStr Token串
                wsToken.TokenStr = wsTokenDTO.TokenStr;
                //EnterpriseID 企业ID
                wsToken.EnterpriseID = wsTokenDTO.EnterpriseID;
                //EnterpriseName 企业名称
                wsToken.EnterpriseName = wsTokenDTO.EnterpriseName;
                //UserID 用户ID
                wsToken.UserID = wsTokenDTO.UserID;
                //UserCode 用户编码
                wsToken.UserCode = wsTokenDTO.UserCode;
                //UserName 用户名称
                wsToken.UserName = wsTokenDTO.UserName;
                //OrgID 组织ID
                wsToken.OrgID = wsTokenDTO.OrgID;
                //OrgCode 组织编码
                wsToken.OrgCode = wsTokenDTO.OrgCode;
                //OrgName 组织名称
                wsToken.OrgName = wsTokenDTO.OrgName;
                //CreateTime 创建时间
                wsToken.CreateTime = wsTokenDTO.CreateTime;
                //LastUpdateTime 最后更新时间
                wsToken.LastUpdateTime = wsTokenDTO.LastUpdateTime;
                //InvalidTime 失效时间
                //IsAlive 活动
                wsToken.IsAlive = true;
                s.InList(wsToken);
                s.Commit();
            }
            return true;
        }
    }

    #endregion
}