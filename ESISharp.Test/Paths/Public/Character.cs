using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Character : PathTest
    {
        [Property("Public", "Character")]
        [TestCase(91105772)]
        public void GetInformation(int characterid)
        {
            var r = Public.Character.GetInformation(characterid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Character")]
        [TestCase(91105772)]
        [TestCase(new int[] { 91105772, 92168909 })]
        public void GetAffiliation(dynamic characterids)
        {
            var r = Public.Character.GetAffiliation(characterids).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Character")]
        [TestCase(91105772)]
        [TestCase(new long[] { 91105772, 92168909 })]
        public void GetNames(dynamic characterids)
        {
            var r = Public.Character.GetNames(characterids).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Character")]
        [TestCase(91105772)]
        public void GetPortraits(int characterid)
        {
            var r = Public.Character.GetPortraits(characterid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Character")]
        [TestCase(91105772)]
        public void GetCorporationHistory(int characterid)
        {
            var r = Public.Character.GetCorporationHistory(characterid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
