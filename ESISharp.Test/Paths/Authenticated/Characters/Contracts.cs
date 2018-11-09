using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Contracts : PathTest
    {
        [Property("AuthedCharacters", "Contracts")]
        [Test]
        public void GetContracts()
        {
            var a = Authenticated.Characters.Contracts.GetContracts(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Contracts")]
        [TestCase(1)]
        [TestCase(2)]
        public void GetContacts(int page)
        {
            var a = Authenticated.Characters.Contracts.GetContracts(GetCharacterId(), page).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Untestable]
        [Property("AuthedCharacters", "Contracts")]
        [TestCase(0)]
        public void GetContractBids(int contractid)
        {
            var a = Authenticated.Characters.Contracts.GetContractBids(GetCharacterId(), contractid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Untestable]
        [Property("AuthedCharacters", "Contracts")]
        [TestCase(0)]
        public void GetContractItems(int contractid)
        {
            var a = Authenticated.Characters.Contracts.GetContractItems(GetCharacterId(), contractid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
