using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.DebugService.Models
{
    [DataContract]
    public class SQLDebugLogMsg
    {
        private Stopwatch _stopwatch;

        [DataMember]
        public string LogID { get; set; }

        /// <summary>
        ///  方法名称
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        ///  方法名称
        /// </summary>
        public CommandType CommandType { get; set; }

        [DataMember]
        public string EnterpriseID { get; set; }

        [DataMember]
        public string OrgCode { get; set; }

        [DataMember]
        public string UserCode { get; set; }

        [DataMember]
        public string SqlString { get; set; }

        [DataMember]
        public string DataParamsString { get; set; }

        [DataMember]
        public string CallStack { get; set; }

        [DataMember]
        public long ElapsedTime { get; set; }

        public void BeforeCall(string methodName, string enterpriseID, string orgCode, string userCode,CommandType commandType, string sqlString, string dataParamsString,
            string callStack)
        {
            this.LogID = Guid.NewGuid().ToString();
            this.MethodName = methodName;
            this.EnterpriseID = enterpriseID;
            this.OrgCode = orgCode;
            this.UserCode = userCode;
            this.CommandType = commandType;
            this.SqlString = sqlString;
            this.DataParamsString = dataParamsString;
            this.CallStack = callStack;
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void AfterCall()
        {
            if (_stopwatch == null) return;
            if (_stopwatch.IsRunning)
            {
                _stopwatch.Stop();
                this.ElapsedTime = _stopwatch.ElapsedMilliseconds;
            }
        }
    }
}