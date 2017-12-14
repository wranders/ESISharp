using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Industry : PathTest
    {
        [Property("Public", "Industry")]
        [Test]
        public void GetFacilities()
        {
            var r = Public.Industry.GetFacilities().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Industry")]
        [Test]
        public void GetSystemIndicies()
        {
            var r = Public.Industry.GetSystemIndicies().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
