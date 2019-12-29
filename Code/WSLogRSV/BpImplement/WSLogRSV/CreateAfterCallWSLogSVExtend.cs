using UFIDA.U9.Cust.Pub.WSLogBE;
using UFSoft.UBF.AopFrame;
using UFSoft.UBF.Business;
using UFSoft.UBF.Util.Exceptions;

namespace UFIDA.U9.Cust.Pub.WSLogRSV
{
    /// <summary>
    ///     CreateAfterCallWSLogSV partial
    /// </summary>
    public partial class CreateAfterCallWSLogSV
    {
        internal BaseStrategy Select()
        {
            return new CreateAfterCallWSLogSVImpementStrategy();
        }
    }

    #region  implement strategy	

    /// <summary>
    ///     Impement Implement
    /// </summary>
    internal class CreateAfterCallWSLogSVImpementStrategy : BaseStrategy
    {
        public override object Do(object obj)
        {
            CreateAfterCallWSLogSV bpObj = (CreateAfterCallWSLogSV) obj;
            WSLogDTOData wsLogDTO = bpObj.WSLogDTO;
            if (wsLogDTO == null) return null;
            if (wsLogDTO.LogID <= 0)
                throw new ApplicationExceptionBase("LogID 不能为空");
            WSLog wsLog = WSLog.Finder.FindByID(wsLogDTO.LogID);
            if (wsLog == null)
                throw new ApplicationExceptionBase(string.Format("LogID:{0} 未找到相应的日志记录", wsLogDTO.LogID));
            using (ISession s = Session.Open())
            {
                //EndTime	结束时间
                wsLog.EndTime = wsLogDTO.EndTime;
                //ElapsedSecond	历时(秒)
                wsLog.ElapsedSecond = wsLogDTO.ElapsedSecond;
                //ResponseContent	返回内容
                wsLog.ResponseContent = wsLogDTO.ResponseContent;
                //CallResult	调用结果
                wsLog.CallResult = wsLogDTO.CallResult ? CallResultEnum.Success : CallResultEnum.Failure;
                //ErrorMessage	错误信息
                wsLog.ErrorMessage = wsLogDTO.ErrorMessage;
                s.InList(wsLog);
                s.Commit();
            }
            return wsLog.ID;
        }
    }

    #endregion
}