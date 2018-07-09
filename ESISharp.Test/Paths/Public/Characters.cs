using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Characters : PathTest
    {
        [Property("Public", "Characters")]
        [TestCase(91105772)]
        public void GetInformation(int characterid)
        {
            var r = Public.Characters.GetInformation(characterid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Characters")]
        [TestCase(91105772)]
        [TestCase(new int[] { 91105772, 92168909 })]
        public void GetAffiliation(dynamic characterids)
        {
            var r = Public.Characters.GetAffiliation(characterids).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Characters")]
        [TestCase(91105772)]
        public void GetPortraits(int characterid)
        {
            var r = Public.Characters.GetPortraits(characterid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Characters")]
        [TestCase(91105772)]
        public void GetCorporationHistory(int characterid)
        {
            var r = Public.Characters.GetCorporationHistory(characterid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
