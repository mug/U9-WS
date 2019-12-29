





namespace UFIDA.U9.Cust.Pub.WSLogSV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Reflection;
	using UFSoft.UBF.AopFrame; 	

	/// <summary>
	/// 创建服务日志服务 business operation
	/// 
	/// </summary>
	[Serializable]	
	public partial class CreateWSLogSV
	{
	    #region Fields
		private UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTO wSLogDTO;
		
	    #endregion
		
	    #region constructor
		public CreateWSLogSV()
		{}
		
	    #endregion

	    #region member		
		/// <summary>
		/// 服务日志DTO	
		/// 创建服务日志服务.Misc.服务日志DTO
		/// </summary>
		/// <value></value>
		public UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTO WSLogDTO
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
		public void Do()
		{	
		    BaseStrategy selector = Select();	
				selector.Execute(this);
		    
		}			
	    #endregion 					
	} 		
}
