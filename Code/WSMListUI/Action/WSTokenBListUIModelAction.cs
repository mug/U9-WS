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
			beQryStrategyImpl.QueryComponentXMLCompressed = @"7VZPbxtFFA8XLnwArpbvk8zMzl+padXYiWQppWkTt+f5my5svNZ6nSa3VkKiQgL1AK1EOXBAoseC
KqhIvwdfoEnEp4C3azs4jkMbKcfMwd73Zmd/v/eb997MwkcLCwv/wKj+q/Fx9fDXp9du7O1kjd1Q
DNK8t9wki7jZCD2X+7S3vdwclhGp5o3r1+4MQ7Hfynf6eS/0ykbql5vUOSYcM4g5HhHDhCHLrEZR
m+gwp1Jg3mz0zE5Ybt7f3Mq/CL31dFDeKfabDZ8O+pnZ/2z+ZBi4Iu2XNaFm40HI+tV/TWFrvw8r
qlfHju7dznLTiphQHSnizivEIjVIu6gRo4lNEvjhwo3f38yHhQtrwywbgXfXOu2bi1292BoOysWN
oV28v3lrcUxpZXXy1Gx0O/fS8LBdmO0Rh+qpnT+EmbshdnoxX8+NH021jHsQmtevrZhB6qqpWi+h
GebWGuQTAdSCdMgI4Ox8DJ5QZxIWJ3rNKHSuJgBd06uf87xsw2utvFeGvfKeyYb10rU0K0OxZey9
dJDaDHxbxTA0G608G+70zvo386I86x19ZXWvb3p+PeyGbLmZTL4x662+MOtbAjk2xkrVcjgXldKe
IOkSjpjkARliMfLRO+o1CYyQi8qxUeSfB1d22lPGhikfVObKRqcMO6OplY3b/VCYavnI0d66PZm5
uQ0J3s6yKQu+tLdf2RBEtzMdRAKJx5yDIBINice5Q1pyMCV1kSeKYysvM4hu51buQzaJxEomqZcR
aUpBQyo1UoYFZI1kjHumvA7VorW82JmsEZ5RilmCVOKgbJmE1xVxyBMviKdGByb+A4IFhEuCdV3d
OiCmIVCjIY0dFs4wYQMNtpamHaIZZmXLDMI490dJMzhljWpBOWmcishZ54BEwqBgbUTYYK6YFCZw
O9GtOwhFC8jM6Hf83cujJ38cv312/NPjc7VcOgvtjAzcWImwgJiAP4QD/QGJqDhPRBJsOIG+XWzP
Qz748vjgq4sjexu1CgaixMQiZqRHymmPoqSCU6skUSfJsgo1XPSLdBA67Rn4d28fv3vzQ+0+F3rp
tPyTnamrFezRQ00qSIuF4AyZgD1iyhKkKLQmxjGB3PY4Oj8hVbeazbKYIVS737357f8ITSFKI3i0
SiNuvUAs0ZBZ0WnkrdbGOyk8FZckwxSqVlxKhh3CBJKdRQ+lEmJAngcZwEcFC2dRK6i5uIdPvzn+
5dUHYidGJTLATlNFoIJwFMgSoxG0Dpw4BoeTIJeTclOgUP5c0yrHKJeIeQ/9VdOIoFwd5QkBB54C
nRPpCPRCkTpAYBK01dxDQzIe2oyEmC02NnECwmXykup6ClVBB+JEGihkX+UwtwhsCJUIqgxWnAoz
jTov1hr1QrHGGKJUDgQmECZTkSAN1QR9JeEmWqOoOBG4VQRThq30DO7hkxeHB38ePf/97+evPxCX
wR1CM0GQCITAxjINcUM2BTgIDMGUBacmuOtmUHb7fj720Y+PDp9+e/Ti9dGzVxdigAPjJgiLlIbi
ZY6K6rrFERxH0LgVJoqc7HJncDNLd89Avz44/PrlhwodsMDOwdVACNjeAJmlva9OLEGp1oR6cyJ0
p7drstTPU/rnX4++f/L+OJdmm+XYri41YFV/I1aYywSyCwmqXZXqsP3QxxHW0FYUHHBEqfdu/7lE
6kvY6J65utk6RWxMZOnUcbt0+oJ+/ZOFq3E1rsbVGI9/AQ==";
		    
			BeforeGetQryModel_Extend(beQryStrategyImpl);
		    
			CaseModel caseModel = beQryStrategyImpl.GetQryModel();
		    
			AfterGetQueryModel_Extend(caseModel);
		    
			QryService.SetCaseModelToSession((BaseWebForm)(this.CurrentPart), caseModel);
		}
        
        
         #endregion
         

	}
}
