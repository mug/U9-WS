



#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace UFIDA.U9.Cust.Pub.WSLogSV {

	public partial class WSLogDTO{

		#region Constructor
		/// <summary>
		/// Constructor with Full Argument 
		/// </summary>
		public WSLogDTO(  System.String requestUrl  , System.String className  , System.String methodName  , System.DateTime startTime  , System.DateTime endTime  , System.Decimal elapsedSecond  , System.String requestContent  , System.String responseContent  , UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum callResult  , System.String errorMessage  , System.Int64 logID  , System.String methodDescription  )
		{
			this.RequestUrl = requestUrl;
			this.ClassName = className;
			this.MethodName = methodName;
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.ElapsedSecond = elapsedSecond;
			this.RequestContent = requestContent;
			this.ResponseContent = responseContent;
			this.CallResult = callResult;
			this.ErrorMessage = errorMessage;
			this.LogID = logID;
			this.MethodDescription = methodDescription;
		}
		#endregion	






		#region Model Methods
		#endregion

	}
}
