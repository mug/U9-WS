

namespace UFIDA.U9.Cust.Pub.WSLogRSV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.IO;
	using NUnit.Framework;
	
	/// <summary>
	/// Business operation test
	/// </summary> 
	[TestFixture]		
	public class CreateBeforeCallWSLogSVTest
	{
		private Proxy.CreateBeforeCallWSLogSVProxy obj = new Proxy.CreateBeforeCallWSLogSVProxy();

		public CreateBeforeCallWSLogSVTest()
		{
		}
		#region AutoTestCode ...
		[Test]
		public void TestDo()
		{
			obj.Do() ;  
		
		}
		#endregion 				
	}
	
}