using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Opportunities : PathTest
    {
        [Property("AuthedCharacters", "Opportunities")]
        [Test]
        public void GetCompleted()
        {
            var a = Authenticated.Characters.Opportunities.GetCompleted(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
