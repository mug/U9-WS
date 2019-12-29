using System;
using UFIDA.U9.UI.PDHelper;

/***********************************************************************************************
 * Form ID: 
 * UIFactory Auto Generator 
 ***********************************************************************************************/

namespace WSLogUIModel
{
    public partial class WSLogUIFormWebPart
    {
        #region Custome eventBind

        //BtnSave_Click...
        private void BtnSave_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnSave_Click_DefaultImpl(sender, e);
        }

        //BtnCancel_Click...
        private void BtnCancel_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnCancel_Click_DefaultImpl(sender, e);
        }

        //BtnAdd_Click...
        private void BtnAdd_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnAdd_Click_DefaultImpl(sender, e);
        }

        //BtnDelete_Click...
        private void BtnDelete_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnDelete_Click_DefaultImpl(sender, e);
        }

        //BtnCopy_Click...
        private void BtnCopy_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnCopy_Click_DefaultImpl(sender, e);
        }

        //BtnSubmit_Click...
        private void BtnSubmit_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnSubmit_Click_DefaultImpl(sender, e);
        }

        //BtnApprove_Click...
        private void BtnApprove_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnApprove_Click_DefaultImpl(sender, e);
        }

        //BtnFind_Click...
        private void BtnFind_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnFind_Click_DefaultImpl(sender, e);
        }

        //BtnList_Click...
        private void BtnList_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnList_Click_DefaultImpl(sender, e);
        }

        //BtnFirstPage_Click...
        private void BtnFirstPage_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnFirstPage_Click_DefaultImpl(sender, e);
        }

        //BtnPrevPage_Click...
        private void BtnPrevPage_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnPrevPage_Click_DefaultImpl(sender, e);
        }

        //BtnNextPage_Click...
        private void BtnNextPage_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnNextPage_Click_DefaultImpl(sender, e);
        }

        //BtnLastPage_Click...
        private void BtnLastPage_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnLastPage_Click_DefaultImpl(sender, e);
        }

        //BtnAttachment_Click...
        private void BtnAttachment_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnAttachment_Click_DefaultImpl(sender, e);
        }

        //BtnFlow_Click...
        private void BtnFlow_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnFlow_Click_DefaultImpl(sender, e);
        }

        //BtnOutput_Click...
        private void BtnOutput_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnOutput_Click_DefaultImpl(sender, e);
        }

        //BtnPrint_Click...
        private void BtnPrint_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnPrint_Click_DefaultImpl(sender, e);
        }

        //BtnOk_Click...
        private void BtnOk_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnOk_Click_DefaultImpl(sender, e);
        }

        //BtnClose_Click...
        private void BtnClose_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnClose_Click_DefaultImpl(sender, e);
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
            if (!this.Page.IsPostBack)
            {
                this.Model.WSLog.Clear();
                this.Model.WSLog.CurrentFilter.OPath = "ID = " + this.LogID;
                this.Action.CommonAction.Load(this.Model);
                WSLogRecord focusedRecord = this.Model.WSLog.FocusedRecord;
                if (focusedRecord != null)
                {
                    focusedRecord.RequestContentView = focusedRecord.RequestContent;
                    focusedRecord.ResponseContentView = focusedRecord.ResponseContent;
                }
            }
        }

        public void AfterCreateChildControls()
        {
            //启用页面个性化                                                                                        
            PersonalizationHelper.SetPersonalizationEnable(this, true);
        }

        public void AfterEventBind()
        {
        }

        public void BeforeUIModelBinding()
        {
        }

        public void AfterUIModelBinding()
        {
            this.Card2.ReadOnly = true;
            this.BtnOk.IsClientClose = true;
            this.BtnClose.IsClientClose = true;
        }

        #endregion

        #region 属性

        /// <summary>
        ///     LogID
        /// </summary>
        private long LogID
        {
            get { return long.Parse(this.NameValues["LogID"].ToString()); }
        }

        #endregion

        #endregion
    }
}