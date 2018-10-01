using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Bookmarks : PathTest
    {
        [Property("AuthedCharacters", "Bookmarks")]
        [TestCase(2)]
        [TestCase(3)]
        public void GetAll(int page)
        {
            var r = Authenticated.Characters.Bookmarks.GetAll(GetCharacterId(), page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Bookmarks")]
        [Test]
        public void GetFolders()
        {
            var r = Authenticated.Characters.Bookmarks.GetFolders(GetCharacterId()).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Bookmarks")]
        [TestCase(2)]
        [TestCase(3)]
        public void GetFolders(int page)
        {
            var r = Authenticated.Characters.Bookmarks.GetFolders(GetCharacterId(), page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
