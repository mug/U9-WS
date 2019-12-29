using System;
using System.Collections;
using System.Collections.Generic ;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WSLogBE
{
	
	/// <summary>
	/// 实体: 服务日志
	/// 
	/// </summary>
	[Serializable]	
	public  partial class WSLog : UFSoft.UBF.Business.BusinessEntity
	{





		#region Create Instance
		/// <summary>
		/// Constructor
		/// </summary>
		public WSLog(){
		}


	
		/// <summary>
		/// Create Instance
		/// </summary>
		/// <returns>Instance</returns>
		public  static WSLog Create() {
			WSLog entity = (WSLog)UFSoft.UBF.Business.Entity.Create(CurrentClassKey, null);
																																																												 
			return entity;
		}

		/// <summary>
		/// use for Serialization
		/// </summary>
		protected WSLog(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
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
		public static WSLog CreateDefault() {
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
		public static WSLog CreateDefaultComponent(){
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
            get { return "UFIDA.U9.Cust.Pub.WSLogBE.WSLog"; }    
        }
		//private static UFSoft.UBF.PL.IClassKey _currentClassKey;
		//由于可能每次访问时的Enterprise不一样，所以每次重取.
		private static UFSoft.UBF.PL.IClassKey CurrentClassKey
		{
			get {
				return  UFSoft.UBF.PL.ClassKeyFacatory.CreateKey("UFIDA.U9.Cust.Pub.WSLogBE.WSLog");
			}
		}
		


		#endregion 

		#region EntityKey
		/// <summary>
		/// Strong Class WSLog EntityKey 
		/// </summary>
		[Serializable()]
	    [DataContract(Name = "EntityKey", Namespace = "UFSoft.UBF.Business.BusinessEntity")]
		public new partial class EntityKey : UFSoft.UBF.Business.BusinessEntity.EntityKey
		{
			public EntityKey(long id): this(id, "UFIDA.U9.Cust.Pub.WSLogBE.WSLog")
			{}
			//Construct using by freamwork.
			protected EntityKey(long id , string entityType):base(id,entityType)
			{}
			/// <summary>
			/// 得到当前Key所对应的Entity．(Session级有缓存,性能不用考虑．)
			/// </summary>
			public new WSLog GetEntity()
			{
				return (WSLog)base.GetEntity();
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
		public new partial class EntityFinder : UFSoft.UBF.Business.BusinessEntity.EntityFinder<WSLog> 
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
			/// IX_WSLog_ClassName_MethodName索引查询参数类型
			/// </summary>
			public class IXWSLogClassNameMethodNameParameter
			{
				private System.String m_ClassName ;
				public  System.String ClassName
				{
					get { return m_ClassName ;}
					set { m_ClassName = value ;}
				}				private System.String m_MethodName ;
				public  System.String MethodName
				{
					get { return m_MethodName ;}
					set { m_MethodName = value ;}
				}
			}
			
			
			/// <summary>
			/// 通过索引IX_WSLog_ClassName_MethodName进行查询(参数对象接口)
			/// </summary>
			public WSLog.EntityList FindByIXWSLogClassNameMethodName(IXWSLogClassNameMethodNameParameter parameter)
			{
                if (parameter == null)
                    throw new ArgumentException("parameter");
                System.Text.StringBuilder sbuilder = new System.Text.StringBuilder(20*2);
                UFSoft.UBF.PL.OqlParamList paramlist = new UFSoft.UBF.PL.OqlParamList();
				
				if (System.String.IsNullOrEmpty(parameter.ClassName))
				{
					sbuilder.Append("  ClassName is null ");
				}
				else
				{
					sbuilder.Append("ClassName = @ClassName");
					paramlist.Add(new UFSoft.UBF.PL.OqlParam("ClassName",parameter.ClassName));
				}				
				if (System.String.IsNullOrEmpty(parameter.MethodName))
				{
					sbuilder.Append("  and  MethodName is null ");
				}
				else
				{
					sbuilder.Append(" and MethodName = @MethodName");
					paramlist.Add(new UFSoft.UBF.PL.OqlParam("MethodName",parameter.MethodName));
				}				
				return this.FindAll(sbuilder.ToString(), paramlist.ToArray());
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
		public partial class EntityList :UFSoft.UBF.Business.Entity.EntityList<WSLog>{
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
		    //private WSLog ContainerEntity ;
		    public  new WSLog ContainerEntity 
		    {
				get { return  (WSLog)base.ContainerEntity ;}
				set { base.ContainerEntity = value ;}
		    }
		    
		    public EntityOriginal(WSLog container)
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
			/// 服务日志.Key.ID
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
			/// 服务日志.Sys.创建时间
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
			/// 服务日志.Sys.创建人
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
			/// 服务日志.Sys.修改时间
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
			/// 服务日志.Sys.修改人
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
			/// 服务日志.Sys.事务版本
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
			/// 请求地址 (该属性可为空,且无默认值)
			/// 服务日志.Misc.请求地址
			/// </summary>
			/// <value></value>
			public  System.String RequestUrl
			{
				get
				{
					System.String value  = (System.String)base.GetValue("RequestUrl");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 类名 (该属性可为空,且无默认值)
			/// 服务日志.Misc.类名
			/// </summary>
			/// <value></value>
			public  System.String ClassName
			{
				get
				{
					System.String value  = (System.String)base.GetValue("ClassName");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 方法名 (该属性可为空,且无默认值)
			/// 服务日志.Misc.方法名
			/// </summary>
			/// <value></value>
			public  System.String MethodName
			{
				get
				{
					System.String value  = (System.String)base.GetValue("MethodName");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 开始时间 (该属性可为空,且无默认值)
			/// 服务日志.Misc.开始时间
			/// </summary>
			/// <value></value>
			public  System.DateTime StartTime
			{
				get
				{
					object obj = base.GetValue("StartTime");
					if (obj == null)
						return System.DateTime.MinValue;
					else
					       return (System.DateTime)obj;
				}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 结束时间 (该属性可为空,且无默认值)
			/// 服务日志.Misc.结束时间
			/// </summary>
			/// <value></value>
			public  System.DateTime EndTime
			{
				get
				{
					object obj = base.GetValue("EndTime");
					if (obj == null)
						return System.DateTime.MinValue;
					else
					       return (System.DateTime)obj;
				}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 历时(秒) (该属性可为空,但有默认值)
			/// 服务日志.Misc.历时(秒)
			/// </summary>
			/// <value></value>
			public  System.Decimal ElapsedSecond
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("ElapsedSecond");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 请求内容 (该属性可为空,且无默认值)
			/// 服务日志.Misc.请求内容
			/// </summary>
			/// <value></value>
			public  System.String RequestContent
			{
				get
				{
					System.String value  = (System.String)base.GetValue("RequestContent");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 返回内容 (该属性可为空,且无默认值)
			/// 服务日志.Misc.返回内容
			/// </summary>
			/// <value></value>
			public  System.String ResponseContent
			{
				get
				{
					System.String value  = (System.String)base.GetValue("ResponseContent");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 调用结果 (该属性可为空,但有默认值)
			/// 服务日志.Misc.调用结果
			/// </summary>
			/// <value></value>
			public  UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum CallResult
			{
				get
				{

					UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum value  = UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum.GetFromValue(base.GetValue("CallResult"));
					return value;
				}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 错误信息 (该属性可为空,且无默认值)
			/// 服务日志.Misc.错误信息
			/// </summary>
			/// <value></value>
			public  System.String ErrorMessage
			{
				get
				{
					System.String value  = (System.String)base.GetValue("ErrorMessage");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 请求次数 (该属性可为空,但有默认值)
			/// 服务日志.Misc.请求次数
			/// </summary>
			/// <value></value>
			public  System.Int32 CallCount
			{
				get
				{
					System.Int32 value  = (System.Int32)base.GetValue("CallCount");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 方法描述 (该属性可为空,且无默认值)
			/// 服务日志.Misc.方法描述
			/// </summary>
			/// <value></value>
			public  System.String MethodDescription
			{
				get
				{
					System.String value  = (System.String)base.GetValue("MethodDescription");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 企业ID (该属性可为空,且无默认值)
			/// 服务日志.Misc.企业ID
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
		/// 服务日志.Key.ID
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
		/// 服务日志.Sys.创建时间
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
		/// 服务日志.Sys.创建人
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
		/// 服务日志.Sys.修改时间
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
		/// 服务日志.Sys.修改人
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
		/// 服务日志.Sys.事务版本
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
		/// 请求地址 (该属性可为空,且无默认值)
		/// 服务日志.Misc.请求地址
		/// </summary>
		/// <value></value>
			public  System.String RequestUrl
		{
			get
			{
				System.String value  = (System.String)base.GetValue("RequestUrl");
				return value;
				}
				set
			{
				
								base.SetValue("RequestUrl", value);
						 
			}
		}
	



		
			/// <summary>
		/// 类名 (该属性可为空,且无默认值)
		/// 服务日志.Misc.类名
		/// </summary>
		/// <value></value>
			public  System.String ClassName
		{
			get
			{
				System.String value  = (System.String)base.GetValue("ClassName");
				return value;
				}
				set
			{
				
								base.SetValue("ClassName", value);
						 
			}
		}
	



		
			/// <summary>
		/// 方法名 (该属性可为空,且无默认值)
		/// 服务日志.Misc.方法名
		/// </summary>
		/// <value></value>
			public  System.String MethodName
		{
			get
			{
				System.String value  = (System.String)base.GetValue("MethodName");
				return value;
				}
				set
			{
				
								base.SetValue("MethodName", value);
						 
			}
		}
	



		
			/// <summary>
		/// 开始时间 (该属性可为空,且无默认值)
		/// 服务日志.Misc.开始时间
		/// </summary>
		/// <value></value>
			public  System.DateTime StartTime
		{
			get
			{
				System.DateTime value  = (System.DateTime)base.GetValue("StartTime");
				return value;
				}
				set
			{
				
								base.SetValue("StartTime", value);
						 
			}
		}
	



		
			/// <summary>
		/// 结束时间 (该属性可为空,且无默认值)
		/// 服务日志.Misc.结束时间
		/// </summary>
		/// <value></value>
			public  System.DateTime EndTime
		{
			get
			{
				System.DateTime value  = (System.DateTime)base.GetValue("EndTime");
				return value;
				}
				set
			{
				
								base.SetValue("EndTime", value);
						 
			}
		}
	



		
			/// <summary>
		/// 历时(秒) (该属性可为空,但有默认值)
		/// 服务日志.Misc.历时(秒)
		/// </summary>
		/// <value></value>
			public  System.Decimal ElapsedSecond
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("ElapsedSecond");
				return value;
				}
				set
			{
				
								base.SetValue("ElapsedSecond", value);
						 
			}
		}
	



		
			/// <summary>
		/// 请求内容 (该属性可为空,且无默认值)
		/// 服务日志.Misc.请求内容
		/// </summary>
		/// <value></value>
			public  System.String RequestContent
		{
			get
			{
				System.String value  = (System.String)base.GetValue("RequestContent");
				return value;
				}
				set
			{
				
								base.SetValue("RequestContent", value);
						 
			}
		}
	



		
			/// <summary>
		/// 返回内容 (该属性可为空,且无默认值)
		/// 服务日志.Misc.返回内容
		/// </summary>
		/// <value></value>
			public  System.String ResponseContent
		{
			get
			{
				System.String value  = (System.String)base.GetValue("ResponseContent");
				return value;
				}
				set
			{
				
								base.SetValue("ResponseContent", value);
						 
			}
		}
	



		
			/// <summary>
		/// 调用结果 (该属性可为空,但有默认值)
		/// 服务日志.Misc.调用结果
		/// </summary>
		/// <value></value>
			public  UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum CallResult
		{
			get
			{

				UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum value  = UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum.GetFromValue(base.GetValue("CallResult"));
				return value;
			}
				set
			{
				
				if (value == null)
					base.SetValue("CallResult",UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum.Empty.Value);
				else
					base.SetValue("CallResult",value.Value);
					 
			}
		}
	



		
			/// <summary>
		/// 错误信息 (该属性可为空,且无默认值)
		/// 服务日志.Misc.错误信息
		/// </summary>
		/// <value></value>
			public  System.String ErrorMessage
		{
			get
			{
				System.String value  = (System.String)base.GetValue("ErrorMessage");
				return value;
				}
				set
			{
				
								base.SetValue("ErrorMessage", value);
						 
			}
		}
	



		
			/// <summary>
		/// 请求次数 (该属性可为空,但有默认值)
		/// 服务日志.Misc.请求次数
		/// </summary>
		/// <value></value>
			public  System.Int32 CallCount
		{
			get
			{
				System.Int32 value  = (System.Int32)base.GetValue("CallCount");
				return value;
				}
				set
			{
				
								base.SetValue("CallCount", value);
						 
			}
		}
	



		
			/// <summary>
		/// 方法描述 (该属性可为空,且无默认值)
		/// 服务日志.Misc.方法描述
		/// </summary>
		/// <value></value>
			public  System.String MethodDescription
		{
			get
			{
				System.String value  = (System.String)base.GetValue("MethodDescription");
				return value;
				}
				set
			{
				
								base.SetValue("MethodDescription", value);
						 
			}
		}
	



		
			/// <summary>
		/// 企业ID (该属性可为空,且无默认值)
		/// 服务日志.Misc.企业ID
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
		public  static string Res_EntityNameS {	get {return EntityRes.GetResource("UFIDA.U9.Cust.Pub.WSLogBE.WSLog")  ;}	}
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
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("RequestUrl")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_RequestUrl　{ get { return EntityRes.GetResource("RequestUrl");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ClassName")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ClassName　{ get { return EntityRes.GetResource("ClassName");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("MethodName")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_MethodName　{ get { return EntityRes.GetResource("MethodName");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("StartTime")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_StartTime　{ get { return EntityRes.GetResource("StartTime");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("EndTime")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_EndTime　{ get { return EntityRes.GetResource("EndTime");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ElapsedSecond")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ElapsedSecond　{ get { return EntityRes.GetResource("ElapsedSecond");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("RequestContent")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_RequestContent　{ get { return EntityRes.GetResource("RequestContent");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ResponseContent")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ResponseContent　{ get { return EntityRes.GetResource("ResponseContent");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("CallResult")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_CallResult　{ get { return EntityRes.GetResource("CallResult");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ErrorMessage")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ErrorMessage　{ get { return EntityRes.GetResource("ErrorMessage");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("CallCount")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_CallCount　{ get { return EntityRes.GetResource("CallCount");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("MethodDescription")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_MethodDescription　{ get { return EntityRes.GetResource("MethodDescription");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("EnterpriseID")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_EnterpriseID　{ get { return EntityRes.GetResource("EnterpriseID");　}　}
		#endregion 



		#region EntityResource 实体的属性名称及相应显示名称资源访问方法
		public class EntityRes
		{
			/// <summary>
			/// EntityName的名称
			/// </summary>
			public static string BE_Name { get { return "WSLog";　}　}
			
			/// <summary>
			/// Entity　的全名. 
			/// </summary>
			public static string BE_FullName { get { return "UFIDA.U9.Cust.Pub.WSLogBE.WSLog";　}　}
		
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
			/// 属性: 请求地址 的名称
			/// </summary>
			public static string RequestUrl　{ get { return "RequestUrl";　}　}
				
			/// <summary>
			/// 属性: 类名 的名称
			/// </summary>
			public static string ClassName　{ get { return "ClassName";　}　}
				
			/// <summary>
			/// 属性: 方法名 的名称
			/// </summary>
			public static string MethodName　{ get { return "MethodName";　}　}
				
			/// <summary>
			/// 属性: 开始时间 的名称
			/// </summary>
			public static string StartTime　{ get { return "StartTime";　}　}
				
			/// <summary>
			/// 属性: 结束时间 的名称
			/// </summary>
			public static string EndTime　{ get { return "EndTime";　}　}
				
			/// <summary>
			/// 属性: 历时(秒) 的名称
			/// </summary>
			public static string ElapsedSecond　{ get { return "ElapsedSecond";　}　}
				
			/// <summary>
			/// 属性: 请求内容 的名称
			/// </summary>
			public static string RequestContent　{ get { return "RequestContent";　}　}
				
			/// <summary>
			/// 属性: 返回内容 的名称
			/// </summary>
			public static string ResponseContent　{ get { return "ResponseContent";　}　}
				
			/// <summary>
			/// 属性: 调用结果 的名称
			/// </summary>
			public static string CallResult　{ get { return "CallResult";　}　}
				
			/// <summary>
			/// 属性: 错误信息 的名称
			/// </summary>
			public static string ErrorMessage　{ get { return "ErrorMessage";　}　}
				
			/// <summary>
			/// 属性: 请求次数 的名称
			/// </summary>
			public static string CallCount　{ get { return "CallCount";　}　}
				
			/// <summary>
			/// 属性: 方法描述 的名称
			/// </summary>
			public static string MethodDescription　{ get { return "MethodDescription";　}　}
				
			/// <summary>
			/// 属性: 企业ID 的名称
			/// </summary>
			public static string EnterpriseID　{ get { return "EnterpriseID";　}　}
		
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
			this.exdMultiLangAttrs.Add("RequestUrl","RequestUrl");
			this.exdMultiLangAttrs.Add("ClassName","ClassName");
			this.exdMultiLangAttrs.Add("MethodName","MethodName");
			this.exdMultiLangAttrs.Add("StartTime","StartTime");
			this.exdMultiLangAttrs.Add("EndTime","EndTime");
			this.exdMultiLangAttrs.Add("ElapsedSecond","ElapsedSecond");
			this.exdMultiLangAttrs.Add("RequestContent","RequestContent");
			this.exdMultiLangAttrs.Add("ResponseContent","ResponseContent");
			this.exdMultiLangAttrs.Add("CallResult","CallResult");
			this.exdMultiLangAttrs.Add("ErrorMessage","ErrorMessage");
			this.exdMultiLangAttrs.Add("CallCount","CallCount");
			this.exdMultiLangAttrs.Add("MethodDescription","MethodDescription");
			this.exdMultiLangAttrs.Add("EnterpriseID","EnterpriseID");
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
		private void DeSerializeKey(WSLogData data)
		{
		
			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			
	
			//Entity中没有EntityKey集合，不用处理。
		}
		
		#endregion 	
        public override void FromEntityData(UFSoft.UBF.Business.DataTransObjectBase dto)
        {
			WSLogData data = dto as WSLogData ;
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
		public void FromEntityData(WSLogData data)
		{
			this.FromEntityData(data,new Hashtable());
		}
		//used by ubf..
		public void FromEntityData(WSLogData data,IDictionary dict)
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
		
								this.SetTypeValue("RequestUrl",data.RequestUrl);
		
								this.SetTypeValue("ClassName",data.ClassName);
		
								this.SetTypeValue("MethodName",data.MethodName);
		
								this.SetTypeValue("StartTime",data.StartTime);
		
								this.SetTypeValue("EndTime",data.EndTime);
		
								this.SetTypeValue("ElapsedSecond",data.ElapsedSecond);
		
								this.SetTypeValue("RequestContent",data.RequestContent);
		
								this.SetTypeValue("ResponseContent",data.ResponseContent);
		
								this.SetTypeValue("ErrorMessage",data.ErrorMessage);
		
								this.SetTypeValue("CallCount",data.CallCount);
		
								this.SetTypeValue("MethodDescription",data.MethodDescription);
		
								this.SetTypeValue("EnterpriseID",data.EnterpriseID);
		
			#endregion 

			#region 组件内属性
	
					this.SetTypeValue("CallResult",data.CallResult);
	     

			#endregion 
			this.NeedPersistable = m_isNeedPersistable ;
			dict[data] = this;
		}

		/// <summary>
		/// Create EntityData From Entity
		/// </summary>
		public WSLogData ToEntityData()
		{
			return ToEntityData(null,null);
		}
		/// <summary>
		/// Create EntityData From Entity - used by ubf 
		/// </summary>
		public WSLogData ToEntityData(WSLogData data, IDictionary dict){
			if (data == null)
				data = new WSLogData();
			
			if (dict == null ) dict = new Hashtable() ;
			//就直接用ID,如果不同实体会出现相同ID，则到时候要改进。? ID一定要有。
			dict["UFIDA.U9.Cust.Pub.WSLogBE.WSLog"+this.ID.ToString()] = data;
		
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
				object obj =this.GetValue("RequestUrl");
				if (obj != null)
					data.RequestUrl=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("ClassName");
				if (obj != null)
					data.ClassName=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("MethodName");
				if (obj != null)
					data.MethodName=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("StartTime");
				if (obj != null)
					data.StartTime=(System.DateTime)obj;
			}
	     
	    
			{
				object obj =this.GetValue("EndTime");
				if (obj != null)
					data.EndTime=(System.DateTime)obj;
			}
	     
	    
			{
				object obj =this.GetValue("ElapsedSecond");
				if (obj != null)
					data.ElapsedSecond=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("RequestContent");
				if (obj != null)
					data.RequestContent=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("ResponseContent");
				if (obj != null)
					data.ResponseContent=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("ErrorMessage");
				if (obj != null)
					data.ErrorMessage=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("CallCount");
				if (obj != null)
					data.CallCount=(System.Int32)obj;
			}
	     
	    
			{
				object obj =this.GetValue("MethodDescription");
				if (obj != null)
					data.MethodDescription=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("EnterpriseID");
				if (obj != null)
					data.EnterpriseID=(System.String)obj;
			}
	     
			#endregion 

			#region 组件内属性 -Entity,"复杂值对象",枚举,实体集合.
	
			{
				object obj =this.GetValue("CallResult");
				if (obj != null)
					data.CallResult=System.Int32.Parse(obj.ToString());
			}
	

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
		
			
		}
			    
	#endregion 
	
	
		#region 应用版型代码区
		#endregion 


	}	
}