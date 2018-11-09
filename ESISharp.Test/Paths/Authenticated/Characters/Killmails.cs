using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;


namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Killmails : PathTest
    {
        [Property("AuthedCharacters", "Killmails")]
        [Test]
        public void Get()
        {
            var a = Authenticated.Characters.Killmails.Get(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Killmails")]
        [TestCase(5)]
        public void Get(int maxcount)
        {
            var a = Authenticated.Characters.Killmails.Get(GetCharacterId(), maxcount).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Killmails")]
        [TestCase(5, 99999999)]
        public void Get(int maxcount, int maxkillid)
        {
            var a = Authenticated.Characters.Killmails.Get(GetCharacterId(), maxcount, maxkillid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
