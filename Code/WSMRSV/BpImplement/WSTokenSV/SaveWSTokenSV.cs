





namespace UFIDA.U9.Cust.Pub.WSM.WSTokenSV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Reflection;
	using UFSoft.UBF.AopFrame; 	

	/// <summary>
	/// 保存Token服务 business operation
	/// 
	/// </summary>
	[Serializable]	
	public partial class SaveWSTokenSV
	{
	    #region Fields
		private UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenDTOData wSTokenDTO;
		
	    #endregion
		
	    #region constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public SaveWSTokenSV()
		{}
		
	    #endregion

	    #region member		
		/// <summary>
		/// 服务TokenDTO	
		/// 保存Token服务.Misc.服务TokenDTO
		/// </summary>
		/// <value></value>
		public UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenDTOData WSTokenDTO
		{
			get
			{
				return this.wSTokenDTO;
			}
			set
			{
				wSTokenDTO = value;
			}
		}
	    #endregion
		
	    #region do method 
		[Transaction(UFSoft.UBF.Transactions.TransactionOption.Required)]
		[Logger]
		[Authorize]
		public System.Boolean Do()
		{	
		    BaseStrategy selector = Select();	
				System.Boolean result =  (System.Boolean)selector.Execute(this);	
		    
			return result ; 
		}			
	    #endregion 					
	} 		
}
