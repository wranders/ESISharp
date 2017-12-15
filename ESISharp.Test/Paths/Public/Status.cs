using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Status : PathTest
    {
        [Property("Public", "Status")]
        [Test]
        public void Get()
        {
            var r = Public.Status.Get().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
