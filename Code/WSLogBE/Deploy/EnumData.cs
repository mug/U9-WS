using System;
using System.Collections.Generic;
using System.Text;
using UFSoft.UBF.Business;

namespace UFIDA.U9.Cust.Pub.WSLogBE
{
	/// <summary>
	/// 枚举值: 调用结果枚举 
	/// 
	/// </summary>
	//枚举可以考虑加基类，目前不改也没影响。
	public enum CallResultEnumData
	{
		/// <summary>
		/// 失败
		/// </summary>
		Failure = 0,
		/// <summary>
		/// 成功
		/// </summary>
		Success = 1,
		/// <summary>
		/// 空值(-1)
		/// </summary>
		Empty  = -1 
	}
}

