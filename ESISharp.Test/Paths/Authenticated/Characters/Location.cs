using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Location : PathTest
    {
        [Property("AuthedCharacters", "Location")]
        [Test]
        public void GetLocation()
        {
            var a = Authenticated.Characters.Location.GetLocation(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Location")]
        [Test]
        public void GetOnlineStatus()
        {
            var a = Authenticated.Characters.Location.GetOnlineStatus(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Location")]
        [Test]
        public void GetCurrentShip()
        {
            var a = Authenticated.Characters.Location.GetCurrentShip(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
