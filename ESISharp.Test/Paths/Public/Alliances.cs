using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;


namespace ESISharp.Test.Paths.Public
{
    public class Alliances : PathTest
    {
        [Property("Public", "Alliances")]
        [TestCase(1354830081)]
        public void GetInformation(int allianceid)
        {
            var r = Public.Alliances.GetInformation(allianceid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Alliances")]
        [TestCase(1354830081)]
        public void GetCorporations(int allianceid)
        {
            var r = Public.Alliances.GetCorporations(allianceid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Alliances")]
        [TestCase(1354830081)]
        [TestCase(new long[] { 1354830081, 498125261 })]
        public void GetNames(dynamic allianceids)
        {
            var r = Public.Alliances.GetNames(allianceids).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Alliances")]
        [TestCase(1354830081)]
        public void GetIcons(int allianceid)
        {
            var r = Public.Alliances.GetIcons(allianceid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Test]
        [Property("Public", "Alliances")]
        public void GetAll()
        {
            var r = Public.Alliances.GetAll().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
