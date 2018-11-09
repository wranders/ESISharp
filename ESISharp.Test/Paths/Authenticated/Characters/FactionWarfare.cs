using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class FactionWarfare : PathTest
    {
        [Property("AuthedCharacters", "FactionWarfare")]
        [Test]
        public void GetOverview()
        {
            var a = Authenticated.Characters.FactionWarfare.GetOverview(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
