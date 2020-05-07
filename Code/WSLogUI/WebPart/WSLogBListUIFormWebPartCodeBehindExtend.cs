using System;
using System.Collections.Specialized;
using UFIDA.U9.Cust.Pub.WSLogBE;
using UFIDA.U9.Cust.Pub.WSLogBP;
using UFIDA.U9.Cust.Pub.WSLogBP.Proxy;
using UFIDA.UBF.Query.CommonService;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.WebControls;

/***********************************************************************************************
 * Form ID: 
 * UIFactory Auto Generator 
 ***********************************************************************************************/

namespace UFIDA.U9.Cust.Pub.WSLogBListUIModel
{
    public partial class WSLogBListUIFormWebPart
    {
        #region Custome eventBind

        //BtnNew_Click...
        private void BtnNew_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnNew_Click_DefaultImpl(sender, e);
        }

        //BtnDelete_Click...
        private void BtnDelete_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnDelete_Click_DefaultImpl(sender, e);
        }

        //BtnOutPut_Click...
        private void BtnOutPut_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnOutPut_Click_DefaultImpl(sender, e);
        }

        //BtnPrint_Click...
        private void BtnPrint_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnPrint_Click_DefaultImpl(sender, e);
        }


        //DDLCase_TextChanged...
        private void DDLCase_TextChanged_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            DDLCase_TextChanged_DefaultImpl(sender, e);
        }

        //OnLookCase_Click...
        private void OnLookCase_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            OnLookCase_Click_DefaultImpl(sender, e);
        }

        //btnSaveCurrentQueryCase_Click...
        private void btnSaveCurrentQueryCase_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //btnSaveCurrentQueryCase_Click_DefaultImpl(sender, e);
            QryService.SaveQueryCaseColumnsWidth(Action, sender, e);
        }

        //BtnDoRequest_Click...
        private void BtnDoRequest_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnDoRequest_Click_DefaultImpl(sender, e);
            //重新请求
            DoRequest();
        }

        //BtnShowContent_Click...
        private void BtnShowContent_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnShowContent_Click_DefaultImpl(sender, e);
            //显示请求内容
            DoShowContent();
        }


        //DataGrid1_GridRowDbClicked...
        private void DataGrid1_GridRowDbClicked_Extend(object sender, GridDBClickEventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            DataGrid1_GridRowDbClicked_DefaultImpl(sender, e);
            //显示请求内容
            DoShowContent();
        }

        #region 自定义数据初始化加载和数据收集

        private void OnLoadData_Extend(object sender)
        {
            OnLoadData_DefaultImpl(sender);
        }

        private void OnDataCollect_Extend(object sender)
        {
            OnDataCollect_DefaultImpl(sender);
        }

        #endregion

        #region 自己扩展 Extended Event handler 

        public void AfterOnLoad()
        {
            AfterOnLoad_Qry_DefaultImpl(); //BE列表自动产生的代码
        }

        public void AfterCreateChildControls()
        {
            AfterCreateChildControls_Qry_DefaultImpl(); //BE列表自动产生的代码
        }

        public void AfterEventBind()
        {
        }

        public void BeforeUIModelBinding()
        {
        }

        public void AfterUIModelBinding()
        {
            AfterUIModelBinding_Qry_DefaultImpl(); //BE列表自动产生的代码
            //新增
            BtnNew.Visible = false;
        }

        #endregion

        #region 方法

        /// <summary>
        ///     重新请求
        /// </summary>
        private void DoRequest()
        {
            Model.ClearErrorMessage();
            WSLogRecord focusedRecord = Model.WSLog.FocusedRecord;
            if (focusedRecord == null) return;
            long wsLogID = focusedRecord.ID;
            DoRequestBPProxy proxy = new DoRequestBPProxy();
            proxy.WSLogID = wsLogID;
            RequestResultDTOData resultData = proxy.Do();
            if (Model.ErrorMessage.hasErrorMessage || Model.ErrorMessage.hasChildMessage) return;
            Action.NavigateAction.Refresh(DataGrid1);
            if (resultData.CallResult != (int) CallResultEnumData.Success)
            {
                IUIModel iModel = Model;
                WSLogRecord record = Model.WSLog.Records.FindByKey(wsLogID) as WSLogRecord;
                Model.WSLog.FocusedRecord = record;
                Model.ErrorMessage.SetErrorMessage(ref iModel, Model.WSLog.EntityFullName,
                    "ID", false, wsLogID, resultData.ErrorMessage);
            }
        }

        /// <summary>
        /// 显示请求内容
        /// </summary>

        private void DoShowContent()
        {
            Model.ClearErrorMessage();
            WSLogRecord focusedRecord = Model.WSLog.FocusedRecord;
            if (focusedRecord == null) return;
            long wsLogID = focusedRecord.ID;
            NameValueCollection nv=new NameValueCollection();
            nv.Add("LogID",wsLogID.ToString());
            const string formID = "37eefa0b-f334-42e2-bc3b-b0ce3c43cb31";
            this.ShowAtlasModalDialog(formID, "请求内容", "1002", "514", this.TaskId.ToString(), nv, false, false,
                false);
        }

        #endregion

        #endregion
    }
}