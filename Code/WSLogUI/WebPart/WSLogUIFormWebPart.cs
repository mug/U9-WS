


using System;
using System.Text;
using System.Collections;
using System.Xml;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Threading;

using Telerik.WebControls;
using UFSoft.UBF.UI.WebControls;
using UFSoft.UBF.UI.WebControls.InterActionComponenet;
using UFSoft.UBF.Util.Log;
using UFSoft.UBF.Util.Context;

//using MagicAjax.UI.Controls;
using UFSoft.UBF.Report.UI.ReportView.Web;
using UFSoft.UBF.UI.WebControlAdapter;
using UFSoft.UBF.UI.FormProcess;
using UFSoft.UBF.UI.IView;
using UFSoft.UBF.UI.Engine;
using UFSoft.UBF.UI.Engine.Builder;
using UFSoft.UBF.UI.Engine.Authorization;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.ActionProcess;
using UFSoft.UBF.UI.ControlModel;
using UFSoft.UBF.UI.Controls;
using UFSoft.UBF.UI.WebControls.Association;
using UFSoft.UBF.UI.WebControls.ClientCallBack;
using System.Web.UI;
using UFSoft.UBF.UI.UIFormPersonalization;
using System.Collections.Specialized;


/***********************************************************************************************
 * Form ID:37eefa0b-f334-42e2-bc3b-b0ce3c43cb31 
 * Form Name:WSLogUIForm
 * UIFactory Auto Generator
 ***********************************************************************************************/
namespace WSLogUIModel
{
	[FormRegister("UFIDA.U9.Cust.Pub.WSLogUI","WSLogUIModel.WSLogUIFormWebPart", "UFIDA.U9.Cust.Pub.WSLogUI.WebPart", "37eefa0b-f334-42e2-bc3b-b0ce3c43cb31","WebPart", "False", 992, 504)] 
	///insert into aspnet_Parts (SysVersion, Path, ClassName, [Assembly], FormId) values (0, 'UFIDA.U9.Cust.Pub.WSLogUI', 'WSLogUIModel.WSLogUIFormWebPart', 'UFIDA.U9.Cust.Pub.WSLogUI.WebPart', '37eefa0b-f334-42e2-bc3b-b0ce3c43cb31')
	///<siteMapNode url="~/erp/simple.aspx?lnk=37eefa0b-f334-42e2-bc3b-b0ce3c43cb31" title="WSLogUIForm"/>
    public partial class WSLogUIFormWebPart : UFSoft.UBF.UI.FormProcess.BaseWebForm
    {
		#region Page Controller/Code Behind
        private static readonly ILogger logger = LoggerManager.GetLogger(typeof(WSLogUIFormWebPart));
        private string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().FullName;
        //private string displayNamePostfix = "displayName";

		#region 强类型化基类属性.
		public new WSLogUIModelAction Action
		{
			get { return (WSLogUIModelAction)base.Action; }
			set { base.Action = value; }
		}
		WSLogUIModelModel _uimodel=null;
		public new WSLogUIModelModel Model
		{
			get 
			{
			     if(_uimodel == null){
			          _uimodel = new WSLogUIModelModel();
			     }
			     return _uimodel; 
			}
			set { _uimodel = value; }
		}
        protected override IUIModel UIModel{
            get{
                return this.Model;
            }
            set{
                this.Model = value as WSLogUIModelModel;
            }
        }
		#endregion 
		public FormAdjust adjust;
        #region variable declaration
        IUFToolbar Toolbar2;
        IUFButton BtnSave;
        IUFButton BtnCancel;
        IUFButton BtnAdd;
        IUFButton BtnDelete;
        IUFSeparator Separator0;
        IUFButton BtnCopy;
        IUFSeparator Separator1;
        IUFButton BtnSubmit;
        IUFButton BtnApprove;
        IUFButton BtnUndoApprove;
        IUFSeparator Separator2;
        IUFButton BtnFind;
        IUFButton BtnList;
        IUFSeparator Separator3;
        IUFButton BtnFirstPage;
        IUFButton BtnPrevPage;
        IUFButton BtnNextPage;
        IUFButton BtnLastPage;
        IUFSeparator Separator4;
        IUFButton BtnAttachment;
        IUFButton BtnFlow;
        IUFSeparator Separator5;
        IUFButton BtnOutput;
        IUFButton BtnPrint;
        IUFCard Card0;
        IUFButton BtnOk;
        IUFButton BtnClose;
        IUFCard Card2;
        IUFLabel lblID5;
        IUFFldNumberControl ID5;
        IUFLabel lblSysVersion121;
        IUFFldNumberControl SysVersion121;
        IUFLabel lblRequestUrl145;
        IUFFldTextBox RequestUrl145;
        IUFLabel lblClassName136;
        IUFFldTextBox ClassName136;
        IUFLabel lblMethodName121;
        IUFFldTextBox MethodName121;
        IUFLabel lblStartTime148;
        IUFFldDatePicker StartTime148;
        IUFLabel lblEndTime163;
        IUFFldDatePicker EndTime163;
        IUFLabel lblElapsedSecond148;
        IUFFldNumberControl ElapsedSecond148;
        IUFLabel lblCallResult259;
        IUFFldDropDownList CallResult259;
        IUFLabel lblCallCount292;
        IUFFldNumberControl CallCount292;
        IUFLabel lblMethodDescription175;
        IUFFldTextBox MethodDescription175;
        IUFLabel lblErrorMessage172;
        IUFFldTextBox ErrorMessage172;
        IUFLabel lblRequestContentView196;
        IUFFldTextBox RequestContentView196;
        IUFLabel lblResponseContentView235;
        IUFFldTextBox ResponseContentView235;
		UpdatePanel updatePanel;
		HiddenField wpFindID;
		IUFContainer topLevelPanel;     
        IUFSeparator SeparatorInFavorites;
        IUFButton BtnDefaultValues;
        #endregion
        
