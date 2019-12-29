


using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WSLogSV
{
	/// <summary>
	/// 服务日志DTO DTO :自定义的数据传输类型 
	/// 
	/// </summary>
	public  partial class WSLogDTO  : UFSoft.UBF.Business.DTOBase
	{
		#region Constructor
		
		/// <summary>
		/// Constructor
		/// </summary>
		public WSLogDTO(){
			initData();
		}
		private void initData()
		{
		
		
		
		
		
					ElapsedSecond = 0m; 
		
		
					CallResult =UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum.GetFromValue(0); 
		
					LogID = 0; 
		

		}

		#endregion
		
		#region Properties
			/// <summary>
		/// 请求地址 (该属性可为空,且无默认值)
		/// 服务日志DTO.Misc.请求地址
		/// </summary>
		/// <value>System.String</value>
		public System.String RequestUrl
		{
			get	
			{	
				return (System.String)base.GetValue("RequestUrl",typeof(System.String));
			}

			 set	
			{
				base.SetValue("RequestUrl",value);
			}
		}
				/// <summary>
		/// 类名 (该属性可为空,且无默认值)
		/// 服务日志DTO.Misc.类名
		/// </summary>
		/// <value>System.String</value>
		public System.String ClassName
		{
			get	
			{	
				return (System.String)base.GetValue("ClassName",typeof(System.String));
			}

			 set	
			{
				base.SetValue("ClassName",value);
			}
		}
				/// <summary>
		/// 方法名 (该属性可为空,且无默认值)
		/// 服务日志DTO.Misc.方法名
		/// </summary>
		/// <value>System.String</value>
		public System.String MethodName
		{
			get	
			{	
				return (System.String)base.GetValue("MethodName",typeof(System.String));
			}

			 set	
			{
				base.SetValue("MethodName",value);
			}
		}
				/// <summary>
		/// 开始时间 (该属性可为空,且无默认值)
		/// 服务日志DTO.Misc.开始时间
		/// </summary>
		/// <value>System.DateTime</value>
		public System.DateTime StartTime
		{
			get	
			{	
				return (System.DateTime)base.GetValue("StartTime",typeof(System.DateTime));
			}

			 set	
			{
				base.SetValue("StartTime",value);
			}
		}
				/// <summary>
		/// 结束时间 (该属性可为空,且无默认值)
		/// 服务日志DTO.Misc.结束时间
		/// </summary>
		/// <value>System.DateTime</value>
		public System.DateTime EndTime
		{
			get	
			{	
				return (System.DateTime)base.GetValue("EndTime",typeof(System.DateTime));
			}

			 set	
			{
				base.SetValue("EndTime",value);
			}
		}
				/// <summary>
		/// 历时(秒) (该属性可为空,但有默认值)
		/// 服务日志DTO.Misc.历时(秒)
		/// </summary>
		/// <value>System.Decimal</value>
		public System.Decimal ElapsedSecond
		{
			get	
			{	
				return (System.Decimal)base.GetValue("ElapsedSecond",typeof(System.Decimal));
			}

			 set	
			{
				base.SetValue("ElapsedSecond",value);
			}
		}
				/// <summary>
		/// 请求内容 (该属性可为空,且无默认值)
		/// 服务日志DTO.Misc.请求内容
		/// </summary>
		/// <value>System.String</value>
		public System.String RequestContent
		{
			get	
			{	
				return (System.String)base.GetValue("RequestContent",typeof(System.String));
			}

			 set	
			{
				base.SetValue("RequestContent",value);
			}
		}
				/// <summary>
		/// 返回内容 (该属性可为空,且无默认值)
		/// 服务日志DTO.Misc.返回内容
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
		/// 调用结果 (该属性可为空,但有默认值)
		/// 服务日志DTO.Misc.调用结果
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
		/// 错误信息 (该属性可为空,且无默认值)
		/// 服务日志DTO.Misc.错误信息
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
				/// <summary>
		/// 日志ID (该属性可为空,但有默认值)
		/// 服务日志DTO.Misc.日志ID
		/// </summary>
		/// <value>System.Int64</value>
		public System.Int64 LogID
		{
			get	
			{	
				return (System.Int64)base.GetValue("LogID",typeof(System.Int64));
			}

			 set	
			{
				base.SetValue("LogID",value);
			}
		}
				/// <summary>
		/// 方法描述 (该属性可为空,且无默认值)
		/// 服务日志DTO.Misc.方法描述
		/// </summary>
		/// <value>System.String</value>
		public System.String MethodDescription
		{
			get	
			{	
				return (System.String)base.GetValue("MethodDescription",typeof(System.String));
			}

			 set	
			{
				base.SetValue("MethodDescription",value);
			}
		}
		
		#endregion	
		#region Multi_Fields
												
		#endregion 

		#region ModelResource
		/// <summary>
		/// 服务日志DTO的显示名称资源--已经废弃，不使用.
		/// </summary>
		public string Res_TypeName {	get {return "" ;}	}
		/// <summary>
		/// 请求地址的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_RequestUrl　{ get { return "";　}　}
		/// <summary>
		/// 类名的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_ClassName　{ get { return "";　}　}
		/// <summary>
		/// 方法名的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_MethodName　{ get { return "";　}　}
		/// <summary>
		/// 开始时间的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_StartTime　{ get { return "";　}　}
		/// <summary>
		/// 结束时间的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_EndTime　{ get { return "";　}　}
		/// <summary>
		/// 历时(秒)的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_ElapsedSecond　{ get { return "";　}　}
		/// <summary>
		/// 请求内容的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_RequestContent　{ get { return "";　}　}
		/// <summary>
		/// 返回内容的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_ResponseContent　{ get { return "";　}　}
		/// <summary>
		/// 调用结果的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_CallResult　{ get { return "";　}　}
		/// <summary>
		/// 错误信息的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_ErrorMessage　{ get { return "";　}　}
		/// <summary>
		/// 日志ID的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_LogID　{ get { return "";　}　}
		/// <summary>
		/// 方法描述的显示名称资源 -- 已经废弃，不使用.
		/// </summary>
		public string Res_MethodDescription　{ get { return "";　}　}
		#endregion 




		#region EntityData exchange
		
		#region  Do SerializeKey -ForDTOType
		//反序化Key到Data的ID中　－－由FromEntityData自动调用，不处理层次关系
		private void DeSerializeKey(WSLogDTOData data)
		{
		












		}

		#endregion 
		
		/// <summary>
		/// Copy Entity From EntityData
		/// </summary>
		public void FromEntityData(WSLogDTOData data)
		{
			this.FromEntityData(data,new Hashtable());
		}
		//used by ubf..
		public void FromEntityData(WSLogDTOData data,IDictionary dict)
		{
			if (data == null)
				return;
			if (dict == null ) dict = new Hashtable() ;
			dict[data] = this;
			DeSerializeKey(data);
		
			this.RequestUrl = data.RequestUrl;

			this.ClassName = data.ClassName;

			this.MethodName = data.MethodName;

			this.StartTime = data.StartTime;

			this.EndTime = data.EndTime;

			this.ElapsedSecond = data.ElapsedSecond;

			this.RequestContent = data.RequestContent;

			this.ResponseContent = data.ResponseContent;

			this.CallResult = UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum.GetFromValue(data.CallResult);

			this.ErrorMessage = data.ErrorMessage;

			this.LogID = data.LogID;

			this.MethodDescription = data.MethodDescription;

		}

		/// <summary>
		/// Create EntityData From Entity
		/// </summary>
		public WSLogDTOData ToEntityData()
		{
			return ToEntityData(null,new Hashtable());
		}
		/// <summary>
		/// Create EntityData From Entity - used by ubf 
		/// </summary>
		public WSLogDTOData ToEntityData(WSLogDTOData data, IDictionary dict){
			if (data == null)
				data = new WSLogDTOData();
			if (dict == null ) 
				dict = new Hashtable() ;
			else
            {
                if (dict.Contains(this))
                {
                    data = (WSLogDTOData)dict[this];
                    return data;
                }
            }
			dict[this] = data;
		
			data.RequestUrl = this.RequestUrl;

			data.ClassName = this.ClassName;

			data.MethodName = this.MethodName;

			data.StartTime = this.StartTime;

			data.EndTime = this.EndTime;

			data.ElapsedSecond = this.ElapsedSecond;

			data.RequestContent = this.RequestContent;

			data.ResponseContent = this.ResponseContent;

			if (this.CallResult!=null)
			{
				data.CallResult = this.CallResult.Value;
			}

			data.ErrorMessage = this.ErrorMessage;

			data.LogID = this.LogID;

			data.MethodDescription = this.MethodDescription;

			return data ;
		}

		#endregion	
	}	
	
}