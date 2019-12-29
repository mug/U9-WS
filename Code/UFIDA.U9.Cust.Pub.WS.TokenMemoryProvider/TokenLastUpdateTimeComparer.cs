using System;
using System.Collections;
using UFIDA.U9.Cust.Pub.WS.Token;

namespace UFIDA.U9.Cust.Pub.WS.Token.MemoryProvider
{
    internal class TokenLastUpdateTimeComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Token xT = (Token) x;
            Token yT = (Token) y;
            return DateTime.Compare(xT.LastUpdateTime, yT.LastUpdateTime);
        }
    }
}