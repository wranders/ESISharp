using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated
{
    public class Markets : PathTest
    {
        [Untestable] // Public Citadel market access too unreliable
        [Property("Authenticated", "Markets")]
        [TestCase(1000000000000)]
        public void GetStructureOrders(long structureid)
        {
            var r = Authenticated.Markets.GetStructureOrders(structureid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Untestable] // Public Citadel market access too unreliable
        [Property("Authenticated", "Markets")]
        [TestCase(1000000000000, 2)]
        public void GetStructureOrders(long structureid, int page)
        {
            var r = Authenticated.Markets.GetStructureOrders(structureid, page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
