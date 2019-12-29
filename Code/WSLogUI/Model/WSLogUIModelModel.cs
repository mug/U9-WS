#region Using directives

using System;
using System.Collections;
using System.Data;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.MD.Runtime.Implement;

#endregion

namespace WSLogUIModel
{
	[Serializable]
	public partial class WSLogUIModelModel : UIModel
	{
		#region Constructor
		public WSLogUIModelModel() : base("WSLogUIModel")
		{
			InitClass();
			this.SetResourceInfo("9f73e563-4e8f-4099-a299-beceb1d99fe5");
            try{
			    AfterInitModel();
            }catch(Exception exception){
              IUIModel model = this;
		      this.ErrorMessage.SetErrorMessage(ref model,exception);
			}
		}

		//just for Clone 
		private WSLogUIModelModel(bool isInit) : base("WSLogUIModel")
		{}
		protected override IUIModel CreateCloneInstance()
		{
			return new WSLogUIModelModel(false);
		}
		#endregion
		#region member
		#region views
		private WSLogView viewWSLog;			
		#endregion
		
		#region links
		#endregion
		
		#region properties
		#endregion
		#endregion

		#region property
		public WSLogView WSLog
		{
			get { return (WSLogView)this["WSLog"]; }
		}
		
		#region RealViews
		#endregion
		
	
		#endregion

		#region function
		private void InitClass()
		{
			this.viewWSLog = new WSLogView(this);
			this.viewWSLog.SetResourceInfo("b52b9031-541b-4d01-869c-aa5b07cc6d5b");
			this.Views.Add(this.viewWSLog);			

			
		}

		public override string AssemblyName
		{
			get { return "UFIDA.U9.Cust.Pub.WSLogUI"; }
		}
		
		#endregion
		private void OnValidate_DefualtImpl()
    {
    }

	}


	[Serializable]
	public partial class WSLogView : UIView
	{
		#region Constructor
		public WSLogView(IUIModel model) : base(model,"WSLog","UFIDA.U9.Cust.Pub.WSLogBE.WSLog", true)
		{
			InitClass();
		}
		//构造空实例,不进行初始化.目前为Clone使用.
		private WSLogView():base(null,"WSLog","UFIDA.U9.Cust.Pub.WSLogBE.WSLog", true)
		{
		}
		protected override IUIView CreateCloneInstance()
		{
			return new WSLogView();
		}
		#endregion

		#region fiels property filter
		public IUIField FieldID
		{
			get { return this.Fields["ID"]; }
		}
		public IUIField FieldCreatedOn
		{
			get { return this.Fields["CreatedOn"]; }
		}
		public IUIField FieldCreatedBy
		{
			get { return this.Fields["CreatedBy"]; }
		}
		public IUIField FieldModifiedOn
		{
			get { return this.Fields["ModifiedOn"]; }
		}
		public IUIField FieldModifiedBy
		{
			get { return this.Fields["ModifiedBy"]; }
		}
		public IUIField FieldSysVersion
		{
			get { return this.Fields["SysVersion"]; }
		}
		public IUIField FieldRequestUrl
		{
			get { return this.Fields["RequestUrl"]; }
		}
		public IUIField FieldClassName
		{
			get { return this.Fields["ClassName"]; }
		}
		public IUIField FieldMethodName
		{
			get { return this.Fields["MethodName"]; }
		}
		public IUIField FieldStartTime
		{
			get { return this.Fields["StartTime"]; }
		}
		public IUIField FieldEndTime
		{
			get { return this.Fields["EndTime"]; }
		}
		public IUIField FieldElapsedSecond
		{
			get { return this.Fields["ElapsedSecond"]; }
		}
		public IUIField FieldRequestContent
		{
			get { return this.Fields["RequestContent"]; }
		}
		public IUIField FieldResponseContent
		{
			get { return this.Fields["ResponseContent"]; }
		}
		public IUIField FieldCallResult
		{
			get { return this.Fields["CallResult"]; }
		}
		public IUIField FieldErrorMessage
		{
			get { return this.Fields["ErrorMessage"]; }
		}
		public IUIField FieldCallCount
		{
			get { return this.Fields["CallCount"]; }
		}
		public IUIField FieldMethodDescription
		{
			get { return this.Fields["MethodDescription"]; }
		}
		public IUIField FieldRequestContentView
		{
			get { return this.Fields["RequestContentView"]; }
		}
		public IUIField FieldResponseContentView
		{
			get { return this.Fields["ResponseContentView"]; }
		}


