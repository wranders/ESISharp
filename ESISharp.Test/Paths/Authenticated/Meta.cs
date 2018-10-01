using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated
{
    public class Meta : PathTest
    {
        [Property("Authenticated", "Meta")]
        [Test]
        public void Verify()
        {
            var r = Public.Meta.Verify(GetToken()).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
