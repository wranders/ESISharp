using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class FactionWarfare : PathTest
    {
        [Property("Public", "Faction Warfare")]
        [Test]
        public void GetWars()
        {
            var r = Public.FactionWarfare.GetWars().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Faction Warfare")]
        [Test]
        public void GetStats()
        {
            var r = Public.FactionWarfare.GetStats().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Faction Warfare")]
        [Test]
        public void GetSystems()
        {
            var r = Public.FactionWarfare.GetSystems().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Faction Warfare")]
        [Test]
        public void GetLeaderboards()
        {
            var r = Public.FactionWarfare.GetLeaderboards().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Faction Warfare")]
        [Test]
        public void GetCharacterLeaderboards()
        {
            var r = Public.FactionWarfare.GetCharacterLeaderboards().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Faction Warfare")]
        [Test]
        public void GetCorporationLeaderboards()
        {
            var r = Public.FactionWarfare.GetCorporationLeaderboards().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

    }
}
