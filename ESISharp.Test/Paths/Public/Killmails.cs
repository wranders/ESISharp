using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Killmails : PathTest
    {
        [Property("Public", "Killmails")]
        [TestCase(66370950, "82d68ba7bd2c0cd20ce6664f7f049157d1b3e0a0")]
        public void GetKillmail(int killmailid, string killmailhash)
        {
            var r = Public.Killmails.GetKillmail(killmailid, killmailhash).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
