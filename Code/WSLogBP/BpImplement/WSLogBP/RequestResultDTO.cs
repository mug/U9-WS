


using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WSLogBP
{
	/// <summary>
	/// 请求结果DTO DTO :自定义的数据传输类型 
	/// 
	/// </summary>
	public  partial class RequestResultDTO  : UFSoft.UBF.Business.DTOBase
	{
		#region Constructor
		
		/// <summary>
		/// Constructor
		/// </summary>
		public RequestResultDTO(){
			initData();
		}
		private void initData()
		{
					WSLogID = 0; 
					CallResult =UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum.GetFromValue(0); 
		
		

		}

		#endregion
		
		#region Properties
			/// <summary>
		/// 服务日志ID (该属性可为空,但有默认值)
		/// 请求结果DTO.Misc.服务日志ID
		/// </summary>
		/// <value>System.Int64</value>
		public System.Int64 WSLogID
		{
			get	
			{	
				return (System.Int64)base.GetValue("WSLogID",typeof(System.Int64));
			}

			 set	
			{
				base.SetValue("WSLogID",value);
			}
		}
				/// <summary>
		/// 调用结果 (该属性可为空,但有默认值)
		/// 请求结果DTO.Misc.调用结果
		/// </summary>
		/// <value>UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum</value>
		public UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum CallResult
		{
			get	
			{	
				return (UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum)base.GetValue("CallResult",typeof(UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum));
			}

			 set	
			{
				base.SetValue("CallResult",value);
			}
		}
				/// <summary>
		/// 返回消息 (该属性可为空,且无默认值)
		/// 请求结果DTO.Misc.返回消息
		/// </summary>
		/// <value>System.String</value>
		public System.String ResponseContent
		{
			get	
			{	
				return (System.String)base.GetValue("ResponseContent",typeof(System.String));
			}

			 set	
			{
				base.SetValue("ResponseContent",value);
			}
		}
				/// <summary>
		/// 错误信息 (该属性可为空,且无默认值)
		/// 请求结果DTO.Misc.错误信息
		/// </summary>
		/// <value>System.String</value>
		public System.String ErrorMessage
		{
			get	
			{	
				return (System.String)base.GetValue("ErrorMessage",typeof(System.String));
			}

			 set	
			{
				base.SetValue("ErrorMessage",value);
			}
		}
		
		#endregion	
		#region Multi_Fields
				
		#endregion 

		#region ModelResource
		/// <summary>
		/// 请求结果DTO的显示名称资源--已经废弃，不使用.
		/// </summary>
		public string Res_TypeName {	get {return "" ;}	}
		/// <summary>
		/// 服务日志ID的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_WSLogID　{ get { return "";　}　}
		/// <summary>
		/// 调用结果的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_CallResult　{ get { return "";　}　}
		/// <summary>
		/// 返回消息的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_ResponseContent　{ get { return "";　}　}
		/// <summary>
		/// 错误信息的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_ErrorMessage　{ get { return "";　}　}
		#endregion 




		#region EntityData exchange
		
		#region  Do SerializeKey -ForDTOType
		//反序化Key到Data的ID中　－－由FromEntityData自动调用，不处理层次关系
		private void DeSerializeKey(RequestResultDTOData data)
		{
		




		}

		#endregion 
		
		/// <summary>
		/// Copy Entity From EntityData
		/// </summary>
		public void FromEntityData(RequestResultDTOData data)
		{
			this.FromEntityData(data,new Hashtable());
		}
		//used by ubf..
		public void FromEntityData(RequestResultDTOData data,IDictionary dict)
		{
			if (data == null)
				return;
			if (dict == null ) dict = new Hashtable() ;
			dict[data] = this;
			DeSerializeKey(data);
		
			this.WSLogID = data.WSLogID;

			this.CallResult = UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum.GetFromValue(data.CallResult);

			this.ResponseContent = data.ResponseContent;

			this.ErrorMessage = data.ErrorMessage;

		}

		/// <summary>
		/// Create EntityData From Entity
		/// </summary>
		public RequestResultDTOData ToEntityData()
		{
			return ToEntityData(null,new Hashtable());
		}
		/// <summary>
		/// Create EntityData From Entity - used by ubf 
		/// </summary>
		public RequestResultDTOData ToEntityData(RequestResultDTOData data, IDictionary dict){
			if (data == null)
				data = new RequestResultDTOData();
			if (dict == null ) 
				dict = new Hashtable() ;
			else
            {
                if (dict.Contains(this))
                {
                    data = (RequestResultDTOData)dict[this];
                    return data;
                }
            }
			dict[this] = data;
		
			data.WSLogID = this.WSLogID;

			if (this.CallResult!=null)
			{
				data.CallResult = this.CallResult.Value;
			}

			data.ResponseContent = this.ResponseContent;

			data.ErrorMessage = this.ErrorMessage;

			return data ;
		}

		#endregion	
	}	
	
}