



using System; 
using System.Collections;
using System.Collections.Generic ;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenSV
{
	/// <summary>
	/// 服务TokenDTO DTO :REST自定义的数据传输类型 
	/// 
	/// </summary>
	[DataContract(Namespace = "UFIDA.U9.Cust.Pub.WSM.WSTokenSV")]
	[Serializable]
	public partial class WSTokenDTOData  
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		public WSTokenDTOData()
		{
			initData();
		}
		private void initData()
		{
		
		
		
		
		
		
		
		
		
		
		
		
		

			//调用默认值初始化服务进行配置方式初始化
			UFSoft.UBF.Service.DTOService.InitConfigDefault(this);
		}
		[System.Runtime.Serialization.OnDeserializing]
		internal void OnDeserializing(System.Runtime.Serialization.StreamingContext context)
		{
			 initData();
		}
		#region Do SerializeKey -ForDTODataType
		//只为处理集合型EntityKey。原因集合型EntityKey由于使用臫的集合对象，无法实现数据共享.-UBF专用.
		public void DoSerializeKeyList(IDictionary dict)
		{
			if (dict == null ) dict = new Hashtable() ;
			if (dict[this] != null)
				return ;
			dict[this] = this;
	        	        	        	        	        	        	        	        	        	        	        	        	        
		}
		#endregion 
		/// <summary>
		/// Constructor Full Argument
		/// </summary>
		public WSTokenDTOData(  System.String tokenStr  , System.String enterpriseID  , System.String enterpriseName  , System.String userID  , System.String userCode  , System.String userName  , System.String orgID  , System.String orgCode  , System.String orgName  , System.DateTime createTime  , System.DateTime lastUpdateTime  , System.String culture  , System.String supportCultureNameList  )
		{
			initData();
			this.TokenStr = tokenStr;
			this.EnterpriseID = enterpriseID;
			this.EnterpriseName = enterpriseName;
			this.UserID = userID;
			this.UserCode = userCode;
			this.UserName = userName;
			this.OrgID = orgID;
			this.OrgCode = orgCode;
			this.OrgName = orgName;
			this.CreateTime = createTime;
			this.LastUpdateTime = lastUpdateTime;
			this.Culture = culture;
			this.SupportCultureNameList = supportCultureNameList;
		}
		#region System Fields 
		//--系统字段,目前没有.EntityData上有相应的字段,用于保存相关的实体状态信息,DTO上没有状态信息.	
		#endregion
		
		#region DTO Properties 
	
		

		/// <summary>
		/// Token串
		/// 服务TokenDTO.Misc.Token串
		/// </summary>
		private System.String m_tokenStr ;
		[DataMember(IsRequired=false)]
		public System.String TokenStr
		{
			get	
			{	
				return m_tokenStr ;
			}
			set	
			{	
				m_tokenStr = value ;	
			}
		}
			
		

		/// <summary>
		/// 企业ID
		/// 服务TokenDTO.Misc.企业ID
		/// </summary>
		private System.String m_enterpriseID ;
		[DataMember(IsRequired=false)]
		public System.String EnterpriseID
		{
			get	
			{	
				return m_enterpriseID ;
			}
			set	
			{	
				m_enterpriseID = value ;	
			}
		}
			
		

		/// <summary>
		/// 企业名称
		/// 服务TokenDTO.Misc.企业名称
		/// </summary>
		private System.String m_enterpriseName ;
		[DataMember(IsRequired=false)]
		public System.String EnterpriseName
		{
			get	
			{	
				return m_enterpriseName ;
			}
			set	
			{	
				m_enterpriseName = value ;	
			}
		}
			
		

		/// <summary>
		/// 用户ID
		/// 服务TokenDTO.Misc.用户ID
		/// </summary>
		private System.String m_userID ;
		[DataMember(IsRequired=false)]
		public System.String UserID
		{
			get	
			{	
				return m_userID ;
			}
			set	
			{	
				m_userID = value ;	
			}
		}
			
		

		/// <summary>
		/// 用户编码
		/// 服务TokenDTO.Misc.用户编码
		/// </summary>
		private System.String m_userCode ;
		[DataMember(IsRequired=false)]
		public System.String UserCode
		{
			get	
			{	
				return m_userCode ;
			}
			set	
			{	
				m_userCode = value ;	
			}
		}
			
		

		/// <summary>
		/// 用户名称
		/// 服务TokenDTO.Misc.用户名称
		/// </summary>
		private System.String m_userName ;
		[DataMember(IsRequired=false)]
		public System.String UserName
		{
			get	
			{	
				return m_userName ;
			}
			set	
			{	
				m_userName = value ;	
			}
		}
			
		

		/// <summary>
		/// 组织ID
		/// 服务TokenDTO.Misc.组织ID
		/// </summary>
		private System.String m_orgID ;
		[DataMember(IsRequired=false)]
		public System.String OrgID
		{
			get	
			{	
				return m_orgID ;
			}
			set	
			{	
				m_orgID = value ;	
			}
		}
			
		

		/// <summary>
		/// 组织编码
		/// 服务TokenDTO.Misc.组织编码
		/// </summary>
		private System.String m_orgCode ;
		[DataMember(IsRequired=false)]
		public System.String OrgCode
		{
			get	
			{	
				return m_orgCode ;
			}
			set	
			{	
				m_orgCode = value ;	
			}
		}
			
		

		/// <summary>
		/// 组织名称
		/// 服务TokenDTO.Misc.组织名称
		/// </summary>
		private System.String m_orgName ;
		[DataMember(IsRequired=false)]
		public System.String OrgName
		{
			get	
			{	
				return m_orgName ;
			}
			set	
			{	
				m_orgName = value ;	
			}
		}
			
		

		/// <summary>
		/// 创建时间
		/// 服务TokenDTO.Misc.创建时间
		/// </summary>
		private System.DateTime m_createTime ;
		[DataMember(IsRequired=false)]
		public System.DateTime CreateTime
		{
			get	
			{	
				return m_createTime ;
			}
			set	
			{	
				m_createTime = value ;	
			}
		}
			
		

		/// <summary>
		/// 最后更新时间
		/// 服务TokenDTO.Misc.最后更新时间
		/// </summary>
		private System.DateTime m_lastUpdateTime ;
		[DataMember(IsRequired=false)]
		public System.DateTime LastUpdateTime
		{
			get	
			{	
				return m_lastUpdateTime ;
			}
			set	
			{	
				m_lastUpdateTime = value ;	
			}
		}
			
		

		/// <summary>
		/// 语言
		/// 服务TokenDTO.Misc.语言
		/// </summary>
		private System.String m_culture ;
		[DataMember(IsRequired=false)]
		public System.String Culture
		{
			get	
			{	
				return m_culture ;
			}
			set	
			{	
				m_culture = value ;	
			}
		}
			
		

		/// <summary>
		/// 支持语言列表
		/// 服务TokenDTO.Misc.支持语言列表
		/// </summary>
		private System.String m_supportCultureNameList ;
		[DataMember(IsRequired=false)]
		public System.String SupportCultureNameList
		{
			get	
			{	
				return m_supportCultureNameList ;
			}
			set	
			{	
				m_supportCultureNameList = value ;	
			}
		}
			
		#endregion	

		#region Multi_Fields
																										
		#endregion 
	} 	
}
