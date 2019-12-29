using System;
using System.Collections.Generic;
using System.Text;
using UFSoft.UBF.Business;
namespace UFIDA.U9.Cust.Pub.WSLogBE
{
    /// <summary>
    /// 可扩展枚举: 调用结果枚举 
    /// 
    /// </summary>
    //枚举可以考虑加基类，目前不改也没影响。
    public sealed class CallResultEnum
    {

        //private static readonly ExtendableEnum innerExtendableEnum = new ExtendableEnum("UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum");
        #region ctor & cctor 
        static CallResultEnum()
        {
            InitData();
        }
        private CallResultEnum(int eValue)
        {
            this.currentValue = eValue;
        }
        private CallResultEnum(int eValue,string name)
        {
            this.currentValue = eValue;
			this.name = name ;
        }
        private static void InitData()
        {
            innerEnums = new System.Collections.Generic.Dictionary<System.Int32,CallResultEnum>();
            failure = new CallResultEnum(0,"Failure") ;
            innerEnums.Add(0,failure) ;
            success = new CallResultEnum(1,"Success") ;
            innerEnums.Add(1,success) ;
            empty = new CallResultEnum(-1,"") ;
			innerEnums.Add(-1,empty) ;
        }
        #endregion

        #region  Empty Value
        private static CallResultEnum empty;
        public static CallResultEnum Empty
        {
            get
            {
                return empty;
            }
        }
        #endregion 

        #region Intstance Propertites 
        private int currentValue;
        public System.Int32 Value
        {
            get
            {
				return currentValue ;         
            }
        }
        private string  name ;
        public string  Name 
        {
            get
            {
                return name;
            }
        }
        [System.Obsolete("已经废弃,请用EnumRes.GetResource(name)方式来获取显示名称. ")]
        public string Res_Name
        {
        	get 
        	{
        		switch ( this.Name )
        		{
        			case "Failure":
        				return this.Res_Failure; 
        			case "Success":
        				return this.Res_Success; 
        			default :
        			    return String.Empty;
        		}
        	}
        }
        #endregion 

        #region public static enum member
        private static CallResultEnum failure ;
        /// <summary>
        /// 枚举值: 失败  Value:0  
        /// 调用结果枚举.Misc.失败
        /// </summary>
        public static CallResultEnum Failure
        {
            get
            {
                return  failure ;
            }
        }
        private static CallResultEnum success ;
        /// <summary>
        /// 枚举值: 成功  Value:1  
        /// 调用结果枚举.Misc.成功
        /// </summary>
        public static CallResultEnum Success
        {
            get
            {
                return  success ;
            }
        }
        #endregion

        #region public Static Property & Method 
        private static System.Collections.Generic.IDictionary<System.Int32, CallResultEnum> innerEnums;
        /// <summary>
        /// Get CallResultEnum's All Values.
        /// </summary>
        public static System.Collections.Generic.ICollection<CallResultEnum> Values
        {
            get
            {
                return  innerEnums.Values;
            }
        }
	
        private static object lockobj = new object();
        /// <summary>
        /// Get CallResultEnum By Value 
        /// </summary>
        public static CallResultEnum GetFromValue(System.Int32 value)
        {
            //仅返回空的方法不是太好,在用的时候,枚举值可能就会设置一个枚举项中没有的,或者枚举值被删除.?
            if (!innerEnums.ContainsKey(value))
            {
                lock (lockobj)
                {
                    if (!innerEnums.ContainsKey(value))
                    {
						CallResultEnum newValue = new CallResultEnum(value, "");
						innerEnums.Add(value,newValue);
						return newValue ;
					}
				}	
            }
            return innerEnums[value]; 
        }
		/// <summary>
        /// Get CallResultEnum By Value 
        /// </summary>
        public static CallResultEnum GetFromValue(object value)
        {
			if (value == null)
				return CallResultEnum.Empty ;
			System.Int32 resultValue = 0 ;
			if (!System.Int32.TryParse(value.ToString(),out resultValue))
				throw new ArgumentException(string.Format("枚举数据异常，该枚举数据值'{0}'为非整型数据",value));
			return GetFromValue(resultValue) ;
        }
        /// <summary>
        /// Get CallResultEnum By Name 
        /// </summary>
        public static CallResultEnum GetFromName(string name)
        {
            foreach (CallResultEnum obj in innerEnums.Values)
            {
                if (obj.Name == name)
                    return obj;
            }
            //don't need modify to return a Default Value .
            return null;
        }
        #endregion 


		#region ModelResource
		/// <summary>
		/// 调用结果枚举的显示名称资源
		/// </summary>
		public string Res_TypeName {	get {return Res_TypeNameS ;}	}
		/// <summary>
		/// 调用结果枚举的显示名称资源
		/// </summary>
		public static string Res_TypeNameS {	get {return EnumRes.GetResource("UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum")  ;} }

		/// <summary>
		/// 已经废弃,请直接使用 EnumRes.GetResource(枚举对象.Name)来取属性的显示资源.
		/// </summary>
        [Obsolete("")]
		public string Res_Failure　{ get {return EnumRes.GetResource("Failure");}　}
		/// <summary>
		/// 已经废弃,请直接使用 EnumRes.GetResource(枚举对象.Name)来取属性的显示资源.
		/// </summary>
        [Obsolete("")]
		public string Res_Success　{ get {return EnumRes.GetResource("Success");}　}
		#endregion 
		
		#region EnumRes
		public class EnumRes
		{
			/// <summary>
			/// 枚举全名: FullName 
			/// </summary>
			public static string Enum_FullName { get { return "UFIDA.U9.Cust.Pub.WSLogBE.CallResultEnum";　}　}

			/// <summary>
			///  获取资源接口,直接传了枚举对象.Name 就可.
			/// </summary>
			public static string GetResource(String attrName)
			{
				if (attrName== Enum_FullName)
					return UFSoft.UBF.Business.Tool.ExtendHelpAPI.GetEnumResource(Enum_FullName);
				return UFSoft.UBF.Business.Tool.ExtendHelpAPI.GetEnumResource(Enum_FullName, attrName);
			}
			/// <summary>
			///  获取资源接口,直接传了枚举对象.Value 或Int32值 就可.
			/// </summary>
			public static string GetResourceByValue(Int32 value)
			{
				return UFSoft.UBF.Business.Tool.ExtendHelpAPI.GetNameForEnumValue(Enum_FullName, value);
			}
		}
		#endregion 
    }
}