








namespace UFIDA.U9.Cust.Pub.WSLogRSV.Proxy
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

    [System.ServiceModel.ServiceContractAttribute(Namespace = "UFIDA.U9.Cust.Pub.WSLogRSV")]
    public interface ICreateBeforeCallWSLogSV
    {
		[OperationContract()]
		System.Int64 Do(UFSoft.UBF.Service.ISVContext context ,UFIDA.U9.Cust.Pub.WSLogRSV.WSLogDTOData wSLogDTO);
    }

    [Serializable]    
    public class CreateBeforeCallWSLogSVProxy : ServiceProxyBase//, UFIDA.U9.Cust.Pub.WSLogRSV.Proxy.ICreateBeforeCallWSLogSV
    {
	#region Fields	
				private UFIDA.U9.Cust.Pub.WSLogRSV.WSLogDTOData wSLogDTO ;
			
	#endregion	
		
	#region Properties
	
				

		/// <summary>
		/// 服务日志DTO (该属性可为空,且无默认值)
		/// 创建调用前日志服务.Misc.服务日志DTO
		/// </summary>
		/// <value>UFIDA.U9.Cust.Pub.WSLogRSV.WSLogDTO</value>
		public UFIDA.U9.Cust.Pub.WSLogRSV.WSLogDTOData WSLogDTO
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
        public CreateBeforeCallWSLogSVProxy()
        {
        }
        #endregion
        
        #region 跨site调用
        public System.Int64 Do(string targetSite)
        {
  			InitKeyList() ;
			System.Int64 result = (System.Int64)InvokeBySite<UFIDA.U9.Cust.Pub.WSLogRSV.Proxy.ICreateBeforeCallWSLogSV>(targetSite);
			return GetRealResult(result);
        }
        #endregion end跨site调用

		#region 跨组织调用
        public System.Int64 Do(long targetOrgId)
        {
  			InitKeyList() ;
			System.Int64 result = (System.Int64)InvokeByOrg<UFIDA.U9.Cust.Pub.WSLogRSV.Proxy.ICreateBeforeCallWSLogSV>(targetOrgId);
			return GetRealResult(result);
        }
		#endregion end跨组织调用

		#region Public Method
		
        public System.Int64 Do()
        {
  			InitKeyList() ;
 			System.Int64 result = (System.Int64)InvokeAgent<UFIDA.U9.Cust.Pub.WSLogRSV.Proxy.ICreateBeforeCallWSLogSV>();
			return GetRealResult(result);
        }
        
		protected override object InvokeImplement<T>(T oChannel)
        {
			IContext context = ContextManager.Context;			

            ICreateBeforeCallWSLogSV channel = oChannel as ICreateBeforeCallWSLogSV;
            if (channel != null)
            {
			UFSoft.UBF.Service.ISVContext isvContext =  GetISVContext(context);
			return channel.Do(isvContext , wSLogDTO);

	    }
            return  (System.Int64)0;
        }
		#endregion
		
		//处理由于序列化导致的返回值接口变化，而进行返回值的实际类型转换处理．
		private System.Int64 GetRealResult(System.Int64 result)
		{

				return result ;
		}
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

