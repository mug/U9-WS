



using System; 
using System.Collections;
using System.Collections.Generic ;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WSLogBP
{
	/// <summary>
	/// 请求结果DTO DTO :自定义的数据传输类型 
	/// 
	/// </summary>
	[DataContract(Name = "UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData", Namespace = "http://www.UFIDA.org/EntityData",IsReference=true)]
	[Serializable]
	[KnownType("GetKnownTypes")]
	public partial class RequestResultDTOData : UFSoft.UBF.Business.DataTransObjectBase
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
		public RequestResultDTOData()
		{
			initData();
		}
		private void initData()
		{
					WSLogID= 0; 
							CallResult= 0; 
				
		

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
		public RequestResultDTOData(  System.Int64 wSLogID  , System.Int32 callResult  , System.String responseContent  , System.String errorMessage  )
		{
			initData();
			this.WSLogID = wSLogID;
			this.CallResult = callResult;
			this.ResponseContent = responseContent;
			this.ErrorMessage = errorMessage;
		}
		#region System Fields 
		//--系统字段,目前没有.EntityData上有相应的字段,用于保存相关的实体状态信息,DTO上没有状态信息.	
		#endregion
		
		#region DTO Properties 
	
		

		/// <summary>
		/// 服务日志ID
		/// 请求结果DTO.Misc.服务日志ID
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Int64 m_wSLogID ;
		public System.Int64 WSLogID
		{
			get	
			{	
				return m_wSLogID ;
			}
			set	
			{	
				m_wSLogID = value ;	
			}
		}
			
		

		/// <summary>
		/// 调用结果
		/// 请求结果DTO.Misc.调用结果
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
		/// 返回消息
		/// 请求结果DTO.Misc.返回消息
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
		/// 错误信息
		/// 请求结果DTO.Misc.错误信息
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
			
		#endregion	

		#region Multi_Fields
								
		#endregion 
	} 	
}

	
