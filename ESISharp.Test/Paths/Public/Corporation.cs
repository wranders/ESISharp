using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Corporation : PathTest
    {
        [Property("Public", "Corporation")]
        [TestCase(109299958)]
        public void GetInformation(int corporationid)
        {
            var r = Public.Corporation.GetInformation(corporationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Corporation")]
        [TestCase(109299958)]
        public void GetAllianceHistory(int corporationid)
        {
            var r = Public.Corporation.GetAllianceHistory(corporationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Corporation")]
        [TestCase(109299958)]
        [TestCase(new long[] { 109299958, 216121397 })]
        public void GetNames(dynamic corporationid)
        {
            var r = Public.Corporation.GetNames(corporationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Corporation")]
        [TestCase(109299958)]
        public void GetIcons(int corporationid)
        {
            var r = Public.Corporation.GetIcons(corporationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Corporation")]
        [Test]
        public void GetNpcCorps()
        {
            var r = Public.Corporation.GetNpcCorps().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
