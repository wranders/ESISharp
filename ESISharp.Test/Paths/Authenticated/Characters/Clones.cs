using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Clones : PathTest
    {
        [Property("AuthedCharacters", "Clones")]
        [Test]
        public void GetAll()
        {
            var a = Authenticated.Characters.Clones.GetAll(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Clones")]
        [Test]
        public void GetActiveImplants()
        {
            var a = Authenticated.Characters.Clones.GetActiveImplants(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
