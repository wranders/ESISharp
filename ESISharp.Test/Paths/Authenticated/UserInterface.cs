using ESISharp.Enumeration;
using ESISharp.Model.Object;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated
{
    public class UserInterface : PathTest
    {
#pragma warning disable S1144, S3459, CS0649

        static readonly object[] SetWaypoint_TestOne =
        {
            new object[] { 30000142, true }
        };

        static readonly object[] SetWaypoint_TestTwo =
        {
            new object[] { 30000142, true, true }
        };

        static readonly object[] OpenNewMailWindow_TestOne =
        {
            new object[] {
                "This is the Body",
                91105772,
                "This is the Subject"
            }
        };

        static readonly object[] OpenNewMailWindow_TestTwo =
        {
            new object[] {
                "This is the Body",
                new List<int> { 91105772 },
                "This is the Subject"
            }
        };

#pragma warning restore

        [Property("Authenticated", "UserInterface")]
        [TestCase(30000142)]
        public void SetWaypoint(int destination)
        {
            var r = Authenticated.UserInterface.SetWaypoint(destination).Execute();
            Assert.True(r.Code == HttpStatusCode.NoContent);
        }

        [Property("Authenticated", "UserInterface")]
        [Test, TestCaseSource("SetWaypoint_TestOne")]
        public void SetWaypoint(int destination, bool addtobeginning)
        {
            var r = Authenticated.UserInterface.SetWaypoint(destination, addtobeginning).Execute();
            Assert.True(r.Code == HttpStatusCode.NoContent);
        }

        [Property("Authenticated", "UserInterface")]
        [Test, TestCaseSource("SetWaypoint_TestTwo")]
        public void SetWaypoint(int destination, bool addtobeginning, bool clearotherwaypoints)
        {
            var r = Authenticated.UserInterface.SetWaypoint(destination, addtobeginning, clearotherwaypoints).Execute();
            Assert.True(r.Code == HttpStatusCode.NoContent);
        }

        [Property("Authenticated", "UserInterface")]
        [TestCase(99999999)]
        public void OpenContractWindow(int contractid)
        {
            var r = Authenticated.UserInterface.OpenContractWindow(contractid).Execute();
            Assert.True(r.Code == HttpStatusCode.NoContent);
        }

        [Property("Authenticated", "UserInterface")]
        [TestCase(608)]
        public void OpenInformationWindow(int targetid)
        {
            var r = Authenticated.UserInterface.OpenInformationWindow(targetid).Execute();
            Assert.True(r.Code == HttpStatusCode.NoContent);
        }

        [Property("Authenticated", "UserInterface")]
        [TestCase(608)]
        public void OpenMarketDetailsWindow(int typeid)
        {
            var r = Authenticated.UserInterface.OpenMarketDetailsWindow(typeid).Execute();
            Assert.True(r.Code == HttpStatusCode.NoContent);
        }

        [Property("Authenticated", "UserInterface")]
        [Test, TestCaseSource("OpenNewMailWindow_TestOne")]
        public void OpenNewMailWindow(string body, int recipient, string subject)
        {
            var r = Authenticated.UserInterface.OpenNewMailWindow(body, recipient, subject).Execute();
            Assert.True(r.Code == HttpStatusCode.NoContent);
        }

        [Property("Authenticated", "UserInterface")]
        [Test, TestCaseSource("OpenNewMailWindow_TestTwo")]
        public void OpenNewMailWindow(string body, IEnumerable<int> recipient, string subject)
        {
            var r = Authenticated.UserInterface.OpenNewMailWindow(body, recipient, subject).Execute();
            Assert.True(r.Code == HttpStatusCode.NoContent);
        }
    }
}
