using UFIDA.U9.Cust.Pub.WSLogBE;
using UFSoft.UBF.AopFrame;
using UFSoft.UBF.Business;

namespace UFIDA.U9.Cust.Pub.WSLogSV
{
    /// <summary>
    ///     CreateWSLogSV partial
    /// </summary>
    public partial class CreateWSLogSV
    {
        internal BaseStrategy Select()
        {
            return new CreateWSLogSVImpementStrategy();
        }
    }

    #region  implement strategy	

    /// <summary>
    ///     Impement Implement
    /// </summary>
    internal class CreateWSLogSVImpementStrategy : BaseStrategy
    {
        public override object Do(object obj)
        {
            CreateWSLogSV bpObj = (CreateWSLogSV) obj;
            WSLogDTO wsLogDTO = bpObj.WSLogDTO;
            if (wsLogDTO == null) return null;
            using (ISession s = Session.Open())
            {
                WSLog wsLog = null;
                if (wsLogDTO.LogID > 0)
                {
                    wsLog = WSLog.Finder.FindByID(wsLogDTO.LogID);
                }
                if (wsLog == null)
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
                //EndTime	结束时间
                wsLog.EndTime = wsLogDTO.EndTime;
                //ElapsedSecond	历时(秒)
                wsLog.ElapsedSecond = wsLogDTO.ElapsedSecond;
                //ResponseContent	返回内容
                wsLog.ResponseContent = wsLogDTO.ResponseContent;
                //CallResult	调用结果
                wsLog.CallResult = wsLogDTO.CallResult;
                //ErrorMessage	错误信息
                wsLog.ErrorMessage = wsLogDTO.ErrorMessage;
                //CallCount 请求次数
                wsLog.CallCount++;

                s.Commit();
            }

            return null;
        }
    }

    #endregion
}