
using System;
using System.Collections;
using System.Transactions;
using NUnit.Framework;
using UFSoft.UBF.Business;

namespace UFIDA.U9.Cust.Pub.WSM.WSTokenBE.TestSuite{

	/// <summary>
	/// WSToken Auto Test Class
	/// </summary>
	[TestFixture]
	public partial class WSTokenTest{
		/// <summary>
		/// test Create
		/// </summary>
		//[Test]
		public void WSTokenCRUD() {
		/*	using (TransactionScope scope = new TransactionScope())
			{
				#region __merge CustomVariable
				UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken obj;
				//add you custome variable code here ...
				#endregion

				using (ISession session = Session.Open()) {
					#region __merge CreateWSToken
										obj  = UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken.Create() ;
					//add you custome assign code here ...
					#endregion

					Assert.IsNotNull(obj, " Create <" + typeof(WSToken).ToString() + "> failed.");
					session.Commit();
				}
	
				UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken.EntityList list = UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken.Finder.FindAll("");
				Assert.IsTrue(list.Contains(obj), " Add <" + typeof(UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken).ToString() + "> failed.");
				using (ISession session = Session.Open()) {
					#region __merge RemoveWSToken	
					obj.Remove();
					//add you custom remove code here ...
					#endregion

					session.Commit();
				}
				list = UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken.Finder.FindAll("");
				Assert.IsFalse(list.Contains(obj), " Delete <" + typeof(UFIDA.U9.Cust.Pub.WSM.WSTokenBE.WSToken).ToString() + "> failed.");
			}
		*/
		}
	}
}

