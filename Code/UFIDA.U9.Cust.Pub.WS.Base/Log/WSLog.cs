using System;
using System.ComponentModel;

namespace UFIDA.U9.Cust.Pub.WCFService.Log
{
    /// <summary>
    ///     调用结果
    /// </summary>
    public enum CallResultEnum
    {
        [Description("失败")] Failure = 0,
        [Description("成功")] Success = 1
    }

    public class WSLog
    {
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
        public CallResultEnum CallResult
        {
            get { return Exception == null ? CallResultEnum.Success : CallResultEnum.Failure; }
        }

        /// <summary>
        ///     异常
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        ///     错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}