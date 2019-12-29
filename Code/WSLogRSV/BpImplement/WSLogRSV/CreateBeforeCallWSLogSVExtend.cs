using UFIDA.U9.Cust.Pub.WSLogBE;
using UFSoft.UBF.AopFrame;
using UFSoft.UBF.Business;

namespace UFIDA.U9.Cust.Pub.WSLogRSV
{
    /// <summary>
    ///     CreateBeforeCallWSLogSV partial
    /// </summary>
    public partial class CreateBeforeCallWSLogSV
    {
        internal BaseStrategy Select()
        {
            return new CreateBeforeCallWSLogSVImpementStrategy();
        }
    }

    #region  implement strategy	

    /// <summary>
    ///     Impement Implement
    /// </summary>
    internal class CreateBeforeCallWSLogSVImpementStrategy : BaseStrategy
    {
        public override object Do(object obj)
        {
            CreateBeforeCallWSLogSV bpObj = (CreateBeforeCallWSLogSV) obj;
            WSLogDTOData wsLogDTO = bpObj.WSLogDTO;
            if (wsLogDTO == null) return null;
            WSLog wsLog = null;
            using (ISession s = Session.Open())
            {
                if (wsLogDTO.LogID > 0)
                {
                    wsLog = WSLog.Finder.FindByID(wsLogDTO.LogID);
                }
                else
                {
                    wsLog = WSLog.Create();
                    //RequestUrl	请求地址
                    wsLog.RequestUrl = wsLogDTO.RequestUrl;
                    //ClassName	类名
                    wsLog.ClassName = wsLogDTO.ClassName;
                    //MethodName	方法名
                    wsLog.MethodName = wsLogDTO.MethodName;
                    //MethodDescription 方法描述
                    wsLog.MethodDescription = wsLogDTO.MethodDescription;
                    //RequestContent	请求内容
                    wsLog.RequestContent = wsLogDTO.RequestContent;
                }
                //StartTime	开始时间
                wsLog.StartTime = wsLogDTO.StartTime;
                //CallCount 请求次数
                wsLog.CallCount++;
                s.InList(wsLog);
                s.Commit();
            }
            return wsLog.ID;
        }
    }

    #endregion
}