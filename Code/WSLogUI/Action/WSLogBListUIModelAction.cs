/**************************************************************
 * Description:
 * WSLogBListUIModelAction.cs
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

namespace UFIDA.U9.Cust.Pub.WSLogBListUIModel
{
	public partial class WSLogBListUIModelAction : BaseAction
	{
		private static readonly ILogger logger = LoggerManager.GetLogger(typeof(WSLogBListUIModelAction));
		//强类型化基类Model属性.
		public new WSLogBListUIModelModel CurrentModel 
		{
			get {
				return (WSLogBListUIModelModel)base.CurrentModel;
			}
			set {
				base.CurrentModel = value ;
			}
		}
		
		public WSLogBListUIModelAction(IPart part) : base(part)
		{
		}
		//Model参数的构造,用于测试用例.
		public WSLogBListUIModelAction(WSLogBListUIModelModel model) : base(model)
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
		public void BtnDoRequest(object sender, UIActionEventArgs e)
		{
			//调用基类委托..
			this.InvokeAction(sender,e,this.BtnDoRequest_Extend);
		}
		private void BtnDoRequest_DefaultImpl(object sender, UIActionEventArgs e)
		{
	  
	 

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
		/// <summary>
		/// Help: 
		/// </summary>
		public void BtnShowContent(object sender, UIActionEventArgs e)
		{
			//调用基类委托..
			this.InvokeAction(sender,e,this.BtnShowContent_Extend);
		}
		private void BtnShowContent_DefaultImpl(object sender, UIActionEventArgs e)
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

			BEQueryStrategyImpl beQryStrategyImpl = new BEQueryStrategyImpl(this.CurrentState, "UFIDA.U9.Cust.Pub.WSLogBE.WSLog", "3e403ab4-5431-490c-ac51-3f1b2826ccfa", UIGrid.UIView, UIGrid, 1);

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
			BEQueryStrategyImpl beQryStrategyImpl = new BEQueryStrategyImpl(this.CurrentState, "UFIDA.U9.Cust.Pub.WSLogBE.WSLog", "3e403ab4-5431-490c-ac51-3f1b2826ccfa", UIGrid.UIView, UIGrid, 1);
			beQryStrategyImpl.QueryComponentXMLCompressed = @"7b0HYBxJliUmL23Ke39K9UrX4HShCIBgEyTYkEAQ7MGIzeaS7B1pRyMpqyqBymVWZV1mFkDM7Z28
995777333nvvvfe6O51OJ/ff/z9cZmQBbPbOStrJniGAqsgfP358Hz8ifo1f89f4NX6N/5se/MTz
6+GXP/V3f/x7vFuU6WVeN0W1/Oyj3fHOR2m+nFazYnnx2Ufr9nz74KPf4+jxT6zz+vqkWqyqZb5s
02L22UcP9vdn0+nOZHu2d/5we/9BNt3Odu9T+3s79w6yyb1PP713/6N0mS3yzz767uvn1cXzoml/
or7+KJ0VzarMrl/EvsqbaV2sWkbmo3Selyv85O7fXK+oPZrqB1+9Ovvso3v5/s69bLK/fX//3u72
/sMdQmN6f3f73vnuZO9g79Pp9DzT9q+rdT3Nn63LUrr+6tnZ0+PxVw/HJ+umHb9cT8aMzJNT+flR
+tXZTxb51dM6u5C+8dvT6mr5UfoqPz9bnlfPq2wmX51k03n+0dHjJ1lTTPEV02gyOZhN8t18+0H2
6WR7/zyfbT/M7z/c3tmd3ZtOZg93z/M9Q6MOXQZpQV2/qd7m/NmrqmqfUrOTatnm79qfzMo1v/qs
KNu8fpNNfrJoiklJn72p1/lH6UlVrhfL/uevq7rtfypQTt+tsuXseX6Zl0RtA6P7KSB0P7tL5Hip
lGJyPDw4P9jJzmfb9/bzT7f392a725M94pu9+7OD+9nD6YNs573J8bKufjqftmdPvT9eZu0cfz55
edbmC/nqycsvV3md4XX54OmbL803xxfE1E/L0vuLIL27xt80iK/O/EHQjO5m+5MH23vZQba9f392
bzu79+D+9qf3DmZ7e7v3Ht6bZN/kIL46+6Ka5aUZye6Dh5OD/XyynX+6Tyy1fzAlGj58uD3d2Zve
n+3tZvcPZnjpWVUvzDv3z+9P8gfTve2DfJfe2dm9vz052Hu4vXeeP9h7OJ2cn2f3XEf0QpZNdx7M
7t/bnuznU+LbvfPtyWQn356cP9zN9u7NPt09nzFphEWe5ufFMm/CP5lYe/ce7O9Ndx9s33u4f297
P9/Ntg8I8vbO3sPZ/uzhvXPq3xDrVf6L1nnTMi8v2w7pel8OEDKr6WtD7eOyyJr+u2fNs+JdTtg9
y8omx9/HZVldPSmz5VvD+x1RgJA9K/JyFpe0F0Q40QMgOTXP2vypoC8fk6hmRZOfzLPlRT47vSQ8
vO6frIty9t15Xuev29p0Kexa1VB4n31EGD4v3uaj01+0zsrRi6qVXz6v8wySTnBHz/Om4V+8D6WV
+Ub+Olvi/TO8cN4y0FfFxVx+O2tekHrk7+W3J3l7lefL3mSLetudnu/v7u3QxO7R7D442N/Ozvcf
bt8jQbj/cHrv3uThzM1uQ8aDSDAwvd1v32t+Oy//aIK/3gTf7YizqPronzz/n+4/fLC3++ne9uT+
vT0wQb79cG92sP0pGbb9fH+2s7/zqZn/0zJbNfnsdT6tlrPO7He/e4+577zanfnbzvJP5XV11pwu
Vu21fTcyxy/rfFrAU5IPXrdkT6YfpS/Wi7wupvIh/THBX9S6KsAFYgnvdohJv2Trsj3Jmly9BiF+
E/wlFufBhDyq8wfbsyl5N/v7kx3yImZkNvMHB7sPZw/u5w/vGTKflFnTgEYdEv+Xf/Pf+5//SX/8
IG3v9nvN7+3snB/cm24/YMdq7x7ZuU8/Jd9ltvcgJ7/vHhsN6fWLvJ1Xs0i3/8Wf8Xf/F3/rn/6e
PU/v57MHGfV878Gn+fb+lGzWw4zMx4OdT3cf5Oezg+nujumZpoBcl6LX8X/+9/1B//lf+cf+F3/m
3/Ff/5l/2/v0nU9zsrA759t5RgPef5jvbWcz+u3+g7098lB27z/ctSrtdDmL9Pxf/r1/6n/x5/+F
79/zZLpPrvPO/W2QfXt/9wE5Rw8+3dnOdnYe7uXnDw8mjt4bTeV/9Tf+nf/F3/yH/Od/xB/+n/8N
f/f7IHC+s79/7zwnV+IAZN+D+d+dkXBPDib39mZ7NCu7ls2ysiS1Swzc7fxv+kP/yz/trwIN/oI/
7306f/jp9F4+23+w/eD8IUxJRi7KvZ2D7YPsQXZA/HZA3o6le11X9Rek8rKLLvH/6z/tz/6v/sa/
8T/7B//i/+IP/hvfp/udg4ez+5+So54/nJAmm2W72+QD7ZNXle/uEuXzhw+tUyfM/tTBjvL8f/En
/on/1T/4N23C4W4o9UYhsJqw2la8qAcH93f2cpqU2T1ijQd7ZGdpRrZ3yRV7+HB2cO/+w70PVwB+
h/fz7P7u7h6pGNLu+/u7n5Ji379PkdUBMeb9/Wm2Z1nhw2Tf63TnYLqfze6T+XiQI6Dcz8ibABPS
oPcf3KcxTqyv+E3Ngdf9/s6D++SR5tt7nx5QcHJ/l0Tv/s7ONqm5A3Kr72UHD60x+1Ct43W7e28y
eXA+Od9+kO8Qqaf3ifH3zs+3zylafHh/79NPJ/uW8z5M4Xidkhd/j+CTV0/xyvZ+dp+0HPn027uf
zmZ72f7u7P7+/m0M93/+J/wR1O/Wf/lX/il3btnzvb0Hu9M94qwJ69e9ndl2tr8/JYP26YOd7GA2
/fRe/o0pGa/fT3cO7u0jPfFwSgEn6ReyoQ/gr+xSYPPwfH8/e2j7/Qb0i9fzZPfB/v3swc72dH9n
n/Q6eUoPc/rtAcltNjm/n+/cd9abRnxSrQdU+n/x1/3F/8WfvlmldJWI/o3onP7CD2G6892D84cP
P92mTAnmPyOFcjDb2b7/KU3P+YPJ/YcPDyxO7GzOvuyK2CAenEyQfMnp65MAL8XDosnOz90wuXT0
G/4aP3p+9Pzo+dHzo+dHz4+eHz0/en70/Oj50fOj52s//w8=";
		    
			BeforeGetQryModel_Extend(beQryStrategyImpl);
		    
			CaseModel caseModel = beQryStrategyImpl.GetQryModel();
		    
			AfterGetQueryModel_Extend(caseModel);
		    
			QryService.SetCaseModelToSession((BaseWebForm)(this.CurrentPart), caseModel);
		}
        
        
         #endregion
         

	}
}
