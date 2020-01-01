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
			beQryStrategyImpl.QueryComponentXMLCompressed = @"7VbNbhs3EHYvvfQBehV0p83lz3IJxAliyQYEOI0TW8mZP0Nn27VWWK0c+5YABRoUaJFDmwBNDz0U
aI5pEbRBnffoC8Q2+hTt7EpyZVluYsBH87DLIZf7zXyc+ciFjxYWFv7BVr2r9nHV+evTazf2drLG
LhSDNO8tN6NF2mxAz+U+7W0vN4dlIEnzxvVrd4ZQ7LfynX7eg17ZSP1ykzknYicMEU4GImgkiBVW
k6BNcFQyFVPZbPTMDiw3729u5V9Abz0dlHeK/WbDp4N+ZvY/mz8JA1ek/bJ2qNl4AFm/etcubO33
cUX16Xige7ez3LRx4EwHRqTzCRGBGaJd0EQwbjnHh4zd+PvNfFg4WBtm2Qi8u9Zp31zs6sXWcFAu
bgzt4v3NW4tjl1ZWJ71mo9u5l8LDdmG2Rz5UvXb+EGfuQuj0Qr6eGz+aahn3AJrXr62YQeqqqZqv
WAsqrTXE8xhdA+WIidFn5wP4iDnDRZjwNcPQuZwgdO1e3c/zso2ftfJeCXvlPZMN66VraVZCsWXs
vXSQ2gzHtoohNButPBvu9M6Ob+ZFeXZ09JfVvb7p+XXYhWy5ySf/mB2t/jA7toR0bIyZqulwLiSJ
9hFRjksilARiIkuJD94xryMQUXRROjaK/HNwZac9ZWyY8kFlrmx0StgZTa1s3O5DYarlo4H21u3J
zM1tTPB2lk1Z+Ke9/crGILqd6SA4Jp5wDoPgGhNPSke0kmgq5oLkiaRWXWYQ3c6t3EM2icQqoZhX
gWjGkEOmNEmMAGKNEkJ6kXgN1aK1vNiZrIm9YIwKThLusGyFws+TyBEf+TjyzGgQ8X9AuCCSKqK6
rm4NRGgM1GhMY0djZ0RsgYGtqWlDMMOsbJkBjHN/lDSDU1bNm4LYS0cDQluPtRBRYkTgxOLOKxpp
4MZNeOsOoGihMzP8HX/38ujJH8dvnx3/9PhcLpfOQgenYi6kIoGBI4IrRYwLMdGxZOCxF8MJ9O1i
ex7ywZfHB19dHFklIFmQGK8C3C2KWplQLQm3DqQHZlGzJsirWMNFv0gH0GnPwL97+/jdmx/q4XOh
l07TP9mZulrRHnVGKq5jIz1luLuJxQwGS5KQeDQr1fQUd+WEjlpqNstixqF6+N2b3/7PoSlEBZEO
gMF7z12VtAbzFWlwTBqnjQzO+kuiYQqVBk9VYh2h1lYHg8M4LSagtDzSMjY0StRZ1ApqLu7h02+O
f3n1gdjgtOfSKQLeVscTyj96okmkPUusZtpqejkpNwUqdayYxMLydYkZzRAUpUlSpW2Eac9kmAKd
E+kI9EKRKuES7p0hjFcpbrRAPYxRXCB2EiIMWkeXVNdTqNqoOFjhCWiDCuUi1BWeCHSCB0uVwPlT
ajIv1hr1QrHijmrHWCDc6/rSgfKlFSeGKeAc1Zebk11tFWBK2ErP4B4+eXF48OfR89//fv76Q3EZ
aBk8kGAAo42DIMaAIaghylFgAqiY4K6bQdnt+/nYRz8+Onz67dGL10fPXl3IA29QnlH38dSjHPlO
IqJDhHcuqixYZm1sT3a5M7iZpbtnoF8fHH798gPhEhpQlT3e7iSGKbTFE4uCx6gTqTRg/fgToju9
XZOlfh7TP/969P2T98e5NCuWY7u61KBVvWqvbEgiZaglkUzQq4TjTdnhnY6ZxBtWZT2N37v95zpS
X8JG98zVzdYpx8aOLJ06bpdOX9Cvf7Jw1a7aVbtq4/Yv";
		    
			BeforeGetQryModel_Extend(beQryStrategyImpl);
		    
			CaseModel caseModel = beQryStrategyImpl.GetQryModel();
		    
			AfterGetQueryModel_Extend(caseModel);
		    
			QryService.SetCaseModelToSession((BaseWebForm)(this.CurrentPart), caseModel);
		}
        
        
         #endregion
         

	}
}
