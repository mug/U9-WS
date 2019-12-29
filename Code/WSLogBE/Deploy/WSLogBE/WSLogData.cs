
	using System; 
	using System.Collections;
	using System.Collections.Generic ;
	using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WSLogBE
{
	/// <summary>
	/// 服务日志 缺省DTO 
	/// 
	/// </summary>
	[DataContract(Name = "UFIDA.U9.Cust.Pub.WSLogBE.WSLogData", Namespace = "http://www.UFIDA.org/EntityData",IsReference=true)]	
	[Serializable]
    [KnownType("GetKnownTypes")]
	public partial class WSLogData : UFSoft.UBF.Business.DataTransObjectBase
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
		public WSLogData()
		{
			initData() ;
		}
		private void initData()
		{
			//设置默认值
	     			
	     			
	     			
	     			
	     			
	     							SysVersion= 0; 			     			
	     			
	     			
	     			
	     			
	     							ElapsedSecond=0m; 
	     			
	     			
	     							CallResult= 0; 			     			
	     							CallCount= 0; 			     			
	     			


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
			get { return "UFIDA.U9.Cust.Pub.WSLogBE.WSLog" ;}
		}
		#endregion


		
		#region Properties Inner Component
	        					/// <summary>
		/// 调用结果
		/// 服务日志.Misc.调用结果
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Int32 m_callResult;
		public System.Int32 CallResult
		{
			get	
			{	
				return m_callResult ;
			}
			set	
			{	
				m_callResult = value ;
			}
		}		

			
		#endregion	

		#region Properties Outer Component
		
				/// <summary>
		/// ID
		/// 服务日志.Key.ID
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
		/// 服务日志.Sys.创建时间
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
		/// 服务日志.Sys.创建人
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
		/// 服务日志.Sys.修改时间
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
		/// 服务日志.Sys.修改人
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
		/// 服务日志.Sys.事务版本
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
		/// 请求地址
		/// 服务日志.Misc.请求地址
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_requestUrl ;
		public System.String RequestUrl
		{
			get	
			{	
				return m_requestUrl  ;
			}
			set	
			{	
				m_requestUrl = value ;	
			}
		}
		

				/// <summary>
		/// 类名
		/// 服务日志.Misc.类名
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_className ;
		public System.String ClassName
		{
			get	
			{	
				return m_className  ;
			}
			set	
			{	
				m_className = value ;	
			}
		}
		

				/// <summary>
		/// 方法名
		/// 服务日志.Misc.方法名
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_methodName ;
		public System.String MethodName
		{
			get	
			{	
				return m_methodName  ;
			}
			set	
			{	
				m_methodName = value ;	
			}
		}
		

				/// <summary>
		/// 开始时间
		/// 服务日志.Misc.开始时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_startTime ;
		public System.DateTime StartTime
		{
			get	
			{	
				return m_startTime  ;
			}
			set	
			{	
				m_startTime = value ;	
			}
		}
		

				/// <summary>
		/// 结束时间
		/// 服务日志.Misc.结束时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_endTime ;
		public System.DateTime EndTime
		{
			get	
			{	
				return m_endTime  ;
			}
			set	
			{	
				m_endTime = value ;	
			}
		}
		

				/// <summary>
		/// 历时(秒)
		/// 服务日志.Misc.历时(秒)
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_elapsedSecond ;
		public System.Decimal ElapsedSecond
		{
			get	
			{	
				return m_elapsedSecond  ;
			}
			set	
			{	
				m_elapsedSecond = value ;	
			}
		}
		

				/// <summary>
		/// 请求内容
		/// 服务日志.Misc.请求内容
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_requestContent ;
		public System.String RequestContent
		{
			get	
			{	
				return m_requestContent  ;
			}
			set	
			{	
				m_requestContent = value ;	
			}
		}
		

				/// <summary>
		/// 返回内容
		/// 服务日志.Misc.返回内容
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_responseContent ;
		public System.String ResponseContent
		{
			get	
			{	
				return m_responseContent  ;
			}
			set	
			{	
				m_responseContent = value ;	
			}
		}
		

				/// <summary>
		/// 错误信息
		/// 服务日志.Misc.错误信息
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_errorMessage ;
		public System.String ErrorMessage
		{
			get	
			{	
				return m_errorMessage  ;
			}
			set	
			{	
				m_errorMessage = value ;	
			}
		}
		

				/// <summary>
		/// 请求次数
		/// 服务日志.Misc.请求次数
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Int32 m_callCount ;
		public System.Int32 CallCount
		{
			get	
			{	
				return m_callCount  ;
			}
			set	
			{	
				m_callCount = value ;	
			}
		}
		

				/// <summary>
		/// 方法描述
		/// 服务日志.Misc.方法描述
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_methodDescription ;
		public System.String MethodDescription
		{
			get	
			{	
				return m_methodDescription  ;
			}
			set	
			{	
				m_methodDescription = value ;	
			}
		}
		

				/// <summary>
		/// 企业ID
		/// 服务日志.Misc.企业ID
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
		
		#endregion	

		#region Multi_Fields
																			
		#endregion 		
	}	

}

