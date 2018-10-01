using ESISharp.Test.Model.Abstract;
using NUnit.Framework;

using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Meta : PathTest
    {
        [Property("Public", "Meta")]
        [Test]
        public void Headers()
        {
            var r = Public.Meta.Headers().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Meta")]
        [Test]
        public void Ping()
        {
            var r = Public.Meta.Ping().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Meta")]
        [Test]
        public void Status()
        {
            var r = Public.Meta.Status().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Meta")]
        [Test]
        public void Versions()
        {
            var r = Public.Meta.Versions().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