        #region constructor
        public WSLogUIFormWebPart()
        {
            FormID = "37eefa0b-f334-42e2-bc3b-b0ce3c43cb31";
            IsAutoSize = bool.Parse("True");
        }
        #endregion


	
            
	//获取档案版型结果: 

        #region eventBind and databind
        private void EventBind()
        {
			//事件绑定模板
				//Button控件事件
			this.BtnSave.Click += new EventHandler(BtnSave_Click);		
						
				//Button控件事件
			this.BtnCancel.Click += new EventHandler(BtnCancel_Click);		
						
				//Button控件事件
			this.BtnAdd.Click += new EventHandler(BtnAdd_Click);		
						
				//Button控件事件
			this.BtnDelete.Click += new EventHandler(BtnDelete_Click);		
						
				//Button控件事件
			this.BtnCopy.Click += new EventHandler(BtnCopy_Click);		
						
				//Button控件事件
			this.BtnSubmit.Click += new EventHandler(BtnSubmit_Click);		
						
				//Button控件事件
			this.BtnApprove.Click += new EventHandler(BtnApprove_Click);		
						
				//Button控件事件
			this.BtnFind.Click += new EventHandler(BtnFind_Click);		
						
				//Button控件事件
			this.BtnList.Click += new EventHandler(BtnList_Click);		
						
				//Button控件事件
			this.BtnFirstPage.Click += new EventHandler(BtnFirstPage_Click);		
						
				//Button控件事件
			this.BtnPrevPage.Click += new EventHandler(BtnPrevPage_Click);		
						
				//Button控件事件
			this.BtnNextPage.Click += new EventHandler(BtnNextPage_Click);		
						
				//Button控件事件
			this.BtnLastPage.Click += new EventHandler(BtnLastPage_Click);		
						
				//Button控件事件
			this.BtnAttachment.Click += new EventHandler(BtnAttachment_Click);		
						
				//Button控件事件
			this.BtnFlow.Click += new EventHandler(BtnFlow_Click);		
						
				//Button控件事件
			this.BtnOutput.Click += new EventHandler(BtnOutput_Click);		
						
				//Button控件事件
			this.BtnPrint.Click += new EventHandler(BtnPrint_Click);		
						
				//Button控件事件
			this.BtnOk.Click += new EventHandler(BtnOk_Click);		
						
				//Button控件事件
			this.BtnClose.Click += new EventHandler(BtnClose_Click);		
						

	
            AfterEventBind();
        }
        #endregion            
        
		#region override method
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad2(e);
		}
		protected override void OnLoadDataDo(EventArgs e)
		{
		    adjust.ProcessAdjustBeforeOnLoad(this);
			if (UIEngineHelper.IsDataBind(PageStatus, this))
			{
				if(this.Model==null){				        
					this.Model = new WSLogUIModelModel();
				}
				OnLoadConsumer(new InParameterModel[]{},new InParameterModel[]{});
				OnLoadData(this);
				this.IsDataBinding = true ; //加载完数据要绑定一次.目前加这.
			}
			else
			{
				//去除.已经移入到OnInit()中.
				//this.Model = (WSLogUIModelModel)this.CurrentState[this.TaskId.ToString()];
			}
			adjust.ProcessAdjustAfterOnLoadData(this);
		            AfterOnLoad();
            
            adjust.ProcessAdjustAfterOnLoad(this);
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender2(e);
		}
        protected override void OnPreRenderDo(EventArgs e)
        {
            adjust.ProcessAdjustBeforeOnPreRender(this);
			base.OnPreRender(e);
			this.CurrentState[this.TaskId.ToString()] = this.Model;
			RegisterClearWebPartPadding();
            UFIDA.U9.UI.PDHelper.FormAuthorityHelper.SetWebPartAuthorization(this);
            
			if (IsDataBinding) //2006-9-7 可由开发人员控制
			{
				BeforeUIModelBinding();
				//BtnFind对应隐藏域的数据传递。:True
				UFIDA.U9.UI.PDHelper.CommonReferenceHelper.BindingBtnFindParam(this);
								if(!Page.IsPostBack)
				{
					EnumTypeBinding.BindEnumControls(this);
				}
				UFIDA.U9.UI.Commands.CommandHelper.BindFlexData(this);
				adjust.ProcessAdjustBeforeDataBinding(this);
				if (this.IsOnlyDataBinding)
				{
					this.DataBinding();
				}
				adjust.ProcessAdjustAfterDataBinding(this);

				AfterUIModelBinding();
			}
			adjust.ProcessAdjustAfterOnPreRender(this);
        }
		protected override void OnInit(EventArgs e)
		{
			base.OnInit2(e);
		}
		protected override void OnInitDo(EventArgs e)
		{			 
			this.Page.InitComplete += new EventHandler(Page_InitComplete);
			WebPartBuilder.InitWebPart(this);
            this.Action = new WSLogUIModelAction(this);
            adjust = new FormAdjust();
		    CreateFormChildControls();
		}
        void Page_InitComplete(object sender, EventArgs e)
        {

            adjust.ProcessInit(this);
        }
        #endregion

      
        
