#region Using directives

using System;
using System.Collections;
using System.Data;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.MD.Runtime.Implement;

#endregion

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenBListUIModel
{
	[Serializable]
	public partial class WSTokenBListUIModelModel : UIModel
	{
		#region Constructor
		public WSTokenBListUIModelModel() : base("WSTokenBListUIModel")
		{
			InitClass();
			this.SetResourceInfo("15710914-b49e-4998-a9ba-c06ca46be2eb");
            try{
			    AfterInitModel();
            }catch(Exception exception){
              IUIModel model = this;
		      this.ErrorMessage.SetErrorMessage(ref model,exception);
			}
		}

		//just for Clone 
		private WSTokenBListUIModelModel(bool isInit) : base("WSTokenBListUIModel")
		{}
		protected override IUIModel CreateCloneInstance()
		{
			return new WSTokenBListUIModelModel(false);
		}
		#endregion
		#region member
		#region views
		private WSTokenView viewWSToken;			
		#endregion
		
		#region links
		#endregion
		
		#region properties
		#endregion
		#endregion

		#region property
		public WSTokenView WSToken
		{
			get { return (WSTokenView)this["WSToken"]; }
		}
		
		#region RealViews
		#endregion
		
	
		#endregion

		#region function
		private void InitClass()
		{
			this.viewWSToken = new WSTokenView(this);
			this.viewWSToken.SetResourceInfo("ea3ad41c-bbb5-4ebc-a9aa-0efd841f599c");
			this.Views.Add(this.viewWSToken);			

			
		}

		public override string AssemblyName
		{
			get { return "UFIDA.U9.Cust.Pub.WSM.WSMListUI"; }
		}
		
		#endregion
		private void OnValidate_DefualtImpl()
    {
    }

	}


	[Serializable]
	public partial class WSTokenView : UIView
	{
		#region Constructor
		public WSTokenView(IUIModel model) : base(model,"WSToken","UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken", true)
		{
			InitClass();
		}
		//构造空实例,不进行初始化.目前为Clone使用.
		private WSTokenView():base(null,"WSToken","UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken", true)
		{
		}
		protected override IUIView CreateCloneInstance()
		{
			return new WSTokenView();
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
			UIModelRuntimeFactory.AddNewUIField(this,"ID", typeof(Int64), false,"","System.Int64", "ID", true,true, false, "",false,(UIFieldType)1,"ba391065-6c27-4c82-acc8-b52b1c93a910","5c2e4a47-390e-421a-af91-b639f8e15f25");


		}
		#endregion
		
		#region override method
		protected override IUIRecord BuildNewRecord(IUIRecordBuilder builder)
		{
			return new WSTokenRecord(builder);
		}
		#endregion

		#region new method
		public new WSTokenRecord FocusedRecord
		{
			get { return (WSTokenRecord)base.FocusedRecord ; }
			set { base.FocusedRecord = value ; }
		}
		public new WSTokenRecord AddNewUIRecord()
		{	
			return (WSTokenRecord)base.AddNewUIRecord();
		}
		public new WSTokenRecord NewUIRecord()
		{	
			return (WSTokenRecord)base.NewUIRecord();
		}
		#endregion 

	}

	[Serializable]
	public class WSTokenRecord : UIRecord
	{
		#region Constructor
		public WSTokenRecord(IUIRecordBuilder builder):base(builder)
		{
		}
		private WSTokenView uiviewWSToken
		{
			get { return (WSTokenView)this.ContainerView; }
		}
		protected override IUIRecord CreateCloneInstance(IUIRecordBuilder builder)
		{
			return new WSTokenRecord(builder);
		}
		#endregion

		#region property
		
		
		public  Int64 ID
		{
			get{
				//object value = this[this.uiviewWSToken.FieldID] ;
				//return (Int64)value;
				return GetValue<Int64>(this.uiviewWSToken.FieldID);
			}
			set{
				this[this.uiviewWSToken.FieldID] = value;
			}
		}
		#endregion
	}
	



}