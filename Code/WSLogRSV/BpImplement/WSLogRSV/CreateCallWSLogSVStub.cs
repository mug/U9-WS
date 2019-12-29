







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
    ///  ICreateCallWSLogSV Interface
    /// </summary>
    [System.ServiceModel.ServiceContractAttribute(Namespace = "UFIDA.U9.Cust.Pub.WSLogRSV")]
    public interface ICreateCallWSLogSV
    {
	[OperationContract()]
        System.Int64 Do(UFSoft.UBF.Service.ISVContext context ,UFIDA.U9.Cust.Pub.WSLogRSV.WSLogDTOData wSLogDTO);
    }

    /// <summary>
    ///  CreateCallWSLogSVStub Class
    /// </summary>
    [UFSoft.UBF.Service.ServiceImplement]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CreateCallWSLogSVStub : ISVStubBase, ICreateCallWSLogSV
    {
        #region ICreateCallWSLogSV Members

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
                BeforeInvoke("UFIDA.U9.Cust.Pub.WSLogRSV.CreateCallWSLogSV");                
                CreateCallWSLogSV objectRef = new CreateCallWSLogSV();
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
				FinallyInvoke("UFIDA.U9.Cust.Pub.WSLogRSV.CreateCallWSLogSV");
            }
        }
	#endregion
    }
}
