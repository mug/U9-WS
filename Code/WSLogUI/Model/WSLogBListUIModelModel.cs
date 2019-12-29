#region Using directives

using System;
using System.Collections;
using System.Data;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.MD.Runtime.Implement;

#endregion

namespace UFIDA.U9.Cust.Pub.WSLogBListUIModel
{
	[Serializable]
	public partial class WSLogBListUIModelModel : UIModel
	{
		#region Constructor
		public WSLogBListUIModelModel() : base("WSLogBListUIModel")
		{
			InitClass();
			this.SetResourceInfo("aac07d53-b4ec-4f2f-bb0e-bf91a23d61fd");
            try{
			    AfterInitModel();
            }catch(Exception exception){
              IUIModel model = this;
		      this.ErrorMessage.SetErrorMessage(ref model,exception);
			}
		}

		//just for Clone 
		private WSLogBListUIModelModel(bool isInit) : base("WSLogBListUIModel")
		{}
		protected override IUIModel CreateCloneInstance()
		{
			return new WSLogBListUIModelModel(false);
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
			this.viewWSLog.SetResourceInfo("8010ad4e-75e2-4614-9336-4da715ee96e3");
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


		#endregion

		#region Init
		private void InitClass()
		{
			UIModelRuntimeFactory.AddNewUIField(this,"ID", typeof(Int64), false,"","System.Int64", "ID", true,true, false, "",false,(UIFieldType)1,"ba391065-6c27-4c82-acc8-b52b1c93a910","2e42fe41-713c-4800-ae08-780003ddeb32");


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
		#endregion
	}
	



}