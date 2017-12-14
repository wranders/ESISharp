using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Loyalty : PathTest
    {
        [Property("Public", "Loyalty")]
        [TestCase(1000160)]
        public void GetStoreOffers(int corporationid)
        {
            var r = Public.Loyalty.GetStoreOffers(corporationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
