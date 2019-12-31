
	using System; 
	using System.Collections;
	using System.Collections.Generic ;
	using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenBE
{
	/// <summary>
	/// 服务Token 缺省DTO 
	/// 
	/// </summary>
	[DataContract(Name = "UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSTokenData", Namespace = "http://www.UFIDA.org/EntityData",IsReference=true)]	
	[Serializable]
    [KnownType("GetKnownTypes")]
	public partial class WSTokenData : UFSoft.UBF.Business.DataTransObjectBase
	{

	    public static IList<Type> GetKnownTypes()
        {
            IList<Type> knownTypes = new List<Type>();
            
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
            
                knownTypes.Add(typeof(UFSoft.UBF.Util.Data.MultiLangDataDict));
            return knownTypes;
        }
		/// <summary>
		/// Default Constructor
		/// </summary>
		public WSTokenData()
		{
			initData() ;
		}
		private void initData()
		{
			//设置默认值
	     			
	     			
	     			
	     			
	     			
	     							SysVersion= 0; 			     			
	     			
	     			
	     			
	     			
	     			
	     							IsAlive=false; 
	     			
	     			
	     			
	     			
	     			
	     			
	     			
	     			


			//设置组合的集合属性为List<>对象. -目前直接在属性上处理.
			
			//调用默认值初始化服务进行配置方式初始化
			UFSoft.UBF.Service.DTOService.InitConfigDefault(this);
		}		
		[System.Runtime.Serialization.OnDeserializing]
        internal void OnDeserializing(System.Runtime.Serialization.StreamingContext context)
        {
			 initData();
        }
        
		#region System Fields
		///<summary>
		/// 实体类型. 
		/// </summary>
		[DataMember(IsRequired=false)]
		public override string SysEntityType
		{
			get { return "UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken" ;}
		}
		#endregion


		
		#region Properties Inner Component
	
		#endregion	

		#region Properties Outer Component
		
				/// <summary>
		/// ID
		/// 服务Token.Key.ID
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Int64 m_iD ;
		public System.Int64 ID
		{
			get	
			{	
				return m_iD  ;
			}
			set	
			{	
				m_iD = value ;	
			}
		}
		

				/// <summary>
		/// 创建时间
		/// 服务Token.Sys.创建时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_createdOn ;
		public System.DateTime CreatedOn
		{
			get	
			{	
				return m_createdOn  ;
			}
			set	
			{	
				m_createdOn = value ;	
			}
		}
		

				/// <summary>
		/// 创建人
		/// 服务Token.Sys.创建人
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_createdBy ;
		public System.String CreatedBy
		{
			get	
			{	
				return m_createdBy  ;
			}
			set	
			{	
				m_createdBy = value ;	
			}
		}
		

				/// <summary>
		/// 修改时间
		/// 服务Token.Sys.修改时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_modifiedOn ;
		public System.DateTime ModifiedOn
		{
			get	
			{	
				return m_modifiedOn  ;
			}
			set	
			{	
				m_modifiedOn = value ;	
			}
		}
		

				/// <summary>
		/// 修改人
		/// 服务Token.Sys.修改人
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_modifiedBy ;
		public System.String ModifiedBy
		{
			get	
			{	
				return m_modifiedBy  ;
			}
			set	
			{	
				m_modifiedBy = value ;	
			}
		}
		

				/// <summary>
		/// 事务版本
		/// 服务Token.Sys.事务版本
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Int64 m_sysVersion ;
		public System.Int64 SysVersion
		{
			get	
			{	
				return m_sysVersion  ;
			}
			set	
			{	
				m_sysVersion = value ;	
			}
		}
		

				/// <summary>
		/// Token串
		/// 服务Token.Misc.Token串
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_tokenStr ;
		public System.String TokenStr
		{
			get	
			{	
				return m_tokenStr  ;
			}
			set	
			{	
				m_tokenStr = value ;	
			}
		}
		

				/// <summary>
		/// 用户编码
		/// 服务Token.Misc.用户编码
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_userCode ;
		public System.String UserCode
		{
			get	
			{	
				return m_userCode  ;
			}
			set	
			{	
				m_userCode = value ;	
			}
		}
		

				/// <summary>
		/// 用户名称
		/// 服务Token.Misc.用户名称
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_userName ;
		public System.String UserName
		{
			get	
			{	
				return m_userName  ;
			}
			set	
			{	
				m_userName = value ;	
			}
		}
		

				/// <summary>
		/// 组织编码
		/// 服务Token.Misc.组织编码
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_orgCode ;
		public System.String OrgCode
		{
			get	
			{	
				return m_orgCode  ;
			}
			set	
			{	
				m_orgCode = value ;	
			}
		}
		

				/// <summary>
		/// 组织名称
		/// 服务Token.Misc.组织名称
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_orgName ;
		public System.String OrgName
		{
			get	
			{	
				return m_orgName  ;
			}
			set	
			{	
				m_orgName = value ;	
			}
		}
		

				/// <summary>
		/// 最后更新时间
		/// 服务Token.Misc.最后更新时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_lastUpdateTime ;
		public System.DateTime LastUpdateTime
		{
			get	
			{	
				return m_lastUpdateTime  ;
			}
			set	
			{	
				m_lastUpdateTime = value ;	
			}
		}
		

				/// <summary>
		/// 活动
		/// 服务Token.Misc.活动
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Boolean m_isAlive ;
		public System.Boolean IsAlive
		{
			get	
			{	
				return m_isAlive  ;
			}
			set	
			{	
				m_isAlive = value ;	
			}
		}
		

				/// <summary>
		/// 失效时间
		/// 服务Token.Misc.失效时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_invalidTime ;
		public System.DateTime InvalidTime
		{
			get	
			{	
				return m_invalidTime  ;
			}
			set	
			{	
				m_invalidTime = value ;	
			}
		}
		

				/// <summary>
		/// 用户ID
		/// 服务Token.Misc.用户ID
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_userID ;
		public System.String UserID
		{
			get	
			{	
				return m_userID  ;
			}
			set	
			{	
				m_userID = value ;	
			}
		}
		

				/// <summary>
		/// 组织ID
		/// 服务Token.Misc.组织ID
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_orgID ;
		public System.String OrgID
		{
			get	
			{	
				return m_orgID  ;
			}
			set	
			{	
				m_orgID = value ;	
			}
		}
		

				/// <summary>
		/// 企业ID
		/// 服务Token.Misc.企业ID
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_enterpriseID ;
		public System.String EnterpriseID
		{
			get	
			{	
				return m_enterpriseID  ;
			}
			set	
			{	
				m_enterpriseID = value ;	
			}
		}
		

				/// <summary>
		/// 企业名称
		/// 服务Token.Misc.企业名称
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_enterpriseName ;
		public System.String EnterpriseName
		{
			get	
			{	
				return m_enterpriseName  ;
			}
			set	
			{	
				m_enterpriseName = value ;	
			}
		}
		

				/// <summary>
		/// 创建时间
		/// 服务Token.Misc.创建时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_createTime ;
		public System.DateTime CreateTime
		{
			get	
			{	
				return m_createTime  ;
			}
			set	
			{	
				m_createTime = value ;	
			}
		}
		

				/// <summary>
		/// 语言
		/// 服务Token.Misc.语言
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_culture ;
		public System.String Culture
		{
			get	
			{	
				return m_culture  ;
			}
			set	
			{	
				m_culture = value ;	
			}
		}
		

				/// <summary>
		/// 支持语言列表
		/// 服务Token.Misc.支持语言列表
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_supportCultureNameList ;
		public System.String SupportCultureNameList
		{
			get	
			{	
				return m_supportCultureNameList  ;
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