        #endregion

	
		/// <summary>
        /// WebPart View
        /// </summary>
        #region view Create Contorls
        private void CreateFormChildControls()
        {
            IUFContainer _panel = UIControlBuilder.BuildTopLevelContainer(this,"WSLogUIForm",true,992,504);
            CommonBuilder.ContainerGridLayoutPropBuilder(_panel, 1, 3, 0, 10, 0, 0, 0, 5);
			InitViewBindingContainer(this, _panel,  null, "", "", null, 1, "");
			UIControlBuilder.BuildContainerGridLayout(_panel, 10,new GridColumnDef[]{new GridColumnDef(992,bool.Parse("False")),},new GridRowDef[]{new GridRowDef(1,bool.Parse("True")),new GridRowDef(448,bool.Parse("False")),new GridRowDef(25,bool.Parse("True")),});
            //???还有用么?
            topLevelPanel = _panel;    
            
            UIControlBuilder.BuildCommonControls(this,ref updatePanel,ref wpFindID);
            





	
			_BuilderControl_Toolbar2(_panel);

		
			UIControlBuilder.BuilderUFControl(this.Toolbar2, "1");		


	
			_BuilderControl_Card0(_panel);

		
			UIControlBuilder.BuilderUFControl(this.Card0, "3");		


	
			_BuilderControl_Card2(_panel);

		
			UIControlBuilder.BuilderUFControl(this.Card2, "2");		



			
     
			
			
            EventBind();
            AfterCreateChildControls();
            
        }        







				        
        private void _BuilderControl_Toolbar2(IUFContainer container)
        {
            IUFToolbar _Toolbar = UIControlBuilder.BuilderToolBarControl(container,"Toolbar2",true, true, "1",992, 1, 0, 0, 1, 1,"100");
            this.Toolbar2 = _Toolbar;
            
            ///foreach Toolbar下的所有控件，增加到此容器
                            this.BtnSave = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnSave", "True", "True", 35, 1,"1", "",true,false,"8288c5a3-3b19-48d3-b139-f7018d2782ee","8288c5a3-3b19-48d3-b139-f7018d2782ee","d86cccd9-8b5b-4de6-97dc-bc64557ebe27");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnSave);
            this.BtnSave.UIModel = this.Model.ElementID;
            this.BtnSave.Action = "SaveClick";
	                            this.BtnCancel = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnCancel", "True", "True", 35, 1,"2", "",true,false,"f35cb480-9e8f-4689-aaac-3e9fc9a0c65e","f35cb480-9e8f-4689-aaac-3e9fc9a0c65e","779bc51b-fd26-41de-bd7b-0b956032e792");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnCancel);
            this.BtnCancel.UIModel = this.Model.ElementID;
            this.BtnCancel.Action = "CancelClick";
	                            this.BtnAdd = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnAdd", "True", "True", 35, 1,"3", "",true,false,"19478b02-d2a9-4d7e-b7af-00070c61ff2d","19478b02-d2a9-4d7e-b7af-00070c61ff2d","3945e867-f214-4bd1-aee2-59aeb42da2ff");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnAdd);
            this.BtnAdd.UIModel = this.Model.ElementID;
            this.BtnAdd.Action = "NewClick";
	                            this.BtnDelete = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnDelete", "True", "True", 35, 1,"4", "",true,false,"0467218f-229b-4954-b2d4-3c5976467f76","0467218f-229b-4954-b2d4-3c5976467f76","e2f9f0f3-1154-4312-8d4b-b711c368ae8a");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnDelete);
            this.BtnDelete.UIModel = this.Model.ElementID;
            this.BtnDelete.Action = "DeleteClick";
	                            _Toolbar.Controls.Add(new UFWebToolbarSeparatorAdapter());
			                            this.BtnCopy = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnCopy", "True", "True", 35, 1,"6", "",true,false,"be9f8d20-e484-464b-9818-a2c1b599b967","be9f8d20-e484-464b-9818-a2c1b599b967","6f2df9ed-c5f9-4c48-bf13-054697738eb8");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnCopy);
            this.BtnCopy.UIModel = this.Model.ElementID;
            this.BtnCopy.Action = "CopyClick";
	                            _Toolbar.Controls.Add(new UFWebToolbarSeparatorAdapter());
			                            this.BtnSubmit = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnSubmit", "True", "True", 35, 1,"8", "",true,false,"c42c0f21-2fd7-49b2-ac54-62f811747b18","c42c0f21-2fd7-49b2-ac54-62f811747b18","81976b13-589c-4fdc-9b81-a362a796ce70");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnSubmit);
            this.BtnSubmit.UIModel = this.Model.ElementID;
            this.BtnSubmit.Action = "SubmitClick";
	                            this.BtnApprove = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnApprove", "True", "True", 35, 1,"9", "",true,false,"eb678a04-c7e1-44f1-b175-8f90f9903862","eb678a04-c7e1-44f1-b175-8f90f9903862","4f113b30-f1e1-44ae-81a9-1d335ca562e7");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnApprove);
            this.BtnApprove.UIModel = this.Model.ElementID;
            this.BtnApprove.Action = "ApproveClick";
	                            this.BtnUndoApprove = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnUndoApprove", "True", "True", 35, 1,"10", "",true,false,"ae796775-bce3-4aed-89a9-20eaa4648a67","ae796775-bce3-4aed-89a9-20eaa4648a67","6b1a2c14-7e6a-4c9b-9ef7-2ec73fad6e46");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnUndoApprove);
            this.BtnUndoApprove.UIModel = this.Model.ElementID;
            this.BtnUndoApprove.Action = "";
	                            _Toolbar.Controls.Add(new UFWebToolbarSeparatorAdapter());
			                            this.BtnFind = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnFind", "True", "True", 35, 1,"12", "",true,false,"27621430-7bc7-4c0e-979e-f0108439d13e","27621430-7bc7-4c0e-979e-f0108439d13e","3fd37917-5541-498b-a027-0dd63261cddc");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnFind);
            this.BtnFind.UIModel = this.Model.ElementID;
            this.BtnFind.Action = "FindClick";
	                            this.BtnList = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnList", "True", "True", 35, 1,"13", "",true,false,"c639596b-5a8c-4fc1-88bb-a3d670cda992","c639596b-5a8c-4fc1-88bb-a3d670cda992","5a2505df-2cee-40c4-9d5a-24e9291dfdb5");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnList);
            this.BtnList.UIModel = this.Model.ElementID;
            this.BtnList.Action = "ListClick";
	                            _Toolbar.Controls.Add(new UFWebToolbarSeparatorAdapter());
			                            this.BtnFirstPage = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnFirstPage", "True", "True", 35, 1,"15", "",true,false,"f229e163-fcd1-4f6a-a645-df86c0efd8ec","f229e163-fcd1-4f6a-a645-df86c0efd8ec","6f7f4784-6ea9-4ae8-b754-55fe0bb87dc4");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnFirstPage);
            this.BtnFirstPage.UIModel = this.Model.ElementID;
            this.BtnFirstPage.Action = "FirstPage";
	                            this.BtnPrevPage = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnPrevPage", "True", "True", 35, 1,"16", "",true,false,"5ed368d8-7616-4696-b671-3f1c895f3b43","5ed368d8-7616-4696-b671-3f1c895f3b43","fd023a07-eab9-4b2d-b994-ddc924690b80");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnPrevPage);
            this.BtnPrevPage.UIModel = this.Model.ElementID;
            this.BtnPrevPage.Action = "PrevPage";
	                            this.BtnNextPage = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnNextPage", "True", "True", 35, 1,"17", "",true,false,"36afec41-957c-493a-97a4-eddb136af5b4","36afec41-957c-493a-97a4-eddb136af5b4","f08e52c2-b50c-4f51-922e-edc4038fce20");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnNextPage);
            this.BtnNextPage.UIModel = this.Model.ElementID;
            this.BtnNextPage.Action = "NextPage";
	                            this.BtnLastPage = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnLastPage", "True", "True", 35, 1,"18", "",true,false,"dc4a37d1-35de-4016-81dd-582aef3cdeb0","dc4a37d1-35de-4016-81dd-582aef3cdeb0","c4e77041-7e74-4fc7-ab94-df893b033d35");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnLastPage);
            this.BtnLastPage.UIModel = this.Model.ElementID;
            this.BtnLastPage.Action = "LastPage";
	                            _Toolbar.Controls.Add(new UFWebToolbarSeparatorAdapter());
			                            this.BtnAttachment = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnAttachment", "True", "True", 35, 1,"20", "",true,false,"92ccef79-ad54-438c-a16e-20a4fd407b97","92ccef79-ad54-438c-a16e-20a4fd407b97","1b9f07d6-fb3e-45fa-94b8-86d00fb1cc0c");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnAttachment);
            this.BtnAttachment.UIModel = this.Model.ElementID;
            this.BtnAttachment.Action = "AttachmentClick";
	                            this.BtnFlow = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnFlow", "True", "True", 35, 1,"21", "",true,false,"e222698c-ae3c-470a-8053-1b69905c510a","e222698c-ae3c-470a-8053-1b69905c510a","09d1961e-7f63-4cbd-aeac-add0078cc6fb");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnFlow);
            this.BtnFlow.UIModel = this.Model.ElementID;
            this.BtnFlow.Action = "FlowClick";
	                            _Toolbar.Controls.Add(new UFWebToolbarSeparatorAdapter());
			                            this.BtnOutput = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnOutput", "True", "True", 35, 1,"23", "",true,false,"688fd549-5a92-49cc-8072-6d5377f6409a","688fd549-5a92-49cc-8072-6d5377f6409a","a7992695-04f7-499d-aa13-3d1ebb2768b9");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnOutput);
            this.BtnOutput.UIModel = this.Model.ElementID;
            this.BtnOutput.Action = "OutputClick";
	                            this.BtnPrint = UIControlBuilder.BuilderToolbarButton(_Toolbar, "True", "BtnPrint", "True", "True", 35, 1,"24", "",true,false,"27b5c615-cde5-458c-be74-833317249568","27b5c615-cde5-458c-be74-833317249568","5f77c777-79ec-4ebb-98bd-8cd87b58728b");
		
            UIControlBuilder.SetButtonAccessKey(this.BtnPrint);
            this.BtnPrint.UIModel = this.Model.ElementID;
            this.BtnPrint.Action = "PrintClick";
	
            
            ((UFWebToolbarAdapter)_Toolbar).RemoveControls();
        }



	                   
        private IUFCard _BuilderControl_Card0(IUFContainer container)
        {
            IUFCard _UFCard = UIControlBuilder.BuildCard(container,"Card0",false,"FunctionBar", true, true, "3","","a6c5b384-0a3f-48a7-bc11-7ec4ea2dff1d");
			CommonBuilder.GridLayoutPropBuilder(container, _UFCard, 992, 25, 0, 2, 1, 1, "100");
            CommonBuilder.ContainerGridLayoutPropBuilder(_UFCard, 22, 1, 0, 5, 10, 3, 10, 2);
			InitViewBindingContainer(this, _UFCard,  null, "", "", null, 1, "");
			UIControlBuilder.BuildContainerGridLayout(_UFCard, 5,new GridColumnDef[]{new GridColumnDef(80,bool.Parse("True")),new GridColumnDef(10,bool.Parse("True")),new GridColumnDef(80,bool.Parse("True")),new GridColumnDef(10,bool.Parse("True")),new GridColumnDef(80,bool.Parse("True")),new GridColumnDef(10,bool.Parse("True")),new GridColumnDef(80,bool.Parse("True")),new GridColumnDef(10,bool.Parse("True")),new GridColumnDef(80,bool.Parse("True")),new GridColumnDef(10,bool.Parse("True")),new GridColumnDef(80,bool.Parse("True")),new GridColumnDef(10,bool.Parse("True")),new GridColumnDef(80,bool.Parse("True")),new GridColumnDef(10,bool.Parse("True")),new GridColumnDef(80,bool.Parse("True")),new GridColumnDef(10,bool.Parse("True")),new GridColumnDef(71,bool.Parse("True")),new GridColumnDef(10,bool.Parse("True")),new GridColumnDef(80,bool.Parse("True")),new GridColumnDef(10,bool.Parse("True")),new GridColumnDef(80,bool.Parse("True")),new GridColumnDef(1,bool.Parse("False")),},new GridRowDef[]{new GridRowDef(20,bool.Parse("True")),});
            this.Card0 = _UFCard;

            ///foreach UFCard下的所有控件，增加到此容器





				this.BtnOk = UIControlBuilder.BuilderUFButton(_UFCard, true, "BtnOk", true, true, 80, 20, 18, 0, 1, 1, "100","", this.Model.ElementID,"OnOk",false,"626ebf9b-f65a-4dd5-8f32-96f84919878c","626ebf9b-f65a-4dd5-8f32-96f84919878c","613facfa-0aa0-4f8c-9f06-8815d10c8b29");
	

		
			UIControlBuilder.BuilderUFControl(this.BtnOk, "9");		


				this.BtnClose = UIControlBuilder.BuilderUFButton(_UFCard, true, "BtnClose", true, true, 80, 20, 20, 0, 1, 1, "100","", this.Model.ElementID,"OnClose",false,"020a5365-8f12-4970-b8df-17ce3ae60a68","020a5365-8f12-4970-b8df-17ce3ae60a68","f5aa23bb-0309-4ec0-b57f-b89c53509dea");
	

		
			UIControlBuilder.BuilderUFControl(this.BtnClose, "10");		



		

            
            container.Controls.Add(_UFCard);
            return _UFCard;
        }

	                   
        private IUFCard _BuilderControl_Card2(IUFContainer container)
        {
            IUFCard _UFCard = UIControlBuilder.BuildCard(container,"Card2",true,"none", true, true, "2","ce361e30-ea37-4d65-89a7-4cde4454e29d","84c7f67b-b0d5-4c5a-941c-f43d25fa5810");
			CommonBuilder.GridLayoutPropBuilder(container, _UFCard, 992, 448, 0, 1, 1, 1, "100");
            CommonBuilder.ContainerGridLayoutPropBuilder(_UFCard, 14, 18, 0, 5, 10, 0, 10, 0);
			InitViewBindingContainer(this, _UFCard,  this.Model.WSLog, "WSLog", "", null, 1, "服务日志");
			UIControlBuilder.BuildContainerGridLayout(_UFCard, 5,new GridColumnDef[]{new GridColumnDef(100,bool.Parse("True")),new GridColumnDef(5,bool.Parse("True")),new GridColumnDef(150,bool.Parse("True")),new GridColumnDef(20,bool.Parse("True")),new GridColumnDef(100,bool.Parse("True")),new GridColumnDef(5,bool.Parse("True")),new GridColumnDef(100,bool.Parse("True")),new GridColumnDef(20,bool.Parse("True")),new GridColumnDef(100,bool.Parse("True")),new GridColumnDef(5,bool.Parse("True")),new GridColumnDef(150,bool.Parse("True")),new GridColumnDef(20,bool.Parse("True")),new GridColumnDef(193,bool.Parse("True")),new GridColumnDef(1,bool.Parse("False")),},new GridRowDef[]{new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(20,bool.Parse("True")),new GridRowDef(19,bool.Parse("False")),new GridRowDef(20,bool.Parse("False")),});
            this.Card2 = _UFCard;

            ///foreach UFCard下的所有控件，增加到此容器





				this.lblID5 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblID5", "", "False", "True", "Right", 100, 20, 0, 0, 1, 1, "100","ce361e30-ea37-4d65-89a7-4cde4454e29d","104e749d-cd2b-4f26-a002-87a532378f67");


								

		
			UIControlBuilder.BuilderUFControl(this.lblID5, "0");		


				this.ID5 = UIControlBuilder.BuilderNumberControl(_UFCard, "ID5", "False", "False", "True", "Left", 7, 60, 0, 150, 20, 0, 0, 1, 1, NumbericType.Numberic, "100",79228162514264337593543950335m, -79228162514264337593543950335m
			,TextAlign.Right,0,true,false,true,"lblID5","19.0","ce361e30-ea37-4d65-89a7-4cde4454e29d","a1f0e77e-a539-43cd-b29b-fe3c5a93f6ba",null,null,null, null);
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.ID5, "False", "ID", this.Model.WSLog, this.Model.WSLog.FieldID, "WSLog");
	
		
			UIControlBuilder.BuilderUFControl(this.ID5, "1");		
		 

