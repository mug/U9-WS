





namespace UFIDA.U9.Cust.Pub.WSM.WSTokenSV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Reflection;
	using UFSoft.UBF.AopFrame; 	

	/// <summary>
	/// 清理Token超时服务 business operation
	/// 
	/// </summary>
	[Serializable]	
	public partial class CleanWSTokenSV
	{
	    #region Fields
		
	    #endregion
		
	    #region constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public CleanWSTokenSV()
		{}
		
	    #endregion

	    #region member		
	    #endregion
		
	    #region do method 
		[Transaction(UFSoft.UBF.Transactions.TransactionOption.Required)]
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
