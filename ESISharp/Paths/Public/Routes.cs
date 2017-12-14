using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.Paths.Public
{
    public class Routes : ApiPath
    {
        internal Routes(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetRoute(int originid, int destinationid)
        {
            return GetRoute(originid, destinationid, RouteFlag.Shortest, new RouteFilter());
        }

        public EsiRequest GetRoute(int originid, int destinationid, RouteFlag flag)
        {
            return GetRoute(originid, destinationid, flag, new RouteFilter());
        }

        public EsiRequest GetRoute(int originid, int destinationid, RouteFilter routefilter)
        {
            return GetRoute(originid, destinationid, RouteFlag.Shortest, routefilter);
        }

        [Path("/route/{origin}/{destination}/", WebMethods.GET)]
        public EsiRequest GetRoute(int originid, int destinationid, RouteFlag flag, RouteFilter routefilter)
        {
            var path = new EsiRequestPath { "route", originid.ToString(), destinationid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>()
            };
            if (routefilter.Avoid != null)
                data.Query.Add("avoid", routefilter.Avoid);
            if (routefilter.Connections != null)
                data.Query.Add("connections", string.Join(",", routefilter.Connections.Select(kvp => string.Format(@"{0}|{1}", kvp.Item1, kvp.Item2))));
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
