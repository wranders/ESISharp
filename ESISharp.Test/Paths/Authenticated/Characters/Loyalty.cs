using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Loyalty : PathTest
    {
        [Property("AuthedCharacters", "Location")]
        [Test]
        public void GetPoints()
        {
            var a = Authenticated.Characters.Loyalty.GetPoints(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
