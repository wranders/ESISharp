using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;


namespace ESISharp.Test.Paths.Public
{
    public class Alliance : PathTest
    {
        [Property("Public", "Alliance")]
        [TestCase(1354830081)]
        public void GetInformation(int allianceid)
        {
            var r = Public.Alliance.GetInformation(allianceid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Alliance")]
        [TestCase(1354830081)]
        public void GetCorporations(int allianceid)
        {
            var r = Public.Alliance.GetCorporations(allianceid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Alliance")]
        [TestCase(1354830081)]
        [TestCase(new long[] { 1354830081, 498125261 })]
        public void GetNames(dynamic allianceids)
        {
            var r = Public.Alliance.GetNames(allianceids).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Alliance")]
        [TestCase(1354830081)]
        public void GetIcons(int allianceid)
        {
            var r = Public.Alliance.GetIcons(allianceid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Test]
        [Property("Public", "Alliance")]
        public void GetAll()
        {
            var r = Public.Alliance.GetAll().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
