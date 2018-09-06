using ESISharp.Enumeration;
using ESISharp.Model.Object;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Routes : PathTest
    {
#pragma warning disable S1144

        static readonly object[] GetRoute_One =
        {
            new object[] { 30000142, 30002187, RouteFlag.Shortest },
            new object[] { 30000142, 30002187, RouteFlag.Secure },
            new object[] { 30000142, 30002187, RouteFlag.Insecure }
        };

        static readonly object[] GetRoute_Two =
        {
            new object[] { 30000142, 30002187, new RouteFilter { Avoid = new List<int> { 30003504 } } },
            new object[] { 30000142, 30002187, new RouteFilter { Connections = new List<RouteConnection> { new RouteConnection( 30000142, 30000140 ), new RouteConnection( 30000140, 30000144 ) } } },
            new object[] { 30000142, 30002187, new RouteFilter { Avoid = new List<int> { 30003504 }, Connections = new List<RouteConnection> { new RouteConnection(30000142, 30000140), new RouteConnection(30000140, 30000144) } } }
        };

        static readonly object[] GetRoute_Three =
        {
            new object[] { 30000142, 30002187, RouteFlag.Shortest, new RouteFilter { Avoid = new List<int> { 30003504 } } },
            new object[] { 30000142, 30002187, RouteFlag.Shortest, new RouteFilter { Connections = new List<RouteConnection> { new RouteConnection( 30000142, 30000140 ), new RouteConnection( 30000140, 30000144 ) } } },
            new object[] { 30000142, 30002187, RouteFlag.Shortest, new RouteFilter { Avoid = new List<int> { 30003504 }, Connections = new List<RouteConnection> { new RouteConnection(30000142, 30000140), new RouteConnection(30000140, 30000144) } } },
            new object[] { 30000142, 30002187, RouteFlag.Secure, new RouteFilter { Avoid = new List<int> { 30003504 } } },
            new object[] { 30000142, 30002187, RouteFlag.Secure, new RouteFilter { Connections = new List<RouteConnection> { new RouteConnection( 30000142, 30000140 ), new RouteConnection( 30000140, 30000144 ) } } },
            new object[] { 30000142, 30002187, RouteFlag.Secure, new RouteFilter { Avoid = new List<int> { 30003504 }, Connections = new List<RouteConnection> { new RouteConnection(30000142, 30000140), new RouteConnection(30000140, 30000144) } } },
            new object[] { 30000142, 30002187, RouteFlag.Insecure, new RouteFilter { Avoid = new List<int> { 30003504 } } },
            new object[] { 30000142, 30002187, RouteFlag.Insecure, new RouteFilter { Connections = new List<RouteConnection> { new RouteConnection( 30000142, 30000140 ), new RouteConnection( 30000140, 30000144 ) } } },
            new object[] { 30000142, 30002187, RouteFlag.Insecure, new RouteFilter { Avoid = new List<int> { 30003504 }, Connections = new List<RouteConnection> { new RouteConnection(30000142, 30000140), new RouteConnection(30000140, 30000144) } } }
        };

#pragma warning restore

        [Property("Public", "Routes")]
        [TestCase(30000142, 30002187)]
        public void GetRoute(int originid, int destinationid)
        {
            var r = Public.Routes.GetRoute(originid, destinationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Routes")]
        [Test, TestCaseSource("GetRoute_One")]
        public void GetRoute(int originid, int destinationid, RouteFlag flag)
        {
            var r = Public.Routes.GetRoute(originid, destinationid, flag).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Routes")]
        [Test, TestCaseSource("GetRoute_Two")]
        public void GetRoute(int originid, int destinationid, RouteFilter routefilter)
        {
            var r = Public.Routes.GetRoute(originid, destinationid, routefilter).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Routes")]
        [Test, TestCaseSource("GetRoute_Three")]
        public void GetRoute(int originid, int destinationid, RouteFlag routeflag, RouteFilter routefilter)
        {
            var r = Public.Routes.GetRoute(originid, destinationid, routeflag, routefilter).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
