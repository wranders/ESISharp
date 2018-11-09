using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class PlanetaryInteraction : PathTest
    {
        [Property("AuthedCharacters", "PlanetaryInteraction")]
        [Test]
        public void GetColonies()
        {
            var a = Authenticated.Characters.PlanetaryInteraction.GetColonies(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Untestable]
        [Property("AuthedCharacters", "PlanetaryInteraction")]
        [TestCase(99999999)]
        public void GetColonyLayout(int planetid)
        {
            var a = Authenticated.Characters.PlanetaryInteraction.GetColonyLayout(GetCharacterId(), planetid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
