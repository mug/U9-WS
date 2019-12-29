/**************************************************************
 * Description:
 * WSTokenBListUIModelAction.cs
 * Product: U9
 * Co.    : UFIDA Group
 * Author : Auto Generated
 * version: 2.0
 **************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UFSoft.UBF.Util.Log;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.ActionProcess;
using UFSoft.UBF.UI.IView; 
using System.Data;
using UFIDA.UBF.Query.CommonService;
using UFSoft.UBF.UI.FormProcess;
using UFSoft.UBF.UI.ControlModel;
using UFIDA.UBF.Query.CommonService.QueryStrategy;
using UFIDA.UBF.Query.CaseModel;
using UFIDA.U9.UI.PDHelper;
using UFSoft.UBF.ExportService;

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenBListUIModel
{
	public partial class WSTokenBListUIModelAction : BaseAction
	{
		private static readonly ILogger logger = LoggerManager.GetLogger(typeof(WSTokenBListUIModelAction));
		//强类型化基类Model属性.
		public new WSTokenBListUIModelModel CurrentModel 
		{
			get {
				return (WSTokenBListUIModelModel)base.CurrentModel;
			}
			set {
				base.CurrentModel = value ;
			}
		}
		
		public WSTokenBListUIModelAction(IPart part) : base(part)
		{
		}
		//Model参数的构造,用于测试用例.
		public WSTokenBListUIModelAction(WSTokenBListUIModelModel model) : base(model)
		{
		}
		/// <summary>
		/// Help: 
		/// </summary>
		public void OnLookCase(object sender, UIActionEventArgs e)
		{
			//调用基类委托..
			this.InvokeAction(sender,e,this.OnLookCase_Extend);
		}
		private void OnLookCase_DefaultImpl(object sender, UIActionEventArgs e)
		{
	  
	 
			//加入{action.Name}的代码模版:.\UITpls\UICommonAction.tpl,参数:QryClick
            UFIDA.U9.UI.Commands.CommandFactory.DoCommand("QryClick",this,sender,e);

	  
		}
		/// <summary>
		/// Help: 
		/// </summary>
		public void OnCaseChanged(object sender, UIActionEventArgs e)
		{
			//调用基类委托..
			this.InvokeAction(sender,e,this.OnCaseChanged_Extend);
		}
		private void OnCaseChanged_DefaultImpl(object sender, UIActionEventArgs e)
		{
	  
	        QryService.OnCaseChangedDefault("DDLCase", this.CurrentPart);
		QueryAdjust();
	 

		}
		/// <summary>
		/// Help: 
		/// </summary>
		public void OnOutPut(object sender, UIActionEventArgs e)
		{
			//调用基类委托..
			this.InvokeAction(sender,e,this.OnOutPut_Extend);
		}
		private void OnOutPut_DefaultImpl(object sender, UIActionEventArgs e)
		{
	  
	 
			//加入{action.Name}的代码模版:.\UITpls\UICommonAction.tpl,参数:OnOutPut
            UFIDA.U9.UI.Commands.CommandFactory.DoCommand("OnOutPut",this,sender,e);

	  
		}
		/// <summary>
		/// Help: 
		/// </summary>
		public void OnGridRowDbClick(object sender, UIActionEventArgs e)
		{
			//调用基类委托..
			this.InvokeAction(sender,e,this.OnGridRowDbClick_Extend);
		}
		private void OnGridRowDbClick_DefaultImpl(object sender, UIActionEventArgs e)
		{
	  
	 

		}
		/// <summary>
		/// Help: 
		/// </summary>
		public void OnNew(object sender, UIActionEventArgs e)
		{
			//调用基类委托..
			this.InvokeAction(sender,e,this.OnNew_Extend);
		}
		private void OnNew_DefaultImpl(object sender, UIActionEventArgs e)
		{
	  
	 

		}
		/// <summary>
		/// Help: 
		/// </summary>
		public void OnPrint(object sender, UIActionEventArgs e)
		{
			//调用基类委托..
			this.InvokeAction(sender,e,this.OnPrint_Extend);
		}
		private void OnPrint_DefaultImpl(object sender, UIActionEventArgs e)
		{
	  
	 
			//加入{action.Name}的代码模版:.\UITpls\UICommonAction.tpl,参数:OnPrint
            UFIDA.U9.UI.Commands.CommandFactory.DoCommand("OnPrint",this,sender,e);

	  
		}
		/// <summary>
		/// Help: 
		/// </summary>
		public void OnDelete(object sender, UIActionEventArgs e)
		{
			//调用基类委托..
			this.InvokeAction(sender,e,this.OnDelete_Extend);
		}
		private void OnDelete_DefaultImpl(object sender, UIActionEventArgs e)
		{
	  
	 
			//加入{action.Name}的代码模版:.\UITpls\UICommonAction.tpl,参数:ListDeleteClick
            UFIDA.U9.UI.Commands.CommandFactory.DoCommand("ListDeleteClick",this,sender,e);

	  
		}
		/// <summary>
		/// Help: 
		/// </summary>
		public void btnSaveCurrentQueryCase(object sender, UIActionEventArgs e)
		{
			//调用基类委托..
			this.InvokeAction(sender,e,this.btnSaveCurrentQueryCase_Extend);
		}
		private void btnSaveCurrentQueryCase_DefaultImpl(object sender, UIActionEventArgs e)
		{
	  
	 

		}
		#region Action的内置两个Action.
		/// <summary>
		/// Help: 数据加载(发生在Form的初始化加载时)
		/// </summary>
		public void OnLoadData(object sender, UIActionEventArgs e)
		{
			//UBF扩展处...
			this.OnLoadData_Extend(sender,e) ;
		}
		private void OnLoadData_DefaultImpl(object sender, UIActionEventArgs e)
		{
		   
		     InitCaseModel();
				}
		/// <summary>
		/// Help: 数据收集(发生在Form的CallBack或者是PostBack时)
		/// </summary>
		public void OnDataCollect(object sender, UIActionEventArgs e)
		{
			//UBF扩展处...
			this.OnDataCollect_Extend(sender,e) ;
		}
		private void OnDataCollect_DefaultImpl(object sender, UIActionEventArgs e)
		{
		    UFIDA.U9.UI.Commands.CommandFactory.DoCommand("DataCollect",this,sender,e);
		}
		#endregion
         

            
        #region BE列表自动产生的代码
        
		public void QueryAdjust()
		{
			IUFDataGrid UIGrid = this.CurrentPart.GetUFControlByName(this.CurrentPart.TopLevelContainer, "DataGrid1") as IUFDataGrid;

			BEQueryStrategyImpl beQryStrategyImpl = new BEQueryStrategyImpl(this.CurrentState, "UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken", "b6f329f2-5cd8-4f2a-9cf9-423b3323b56c", UIGrid.UIView, UIGrid, 1);

			beQryStrategyImpl.Adjust();
		    
			AfterQryAdjust_Extend(UIGrid);

			UIGrid.UIView.CurrentFilter.OPath = CustomFilterOpath_Extend(QryService.GetDefaultOpath((BaseWebForm)(this.CurrentPart)));
			UIGrid.UIView.CurrentFilter.OrderBy = QryService.GetOrderByOpath((BaseWebForm)(this.CurrentPart));

			UIGrid.UIView.Clear();
			this.NavigateAction.FirstPage(null);

			//20090316 UBF2.9_查询_yzx_修改查询设计器的tpl_用于显示多webpart查询的IE状态栏提示信息
			QryService.ShowQueryInfoInIEStatusBar((BaseWebForm)this.CurrentPart, UIGrid.UIView);
		}

		public void InitCaseModel()
		{
			QryService.ClearSession((UFSoft.UBF.UI.FormProcess.BaseWebForm)(this.CurrentPart));
			IUFDataGrid UIGrid = this.CurrentPart.GetUFControlByName(this.CurrentPart.TopLevelContainer, "DataGrid1") as IUFDataGrid;
			BEQueryStrategyImpl beQryStrategyImpl = new BEQueryStrategyImpl(this.CurrentState, "UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken", "b6f329f2-5cd8-4f2a-9cf9-423b3323b56c", UIGrid.UIView, UIGrid, 1);
			beQryStrategyImpl.QueryComponentXMLCompressed = @"7VZNbxtFGA4XLvwArpbvk8zn7o7UtErsRrKU0rSJ2/N8vJMubLzWep0mNyohUSGBeoBWohw4INFj
QRVUpL+DX9Ak4lfAu2s7dRyHNlKOmYM9Hzv7PO+z7/vMLHy0sLDwL7bqv2ofV52/P712Y28na+xC
MUjz3nKTLdJmA3ou92lve7k5LANJmjeuX7szhGK/le/08x70ykbql5vcORk5aYh0KhBJmSRWWk2C
NsFRxeOIqmajZ3ZguXl/cyv/Anrr6aC8U+w3Gz4d9DOz/9n8RRi4Iu2XNaFm4wFk/eq/prC138cd
1aPjie7dznLTRkFwHThRzidEBm6IdkETyYUVAn9U5MbPb+bDwsHaMMtG4N21TntlsasXW8NBubgx
tIv3N28tjimt3pz0mo1u514KD9uF2R5xqHrt/CGu3IXQ6YV8PTd+tNQy7gE0r19bNYPUVUu1XpGW
VFlriBcRUoPYERMhZ+cDeMadETJM9JpR6FxNELqmV/fzvGzjY628V8Jeec9kw3rrWpqVUGwZey8d
pDbDua1iCM1GK8+GO72z85t5UZ6dHb3l5l7f9Pw67EK23BSTd8zOVm+YnVtCOTbGStVyOBeSRHtG
YicUkbECYpilxAfvuNcMJGMXlWOjyD8HV3baU4MNUz6ohqsbnRJ2RkurG7f7UJhq+2iivXV7srKy
jQnezrKpEb5pb78aYxDdznQQAhNPOodBCI2Jp5QjOlY4jLkLSiSK2vgyg+h2buUeskkkNpYx93Eg
mnPUkMeaJEYCsSaWUnmZeA3VprW82JnsibzknEpBEuGwbGWMjyfMEc98xDw3GmT0Dgg3MBUzquvq
1kCkxkCNxjR2NHJGRhY42FqaNgQzzMqWGcA490dJMzg1GtWCCtzGQRHmXYzELSBx6kic6EShahSr
dqJbdwBFC8nM6Hf8/Yujx38ev3l6/POjc7VcOgttLfMAhpHIMEYkCxi/cJ4wJihwyYHZE9u6XWzP
Qz746vjg64sjC5eAUMYQ9EZ0zQQ4Ckk1EcEyE6wHFZ8ky02s4aJfpAPotGfg37559Pb1j/X0udBL
p+WffJm6WnE86oxJaSktepE3ATPY0ogkieKEg7KaM0wkekKqtprNspghVE+/ff37/xGaQoy8i4JX
htCQeJTBaaItZwRLJWJY+k6zy5JhClUyCjrhHk0GPUcqJ4g2MhBwhlqVAPXSnUWtoObiHj759vjX
lx+IDVFINARLPGY3Oj+1REtHSRy09gKkMpG5nJSbAsVSZjaRVZgUA44onuQiUkQBF5RTHwvrpkDn
RDoCvVCkPFEhWCWJEkEQKViC3xZdSUq0KbwvKG3YJdX1qVCFtVxzklDP0aFClVGYWxocDTGTQr/T
t0KdF2uNeqFYjaMuCSHCr+rxqypMYc2VJsonmimINY9PzvNWAaaErfQM7uHj54cHfx09++OfZ68+
EFfEWC4Sr1whrrIpaLxHyMgTsMY5jd4C4QR33QzKbt/Pxz766cvDJ98dPX919PTlhRi4WAabWEci
6x3mM0cL1UmCFqpDwHoG8c7IOoOVLN09A/3q4PCbFx8qNJanlx7ziUKEqYTWoYOMCLqmE86ayLkT
x+70dk2W+nlK//Lb0Q+P3x/n0qxZjsfVpQZH1V/NChnEyqgYz0HMd8nRxgyAwLOXotd4kMDMez//
uUTqS1h9mVzZbJ3iNeaxdOq0XTp9P7/+ycJVu2pX7apN2n8=";
		    
			BeforeGetQryModel_Extend(beQryStrategyImpl);
		    
			CaseModel caseModel = beQryStrategyImpl.GetQryModel();
		    
			AfterGetQueryModel_Extend(caseModel);
		    
			QryService.SetCaseModelToSession((BaseWebForm)(this.CurrentPart), caseModel);
		}
        
        
         #endregion
         

	}
}
