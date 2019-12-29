








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
    public interface ICleanWSTokenSV
    {
		[OperationContract()]
		void Do(UFSoft.UBF.Service.ISVContext context );
    }

    [Serializable]    
    public class CleanWSTokenSVProxy : ServiceProxyBase//, UFIDA.U9.Cust.Pub.WSM.WSTokenSV.Proxy.ICleanWSTokenSV
    {
	#region Fields	
	
	#endregion	
		
	#region Properties
	
	
	#endregion	


	#region Constructors
        public CleanWSTokenSVProxy()
        {
        }
        #endregion
        
        #region 跨site调用
        public void Do(string targetSite)
        {
  			InitKeyList() ;
			InvokeBySite<UFIDA.U9.Cust.Pub.WSM.WSTokenSV.Proxy.ICleanWSTokenSV>(targetSite);
			
        }
        #endregion end跨site调用

		#region 跨组织调用
        public void Do(long targetOrgId)
        {
  			InitKeyList() ;
			InvokeByOrg<UFIDA.U9.Cust.Pub.WSM.WSTokenSV.Proxy.ICleanWSTokenSV>(targetOrgId);
			
        }
		#endregion end跨组织调用

		#region Public Method
		
        public void Do()
        {
  			InitKeyList() ;
 			InvokeAgent<UFIDA.U9.Cust.Pub.WSM.WSTokenSV.Proxy.ICleanWSTokenSV>();
			
        }
        
		protected override object InvokeImplement<T>(T oChannel)
        {
			IContext context = ContextManager.Context;			

            ICleanWSTokenSV channel = oChannel as ICleanWSTokenSV;
            if (channel != null)
            {
			UFSoft.UBF.Service.ISVContext isvContext =  GetISVContext(context);
			channel.Do(isvContext );

	    }
            return  null;
        }
		#endregion
		
		#region  Init KeyList 
		//初始化SKey集合--由于接口不一样.BP.SV都要处理
		private void InitKeyList()
		{
			System.Collections.Hashtable dict = new System.Collections.Hashtable() ;

		}
		#endregion 

    }
}

