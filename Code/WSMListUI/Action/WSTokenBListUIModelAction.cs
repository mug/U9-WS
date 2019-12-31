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
			beQryStrategyImpl.QueryComponentXMLCompressed = @"7VZPbxtFFA8XLnwArpbvk8z/2ZGaVo2dSJZSmjZxe56/6cLGa63XaXJrJSQqJFAP0EqUAwckeiyo
gor0e/AFmkR8Cni7toPjOLSRcswcdue92dnfe7/3Z2bho4WFhX9gVO9qfFxN/vr02o29nayxG4pB
mveWm2QRNxuh53Kf9raXm8MyoqR54/q1O8NQ7LfynX7eC72ykfrlJnWOS8cN4k5ExDHhyHKrUdQm
Oiyoklg0Gz2zE5ab9ze38i9Cbz0dlHeK/WbDp4N+ZvY/m78YBq5I+2VtULPxIGT96l2bsLXfhx3V
p2NF925nuWllZFRHioTzCeKRGqRd1IhTZhmDh5Bu/P1mPixcWBtm2Qi8u9Zp31zs6sXWcFAubgzt
4v3NW4tjk1ZWJ7Nmo9u5l4aH7cJsj2yoZu38IazcDbHTi/l6bvxoqWXcg9C8fm3FDFJXLdV8Sc2x
sNYgzySYFpRDRoLNzsfgCXWG8Tjha4ahczkB6Nq8ep7nZRs+a+W9MuyV90w2rLeupVkZii1j76WD
1Gag2yqGodlo5dlwp3dWv5kX5Vnt6C+re33T8+thN2TLTTb5x6y2+sOsbgno2BgzVdPhXEwS7QlS
jgnElQjIEIuRj95Rr0nghFyUjo0i/zy4stOeEjZM+aASVzY6ZdgZLa1s3O6HwlTbR4r21u3Jys1t
SPB2lk1J8Ke9/UoGJ7qdaScYJB53DpxgGhJPCIe0EiAq6qJgicBWXaYT3c6t3Ids4olVXFGvItKU
AodUaZQYHpA1inPheeJ1qDat5cXOZI/0nFLMGUqYg7LlCj5PiEOeeEk8NTpw+R8QbCBCEazr6tYB
cQ2OGg1p7LB0hksbaLA1Ne0QzTArW2YQxrk/SprBKanmzWpJlQoGGUc5GC4tMl5y5KLEmguCwbEJ
b91BKFpgzAx/x9+9PHryx/HbZ8c/PT6Xy6Wz0NopayNkmzbQrLjkDllmI4SMSGIUYVyelOHtYnse
8sGXxwdfXRyZGKNwwAF5Zyl0TVx1KcNQgM4lvNUe+uYEeRVquOgX6SB02jPw794+fvfmh1p9LvTS
afonkamrFeTRZBQJbIWOGKNAE1FFVyIrnEJSByNYVIwxMzGqbjWbZTFjUK1+9+a3/zNoClFICLfF
AjFKIACCEUhFyxGD8tEsEEZwuCQaplCjS6h3AGgth7TXPEFaK4qIZdhAQrg4j/wKai7u4dNvjn95
9YHYXBMlolLIVBXKqZDIBEsQjk5TLxnXyl9Oyk2BSu1ckoSApKXgsIBsgxMGI5IoTExkGhrXFOgc
T0egF/LUQU/xpoptkkA/NKHqGuCzk4rDCqaM8Euq6ylUH6xkcIQiKz0UlqceWe8dYhouBYmVImg8
jTrP1xr1Yr5qOL4okYg45as8ZshEaZCIEYNFgmgsJ6itIpgybKVncA+fvDg8+PPo+e9/P3/9gbgY
O6ypZchGQ+Dg1BzpRAoE7ML9wmFI6BPcdTMou30/H/vox0eHT789evH66NmrC1lAYhQCKEc+SRTi
xEEjE0IgOBVkCMIErU747gxuZunuGejXB4dfv/xAOKUUj9VhEaJncLvTQLTnHEUTKYFAB+pPyqfT
2zVZ6ucx/fOvR98/eb+fS7PNcixXlxqQqteYhACHvILm5QPUV2Qe2hi1KBAJaR68Vvr94T/XkPoS
Nrpnrm62Thk2NmTp1HG7dPqCfv2ThatxNa7G1RiPfwE=";
		    
			BeforeGetQryModel_Extend(beQryStrategyImpl);
		    
			CaseModel caseModel = beQryStrategyImpl.GetQryModel();
		    
			AfterGetQueryModel_Extend(caseModel);
		    
			QryService.SetCaseModelToSession((BaseWebForm)(this.CurrentPart), caseModel);
		}
        
        
         #endregion
         

	}
}
