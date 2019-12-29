using System;
using System.Collections;
using System.Collections.Generic ;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenBE
{
	
	/// <summary>
	/// 实体: 服务Token
	/// 
	/// </summary>
	[Serializable]	
	public  partial class WSToken : UFSoft.UBF.Business.BusinessEntity
	{





		#region Create Instance
		/// <summary>
		/// Constructor
		/// </summary>
		public WSToken(){
		}


	
		/// <summary>
		/// Create Instance
		/// </summary>
		/// <returns>Instance</returns>
		public  static WSToken Create() {
			WSToken entity = (WSToken)UFSoft.UBF.Business.Entity.Create(CurrentClassKey, null);
																																																												 
			return entity;
		}

		/// <summary>
		/// use for Serialization
		/// </summary>
		protected WSToken(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
			:base(info,context)
		{
		}
		protected override bool IsMainEntity
		{
			get { return true ;}
		}
		#endregion

		#region Create Default 
		/// <summary>
		/// Create Instance
		/// </summary>
		/// <returns>Default Instance</returns>
		public static WSToken CreateDefault() {
		#if Test		
			return CreateDefault_Extend() ;
		#else 
		    return null;
		#endif
		}
		/// <summary>
		/// Create DefaultComponent
		/// </summary>
		/// <returns>DefaultComponent Instance</returns>
		public static WSToken CreateDefaultComponent(){
		#if Test		
			return CreateDefaultComponent_Extend() ;
		#else 
		    return null;
		#endif
		}

		#endregion

		#region ClassKey
		protected override string ClassKey_FullName
        {
            get { return "UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken"; }    
        }
		//private static UFSoft.UBF.PL.IClassKey _currentClassKey;
		//由于可能每次访问时的Enterprise不一样，所以每次重取.
		private static UFSoft.UBF.PL.IClassKey CurrentClassKey
		{
			get {
				return  UFSoft.UBF.PL.ClassKeyFacatory.CreateKey("UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken");
			}
		}
		


		#endregion 

		#region EntityKey
		/// <summary>
		/// Strong Class WSToken EntityKey 
		/// </summary>
		[Serializable()]
	    [DataContract(Name = "EntityKey", Namespace = "UFSoft.UBF.Business.BusinessEntity")]
		public new partial class EntityKey : UFSoft.UBF.Business.BusinessEntity.EntityKey
		{
			public EntityKey(long id): this(id, "UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken")
			{}
			//Construct using by freamwork.
			protected EntityKey(long id , string entityType):base(id,entityType)
			{}
			/// <summary>
			/// 得到当前Key所对应的Entity．(Session级有缓存,性能不用考虑．)
			/// </summary>
			public new WSToken GetEntity()
			{
				return (WSToken)base.GetEntity();
			}
			public static bool operator ==(EntityKey obja, EntityKey objb)
			{
				if (object.ReferenceEquals(obja, null))
				{
					if (object.ReferenceEquals(objb, null))
						return true;
					return false;
				}
				return obja.Equals(objb);
			}
			public static bool operator !=(EntityKey obja, EntityKey objb)
			{
				return !(obja == objb);
			}
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}
			public override bool Equals(object obj)
			{
				return base.Equals(obj);
			}
		}
		protected override UFSoft.UBF.Business.BusinessEntity.EntityKey CreateEntityKey()
		{
			return new EntityKey(this.ID);
		}
		/// <summary>
		/// Strong Class EntityKey Property
		/// </summary>
		public new EntityKey Key
		{
			get
			{
				return base.Key as EntityKey;
			}
		}
		#endregion

		#region Finder
		/// <summary>
		/// Strong Class EntityFinder
		/// </summary>
		public new partial class EntityFinder : UFSoft.UBF.Business.BusinessEntity.EntityFinder<WSToken> 
		{
		    public EntityFinder():base(CurrentClassKey)
			{
			}
			public new EntityList FindAll(string opath, params UFSoft.UBF.PL.OqlParam[] oqlParameters)
			{
				return new EntityList(base.FindAll(opath, oqlParameters));                
			}
			public new EntityList FindAll(UFSoft.UBF.PL.ObjectQueryOptions options, string opath, params UFSoft.UBF.PL.OqlParam[] oqlParameters)
			{
				return new EntityList(base.FindAll(options,opath, oqlParameters));                
			}









			/// <summary>
			/// 业务主键查询参数类型
			/// </summary>
			public class BusinessKeyParameter
			{
				private System.String m_TokenStr ;
				public  System.String TokenStr
				{
					get { return m_TokenStr ;}
					set { m_TokenStr = value ;}
				}
			}
			/// <summary>
			/// 通过实体设置的业务主键进行查询 -业务主键展开方式,会受业务主键调整影响接口.建议使用另一参数类型对象接口查询．
			/// </summary>
			public WSToken FindByBusinessKey(  System.String tokenStr  )
			{
				BusinessKeyParameter　parameter = new BusinessKeyParameter() ;
				
				parameter.TokenStr = tokenStr ;
				return this.FindByBusinessKey(parameter) ;
			}
			/// <summary>
			/// 通过实体设置的业务主键进行查询－建议使用.
			/// </summary>
			public WSToken FindByBusinessKey(BusinessKeyParameter parameter)
			{
                if (parameter == null)
                    throw new ArgumentException("parameter");
                System.Text.StringBuilder sbuilder = new System.Text.StringBuilder(40*1);
                UFSoft.UBF.PL.OqlParamList paramlist = new UFSoft.UBF.PL.OqlParamList();
                
								
				

				sbuilder.Append("TokenStr = @TokenStr");
				paramlist.Add(new UFSoft.UBF.PL.OqlParam("TokenStr",parameter.TokenStr));				
						
				return this.Find(sbuilder.ToString(), paramlist.ToArray());
			}
			
			/// <summary>
			/// UFIDA_U9_Cust_Pub_WSM_WSTokenBE_BizEntity_BusinessKey_Index索引查询参数类型
			/// </summary>
			public class UFIDAU9CustPubWSMWSTokenBEBizEntityBusinessKeyIndexParameter
			{
				private System.String m_Token ;
				public  System.String Token
				{
					get { return m_Token ;}
					set { m_Token = value ;}
				}
			}
			
			
			/// <summary>
			/// 通过索引UFIDA_U9_Cust_Pub_WSM_WSTokenBE_BizEntity_BusinessKey_Index进行查询(参数对象接口)
			/// </summary>
			public WSToken FindByUFIDAU9CustPubWSMWSTokenBEBizEntityBusinessKeyIndex(UFIDAU9CustPubWSMWSTokenBEBizEntityBusinessKeyIndexParameter parameter)
			{
                if (parameter == null)
                    throw new ArgumentException("parameter");
                System.Text.StringBuilder sbuilder = new System.Text.StringBuilder(20*1);
                UFSoft.UBF.PL.OqlParamList paramlist = new UFSoft.UBF.PL.OqlParamList();
				
				sbuilder.Append("Token = @Token");
				paramlist.Add(new UFSoft.UBF.PL.OqlParam("Token",parameter.Token));				
				return this.Find(sbuilder.ToString(), paramlist.ToArray());
			}
			
		}

		//private static EntityFinder _finder  ;

		/// <summary>
		/// Finder
		/// </summary>
		public static EntityFinder Finder {
			get {
				//if (_finder == null)
				//	_finder =  new EntityFinder() ;
				return new EntityFinder() ;
			}
		}
		#endregion
			
		#region List

		/// <summary>
		/// EntityList
		/// </summary>
		public partial class EntityList :UFSoft.UBF.Business.Entity.EntityList<WSToken>{
		    #region constructor 
		    /// <summary>
		    /// EntityList 无参的构造方法,用于其它特殊情况
		    /// </summary>
		    public EntityList()
		    {
		    }

		    /// <summary>
		    /// EntityList Constructor With Collection .主要用于查询返回实体集时使用.
		    /// </summary>
		    public EntityList(IList list) : base(list)
		    { 
		    }
		    
		    /// <summary>
		    ///  EntityList Constructor , used by  peresidence
		    /// </summary>
		    /// <param name="childAttrName">this EntityList's child Attribute Name</param>
		    /// <param name="parentEntity">this EntityList's Parent Entity </param>
		    /// <param name="parentAttrName">Parent Entity's Attribute Name with this EntityList's </param>
		    /// <param name="list">list </param>
		    public EntityList(string childAttrName,UFSoft.UBF.Business.BusinessEntity parentEntity, string parentAttrName, IList list)
			    :base(childAttrName,parentEntity,parentAttrName,list) 
		    { 
			
		    }

		    #endregion 
		    //用于一对多关联.	
		    internal IList InnerList
		    {
		    	//get { return this.innerList; }
		    	set {
		    		if (value != null)
		    		    this.innerList = value; 
		    	}
		    }
		    protected override bool IsMainEntity
		    {
			    get { return true ;}
		    }
		}
		#endregion
		
		#region Typeed OriginalData
		/// <summary>
		/// 当前实体对象的旧数据对象(为上次更新后的数据)
		/// </summary>
		public new EntityOriginal OriginalData
		{
			get {
				return (EntityOriginal)base.OriginalData;
			}
            protected set
            {
				base.OriginalData = value ;
            }
		}
		protected override UFSoft.UBF.Business.BusinessEntity.EntityOriginal CreateOriginalData()
		{
			return new EntityOriginal(this);
		}
		
		public new partial class EntityOriginal: UFSoft.UBF.Business.Entity.EntityOriginal
		{
		    //private WSToken ContainerEntity ;
		    public  new WSToken ContainerEntity 
		    {
				get { return  (WSToken)base.ContainerEntity ;}
				set { base.ContainerEntity = value ;}
		    }
		    
		    public EntityOriginal(WSToken container)
		    {
				if (container == null )
					throw new ArgumentNullException("container") ;
				ContainerEntity = container ;
				base.innerData = container.OldValues ;
				InitInnerData();
		    }
	




			#region member					
			
			/// <summary>
			///  OrginalData属性。只可读。
			/// ID (该属性不可为空,且无默认值)
			/// 服务Token.Key.ID
			/// </summary>
			/// <value></value>
			public  System.Int64 ID
			{
				get
				{
					System.Int64 value  = (System.Int64)base.GetValue("ID");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 创建时间 (该属性可为空,且无默认值)
			/// 服务Token.Sys.创建时间
			/// </summary>
			/// <value></value>
			public  System.DateTime CreatedOn
			{
				get
				{
					object obj = base.GetValue("CreatedOn");
					if (obj == null)
						return System.DateTime.MinValue;
					else
					       return (System.DateTime)obj;
				}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 创建人 (该属性可为空,且无默认值)
			/// 服务Token.Sys.创建人
			/// </summary>
			/// <value></value>
			public  System.String CreatedBy
			{
				get
				{
					System.String value  = (System.String)base.GetValue("CreatedBy");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 修改时间 (该属性可为空,且无默认值)
			/// 服务Token.Sys.修改时间
			/// </summary>
			/// <value></value>
			public  System.DateTime ModifiedOn
			{
				get
				{
					object obj = base.GetValue("ModifiedOn");
					if (obj == null)
						return System.DateTime.MinValue;
					else
					       return (System.DateTime)obj;
				}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 修改人 (该属性可为空,且无默认值)
			/// 服务Token.Sys.修改人
			/// </summary>
			/// <value></value>
			public  System.String ModifiedBy
			{
				get
				{
					System.String value  = (System.String)base.GetValue("ModifiedBy");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 事务版本 (该属性可为空,但有默认值)
			/// 服务Token.Sys.事务版本
			/// </summary>
			/// <value></value>
			public  System.Int64 SysVersion
			{
				get
				{
					System.Int64 value  = (System.Int64)base.GetValue("SysVersion");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// Token串 (该属性不可为空,且无默认值)
			/// 服务Token.Misc.Token串
			/// </summary>
			/// <value></value>
			public  System.String TokenStr
			{
				get
				{
					System.String value  = (System.String)base.GetValue("TokenStr");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 用户编码 (该属性不可为空,且无默认值)
			/// 服务Token.Misc.用户编码
			/// </summary>
			/// <value></value>
			public  System.String UserCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("UserCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 用户名称 (该属性可为空,且无默认值)
			/// 服务Token.Misc.用户名称
			/// </summary>
			/// <value></value>
			public  System.String UserName
			{
				get
				{
					System.String value  = (System.String)base.GetValue("UserName");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 组织编码 (该属性可为空,且无默认值)
			/// 服务Token.Misc.组织编码
			/// </summary>
			/// <value></value>
			public  System.String OrgCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("OrgCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 组织名称 (该属性不可为空,且无默认值)
			/// 服务Token.Misc.组织名称
			/// </summary>
			/// <value></value>
			public  System.String OrgName
			{
				get
				{
					System.String value  = (System.String)base.GetValue("OrgName");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 最后更新时间 (该属性可为空,且无默认值)
			/// 服务Token.Misc.最后更新时间
			/// </summary>
			/// <value></value>
			public  System.DateTime LastUpdateTime
			{
				get
				{
					object obj = base.GetValue("LastUpdateTime");
					if (obj == null)
						return System.DateTime.MinValue;
					else
					       return (System.DateTime)obj;
				}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 活动 (该属性可为空,但有默认值)
			/// 服务Token.Misc.活动
			/// </summary>
			/// <value></value>
			public  System.Boolean IsAlive
			{
				get
				{
					System.Boolean value  = (System.Boolean)base.GetValue("IsAlive");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 失效时间 (该属性可为空,且无默认值)
			/// 服务Token.Misc.失效时间
			/// </summary>
			/// <value></value>
			public  System.DateTime InvalidTime
			{
				get
				{
					object obj = base.GetValue("InvalidTime");
					if (obj == null)
						return System.DateTime.MinValue;
					else
					       return (System.DateTime)obj;
				}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 用户ID (该属性可为空,且无默认值)
			/// 服务Token.Misc.用户ID
			/// </summary>
			/// <value></value>
			public  System.String UserID
			{
				get
				{
					System.String value  = (System.String)base.GetValue("UserID");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 组织ID (该属性可为空,且无默认值)
			/// 服务Token.Misc.组织ID
			/// </summary>
			/// <value></value>
			public  System.String OrgID
			{
				get
				{
					System.String value  = (System.String)base.GetValue("OrgID");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 企业ID (该属性可为空,且无默认值)
			/// 服务Token.Misc.企业ID
			/// </summary>
			/// <value></value>
			public  System.String EnterpriseID
			{
				get
				{
					System.String value  = (System.String)base.GetValue("EnterpriseID");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 企业名称 (该属性可为空,且无默认值)
			/// 服务Token.Misc.企业名称
			/// </summary>
			/// <value></value>
			public  System.String EnterpriseName
			{
				get
				{
					System.String value  = (System.String)base.GetValue("EnterpriseName");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 创建时间 (该属性可为空,且无默认值)
			/// 服务Token.Misc.创建时间
			/// </summary>
			/// <value></value>
			public  System.DateTime CreateTime
			{
				get
				{
					object obj = base.GetValue("CreateTime");
					if (obj == null)
						return System.DateTime.MinValue;
					else
					       return (System.DateTime)obj;
				}
			}
		



		

			#endregion

			#region List member						
			#endregion

			#region Be List member						
			#endregion



		    
		}
		#endregion 







		#region member					
		
			/// <summary>
		/// ID (该属性不可为空,且无默认值)
		/// 服务Token.Key.ID
		/// </summary>
		/// <value></value>
	 
		public new System.Int64 ID
		{
			get
			{
				System.Int64 value  = (System.Int64)base.GetValue("ID");
				return value;
				}
				set
			{
				
								base.SetValue("ID", value);
						 
			}
		}
	



		
			/// <summary>
		/// 创建时间 (该属性可为空,且无默认值)
		/// 服务Token.Sys.创建时间
		/// </summary>
		/// <value></value>
			public  System.DateTime CreatedOn
		{
			get
			{
				System.DateTime value  = (System.DateTime)base.GetValue("CreatedOn");
				return value;
				}
				set
			{
				
								base.SetValue("CreatedOn", value);
						 
			}
		}
	



		
			/// <summary>
		/// 创建人 (该属性可为空,且无默认值)
		/// 服务Token.Sys.创建人
		/// </summary>
		/// <value></value>
			public  System.String CreatedBy
		{
			get
			{
				System.String value  = (System.String)base.GetValue("CreatedBy");
				return value;
				}
				set
			{
				
								base.SetValue("CreatedBy", value);
						 
			}
		}
	



		
			/// <summary>
		/// 修改时间 (该属性可为空,且无默认值)
		/// 服务Token.Sys.修改时间
		/// </summary>
		/// <value></value>
			public  System.DateTime ModifiedOn
		{
			get
			{
				System.DateTime value  = (System.DateTime)base.GetValue("ModifiedOn");
				return value;
				}
				set
			{
				
								base.SetValue("ModifiedOn", value);
						 
			}
		}
	



		
			/// <summary>
		/// 修改人 (该属性可为空,且无默认值)
		/// 服务Token.Sys.修改人
		/// </summary>
		/// <value></value>
			public  System.String ModifiedBy
		{
			get
			{
				System.String value  = (System.String)base.GetValue("ModifiedBy");
				return value;
				}
				set
			{
				
								base.SetValue("ModifiedBy", value);
						 
			}
		}
	



		
			/// <summary>
		/// 事务版本 (该属性可为空,但有默认值)
		/// 服务Token.Sys.事务版本
		/// </summary>
		/// <value></value>
			public  System.Int64 SysVersion
		{
			get
			{
				System.Int64 value  = (System.Int64)base.GetValue("SysVersion");
				return value;
				}
				set
			{
				
								base.SetValue("SysVersion", value);
						 
			}
		}
	



		
			/// <summary>
		/// Token串 (该属性不可为空,且无默认值)
		/// 服务Token.Misc.Token串
		/// </summary>
		/// <value></value>
			public  System.String TokenStr
		{
			get
			{
				System.String value  = (System.String)base.GetValue("TokenStr");
				return value;
				}
				set
			{
				
								base.SetValue("TokenStr", value);
						 
			}
		}
	



		
			/// <summary>
		/// 用户编码 (该属性不可为空,且无默认值)
		/// 服务Token.Misc.用户编码
		/// </summary>
		/// <value></value>
			public  System.String UserCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("UserCode");
				return value;
				}
				set
			{
				
								base.SetValue("UserCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// 用户名称 (该属性可为空,且无默认值)
		/// 服务Token.Misc.用户名称
		/// </summary>
		/// <value></value>
			public  System.String UserName
		{
			get
			{
				System.String value  = (System.String)base.GetValue("UserName");
				return value;
				}
				set
			{
				
								base.SetValue("UserName", value);
						 
			}
		}
	



		
			/// <summary>
		/// 组织编码 (该属性可为空,且无默认值)
		/// 服务Token.Misc.组织编码
		/// </summary>
		/// <value></value>
			public  System.String OrgCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("OrgCode");
				return value;
				}
				set
			{
				
								base.SetValue("OrgCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// 组织名称 (该属性不可为空,且无默认值)
		/// 服务Token.Misc.组织名称
		/// </summary>
		/// <value></value>
			public  System.String OrgName
		{
			get
			{
				System.String value  = (System.String)base.GetValue("OrgName");
				return value;
				}
				set
			{
				
								base.SetValue("OrgName", value);
						 
			}
		}
	



		
			/// <summary>
		/// 最后更新时间 (该属性可为空,且无默认值)
		/// 服务Token.Misc.最后更新时间
		/// </summary>
		/// <value></value>
			public  System.DateTime LastUpdateTime
		{
			get
			{
				System.DateTime value  = (System.DateTime)base.GetValue("LastUpdateTime");
				return value;
				}
				set
			{
				
								base.SetValue("LastUpdateTime", value);
						 
			}
		}
	



		
			/// <summary>
		/// 活动 (该属性可为空,但有默认值)
		/// 服务Token.Misc.活动
		/// </summary>
		/// <value></value>
			public  System.Boolean IsAlive
		{
			get
			{
				System.Boolean value  = (System.Boolean)base.GetValue("IsAlive");
				return value;
				}
				set
			{
				
								base.SetValue("IsAlive", value);
						 
			}
		}
	



		
			/// <summary>
		/// 失效时间 (该属性可为空,且无默认值)
		/// 服务Token.Misc.失效时间
		/// </summary>
		/// <value></value>
			public  System.DateTime InvalidTime
		{
			get
			{
				System.DateTime value  = (System.DateTime)base.GetValue("InvalidTime");
				return value;
				}
				set
			{
				
								base.SetValue("InvalidTime", value);
						 
			}
		}
	



		
			/// <summary>
		/// 用户ID (该属性可为空,且无默认值)
		/// 服务Token.Misc.用户ID
		/// </summary>
		/// <value></value>
			public  System.String UserID
		{
			get
			{
				System.String value  = (System.String)base.GetValue("UserID");
				return value;
				}
				set
			{
				
								base.SetValue("UserID", value);
						 
			}
		}
	



		
			/// <summary>
		/// 组织ID (该属性可为空,且无默认值)
		/// 服务Token.Misc.组织ID
		/// </summary>
		/// <value></value>
			public  System.String OrgID
		{
			get
			{
				System.String value  = (System.String)base.GetValue("OrgID");
				return value;
				}
				set
			{
				
								base.SetValue("OrgID", value);
						 
			}
		}
	



		
			/// <summary>
		/// 企业ID (该属性可为空,且无默认值)
		/// 服务Token.Misc.企业ID
		/// </summary>
		/// <value></value>
			public  System.String EnterpriseID
		{
			get
			{
				System.String value  = (System.String)base.GetValue("EnterpriseID");
				return value;
				}
				set
			{
				
								base.SetValue("EnterpriseID", value);
						 
			}
		}
	



		
			/// <summary>
		/// 企业名称 (该属性可为空,且无默认值)
		/// 服务Token.Misc.企业名称
		/// </summary>
		/// <value></value>
			public  System.String EnterpriseName
		{
			get
			{
				System.String value  = (System.String)base.GetValue("EnterpriseName");
				return value;
				}
				set
			{
				
								base.SetValue("EnterpriseName", value);
						 
			}
		}
	



		
			/// <summary>
		/// 创建时间 (该属性可为空,且无默认值)
		/// 服务Token.Misc.创建时间
		/// </summary>
		/// <value></value>
			public  System.DateTime CreateTime
		{
			get
			{
				System.DateTime value  = (System.DateTime)base.GetValue("CreateTime");
				return value;
				}
				set
			{
				
								base.SetValue("CreateTime", value);
						 
			}
		}
	



	

		#endregion

		#region List member						
		#endregion

		#region Be List member						
		#endregion
		
		#region ModelResource 其余去除，保留EntityName
		/// <summary>
		/// Entity的显示名称资源-请使用EntityRes.GetResource(EntityRes.BE_FullName)的方式取 Entity的显示名称资源.
		/// </summary>
		[Obsolete("")]
		public  string Res_EntityName {	get {return Res_EntityNameS ;}	}
		/// <summary>
		/// Entity的显示名称资源-请使用EntityRes.GetResource(EntityRes.BE_FullName)的方式取 Entity的显示名称资源.
		/// </summary>
		[Obsolete("")]
		public  static string Res_EntityNameS {	get {return EntityRes.GetResource("UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken")  ;}	}
		#endregion 		

		#region ModelResource,这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource()内部类的方式取资源
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ID")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ID　{ get { return EntityRes.GetResource("ID");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("CreatedOn")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_CreatedOn　{ get { return EntityRes.GetResource("CreatedOn");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("CreatedBy")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_CreatedBy　{ get { return EntityRes.GetResource("CreatedBy");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ModifiedOn")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ModifiedOn　{ get { return EntityRes.GetResource("ModifiedOn");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ModifiedBy")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ModifiedBy　{ get { return EntityRes.GetResource("ModifiedBy");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("SysVersion")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_SysVersion　{ get { return EntityRes.GetResource("SysVersion");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("TokenStr")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_TokenStr　{ get { return EntityRes.GetResource("TokenStr");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("UserCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_UserCode　{ get { return EntityRes.GetResource("UserCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("UserName")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_UserName　{ get { return EntityRes.GetResource("UserName");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("OrgCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_OrgCode　{ get { return EntityRes.GetResource("OrgCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("OrgName")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_OrgName　{ get { return EntityRes.GetResource("OrgName");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("LastUpdateTime")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_LastUpdateTime　{ get { return EntityRes.GetResource("LastUpdateTime");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("IsAlive")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_IsAlive　{ get { return EntityRes.GetResource("IsAlive");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("InvalidTime")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_InvalidTime　{ get { return EntityRes.GetResource("InvalidTime");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("UserID")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_UserID　{ get { return EntityRes.GetResource("UserID");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("OrgID")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_OrgID　{ get { return EntityRes.GetResource("OrgID");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("EnterpriseID")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_EnterpriseID　{ get { return EntityRes.GetResource("EnterpriseID");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("EnterpriseName")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_EnterpriseName　{ get { return EntityRes.GetResource("EnterpriseName");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("CreateTime")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_CreateTime　{ get { return EntityRes.GetResource("CreateTime");　}　}
		#endregion 



		#region EntityResource 实体的属性名称及相应显示名称资源访问方法
		public class EntityRes
		{
			/// <summary>
			/// EntityName的名称
			/// </summary>
			public static string BE_Name { get { return "WSToken";　}　}
			
			/// <summary>
			/// Entity　的全名. 
			/// </summary>
			public static string BE_FullName { get { return "UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken";　}　}
		
			/// <summary>
			/// 属性: ID 的名称
			/// </summary>
			public static string ID　{ get { return "ID";　}　}
				
			/// <summary>
			/// 属性: 创建时间 的名称
			/// </summary>
			public static string CreatedOn　{ get { return "CreatedOn";　}　}
				
			/// <summary>
			/// 属性: 创建人 的名称
			/// </summary>
			public static string CreatedBy　{ get { return "CreatedBy";　}　}
				
			/// <summary>
			/// 属性: 修改时间 的名称
			/// </summary>
			public static string ModifiedOn　{ get { return "ModifiedOn";　}　}
				
			/// <summary>
			/// 属性: 修改人 的名称
			/// </summary>
			public static string ModifiedBy　{ get { return "ModifiedBy";　}　}
				
			/// <summary>
			/// 属性: 事务版本 的名称
			/// </summary>
			public static string SysVersion　{ get { return "SysVersion";　}　}
				
			/// <summary>
			/// 属性: Token串 的名称
			/// </summary>
			public static string TokenStr　{ get { return "TokenStr";　}　}
				
			/// <summary>
			/// 属性: 用户编码 的名称
			/// </summary>
			public static string UserCode　{ get { return "UserCode";　}　}
				
			/// <summary>
			/// 属性: 用户名称 的名称
			/// </summary>
			public static string UserName　{ get { return "UserName";　}　}
				
			/// <summary>
			/// 属性: 组织编码 的名称
			/// </summary>
			public static string OrgCode　{ get { return "OrgCode";　}　}
				
			/// <summary>
			/// 属性: 组织名称 的名称
			/// </summary>
			public static string OrgName　{ get { return "OrgName";　}　}
				
			/// <summary>
			/// 属性: 最后更新时间 的名称
			/// </summary>
			public static string LastUpdateTime　{ get { return "LastUpdateTime";　}　}
				
			/// <summary>
			/// 属性: 活动 的名称
			/// </summary>
			public static string IsAlive　{ get { return "IsAlive";　}　}
				
			/// <summary>
			/// 属性: 失效时间 的名称
			/// </summary>
			public static string InvalidTime　{ get { return "InvalidTime";　}　}
				
			/// <summary>
			/// 属性: 用户ID 的名称
			/// </summary>
			public static string UserID　{ get { return "UserID";　}　}
				
			/// <summary>
			/// 属性: 组织ID 的名称
			/// </summary>
			public static string OrgID　{ get { return "OrgID";　}　}
				
			/// <summary>
			/// 属性: 企业ID 的名称
			/// </summary>
			public static string EnterpriseID　{ get { return "EnterpriseID";　}　}
				
			/// <summary>
			/// 属性: 企业名称 的名称
			/// </summary>
			public static string EnterpriseName　{ get { return "EnterpriseName";　}　}
				
			/// <summary>
			/// 属性: 创建时间 的名称
			/// </summary>
			public static string CreateTime　{ get { return "CreateTime";　}　}
		
			/// <summary>
			/// 获取显示名称资源方法
			/// </summary>
			public static string GetResource(String attrName){
				if (attrName == BE_Name || attrName== BE_FullName)
					return UFSoft.UBF.Business.Tool.ExtendHelpAPI.GetEntityResource(BE_FullName);
																																						
				return UFSoft.UBF.Business.Tool.ExtendHelpAPI.GetAttrResource(BE_FullName, attrName);
			}

		}
		#endregion 


		#region EntityObjectBuilder 持久化性能优化
        private Dictionary<string, string> multiLangAttrs = null;
        private Dictionary<string, string> exdMultiLangAttrs = null;
        private string col_ID_Name = string.Empty;

        public override  Dictionary<string, string> MultiLangAttrs
        {
			get
			{
				return multiLangAttrs;
			}
        }
        public override  Dictionary<string, string> ExdMultiLangAttrs
        {
			get
			{
				return exdMultiLangAttrs;
			}
        }
        public override string Col_ID_Name
        {
			get
			{
				return col_ID_Name;
			}
        }  
        public override void IniData()
        {
			this.multiLangAttrs = new Dictionary<string, string>();
			this.exdMultiLangAttrs = new Dictionary<string, string>();
	
			this.col_ID_Name ="ID";
			this.exdMultiLangAttrs.Add("ID","ID");
			this.exdMultiLangAttrs.Add("CreatedOn","CreatedOn");
			this.exdMultiLangAttrs.Add("CreatedBy","CreatedBy");
			this.exdMultiLangAttrs.Add("ModifiedOn","ModifiedOn");
			this.exdMultiLangAttrs.Add("ModifiedBy","ModifiedBy");
			this.exdMultiLangAttrs.Add("SysVersion","SysVersion");
			this.exdMultiLangAttrs.Add("TokenStr","TokenStr");
			this.exdMultiLangAttrs.Add("UserCode","UserCode");
			this.exdMultiLangAttrs.Add("UserName","UserName");
			this.exdMultiLangAttrs.Add("OrgCode","OrgCode");
			this.exdMultiLangAttrs.Add("OrgName","OrgName");
			this.exdMultiLangAttrs.Add("LastUpdateTime","LastUpdateTime");
			this.exdMultiLangAttrs.Add("IsAlive","IsAlive");
			this.exdMultiLangAttrs.Add("InvalidTime","InvalidTime");
			this.exdMultiLangAttrs.Add("UserID","UserID");
			this.exdMultiLangAttrs.Add("OrgID","OrgID");
			this.exdMultiLangAttrs.Add("EnterpriseID","EnterpriseID");
			this.exdMultiLangAttrs.Add("EnterpriseName","EnterpriseName");
			this.exdMultiLangAttrs.Add("CreateTime","CreateTime");
        }
	#endregion 




		
		
		#region override SetTypeValue method(Use By UICommonCRUD OR Weakly Type Operation)
		public override void SetTypeValue(object propName, object value)
		{
			
			string propstr = propName.ToString();
			switch(propstr)
			{
			
																																																									

				default:
					//调用基类的实现，最终Entity基类为SetValue()
					base.SetTypeValue(propName,value);
					return;
			}
		}
		#endregion


	


		#region EntityData exchange
		
		#region  DeSerializeKey -ForEntityPorpertyType
		//反序化Key到Data的ID中 --由FromEntityData自动调用一次。实际可以分离,由跨组织服务去调用.
		private void DeSerializeKey(WSTokenData data)
		{
		
			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			
	
			//Entity中没有EntityKey集合，不用处理。
		}
		
		#endregion 	
        public override void FromEntityData(UFSoft.UBF.Business.DataTransObjectBase dto)
        {
			WSTokenData data = dto as WSTokenData ;
			if (data == null)
				return ;
            this.FromEntityData(data) ;
        }

        public override UFSoft.UBF.Business.DataTransObjectBase ToEntityDataBase()
        {
            return this.ToEntityData();
        }
		/// <summary>
		/// Copy Entity From EntityData
		/// </summary>
		public void FromEntityData(WSTokenData data)
		{
			this.FromEntityData(data,new Hashtable());
		}
		//used by ubf..
		public void FromEntityData(WSTokenData data,IDictionary dict)
		{
			if (data == null)
				return;
			bool m_isNeedPersistable = this.NeedPersistable ;
			this.NeedPersistable = false ;
			
			//this.innerData.ChangeEventEnabled = false;
			//this.innerRelation.RelationEventEnabled = false;
				
			if (dict == null ) dict = new Hashtable() ;
			dict[data] = this;
			this.SysState = data.SysState ;
			DeSerializeKey(data);
			#region 组件外属性
		
			//ID与系统字段不处理 --Sysversion需要处理。

		
			//ID与系统字段不处理 --Sysversion需要处理。

		
			//ID与系统字段不处理 --Sysversion需要处理。

		
			//ID与系统字段不处理 --Sysversion需要处理。

		
			//ID与系统字段不处理 --Sysversion需要处理。

								this.SetTypeValue("SysVersion",data.SysVersion);
		
								this.SetTypeValue("TokenStr",data.TokenStr);
		
								this.SetTypeValue("UserCode",data.UserCode);
		
								this.SetTypeValue("UserName",data.UserName);
		
								this.SetTypeValue("OrgCode",data.OrgCode);
		
								this.SetTypeValue("OrgName",data.OrgName);
		
								this.SetTypeValue("LastUpdateTime",data.LastUpdateTime);
		
								this.SetTypeValue("IsAlive",data.IsAlive);
		
								this.SetTypeValue("InvalidTime",data.InvalidTime);
		
								this.SetTypeValue("UserID",data.UserID);
		
								this.SetTypeValue("OrgID",data.OrgID);
		
								this.SetTypeValue("EnterpriseID",data.EnterpriseID);
		
								this.SetTypeValue("EnterpriseName",data.EnterpriseName);
		
								this.SetTypeValue("CreateTime",data.CreateTime);
		
			#endregion 

			#region 组件内属性
	
			#endregion 
			this.NeedPersistable = m_isNeedPersistable ;
			dict[data] = this;
		}

		/// <summary>
		/// Create EntityData From Entity
		/// </summary>
		public WSTokenData ToEntityData()
		{
			return ToEntityData(null,null);
		}
		/// <summary>
		/// Create EntityData From Entity - used by ubf 
		/// </summary>
		public WSTokenData ToEntityData(WSTokenData data, IDictionary dict){
			if (data == null)
				data = new WSTokenData();
			
			if (dict == null ) dict = new Hashtable() ;
			//就直接用ID,如果不同实体会出现相同ID，则到时候要改进。? ID一定要有。
			dict["UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken"+this.ID.ToString()] = data;
		
			data.SysState = this.SysState ;
			#region 组件外属性 -BusinessEntity,"简单值对象",简单类型,多语言.不可能存在一对多.没有集合可能.
	    
			{
				object obj =this.GetValue("ID");
				if (obj != null)
					data.ID=(System.Int64)obj;
			}
	     
	    
			{
				object obj =this.GetValue("CreatedOn");
				if (obj != null)
					data.CreatedOn=(System.DateTime)obj;
			}
	     
	    
			{
				object obj =this.GetValue("CreatedBy");
				if (obj != null)
					data.CreatedBy=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("ModifiedOn");
				if (obj != null)
					data.ModifiedOn=(System.DateTime)obj;
			}
	     
	    
			{
				object obj =this.GetValue("ModifiedBy");
				if (obj != null)
					data.ModifiedBy=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("SysVersion");
				if (obj != null)
					data.SysVersion=(System.Int64)obj;
			}
	     
	    
			{
				object obj =this.GetValue("TokenStr");
				if (obj != null)
					data.TokenStr=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("UserCode");
				if (obj != null)
					data.UserCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("UserName");
				if (obj != null)
					data.UserName=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("OrgCode");
				if (obj != null)
					data.OrgCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("OrgName");
				if (obj != null)
					data.OrgName=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("LastUpdateTime");
				if (obj != null)
					data.LastUpdateTime=(System.DateTime)obj;
			}
	     
	    
			{
				object obj =this.GetValue("IsAlive");
				if (obj != null)
					data.IsAlive=(System.Boolean)obj;
			}
	     
	    
			{
				object obj =this.GetValue("InvalidTime");
				if (obj != null)
					data.InvalidTime=(System.DateTime)obj;
			}
	     
	    
			{
				object obj =this.GetValue("UserID");
				if (obj != null)
					data.UserID=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("OrgID");
				if (obj != null)
					data.OrgID=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("EnterpriseID");
				if (obj != null)
					data.EnterpriseID=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("EnterpriseName");
				if (obj != null)
					data.EnterpriseName=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("CreateTime");
				if (obj != null)
					data.CreateTime=(System.DateTime)obj;
			}
	     
			#endregion 

			#region 组件内属性 -Entity,"复杂值对象",枚举,实体集合.
	

			#endregion 
			return data ;
		}

		#endregion
	



	
        #region EntityValidator 
	//实体检验： 含自身检验器检验，内嵌属性类型的检验以及属性类型上的校验器的检验。
        private bool SelfEntityValidator()
        {
        



















			//调用实体自身校验器代码.
            return true; 
        }
		//校验属性是否为空的检验。主要是关联对象的效验
		public override void SelfNullableVlidator()
		{
			base.SelfNullableVlidator();
		
			if (string.IsNullOrEmpty((string)base.GetValue("TokenStr"))){
				UFSoft.UBF.Business.AttributeInValidException TokenStr_Exception =new UFSoft.UBF.Business.AttributeInValidException("UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken","TokenStr","6cc2c6c2-b5ef-4973-9128-0b7137c38c53");
				if (UFSoft.UBF.PL.Tool.ConfigParm.SupportNullableVlidatorStackTrace)
					TokenStr_Exception.MyStackTrace =  new System.Diagnostics.StackTrace(true).ToString();
				this.PropertyExceptions.Add(TokenStr_Exception);
			}

			if (string.IsNullOrEmpty((string)base.GetValue("UserCode"))){
				UFSoft.UBF.Business.AttributeInValidException UserCode_Exception =new UFSoft.UBF.Business.AttributeInValidException("UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken","UserCode","fa40abd7-559d-4753-9cb1-f1906a650442");
				if (UFSoft.UBF.PL.Tool.ConfigParm.SupportNullableVlidatorStackTrace)
					UserCode_Exception.MyStackTrace =  new System.Diagnostics.StackTrace(true).ToString();
				this.PropertyExceptions.Add(UserCode_Exception);
			}

			if (string.IsNullOrEmpty((string)base.GetValue("OrgName"))){
				UFSoft.UBF.Business.AttributeInValidException OrgName_Exception =new UFSoft.UBF.Business.AttributeInValidException("UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken","OrgName","b8811fb6-374c-464e-ab00-58601bd71346");
				if (UFSoft.UBF.PL.Tool.ConfigParm.SupportNullableVlidatorStackTrace)
					OrgName_Exception.MyStackTrace =  new System.Diagnostics.StackTrace(true).ToString();
				this.PropertyExceptions.Add(OrgName_Exception);
			}

			
		}
			    
	#endregion 
	
	
		#region 应用版型代码区
		#endregion 


	}	
}