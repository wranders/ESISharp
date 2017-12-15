using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Wars : PathTest
    {
        [Property("Public", "Wars")]
        [Test]
        public void Get()
        {
            var r = Public.Wars.Get().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Wars")]
        [TestCase(10000)]
        public void Get(int maxwarid)
        {
            var r = Public.Wars.Get(maxwarid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Wars")]
        [TestCase(10000)]
        public void GetInfo(int maxwarid)
        {
            var r = Public.Wars.GetInfo(maxwarid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Wars")]
        [TestCase(291410)]
        public void GetKillmails(int warid)
        {
            var r = Public.Wars.GetKillmails(warid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Wars")]
        [TestCase(291410, 2)]
        public void GetKillmails(int warid, int page)
        {
            var r = Public.Wars.GetKillmails(warid, page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
