using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Markets : PathTest
    {
        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetOpenOrders()
        {
            var a = Authenticated.Characters.Markets.GetOpenOrders(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [Test]
        public void GetOrdersHistory()
        {
            var a = Authenticated.Characters.Markets.GetOrdersHistory(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Main")]
        [TestCase(1)]
        [TestCase(2)]
        public void GetOrdersHistory(int page)
        {
            var a = Authenticated.Characters.Markets.GetOrdersHistory(GetCharacterId(), page).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
