using System;
using UFIDA.U9.Cust.Pub.WSLogSV;
using UFIDA.U9.Cust.Pub.WSLogSV.Proxy;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WCFService.Log
{
    /// <summary>
    ///     WebService日志帮助类
    /// </summary>
    public static class WSLogHelper
    {
        private static readonly ILogger _logger = LoggerManager.GetLogger("WSLog");

        /// <summary>
        ///     创建日志
        /// </summary>
        /// <param name="wsLog"></param>
        public static void CreateWSLog(WSLog wsLog)
        {
            try
            {
                CreateWSLogSVProxy proxy = new CreateWSLogSVProxy();
                WSLogDTOData dtoData = new WSLogDTOData();
                //日志ID
                dtoData.LogID = wsLog.LogID;
                //RequestUrl 请求地址
                dtoData.RequestUrl = wsLog.RequestUrl;
                //ClassName 类名
                dtoData.ClassName = wsLog.ClassName;
                //MethodName 方法名
                dtoData.MethodName = wsLog.MethodName;
                //MethodDescription 方法描述
                dtoData.MethodDescription = wsLog.MethodDescription;
                //StartTime 开始时间
                dtoData.StartTime = wsLog.StartTime;
                //EndTime 结束时间
                dtoData.EndTime = wsLog.EndTime;
                //ElapsedSecond 历时(秒)
                dtoData.ElapsedSecond = wsLog.ElapsedSecond;
                //RequestContent  请求内容
                dtoData.RequestContent = wsLog.RequestContent;
                //ResponseContent 返回内容
                dtoData.ResponseContent = wsLog.ResponseContent;
                //CallResult  调用结果
                dtoData.CallResult = wsLog.CallResult == CallResultEnum.Success ? 1 : 0;
                //ErrorMessage    错误信息
                dtoData.ErrorMessage = wsLog.ErrorMessage;
                proxy.WSLogDTO = dtoData;
                proxy.Do();
            }
            catch (Exception ex)
            {
                _logger.Error("记录服务日志异常");
                _logger.Error(ex);
            }
        }
    }
}