using System;
using System.Collections.Generic;

namespace UFIDA.U9.Cust.Pub.WS.CommService.Json.Linq.JsonPath
{
    internal class QueryFilter : PathFilter
    {
        public QueryExpression Expression { get; set; }

        public override IEnumerable<JToken> ExecuteFilter(IEnumerable<JToken> current, bool errorWhenNoMatch)
        {
            foreach (JToken t in current)
            {
                foreach (JToken v in t)
                {
                    if (Expression.IsMatch(v))
                        yield return v;
                }
            }
        }
    }
}