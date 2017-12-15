using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Sovereignty : PathTest
    {
        [Property("Public", "Sovereignty")]
        [Test]
        public void GetStructures()
        {
            var r = Public.Sovereignty.GetStructures().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Sovereignty")]
        [Test]
        public void GetCampaigns()
        {
            var r = Public.Sovereignty.GetCampaigns().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Sovereignty")]
        [Test]
        public void GetSystems()
        {
            var r = Public.Sovereignty.GetSystems().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
