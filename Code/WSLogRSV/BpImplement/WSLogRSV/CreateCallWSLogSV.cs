





namespace UFIDA.U9.Cust.Pub.WSLogRSV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Reflection;
	using UFSoft.UBF.AopFrame; 	

	/// <summary>
	/// 创建调用日志服务 business operation
	/// 
	/// </summary>
	[Serializable]	
	public partial class CreateCallWSLogSV
	{
	    #region Fields
		private UFIDA.U9.Cust.Pub.WSLogRSV.WSLogDTOData wSLogDTO;
		
	    #endregion
		
	    #region constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public CreateCallWSLogSV()
		{}
		
	    #endregion

	    #region member		
		/// <summary>
		/// 服务日志DTO	
		/// 创建调用日志服务.Misc.服务日志DTO
		/// </summary>
		/// <value></value>
		public UFIDA.U9.Cust.Pub.WSLogRSV.WSLogDTOData WSLogDTO
		{
			get
			{
				return this.wSLogDTO;
			}
			set
			{
				wSLogDTO = value;
			}
		}
	    #endregion
		
	    #region do method 
		[Transaction(UFSoft.UBF.Transactions.TransactionOption.RequiresNew)]
		[Logger]
		[Authorize]
		public System.Int64 Do()
		{	
		    BaseStrategy selector = Select();	
				System.Int64 result =  (System.Int64)selector.Execute(this);	
		    
			return result ; 
		}			
	    #endregion 					
	} 		
}
