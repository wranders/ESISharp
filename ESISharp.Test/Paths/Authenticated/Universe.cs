using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated
{
    public class Universe : PathTest
    {
        [Property("Authenticated", "Universe")]
        [TestCase(1023814371106)]
        public void GetStructureInformation(long structureid)
        {
            var r = Authenticated.Universe.GetStructureInformation(structureid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
