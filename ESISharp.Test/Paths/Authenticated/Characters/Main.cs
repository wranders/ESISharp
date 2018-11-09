using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;


namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Main : PathTest
    {
        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetAgentResearch()
        {
            var a = Authenticated.Characters.GetAgentResearch(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetBlueprints()
        {
            var a = Authenticated.Characters.GetBlueprints(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [TestCase(1)]
        [TestCase(2)]
        public void GetBlueprints(int page)
        {
            var a = Authenticated.Characters.GetBlueprints(GetCharacterId(), page).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [TestCase(2112424022)]
        public void CalculateCspaCharge(int charactertocheck)
        {
            var a = Authenticated.Characters.CalculateCspaCharge(GetCharacterId(), charactertocheck).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
        }

        [Property("AuthedCharacters", "Main")]
        [TestCase(new int[] { 2112424022 })]
        public void CalculateCspaCharge(IEnumerable<int> characterstocheck)
        {
            var a = Authenticated.Characters.CalculateCspaCharge(GetCharacterId(), characterstocheck).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
        }

        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetFatigue()
        {
            var a = Authenticated.Characters.GetFatigue(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetMedals()
        {
            var a = Authenticated.Characters.GetMedals(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetNotifications()
        {
            var a = Authenticated.Characters.GetNotifications(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetNotificationsContacts()
        {
            var a = Authenticated.Characters.GetNotificationsContacts(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetRoles()
        {
            var a = Authenticated.Characters.GetRoles(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetStandings()
        {
            var a = Authenticated.Characters.GetStandings(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetStats()
        {
            var a = Authenticated.Characters.GetStats(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetTitles()
        {
            var a = Authenticated.Characters.GetTitles(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
