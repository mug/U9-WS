







namespace UFIDA.U9.Cust.Pub.WSLogRSV
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
    ///  ICreateAfterCallWSLogSV Interface
    /// </summary>
    [System.ServiceModel.ServiceContractAttribute(Namespace = "UFIDA.U9.Cust.Pub.WSLogRSV")]
    public interface ICreateAfterCallWSLogSV
    {
	[OperationContract()]
        System.Int64 Do(UFSoft.UBF.Service.ISVContext context ,UFIDA.U9.Cust.Pub.WSLogRSV.WSLogDTOData wSLogDTO);
    }

    /// <summary>
    ///  CreateAfterCallWSLogSVStub Class
    /// </summary>
    [UFSoft.UBF.Service.ServiceImplement]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CreateAfterCallWSLogSVStub : ISVStubBase, ICreateAfterCallWSLogSV
    {
        #region ICreateAfterCallWSLogSV Members

        //[OperationBehavior]
        public System.Int64 Do(UFSoft.UBF.Service.ISVContext context , UFIDA.U9.Cust.Pub.WSLogRSV.WSLogDTOData wSLogDTO)
        {
			
			ICommonDataContract commonData = CommonDataContractFactory.GetCommonData(context);
			return DoEx(commonData, wSLogDTO);
        }
        
        //[OperationBehavior]
        public System.Int64 DoEx(ICommonDataContract commonData, UFIDA.U9.Cust.Pub.WSLogRSV.WSLogDTOData wSLogDTO)
        {
			this.CommonData = commonData ;
            try
            {
                BeforeInvoke("UFIDA.U9.Cust.Pub.WSLogRSV.CreateAfterCallWSLogSV");                
                CreateAfterCallWSLogSV objectRef = new CreateAfterCallWSLogSV();
				objectRef.WSLogDTO = wSLogDTO;

				//处理返回类型.
				System.Int64 result = objectRef.Do();
				return result ;

	        }
			catch (System.Exception e)
            {
				DealException(e);
				throw;
            }
            finally
            {
				FinallyInvoke("UFIDA.U9.Cust.Pub.WSLogRSV.CreateAfterCallWSLogSV");
            }
        }
	#endregion
    }
}
