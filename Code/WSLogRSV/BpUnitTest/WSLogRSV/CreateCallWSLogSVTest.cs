

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
	public class CreateCallWSLogSVTest
	{
		private Proxy.CreateCallWSLogSVProxy obj = new Proxy.CreateCallWSLogSVProxy();

		public CreateCallWSLogSVTest()
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