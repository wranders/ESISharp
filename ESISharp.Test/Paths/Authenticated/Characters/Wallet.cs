using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Wallet : PathTest
    {
        [Property("AuthedCharacters", "Wallet")]
        [Test]
        public void GetBalance()
        {
            var a = Authenticated.Characters.Wallet.GetBalance(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Wallet")]
        [Test]
        public void GetJournal()
        {
            var a = Authenticated.Characters.Wallet.GetJournal(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Wallet")]
        [TestCase(1)]
        [TestCase(2)]
        public void GetJournal(int page)
        {
            var a = Authenticated.Characters.Wallet.GetJournal(GetCharacterId(), page).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Wallet")]
        [Test]
        public void GetTransactions()
        {
            var a = Authenticated.Characters.Wallet.GetTransactions(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Wallet")]
        [TestCase(9999999999)]
        public void GetTransactions(long fromid)
        {
            var a = Authenticated.Characters.Wallet.GetTransactions(GetCharacterId(), fromid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