				this.lblSysVersion121 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblSysVersion121", "", "False", "True", "Right", 100, 20, 0, 0, 1, 1, "100","deea45c5-810b-48a7-8dc4-fa130ce73181","5448a988-4fb8-436c-991c-d1725d929c26");


								

		
			UIControlBuilder.BuilderUFControl(this.lblSysVersion121, "2");		


				this.SysVersion121 = UIControlBuilder.BuilderNumberControl(_UFCard, "SysVersion121", "True", "False", "True", "Left", 7, 60, 0, 150, 20, 0, 0, 1, 1, NumbericType.Numberic, "100",79228162514264337593543950335m, -79228162514264337593543950335m
			,TextAlign.Right,0,true,false,true,"lblSysVersion121","19.0","deea45c5-810b-48a7-8dc4-fa130ce73181","be78fd2a-ffc8-47ee-b165-d8541e7a92da",null,null,null, null);
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.SysVersion121, "False", "SysVersion", this.Model.WSLog, this.Model.WSLog.FieldSysVersion, "WSLog");
	
		
			UIControlBuilder.BuilderUFControl(this.SysVersion121, "3");		
		 

				this.lblRequestUrl145 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblRequestUrl145", "", "True", "True", "Right", 100, 20, 0, 0, 1, 1, "100","741c99b1-e180-4c83-9ec4-7c74342f3a0b","71d64da9-a641-4eba-b883-75d23f882227");


								

		
			UIControlBuilder.BuilderUFControl(this.lblRequestUrl145, "4");		


				this.RequestUrl145 = UIControlBuilder.BuilderTextBox(_UFCard, "RequestUrl145", "True", "True", "True", "False", "Left", 0, 60, 0, 375, 20, 2, 0, 5, 1, "False", "100"
			,"",TextBoxMode.SingleLine,TextAlign.Left, true,false,"lblRequestUrl145","","500","741c99b1-e180-4c83-9ec4-7c74342f3a0b","89f1285c-926c-4d78-b4f6-3cc5f0b3f2e9");
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.RequestUrl145, "False", "RequestUrl", this.Model.WSLog, this.Model.WSLog.FieldRequestUrl, "WSLog");


		
			UIControlBuilder.BuilderUFControl(this.RequestUrl145, "5");		
		 

				this.lblClassName136 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblClassName136", "", "True", "True", "Right", 100, 20, 0, 1, 1, 1, "100","dccc20ef-b198-4b11-9015-d0e5c06e423a","e2c2b865-b506-4687-bdc0-da2111f36e7a");


								

		
			UIControlBuilder.BuilderUFControl(this.lblClassName136, "6");		


				this.ClassName136 = UIControlBuilder.BuilderTextBox(_UFCard, "ClassName136", "True", "True", "True", "False", "Left", 0, 60, 0, 375, 20, 2, 1, 5, 1, "False", "100"
			,"",TextBoxMode.SingleLine,TextAlign.Left, true,false,"lblClassName136","","100","dccc20ef-b198-4b11-9015-d0e5c06e423a","84f1a768-6040-4bc4-b0a2-0d5e1036e755");
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.ClassName136, "False", "ClassName", this.Model.WSLog, this.Model.WSLog.FieldClassName, "WSLog");


		
			UIControlBuilder.BuilderUFControl(this.ClassName136, "7");		
		 

				this.lblMethodName121 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblMethodName121", "", "True", "True", "Right", 100, 20, 0, 2, 1, 1, "100","3e45084e-3a4c-4856-93d5-53966c9d5077","31f8e3eb-e089-41d4-8a66-064163ce601d");


								

		
			UIControlBuilder.BuilderUFControl(this.lblMethodName121, "8");		


				this.MethodName121 = UIControlBuilder.BuilderTextBox(_UFCard, "MethodName121", "True", "True", "True", "False", "Left", 0, 60, 0, 375, 20, 2, 2, 5, 1, "False", "100"
			,"",TextBoxMode.SingleLine,TextAlign.Left, true,false,"lblMethodName121","","100","3e45084e-3a4c-4856-93d5-53966c9d5077","a2801b19-fa0e-4771-9118-5e0f05c1e6ca");
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.MethodName121, "False", "MethodName", this.Model.WSLog, this.Model.WSLog.FieldMethodName, "WSLog");


		
			UIControlBuilder.BuilderUFControl(this.MethodName121, "9");		
		 

				this.lblStartTime148 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblStartTime148", "", "True", "True", "Right", 100, 20, 0, 4, 1, 1, "100","8f5db037-3cc2-4077-a3b2-85c148b8ea7a","9ea47f59-6582-4fd9-b340-87a8d8bcdce2");


								

		
			UIControlBuilder.BuilderUFControl(this.lblStartTime148, "10");		


				this.StartTime148 = UIControlBuilder.BuilderDatePicker(_UFCard, "StartTime148", true, true, true, "DateTime","Left", 5, 60, 0, 375, 20, 2, 4, 5, 1, "100",true,false,"lblStartTime148","8f5db037-3cc2-4077-a3b2-85c148b8ea7a","c1c5722a-25ad-4020-a1fa-acae4a7d4a1d");
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.StartTime148, "False", "StartTime", this.Model.WSLog, this.Model.WSLog.FieldStartTime, "WSLog");


		
			UIControlBuilder.BuilderUFControl(this.StartTime148, "11");		
		 

				this.lblEndTime163 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblEndTime163", "", "True", "True", "Right", 100, 20, 0, 5, 1, 1, "100","7f743bc2-ffe1-456f-af0b-29b5c740a09d","4d36e4c4-1569-476d-a0cc-9f23147ce296");


								

		
			UIControlBuilder.BuilderUFControl(this.lblEndTime163, "12");		


				this.EndTime163 = UIControlBuilder.BuilderDatePicker(_UFCard, "EndTime163", true, true, true, "DateTime","Left", 5, 60, 0, 375, 20, 2, 5, 5, 1, "100",true,false,"lblEndTime163","7f743bc2-ffe1-456f-af0b-29b5c740a09d","15a0fda5-f7b2-4f23-8793-8c3e30f06fed");
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.EndTime163, "False", "EndTime", this.Model.WSLog, this.Model.WSLog.FieldEndTime, "WSLog");


		
			UIControlBuilder.BuilderUFControl(this.EndTime163, "13");		
		 

				this.lblElapsedSecond148 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblElapsedSecond148", "", "True", "True", "Right", 100, 20, 0, 6, 1, 1, "100","02b4e5a8-81bc-4b21-ae82-dbdc93c87522","933fc1ab-b12d-4dba-9770-27e617f90340");


								

		
			UIControlBuilder.BuilderUFControl(this.lblElapsedSecond148, "14");		


				this.ElapsedSecond148 = UIControlBuilder.BuilderNumberControl(_UFCard, "ElapsedSecond148", "True", "True", "True", "Left", 8, 60, 0, 375, 20, 2, 6, 5, 1, NumbericType.Numberic, "100",79228162514264337593543950335m, -79228162514264337593543950335m
			,TextAlign.Right,3,true,false,true,"lblElapsedSecond148","24.9","02b4e5a8-81bc-4b21-ae82-dbdc93c87522","2c883b1e-b63b-4d0d-beb9-ddf2f9803882",null,null,null, null);
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.ElapsedSecond148, "False", "ElapsedSecond", this.Model.WSLog, this.Model.WSLog.FieldElapsedSecond, "WSLog");
	
		
			UIControlBuilder.BuilderUFControl(this.ElapsedSecond148, "15");		
		 

				this.lblCallResult259 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblCallResult259", "", "True", "True", "Right", 100, 20, 8, 1, 1, 1, "100","12787766-dae4-4889-b322-897aa034a937","1e86e85d-5da1-4878-b983-887deca30366");


								

		
			UIControlBuilder.BuilderUFControl(this.lblCallResult259, "16");		


		        this.CallResult259 = UIControlBuilder.BuilderDropDownList(_UFCard, "CallResult259", "UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum", true,  true, true, "Left", 2, 60, 0, 363, 20, 10, 1, 3, 1, "100",true,false,"lblCallResult259","12787766-dae4-4889-b322-897aa034a937","cb73e2ca-b71a-4c9f-a36b-a4460943bdeb");
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.CallResult259, "False", "CallResult", this.Model.WSLog, this.Model.WSLog.FieldCallResult, "WSLog");
			EnumTypeList.Add("UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum");
			EnumControlsMap.Add(this.CallResult259, _UFCard);
		

		
			UIControlBuilder.BuilderUFControl(this.CallResult259, "17");		
		 

				this.lblCallCount292 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblCallCount292", "", "True", "True", "Right", 100, 20, 8, 0, 1, 1, "100","c1f059d4-17e6-481a-bb41-b2aaed45a759","77e8dc11-94d2-40b1-92d0-26d8a3788f97");


								

		
			UIControlBuilder.BuilderUFControl(this.lblCallCount292, "18");		


				this.CallCount292 = UIControlBuilder.BuilderNumberControl(_UFCard, "CallCount292", "True", "True", "True", "Left", 2, 60, 0, 363, 20, 10, 0, 3, 1, NumbericType.Numberic, "100",79228162514264337593543950335m, -79228162514264337593543950335m
			,TextAlign.Right,0,true,false,true,"lblCallCount292","10.0","c1f059d4-17e6-481a-bb41-b2aaed45a759","5ecb462d-2e4a-44db-b852-44b3a28a4118",null,null,null, null);
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.CallCount292, "False", "CallCount", this.Model.WSLog, this.Model.WSLog.FieldCallCount, "WSLog");
	
		
			UIControlBuilder.BuilderUFControl(this.CallCount292, "19");		
		 

				this.lblMethodDescription175 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblMethodDescription175", "", "True", "True", "Right", 100, 20, 0, 3, 1, 1, "100","79ba63c9-5a55-41f6-8086-44807bb3825e","37c8834d-7cc7-49bc-8841-af2935bfb800");


								

		
			UIControlBuilder.BuilderUFControl(this.lblMethodDescription175, "20");		


				this.MethodDescription175 = UIControlBuilder.BuilderTextBox(_UFCard, "MethodDescription175", "True", "True", "True", "False", "Left", 0, 60, 0, 375, 20, 2, 3, 5, 1, "False", "100"
			,"",TextBoxMode.SingleLine,TextAlign.Left, true,false,"lblMethodDescription175","","100","79ba63c9-5a55-41f6-8086-44807bb3825e","712736b3-3bce-44ca-b39a-b2fdba163133");
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.MethodDescription175, "False", "MethodDescription", this.Model.WSLog, this.Model.WSLog.FieldMethodDescription, "WSLog");


		
			UIControlBuilder.BuilderUFControl(this.MethodDescription175, "21");		
		 

				this.lblErrorMessage172 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblErrorMessage172", "", "True", "True", "Right", 100, 20, 8, 2, 1, 1, "100","6b95fd3e-78ad-4bd3-80c3-7133cc179349","9464a4f1-2cb2-4b04-9b07-03e5e51a8b3c");


								

		
			UIControlBuilder.BuilderUFControl(this.lblErrorMessage172, "22");		


				this.ErrorMessage172 = UIControlBuilder.BuilderTextBox(_UFCard, "ErrorMessage172", "True", "True", "True", "True", "Left", 0, 60, 0, 363, 120, 10, 2, 3, 5, "False", "100"
			,"",TextBoxMode.MultiLine,TextAlign.Left, true,false,"lblErrorMessage172","","2000","6b95fd3e-78ad-4bd3-80c3-7133cc179349","a3acf944-949f-40ab-b142-ffdac295bc9d");
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.ErrorMessage172, "False", "ErrorMessage", this.Model.WSLog, this.Model.WSLog.FieldErrorMessage, "WSLog");


		
			UIControlBuilder.BuilderUFControl(this.ErrorMessage172, "23");		
		 

				this.lblRequestContentView196 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblRequestContentView196", "", "True", "True", "Right", 100, 20, 0, 7, 1, 1, "100","aefa9c08-db62-49b6-af0f-ded717af25cd","d60f40c9-7db5-4ce9-a42d-a22cece3792e");


								

		
			UIControlBuilder.BuilderUFControl(this.lblRequestContentView196, "28");		


				this.RequestContentView196 = UIControlBuilder.BuilderTextBox(_UFCard, "RequestContentView196", "True", "True", "True", "True", "Left", 0, 60, 0, 375, 269, 2, 7, 5, 11, "False", "100"
			,"",TextBoxMode.MultiLine,TextAlign.Left, true,false,"lblRequestContentView196","","5000","aefa9c08-db62-49b6-af0f-ded717af25cd","f78e0284-1cca-4dcd-b34f-b5569ba37f21");
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.RequestContentView196, "False", "RequestContentView", this.Model.WSLog, this.Model.WSLog.FieldRequestContentView, "WSLog");


		
			UIControlBuilder.BuilderUFControl(this.RequestContentView196, "29");		
		 

				this.lblResponseContentView235 = UIControlBuilder.BuilderUFLabel(_UFCard, "lblResponseContentView235", "", "True", "True", "Right", 100, 20, 8, 7, 1, 1, "100","d64ca7ce-1baf-4b1c-892b-16d1232b7f66","b0ef4ba8-2167-4ce3-a719-b751c64a5fe1");


								

		
			UIControlBuilder.BuilderUFControl(this.lblResponseContentView235, "30");		


				this.ResponseContentView235 = UIControlBuilder.BuilderTextBox(_UFCard, "ResponseContentView235", "True", "True", "True", "True", "Left", 0, 60, 0, 363, 269, 10, 7, 3, 11, "False", "100"
			,"",TextBoxMode.MultiLine,TextAlign.Left, true,false,"lblResponseContentView235","","5000","d64ca7ce-1baf-4b1c-892b-16d1232b7f66","94e331ea-0b59-4e8b-a9cb-af72d4c48817");
			UIControlBuilder.BuilderUIFieldBindingControl(this, this.ResponseContentView235, "False", "ResponseContentView", this.Model.WSLog, this.Model.WSLog.FieldResponseContentView, "WSLog");


		
			UIControlBuilder.BuilderUFControl(this.ResponseContentView235, "31");		
		 


																												

            
            container.Controls.Add(_UFCard);
            return _UFCard;
        }





		#endregion
		

	}
}
