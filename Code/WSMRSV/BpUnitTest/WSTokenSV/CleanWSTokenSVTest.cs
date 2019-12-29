

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenSV
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
	public class CleanWSTokenSVTest
	{
		private Proxy.CleanWSTokenSVProxy obj = new Proxy.CleanWSTokenSVProxy();

		public CleanWSTokenSVTest()
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