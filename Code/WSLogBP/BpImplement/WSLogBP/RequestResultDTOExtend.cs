



#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace UFIDA.U9.Cust.Pub.WSLogBP {

	public partial class RequestResultDTO{

		#region Constructor
		/// <summary>
		/// Constructor with Full Argument 
		/// </summary>
		public RequestResultDTO(  System.Int64 wSLogID  , UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum callResult  , System.String responseContent  , System.String errorMessage  )
		{
			this.WSLogID = wSLogID;
			this.CallResult = callResult;
			this.ResponseContent = responseContent;
			this.ErrorMessage = errorMessage;
		}
		#endregion	






		#region Model Methods
		#endregion

	}
}
