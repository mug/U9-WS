
using System;
using System.Collections;
using System.Transactions;
using NUnit.Framework;
using UFSoft.UBF.Business;

namespace UFIDA.U9.Cust.Pub.WSLogBE.TestSuite{

	/// <summary>
	/// WSLog Auto Test Class
	/// </summary>
	[TestFixture]
	public partial class WSLogTest{
		/// <summary>
		/// test Create
		/// </summary>
		//[Test]
		public void WSLogCRUD() {
		/*	using (TransactionScope scope = new TransactionScope())
			{
				#region __merge CustomVariable
				UFIDA.U9.Cust.Pub.WSLogBE.WSLog obj;
				//add you custome variable code here ...
				#endregion

				using (ISession session = Session.Open()) {
					#region __merge CreateWSLog
										obj  = UFIDA.U9.Cust.Pub.WSLogBE.WSLog.Create() ;
					//add you custome assign code here ...
					#endregion

					Assert.IsNotNull(obj, " Create <" + typeof(WSLog).ToString() + "> failed.");
					session.Commit();
				}
	
				UFIDA.U9.Cust.Pub.WSLogBE.WSLog.EntityList list = UFIDA.U9.Cust.Pub.WSLogBE.WSLog.Finder.FindAll("");
				Assert.IsTrue(list.Contains(obj), " Add <" + typeof(UFIDA.U9.Cust.Pub.WSLogBE.WSLog).ToString() + "> failed.");
				using (ISession session = Session.Open()) {
					#region __merge RemoveWSLog	
					obj.Remove();
					//add you custom remove code here ...
					#endregion

					session.Commit();
				}
				list = UFIDA.U9.Cust.Pub.WSLogBE.WSLog.Finder.FindAll("");
				Assert.IsFalse(list.Contains(obj), " Delete <" + typeof(UFIDA.U9.Cust.Pub.WSLogBE.WSLog).ToString() + "> failed.");
			}
		*/
		}
	}
}

