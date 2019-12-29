







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
    ///  IWSTokenIsExpiredSV Interface
    /// </summary>
    [System.ServiceModel.ServiceContractAttribute(Namespace = "UFIDA.U9.Cust.Pub.WSM.WSTokenSV")]
    public interface IWSTokenIsExpiredSV
    {
	[OperationContract()]
        System.Boolean Do(UFSoft.UBF.Service.ISVContext context ,UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenDTOData wSTokenDTO);
    }

    /// <summary>
    ///  WSTokenIsExpiredSVStub Class
    /// </summary>
    [UFSoft.UBF.Service.ServiceImplement]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class WSTokenIsExpiredSVStub : ISVStubBase, IWSTokenIsExpiredSV
    {
        #region IWSTokenIsExpiredSV Members

        //[OperationBehavior]
        public System.Boolean Do(UFSoft.UBF.Service.ISVContext context , UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenDTOData wSTokenDTO)
        {
			
			ICommonDataContract commonData = CommonDataContractFactory.GetCommonData(context);
			return DoEx(commonData, wSTokenDTO);
        }
        
        //[OperationBehavior]
        public System.Boolean DoEx(ICommonDataContract commonData, UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenDTOData wSTokenDTO)
        {
			this.CommonData = commonData ;
            try
            {
                BeforeInvoke("UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenIsExpiredSV");                
                WSTokenIsExpiredSV objectRef = new WSTokenIsExpiredSV();
				objectRef.WSTokenDTO = wSTokenDTO;

				//处理返回类型.
				System.Boolean result = objectRef.Do();
				return result ;

	        }
			catch (System.Exception e)
            {
				DealException(e);
				throw;
            }
            finally
            {
				FinallyInvoke("UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenIsExpiredSV");
            }
        }
	#endregion
    }
}
