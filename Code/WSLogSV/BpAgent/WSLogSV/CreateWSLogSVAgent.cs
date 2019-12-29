








namespace UFIDA.U9.Cust.Pub.WSLogSV.Proxy
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
		void Do(IContext context, out IList<MessageBase> outMessages ,UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTOData wSLogDTO);
    }
	[Serializable]    
    public class CreateWSLogSVProxy : ServiceProxyBase//, UFIDA.U9.Cust.Pub.WSLogSV.Proxy.ICreateWSLogSV
    {
	#region Fields	
				private UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTOData wSLogDTO ;
			
	#endregion	
		
	#region Properties
	
				

		/// <summary>
		/// 服务日志DTO (该属性可为空,且无默认值)
		/// 创建服务日志服务.Misc.服务日志DTO
		/// </summary>
		/// <value>UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTO</value>
		public UFIDA.U9.Cust.Pub.WSLogSV.WSLogDTOData WSLogDTO
		{
			get	
			{	
				return this.wSLogDTO;
			}

			set	
			{	
				this.wSLogDTO = value;	
			}
		}		
			
	#endregion	


	#region Constructors
        public CreateWSLogSVProxy()
        {
        }
        #endregion
        
        #region 跨site调用
        public void Do(string targetSite)
        {
  			InitKeyList() ;
			InvokeBySite<UFIDA.U9.Cust.Pub.WSLogSV.Proxy.ICreateWSLogSV>(targetSite);
			
        }
        #endregion end跨site调用

		#region 跨组织调用
        public void Do(long targetOrgId)
        {
  			InitKeyList() ;
			InvokeByOrg<UFIDA.U9.Cust.Pub.WSLogSV.Proxy.ICreateWSLogSV>(targetOrgId);
			
        }
		#endregion end跨组织调用

		#region Public Method
		
        public void Do()
        {
  			InitKeyList() ;
 			InvokeAgent<UFIDA.U9.Cust.Pub.WSLogSV.Proxy.ICreateWSLogSV>();
			
        }
        
		protected override object InvokeImplement<T>(T oChannel)
        {
			IContext context = ContextManager.Context;			

            ICreateWSLogSV channel = oChannel as ICreateWSLogSV;
            if (channel != null)
            {
				channel.Do(context, out returnMsgs, wSLogDTO);
	    }
            return  null;
        }
		#endregion
		
		#region  Init KeyList 
		//初始化SKey集合--由于接口不一样.BP.SV都要处理
		private void InitKeyList()
		{
			System.Collections.Hashtable dict = new System.Collections.Hashtable() ;
						{
				if (WSLogDTO != null)
				{
					WSLogDTO.DoSerializeKeyList(dict);
				}
			}
		
		}
		#endregion 

    }
}



