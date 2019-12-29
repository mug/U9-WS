





namespace UFIDA.U9.Cust.Pub.WSLogBP
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Reflection;
	using UFSoft.UBF.AopFrame; 	

	/// <summary>
	/// 请求处理 business operation
	/// 
	/// </summary>
	[Serializable]	
	public partial class DoRequestBP
	{
	    #region Fields
		private System.Int64 wSLogID;
		
	    #endregion
		
	    #region constructor
		public DoRequestBP()
		{}
		
	    #endregion

	    #region member		
		/// <summary>
		/// 服务日志ID	
		/// 请求处理.Misc.服务日志ID
		/// </summary>
		/// <value></value>
		public System.Int64 WSLogID
		{
			get
			{
				return this.wSLogID;
			}
			set
			{
				wSLogID = value;
			}
		}
	    #endregion
		
	    #region do method 
		[Transaction(UFSoft.UBF.Transactions.TransactionOption.Required)]
		[Logger]
		[Authorize]
		public UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTO Do()
		{	
		    BaseStrategy selector = Select();	
				UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTO result =  (UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTO)selector.Execute(this);	
		    
			return result ; 
		}			
	    #endregion 					
	} 		
}
