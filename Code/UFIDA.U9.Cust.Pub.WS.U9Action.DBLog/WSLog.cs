using System;
using System.ComponentModel;
using System.Diagnostics;
using UFIDA.U9.Cust.Pub.WSLogRSV;
using UFIDA.U9.Cust.Pub.WSLogRSV.Proxy;

namespace UFIDA.U9.Cust.Pub.WS.DBLog
{
    /// <summary>
    ///     调用结果
    /// </summary>
    public enum CallResultEnum
    {
        [Description("失败")] Failure = 0,
        [Description("成功")] Success = 1
    }

    /// <summary>
    ///     服务日志
    /// </summary>
    public sealed class WSLog
    {
        #region 方法

        /// <summary>
        ///     转换为DTO
        /// </summary>
        /// <returns></returns>
        public WSLogDTOData ToWSLogDTO()
        {
            WSLogDTOData dtoData = new WSLogDTOData();
            //日志ID
            dtoData.LogID = this.LogID;
            //RequestUrl 请求地址
            dtoData.RequestUrl = this.RequestUrl;
            //ClassName 类名
            dtoData.ClassName = this.ClassName;
            //MethodName 方法名
            dtoData.MethodName = this.MethodName;
            //MethodDescription 方法描述
            dtoData.MethodDescription = this.MethodDescription;  
            //EnterpriseID 企业ID
            //dtoData.EnterpriseID = EnterpriseID;
            //StartTime 开始时间
            dtoData.StartTime = this.StartTime;
            //EndTime 结束时间
            dtoData.EndTime = this.EndTime;
            //ElapsedSecond 历时(秒)
            dtoData.ElapsedSecond = this.ElapsedSecond;
            //RequestContent  请求内容
            dtoData.RequestContent = this.RequestContent;
            //ResponseContent 返回内容
            dtoData.ResponseContent = this.ResponseContent;
            //CallResult  调用结果
            dtoData.CallResult = this.CallResult == CallResultEnum.Success;
            //ErrorMessage    错误信息
            dtoData.ErrorMessage = this.ErrorMessage;
            return dtoData;
        }

        /// <summary>
        ///     创建调用日志
        /// </summary>
        public void DoCallLog()
        {
            CreateCallWSLogSVProxy proxy = new CreateCallWSLogSVProxy();
            proxy.WSLogDTO = this.ToWSLogDTO();
            this.LogID = proxy.Do();
        }

        /// <summary>
        ///     创建调用前日志
        /// </summary>
        /// <returns></returns>
        public void DoBeforeCallLog()
        {
            _watch = new Stopwatch();
            _watch.Start();
            CreateBeforeCallWSLogSVProxy proxy = new CreateBeforeCallWSLogSVProxy();
            proxy.WSLogDTO = this.ToWSLogDTO();
            this.LogID = proxy.Do();
        }

        /// <summary>
        ///     创建调用后日志
        /// </summary>
        /// <returns></returns>
        public void DoAfterCallLog()
        {
            if (_watch != null)
            {
                _watch.Stop();
                this.ElapsedSecond = Math.Round(_watch.ElapsedMilliseconds/1000M, 3);
            }
            CreateAfterCallWSLogSVProxy proxy = new CreateAfterCallWSLogSVProxy();
            proxy.WSLogDTO = this.ToWSLogDTO();
            this.LogID = proxy.Do();
        }

        #endregion

        #region 属性

        private Stopwatch _watch;

        /// <summary>
        ///     日志ID
        /// </summary>
        public long LogID { get; set; }

        /// <summary>
        ///     请求URL
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        ///     请求类
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        ///     请求方法
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        ///     方法描述
        /// </summary>
        public string MethodDescription { get; set; }

        /// <summary>
        ///     开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        ///     历时
        /// </summary>
        public decimal ElapsedSecond { get; set; }

        /// <summary>
        ///     企业ID
        /// </summary>
        public string EnterpriseID { get; set; }

        /// <summary>
        ///     请求内容
        /// </summary>
        public string RequestContent { get; set; }

        /// <summary>
        ///     返回内容
        /// </summary>
        public string ResponseContent { get; set; }

        /// <summary>
        ///     调用结果
        /// </summary>
        public CallResultEnum CallResult { get; set; }

        /// <summary>
        ///     错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        #endregion
    }
}