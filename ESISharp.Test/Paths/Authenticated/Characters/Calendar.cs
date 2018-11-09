using ESISharp.Enumeration;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Calendar : PathTest
    {
#pragma warning disable S1144

        static readonly object[] RespondToEvent_TestOne =
        {
            new object[] { 1825262, CalendarResponse.Accepted },
            new object[] { 1825262, CalendarResponse.Declined },
            new object[] { 1825262, CalendarResponse.Tentative }
        };

#pragma warning restore

        [Property("AuthedCharacters", "Calendar")]
        [Test]
        public void GetEventSummaries()
        {
            var a = Authenticated.Characters.Calendar.GetEventSummaries(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Calendar")]
        [TestCase(1824262)]
        public void GetEventSummaries(int fromeventid)
        {
            var a = Authenticated.Characters.Calendar.GetEventSummaries(GetCharacterId(), fromeventid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Calendar")]
        [TestCase(1825262)]
        public void GetEvent(int eventid)
        {
            var a = Authenticated.Characters.Calendar.GetEvent(GetCharacterId(), eventid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Calendar")]
        [Test, TestCaseSource("RespondToEvent_TestOne")]
        public void RespondToEvent(int eventid, CalendarResponse response)
        {
            var a = Authenticated.Characters.Calendar.RespondToEvent(GetCharacterId(), eventid, response).Execute();
            Assert.True(a.Code == HttpStatusCode.NoContent);
        }

        [Property("AuthedCharacters", "Calendar")]
        [TestCase(1825262)]
        public void GetAttendees(int eventid)
        {
            var a = Authenticated.Characters.Calendar.GetAttendees(GetCharacterId(), eventid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
