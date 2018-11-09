using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Fleets : PathTest
    {
        [Property("AuthedCharacters", "Fleets")]
        [Test]
        public void GetAll()
        {
            // This test is not fool-proof. Chances are, the character being used is not a fleet, so
            // this will return a 404 with the error message being something like "character is not 
            // in a fleet".
            // This only currently tests for a 404, which could occur if the path is unavailable for 
            // some other reason.
            var a = Authenticated.Characters.Fleets.GetInfo(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.NotFound);
        }
    }
}
