







namespace UFIDA.U9.Cust.Pub.WSM.WSTokenSV
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.Runtime.Serialization;
	using System.IO;
	using UFSoft.UBF.Util.Context;
	using UFSoft.UBF;
	using UFSoft.UBF.Exceptions;
	using UFSoft.UBF.Service.Base ;

    /// <summary>
    ///  ICleanWSTokenSV Interface
    /// </summary>
    [System.ServiceModel.ServiceContractAttribute(Namespace = "UFIDA.U9.Cust.Pub.WSM.WSTokenSV")]
    public interface ICleanWSTokenSV
    {
	[OperationContract()]
        void Do(UFSoft.UBF.Service.ISVContext context );
    }

    /// <summary>
    ///  CleanWSTokenSVStub Class
    /// </summary>
    [UFSoft.UBF.Service.ServiceImplement]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CleanWSTokenSVStub : ISVStubBase, ICleanWSTokenSV
    {
        #region ICleanWSTokenSV Members

        //[OperationBehavior]
        public void Do(UFSoft.UBF.Service.ISVContext context )
        {
			
			ICommonDataContract commonData = CommonDataContractFactory.GetCommonData(context);
			DoEx(commonData);
        }
        
        //[OperationBehavior]
        public void DoEx(ICommonDataContract commonData)
        {
			this.CommonData = commonData ;
            try
            {
                BeforeInvoke("UFIDA.U9.Cust.Pub.WSM.WSTokenSV.CleanWSTokenSV");                
                CleanWSTokenSV objectRef = new CleanWSTokenSV();

				//处理返回类型.
				objectRef.Do(); //没有返回值

	        }
			catch (System.Exception e)
            {
				DealException(e);
				throw;
            }
            finally
            {
				FinallyInvoke("UFIDA.U9.Cust.Pub.WSM.WSTokenSV.CleanWSTokenSV");
            }
        }
	#endregion
    }
}
