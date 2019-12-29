using UFIDA.UBF.Query.CaseModel;
using UFIDA.UBF.Query.CommonService.QueryStrategy;
using UFSoft.UBF.UI.ActionProcess;
using UFSoft.UBF.UI.ControlModel;

namespace UFIDA.U9.Cust.Pub.WSLogBListUIModel
{
    public partial class WSLogBListUIModelAction
    {
        public override void OnInitAction()
        {
            base.OnInitAction();
            //提示:可注册你自己的方法到相应的事件中,如下.
            //this.CommonAction.BeforeLoad += new ActionLoadDelegate(CommonAction_BeforeLoad);
        }

        private void OnLookCase_Extend(object sender, UIActionEventArgs e)
        {
            //调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            OnLookCase_DefaultImpl(sender, e);
        }

        private void OnCaseChanged_Extend(object sender, UIActionEventArgs e)
        {
            //调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            OnCaseChanged_DefaultImpl(sender, e);
        }

        private void OnOutPut_Extend(object sender, UIActionEventArgs e)
        {
            //调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            OnOutPut_DefaultImpl(sender, e);
        }

        private void OnGridRowDbClick_Extend(object sender, UIActionEventArgs e)
        {
            //List Grid RowDbClic Code Demo...
            //string DataID = this.CurrentModel.PositionType.FocusedRecord.ID.ToString();
            //string CardPageID="Test";//在这里CardPageID表示卡片的URI
            //OnNavigatCard("Browse", DataID, CardPageID);
            //调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            OnGridRowDbClick_DefaultImpl(sender, e);
        }

        private void OnNew_Extend(object sender, UIActionEventArgs e)
        {
            //调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            OnNew_DefaultImpl(sender, e);
        }

        private void OnPrint_Extend(object sender, UIActionEventArgs e)
        {
            //调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            OnPrint_DefaultImpl(sender, e);
        }

        private void OnDelete_Extend(object sender, UIActionEventArgs e)
        {
            //调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            OnDelete_DefaultImpl(sender, e);
        }

        private void BtnDoRequest_Extend(object sender, UIActionEventArgs e)
        {
            //调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            BtnDoRequest_DefaultImpl(sender, e);
        }

        private void BtnShowContent_Extend(object sender, UIActionEventArgs e)
        {
            //调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            BtnShowContent_DefaultImpl(sender, e);
        }

        private void btnSaveCurrentQueryCase_Extend(object sender, UIActionEventArgs e)
        {
            //调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            btnSaveCurrentQueryCase_DefaultImpl(sender, e);
        }

        #region UBF 内置两数据处理Action

        //数据加载的扩展
        private void OnLoadData_Extend(object sender, UIActionEventArgs e)
        {
            OnLoadData_DefaultImpl(sender, e);
        }

        //数据收集的扩展
        private void OnDataCollect_Extend(object sender, UIActionEventArgs e)
        {
            OnDataCollect_DefaultImpl(sender, e);
        }

        #endregion

        #region 列表应用开发人员扩展代码段

        private string CustomFilterOpath_Extend(string filterOpath)
        {
            return filterOpath;
        }

        private void AfterQryAdjust_Extend(IUFDataGrid UIGrid)
        {
        }


        private void BeforeGetQryModel_Extend(BEQueryStrategyImpl beQryStrategyImpl)
        {
        }

        private void AfterGetQueryModel_Extend(CaseModel caseModel)
        {
        }

        #endregion
    }
}