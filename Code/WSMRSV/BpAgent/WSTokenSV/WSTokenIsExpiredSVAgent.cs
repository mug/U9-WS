








namespace UFIDA.U9.Cust.Pub.WSM.WSTokenSV.Proxy
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

    [System.ServiceModel.ServiceContractAttribute(Namespace = "UFIDA.U9.Cust.Pub.WSM.WSTokenSV")]
    public interface IWSTokenIsExpiredSV
    {
		[OperationContract()]
		System.Boolean Do(UFSoft.UBF.Service.ISVContext context ,UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenDTOData wSTokenDTO);
    }

    [Serializable]    
    public class WSTokenIsExpiredSVProxy : ServiceProxyBase//, UFIDA.U9.Cust.Pub.WSM.WSTokenSV.Proxy.IWSTokenIsExpiredSV
    {
	#region Fields	
				private UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenDTOData wSTokenDTO ;
			
	#endregion	
		
	#region Properties
	
				

		/// <summary>
		/// 服务TokenDTO (该属性可为空,且无默认值)
		/// Toke是否失效服务.Misc.服务TokenDTO
		/// </summary>
		/// <value>UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenDTO</value>
		public UFIDA.U9.Cust.Pub.WSM.WSTokenSV.WSTokenDTOData WSTokenDTO
		{
			get	
			{	
				return this.wSTokenDTO;
			}

			set	
			{	
				this.wSTokenDTO = value;	
			}
		}		
			
	#endregion	


	#region Constructors
        public WSTokenIsExpiredSVProxy()
        {
        }
        #endregion
        
        #region 跨site调用
        public System.Boolean Do(string targetSite)
        {
  			InitKeyList() ;
			System.Boolean result = (System.Boolean)InvokeBySite<UFIDA.U9.Cust.Pub.WSM.WSTokenSV.Proxy.IWSTokenIsExpiredSV>(targetSite);
			return GetRealResult(result);
        }
        #endregion end跨site调用

		#region 跨组织调用
        public System.Boolean Do(long targetOrgId)
        {
  			InitKeyList() ;
			System.Boolean result = (System.Boolean)InvokeByOrg<UFIDA.U9.Cust.Pub.WSM.WSTokenSV.Proxy.IWSTokenIsExpiredSV>(targetOrgId);
			return GetRealResult(result);
        }
		#endregion end跨组织调用

		#region Public Method
		
        public System.Boolean Do()
        {
  			InitKeyList() ;
 			System.Boolean result = (System.Boolean)InvokeAgent<UFIDA.U9.Cust.Pub.WSM.WSTokenSV.Proxy.IWSTokenIsExpiredSV>();
			return GetRealResult(result);
        }
        
		protected override object InvokeImplement<T>(T oChannel)
        {
			IContext context = ContextManager.Context;			

            IWSTokenIsExpiredSV channel = oChannel as IWSTokenIsExpiredSV;
            if (channel != null)
            {
			UFSoft.UBF.Service.ISVContext isvContext =  GetISVContext(context);
			return channel.Do(isvContext , wSTokenDTO);

	    }
            return  false;
        }
		#endregion
		
		//处理由于序列化导致的返回值接口变化，而进行返回值的实际类型转换处理．
		private System.Boolean GetRealResult(System.Boolean result)
		{

				return result ;
		}
		#region  Init KeyList 
		//初始化SKey集合--由于接口不一样.BP.SV都要处理
		private void InitKeyList()
		{
			System.Collections.Hashtable dict = new System.Collections.Hashtable() ;
						{
				if (WSTokenDTO != null)
				{
					WSTokenDTO.DoSerializeKeyList(dict);
				}
			}
		
		}
		#endregion 

    }
}

