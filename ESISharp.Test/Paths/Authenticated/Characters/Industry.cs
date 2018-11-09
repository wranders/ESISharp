using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Industry : PathTest
    {
        [Property("AuthedCharacters", "Industry")]
        [Test]
        public void GetJobs()
        {
            var a = Authenticated.Characters.Industry.GetJobs(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Industry")]
        [TestCase(false)]
        [TestCase(true)]
        public void GetJobs(bool includecompleted)
        {
            var a = Authenticated.Characters.Industry.GetJobs(GetCharacterId(), includecompleted).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Industry")]
        [Test]
        public void GetMiningLedger()
        {
            var a = Authenticated.Characters.Industry.GetMiningLedger(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Industry")]
        [TestCase(1)]
        [TestCase(2)]
        public void GetMiningLedger(int page)
        {
            var a = Authenticated.Characters.Industry.GetMiningLedger(GetCharacterId(), page).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
