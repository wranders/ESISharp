using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Corporation : PathTest
    {
        [Property("Public", "Corporations")]
        [TestCase(109299958)]
        public void GetInformation(int corporationid)
        {
            var r = Public.Corporations.GetInformation(corporationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Corporations")]
        [TestCase(109299958)]
        public void GetAllianceHistory(int corporationid)
        {
            var r = Public.Corporations.GetAllianceHistory(corporationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Corporations")]
        [TestCase(109299958)]
        public void GetIcons(int corporationid)
        {
            var r = Public.Corporations.GetIcons(corporationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Corporations")]
        [Test]
        public void GetNpcCorps()
        {
            var r = Public.Corporations.GetNpcCorps().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
