







namespace UFIDA.U9.Cust.Pub.WSLogSV
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

    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.UFIDA.org", Name="UFIDA.U9.Cust.Pub.WSLogSV.ICreateWSLogSV")]
    public interface ICreateWSLogSV
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
        void Do(IContext context ,out IList<MessageBase> outMessages ,UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTOData wSLogDTO);
    }

    [UFSoft.UBF.Service.ServiceImplement]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CreateWSLogSVStub : ServiceStubBase, ICreateWSLogSV
    {
        #region ICreateWSLogSV Members

        //[OperationBehavior]
        public void Do(IContext context ,out IList<MessageBase> outMessages, UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTOData wSLogDTO)
        {
			
			ICommonDataContract commonData = CommonDataContractFactory.GetCommonData(context, out outMessages);
			DoEx(commonData, wSLogDTO);
        }
        
        //[OperationBehavior]
        public void DoEx(ICommonDataContract commonData, UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTOData wSLogDTO)
        {
			this.CommonData = commonData ;
            try
            {
                BeforeInvoke("UFIDA.U9.Cust.Pub.WSLogSV.CreateWSLogSV");                
                CreateWSLogSV objectRef = new CreateWSLogSV();
	
				if (wSLogDTO != null)
				{
					DeSerializeKey(wSLogDTO);
					UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTO temp = new UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTO();
					temp.FromEntityData(wSLogDTO);
					objectRef.WSLogDTO = temp;
				}

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
				FinallyInvoke("UFIDA.U9.Cust.Pub.WSLogSV.CreateWSLogSV");
            }
        }
	#endregion
    }
}
