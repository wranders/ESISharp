using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Dogma : PathTest
    {
        [Property("Public", "Dogma")]
        [Test]
        public void GetAttributes()
        {
            var r = Public.Dogma.GetAttributes().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Dogma")]
        [TestCase(2)]
        public void GetAttributeInformation(int attributeid)
        {
            var r = Public.Dogma.GetAttributeInformation(attributeid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Dogma")]
        [Test]
        public void GetEffects()
        {
            var r = Public.Dogma.GetEffects().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Dogma")]
        [TestCase(4)]
        public void GetEffectInformation(int effectid)
        {
            var r = Public.Dogma.GetEffectInformation(effectid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Dogma")]
        [Test]
        public void GetDynamicItemInformation(int typeid, int itemid)
        {
            //TODO: Figure out how this endpoint works and what it's for, then write a test.
            Assert.True(true);
        }
    }
}
