using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Assets : PathTest
    {
        private const int CharacterId = 91105772;
#pragma warning disable S1144

        static readonly object[] GetAll_One =
        {
            new object[] { CharacterId, 2 },
            new object[] { CharacterId, 3 }
        };

        static readonly object[] GetLocations_One =
        {
            new object[] { CharacterId, new List<long>() { 1002143262874, 1026459286466 } }
        };

#pragma warning restore

        [Property("AuthedCharacters", "Assets")]
        [TestCase(CharacterId)]
        public void GetAll(int characterid)
        {
            var a = Authenticated.Characters.Assets.GetAll(characterid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Assets")]
        [Test,TestCaseSource("GetAll_One")]
        public void GetAll(int characterid, int page)
        {
            var a = Authenticated.Characters.Assets.GetAll(characterid, page).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Assets")]
        [TestCase(CharacterId, 1026459286466)]
        public void GetLocations(int characterid, long item)
        {
            var a = Authenticated.Characters.Assets.GetLocations(characterid, item).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Assets")]
        [Test, TestCaseSource("GetLocations_One")]
        public void GetLocations(int characterid, IEnumerable<long> item)
        {
            var a = Authenticated.Characters.Assets.GetLocations(characterid, item).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Assets")]
        [TestCase(CharacterId, 1026459286466)]
        public void GetNames(int characterid, long item)
        {
            var a = Authenticated.Characters.Assets.GetNames(characterid, item).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Assets")]
        [Test, TestCaseSource("GetLocations_One")]
        public void GetNames(int characterid, IEnumerable<long> item)
        {
            var a = Authenticated.Characters.Assets.GetNames(characterid, item).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
