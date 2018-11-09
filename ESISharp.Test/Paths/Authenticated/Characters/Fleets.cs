using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Fleets : PathTest
    {
        [Untestable]
        [Property("AuthedCharacters", "Fleets")]
        [Test]
        public void GetInfo()
        {
            var a = Authenticated.Characters.Fleets.GetInfo(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
