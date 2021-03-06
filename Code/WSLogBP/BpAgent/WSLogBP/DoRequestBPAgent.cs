﻿








namespace UFIDA.U9.Cust.Pub.WSLogBP.Proxy
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.IO;
	using System.ServiceModel;
	using System.Runtime.Serialization;
	using UFSoft.UBF;
	using UFSoft.UBF.Exceptions;
	using UFSoft.UBF.Util.Context;
	using UFSoft.UBF.Service;
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
		UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData Do(IContext context, out IList<MessageBase> outMessages ,System.Int64 wSLogID);
    }
	[Serializable]    
    public class DoRequestBPProxy : OperationProxyBase//, UFIDA.U9.Cust.Pub.WSLogBP.Proxy.IDoRequestBP
    {
	#region Fields	
				private System.Int64 wSLogID ;
			
	#endregion	
		
	#region Properties
	
				

		/// <summary>
		/// 服务日志ID (该属性可为空,但有默认值)
		/// 请求处理.Misc.服务日志ID
		/// </summary>
		/// <value>System.Int64</value>
		public System.Int64 WSLogID
		{
			get	
			{	
				return this.wSLogID;
			}

			set	
			{	
				this.wSLogID = value;	
			}
		}		
			
	#endregion	


	#region Constructors
        public DoRequestBPProxy()
        {
        }
        #endregion
        

		#region Public Method
		
        public UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData Do()
        {
  			InitKeyList() ;
 			UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData result = (UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData)InvokeAgent<UFIDA.U9.Cust.Pub.WSLogBP.Proxy.IDoRequestBP>();
			return GetRealResult(result);
        }
        
		protected override object InvokeImplement<T>(T oChannel)
        {
			IContext context = ContextManager.Context;			

            IDoRequestBP channel = oChannel as IDoRequestBP;
            if (channel != null)
            {
				return channel.Do(context, out returnMsgs, wSLogID);
	    }
            return  null;
        }
		#endregion
		
		//处理由于序列化导致的返回值接口变化，而进行返回值的实际类型转换处理．
		private UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData GetRealResult(UFIDA.U9.Cust.Pub.WSLogBP.RequestResultDTOData result)
		{

				return result ;
		}
		#region  Init KeyList 
		//初始化SKey集合--由于接口不一样.BP.SV都要处理
		private void InitKeyList()
		{
			System.Collections.Hashtable dict = new System.Collections.Hashtable() ;
					
		}
		#endregion 

    }
}



