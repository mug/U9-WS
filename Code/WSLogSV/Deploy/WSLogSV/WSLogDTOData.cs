



using System; 
using System.Collections;
using System.Collections.Generic ;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WSLogSV
{
	/// <summary>
	/// 服务日志DTO DTO :自定义的数据传输类型 
	/// 
	/// </summary>
	[DataContract(Name = "UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTOData", Namespace = "http://www.UFIDA.org/EntityData",IsReference=true)]
	[Serializable]
	[KnownType("GetKnownTypes")]
	public partial class WSLogDTOData : UFSoft.UBF.Business.DataTransObjectBase
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
		public WSLogDTOData()
		{
			initData();
		}
		private void initData()
		{
		
		
		
		
		
					ElapsedSecond=0m; 
		
		
					CallResult= 0; 
				
					LogID= 0; 
				

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
		public WSLogDTOData(  System.String requestUrl  , System.String className  , System.String methodName  , System.DateTime startTime  , System.DateTime endTime  , System.Decimal elapsedSecond  , System.String requestContent  , System.String responseContent  , System.Int32 callResult  , System.String errorMessage  , System.Int64 logID  , System.String methodDescription  )
		{
			initData();
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
		#region System Fields 
		//--系统字段,目前没有.EntityData上有相应的字段,用于保存相关的实体状态信息,DTO上没有状态信息.	
		#endregion
		
		#region DTO Properties 
	
		

		/// <summary>
		/// 请求地址
		/// 服务日志DTO.Misc.请求地址
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_requestUrl ;
		public System.String RequestUrl
		{
			get	
			{	
				return m_requestUrl ;
			}
			set	
			{	
				m_requestUrl = value ;	
			}
		}
			
		

		/// <summary>
		/// 类名
		/// 服务日志DTO.Misc.类名
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_className ;
		public System.String ClassName
		{
			get	
			{	
				return m_className ;
			}
			set	
			{	
				m_className = value ;	
			}
		}
			
		

		/// <summary>
		/// 方法名
		/// 服务日志DTO.Misc.方法名
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_methodName ;
		public System.String MethodName
		{
			get	
			{	
				return m_methodName ;
			}
			set	
			{	
				m_methodName = value ;	
			}
		}
			
		

		/// <summary>
		/// 开始时间
		/// 服务日志DTO.Misc.开始时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_startTime ;
		public System.DateTime StartTime
		{
			get	
			{	
				return m_startTime ;
			}
			set	
			{	
				m_startTime = value ;	
			}
		}
			
		

		/// <summary>
		/// 结束时间
		/// 服务日志DTO.Misc.结束时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_endTime ;
		public System.DateTime EndTime
		{
			get	
			{	
				return m_endTime ;
			}
			set	
			{	
				m_endTime = value ;	
			}
		}
			
		

		/// <summary>
		/// 历时(秒)
		/// 服务日志DTO.Misc.历时(秒)
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_elapsedSecond ;
		public System.Decimal ElapsedSecond
		{
			get	
			{	
				return m_elapsedSecond ;
			}
			set	
			{	
				m_elapsedSecond = value ;	
			}
		}
			
		

		/// <summary>
		/// 请求内容
		/// 服务日志DTO.Misc.请求内容
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_requestContent ;
		public System.String RequestContent
		{
			get	
			{	
				return m_requestContent ;
			}
			set	
			{	
				m_requestContent = value ;	
			}
		}
			
		

		/// <summary>
		/// 返回内容
		/// 服务日志DTO.Misc.返回内容
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_responseContent ;
		public System.String ResponseContent
		{
			get	
			{	
				return m_responseContent ;
			}
			set	
			{	
				m_responseContent = value ;	
			}
		}
			
		

		/// <summary>
		/// 调用结果
		/// 服务日志DTO.Misc.调用结果
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Int32 m_callResult ;
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
			
		

		/// <summary>
		/// 错误信息
		/// 服务日志DTO.Misc.错误信息
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_errorMessage ;
		public System.String ErrorMessage
		{
			get	
			{	
				return m_errorMessage ;
			}
			set	
			{	
				m_errorMessage = value ;	
			}
		}
			
		

		/// <summary>
		/// 日志ID
		/// 服务日志DTO.Misc.日志ID
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Int64 m_logID ;
		public System.Int64 LogID
		{
			get	
			{	
				return m_logID ;
			}
			set	
			{	
				m_logID = value ;	
			}
		}
			
		

		/// <summary>
		/// 方法描述
		/// 服务日志DTO.Misc.方法描述
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_methodDescription ;
		public System.String MethodDescription
		{
			get	
			{	
				return m_methodDescription ;
			}
			set	
			{	
				m_methodDescription = value ;	
			}
		}
			
		#endregion	

		#region Multi_Fields
																								
		#endregion 
	} 	
}

	
