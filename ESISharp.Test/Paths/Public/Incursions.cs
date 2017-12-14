using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Incursions : PathTest
    {
        [Property("Public", "Incursions")]
        [Test]
        public void GetIncursions()
        {
            var r = Public.Incursions.GetIncursions().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
