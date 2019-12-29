







namespace UFIDA.U9.Cust.Pub.WSLogBP
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

    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.UFIDA.org", Name="UFIDA.U9.Cust.Pub.WSLogBP.IDoRequestBP")]
    public interface IDoRequestBP
    {
		[ServiceKnownType(typeof(ApplicationContext))]
		[ServiceKnownType(typeof(PlatformContext))]
		[ServiceKnownType(typeof(ThreadContext))]
		[ServiceKnownType(typeof( UFSoft.UBF.Business.BusinessException))]
		[ServiceKnownType(typeof( UFSoft.UBF.Business.EntityNotExistException))]
		[ServiceKnownType(typeof( UFSoft.UBF.Business.AttributeInValidException))]
		[ServiceKnownType(typeof(UFSoft.UBF.Business.AttrsContainerException))]
		[ServiceKnownType(typeof(UFSoft.UBF.Exceptions.MessageBase))]
			[FaultContract(typeof(UFSoft.UBF.Service.ServiceLostException))]
		[FaultContract(typeof(UFSoft.UBF.Service.ServiceException))]
		[FaultContract(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
		[FaultContract(typeof(ExceptionBase))]
		[FaultContract(typeof(Exception))]
		[OperationContract()]
        UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData Do(IContext context ,out IList<MessageBase> outMessages ,System.Int64 wSLogID);
    }

    [UFSoft.UBF.Service.ServiceImplement]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class DoRequestBPStub : OperationStubBase, IDoRequestBP
    {
        #region IDoRequestBP Members

        //[OperationBehavior]
        public UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData Do(IContext context ,out IList<MessageBase> outMessages, System.Int64 wSLogID)
        {
			
			ICommonDataContract commonData = CommonDataContractFactory.GetCommonData(context, out outMessages);
			return DoEx(commonData, wSLogID);
        }
        
        //[OperationBehavior]
        public UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData DoEx(ICommonDataContract commonData, System.Int64 wSLogID)
        {
			this.CommonData = commonData ;
            try
            {
                BeforeInvoke("UFIDA.U9.Cust.Pub.WSLogBP.DoRequestBP");                
                DoRequestBP objectRef = new DoRequestBP();
	
				objectRef.WSLogID = wSLogID;

				//处理返回类型.
				UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTO result = objectRef.Do();

				if (result == null)
					return null ;
						UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData resultdata = result.ToEntityData();
				DoSerializeKey(resultdata, "UFIDA.U9.Cust.Pub.WSLogBP.DoRequestBP");
				return resultdata;

	        }
			catch (System.Exception e)
            {
				DealException(e);
				throw;
            }
            finally
            {
				FinallyInvoke("UFIDA.U9.Cust.Pub.WSLogBP.DoRequestBP");
            }
        }
	#endregion
    }
}