		[Obsolete("请使用CurrentFilter属性，这个方法有可能会导致强弱类型转换出错")]
		public WSLogDefaultFilterFilter DefaultFilter
		{
			get { return (WSLogDefaultFilterFilter)this.CurrentFilter; }
		}
		#endregion

		#region Init
		private void InitClass()
		{
			UIModelRuntimeFactory.AddNewUIField(this,"ID", typeof(Int64), false,"","System.Int64", "ID", true,true, false, "",false,(UIFieldType)1,"ba391065-6c27-4c82-acc8-b52b1c93a910","ce361e30-ea37-4d65-89a7-4cde4454e29d");
			UIModelRuntimeFactory.AddNewUIField(this,"CreatedOn", typeof(DateTime), true,"","System.DateTime", "CreatedOn", true,true, false, "",false,(UIFieldType)1,"3834a958-120f-4ac9-8d60-1a7be6d3f12f","2591458e-d2a8-4816-b9fb-f2ddf1448084");
			UIModelRuntimeFactory.AddNewUIField(this,"CreatedBy", typeof(String), true,"","System.String", "CreatedBy", true,true, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","41a99b21-5c91-492f-9223-f107555a3fec");
			UIModelRuntimeFactory.AddNewUIField(this,"ModifiedOn", typeof(DateTime), true,"","System.DateTime", "ModifiedOn", true,true, false, "",false,(UIFieldType)1,"3834a958-120f-4ac9-8d60-1a7be6d3f12f","ed13e543-6e77-4e4e-960e-d8fff0ea0341");
			UIModelRuntimeFactory.AddNewUIField(this,"ModifiedBy", typeof(String), true,"","System.String", "ModifiedBy", true,true, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","138f75bc-d515-46bb-ac60-6ccc5df56afe");
			UIModelRuntimeFactory.AddNewUIField(this,"SysVersion", typeof(Int64), true,"0","System.Int64", "SysVersion", true,true, false, "",false,(UIFieldType)1,"ba391065-6c27-4c82-acc8-b52b1c93a910","deea45c5-810b-48a7-8dc4-fa130ce73181");
			UIModelRuntimeFactory.AddNewUIField(this,"RequestUrl", typeof(String), true,"","System.String", "RequestUrl", true,true, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","741c99b1-e180-4c83-9ec4-7c74342f3a0b");
			UIModelRuntimeFactory.AddNewUIField(this,"ClassName", typeof(String), true,"","System.String", "ClassName", true,true, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","dccc20ef-b198-4b11-9015-d0e5c06e423a");
			UIModelRuntimeFactory.AddNewUIField(this,"MethodName", typeof(String), true,"","System.String", "MethodName", true,true, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","3e45084e-3a4c-4856-93d5-53966c9d5077");
			UIModelRuntimeFactory.AddNewUIField(this,"StartTime", typeof(DateTime), true,"","System.DateTime", "StartTime", true,true, false, "",false,(UIFieldType)1,"3834a958-120f-4ac9-8d60-1a7be6d3f12f","8f5db037-3cc2-4077-a3b2-85c148b8ea7a");
			UIModelRuntimeFactory.AddNewUIField(this,"EndTime", typeof(DateTime), true,"","System.DateTime", "EndTime", true,true, false, "",false,(UIFieldType)1,"3834a958-120f-4ac9-8d60-1a7be6d3f12f","7f743bc2-ffe1-456f-af0b-29b5c740a09d");
			UIModelRuntimeFactory.AddNewUIField(this,"ElapsedSecond", typeof(Decimal), true,"0","System.Decimal", "ElapsedSecond", true,true, false, "",false,(UIFieldType)1,"91031687-94bb-4988-a939-df7bf999ef4f","02b4e5a8-81bc-4b21-ae82-dbdc93c87522");
			UIModelRuntimeFactory.AddNewUIField(this,"RequestContent", typeof(String), true,"","System.String", "RequestContent", true,true, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","e3a8b83b-3c81-4290-baaf-7cf4b7ad7dd0");
			UIModelRuntimeFactory.AddNewUIField(this,"ResponseContent", typeof(String), true,"","System.String", "ResponseContent", true,true, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","7828ad2c-e974-4086-b1e3-4a638a91689c");
			UIModelRuntimeFactory.AddNewUIField(this,"CallResult", typeof(Int32), true,"0","UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum", "CallResult", true,true, false, "",false,(UIFieldType)2,"128c6abf-abe7-4c50-aed1-6fdf20e32110","12787766-dae4-4889-b322-897aa034a937");
			UIModelRuntimeFactory.AddNewUIField(this,"ErrorMessage", typeof(String), true,"","System.String", "ErrorMessage", true,true, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","6b95fd3e-78ad-4bd3-80c3-7133cc179349");
			UIModelRuntimeFactory.AddNewUIField(this,"CallCount", typeof(Int32), true,"0","System.Int32", "CallCount", true,true, false, "",false,(UIFieldType)1,"d7c6031e-d3fe-41aa-a397-5edd86c10cae","c1f059d4-17e6-481a-bb41-b2aaed45a759");
			UIModelRuntimeFactory.AddNewUIField(this,"MethodDescription", typeof(String), true,"","System.String", "MethodDescription", true,true, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","79ba63c9-5a55-41f6-8086-44807bb3825e");
			UIModelRuntimeFactory.AddNewUIField(this,"RequestContentView", typeof(String), true,"","System.String", "", false,false, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","aefa9c08-db62-49b6-af0f-ded717af25cd");
			UIModelRuntimeFactory.AddNewUIField(this,"ResponseContentView", typeof(String), true,"","System.String", "", false,false, false, "",false,(UIFieldType)1,"3d174255-fd12-47f7-8844-3b5e4fae9e8c","d64ca7ce-1baf-4b1c-892b-16d1232b7f66");


			this.CurrentFilter = new WSLogDefaultFilterFilter(this);
		}
		#endregion
		
		#region override method
		protected override IUIRecord BuildNewRecord(IUIRecordBuilder builder)
		{
			return new WSLogRecord(builder);
		}
		#endregion

		#region new method
		public new WSLogRecord FocusedRecord
		{
			get { return (WSLogRecord)base.FocusedRecord ; }
			set { base.FocusedRecord = value ; }
		}
		public new WSLogRecord AddNewUIRecord()
		{	
			return (WSLogRecord)base.AddNewUIRecord();
		}
		public new WSLogRecord NewUIRecord()
		{	
			return (WSLogRecord)base.NewUIRecord();
		}
		#endregion 

	}

	[Serializable]
	public class WSLogRecord : UIRecord
	{
		#region Constructor
		public WSLogRecord(IUIRecordBuilder builder):base(builder)
		{
		}
		private WSLogView uiviewWSLog
		{
			get { return (WSLogView)this.ContainerView; }
		}
		protected override IUIRecord CreateCloneInstance(IUIRecordBuilder builder)
		{
			return new WSLogRecord(builder);
		}
		#endregion

		#region property
		
		
		public  Int64 ID
		{
			get{
				//object value = this[this.uiviewWSLog.FieldID] ;
				//return (Int64)value;
				return GetValue<Int64>(this.uiviewWSLog.FieldID);
			}
			set{
				this[this.uiviewWSLog.FieldID] = value;
			}
		}
		
		
		public  DateTime? CreatedOn
		{
			get{
				//object value = this[this.uiviewWSLog.FieldCreatedOn] ;
				//return (DateTime?)value;
				return GetValue<DateTime?>(this.uiviewWSLog.FieldCreatedOn);
			}
			set{
				this[this.uiviewWSLog.FieldCreatedOn] = value;
			}
		}
		
		
		public  String CreatedBy
		{
			get{
				//object value = this[this.uiviewWSLog.FieldCreatedBy] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldCreatedBy);
			}
			set{
				this[this.uiviewWSLog.FieldCreatedBy] = value;
			}
		}
		
		
		public  DateTime? ModifiedOn
		{
			get{
				//object value = this[this.uiviewWSLog.FieldModifiedOn] ;
				//return (DateTime?)value;
				return GetValue<DateTime?>(this.uiviewWSLog.FieldModifiedOn);
			}
			set{
				this[this.uiviewWSLog.FieldModifiedOn] = value;
			}
		}
		
		
		public  String ModifiedBy
		{
			get{
				//object value = this[this.uiviewWSLog.FieldModifiedBy] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldModifiedBy);
			}
			set{
				this[this.uiviewWSLog.FieldModifiedBy] = value;
			}
		}
		
		
		public new Int64? SysVersion
		{
			get{
				//object value = this[this.uiviewWSLog.FieldSysVersion] ;
				//return (Int64?)value;
				return GetValue<Int64?>(this.uiviewWSLog.FieldSysVersion);
			}
			set{
				this[this.uiviewWSLog.FieldSysVersion] = value;
			}
		}
		
		
		public  String RequestUrl
		{
			get{
				//object value = this[this.uiviewWSLog.FieldRequestUrl] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldRequestUrl);
			}
			set{
				this[this.uiviewWSLog.FieldRequestUrl] = value;
			}
		}
		
		
		public  String ClassName
		{
			get{
				//object value = this[this.uiviewWSLog.FieldClassName] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldClassName);
			}
			set{
				this[this.uiviewWSLog.FieldClassName] = value;
			}
		}
		
		
		public  String MethodName
		{
			get{
				//object value = this[this.uiviewWSLog.FieldMethodName] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldMethodName);
			}
			set{
				this[this.uiviewWSLog.FieldMethodName] = value;
			}
		}
		
		
		public  DateTime? StartTime
		{
			get{
				//object value = this[this.uiviewWSLog.FieldStartTime] ;
				//return (DateTime?)value;
				return GetValue<DateTime?>(this.uiviewWSLog.FieldStartTime);
			}
			set{
				this[this.uiviewWSLog.FieldStartTime] = value;
			}
		}
		
		
		public  DateTime? EndTime
		{
			get{
				//object value = this[this.uiviewWSLog.FieldEndTime] ;
				//return (DateTime?)value;
				return GetValue<DateTime?>(this.uiviewWSLog.FieldEndTime);
			}
			set{
				this[this.uiviewWSLog.FieldEndTime] = value;
			}
		}
		
		
		public  Decimal? ElapsedSecond
		{
			get{
				//object value = this[this.uiviewWSLog.FieldElapsedSecond] ;
				//return (Decimal?)value;
				return GetValue<Decimal?>(this.uiviewWSLog.FieldElapsedSecond);
			}
			set{
				this[this.uiviewWSLog.FieldElapsedSecond] = value;
			}
		}
		
		
		public  String RequestContent
		{
			get{
				//object value = this[this.uiviewWSLog.FieldRequestContent] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldRequestContent);
			}
			set{
				this[this.uiviewWSLog.FieldRequestContent] = value;
			}
		}
		
		
		public  String ResponseContent
		{
			get{
				//object value = this[this.uiviewWSLog.FieldResponseContent] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldResponseContent);
			}
			set{
				this[this.uiviewWSLog.FieldResponseContent] = value;
			}
		}
		
		
		public  Int32? CallResult
		{
			get{
				//object value = this[this.uiviewWSLog.FieldCallResult] ;
				//return (Int32?)value;
				return GetValue<Int32?>(this.uiviewWSLog.FieldCallResult);
			}
			set{
				this[this.uiviewWSLog.FieldCallResult] = value;
			}
		}
		
		
		public  String ErrorMessage
		{
			get{
				//object value = this[this.uiviewWSLog.FieldErrorMessage] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldErrorMessage);
			}
			set{
				this[this.uiviewWSLog.FieldErrorMessage] = value;
			}
		}
		
		
		public  Int32? CallCount
		{
			get{
				//object value = this[this.uiviewWSLog.FieldCallCount] ;
				//return (Int32?)value;
				return GetValue<Int32?>(this.uiviewWSLog.FieldCallCount);
			}
			set{
				this[this.uiviewWSLog.FieldCallCount] = value;
			}
		}
		
		
		public  String MethodDescription
		{
			get{
				//object value = this[this.uiviewWSLog.FieldMethodDescription] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldMethodDescription);
			}
			set{
				this[this.uiviewWSLog.FieldMethodDescription] = value;
			}
		}
		
		
		public  String RequestContentView
		{
			get{
				//object value = this[this.uiviewWSLog.FieldRequestContentView] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldRequestContentView);
			}
			set{
				this[this.uiviewWSLog.FieldRequestContentView] = value;
			}
		}
		
		
		public  String ResponseContentView
		{
			get{
				//object value = this[this.uiviewWSLog.FieldResponseContentView] ;
				//return (String)value;
				return GetValue<String>(this.uiviewWSLog.FieldResponseContentView);
			}
			set{
				this[this.uiviewWSLog.FieldResponseContentView] = value;
			}
		}
		#endregion
	}
	
	[Serializable]
	public class WSLogDefaultFilterFilter : UIFilter
	{
		#region Constructor
		public WSLogDefaultFilterFilter(IUIView view) 
			: base("DefaultFilter",view,@"",@"")
		{
			InitClass();
		}
		//for Clone Constructor
		private WSLogDefaultFilterFilter()
			: base("DefaultFilter",null,"","")
		{}
		protected override IUIFilter CreateCloneInstance()
		{
			return new WSLogDefaultFilterFilter();
		}
		#endregion

		#region property
		#endregion
		
		#region function
		private void InitClass()
		{
		}
		#endregion

	}



}