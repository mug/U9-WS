

namespace UFIDA.U9.Cust.Pub.WSLogSV
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
	public class CreateWSLogSVTest
	{
		private Proxy.CreateWSLogSVProxy obj = new Proxy.CreateWSLogSVProxy();

		public CreateWSLogSVTest()
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