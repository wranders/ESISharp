using ESISharp.Enumerations;
using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Calendar paths</summary>
    public class CharacterCalendar
    {
        protected ESIEve EasyObject;

        internal CharacterCalendar(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Calendar Events (Returns the next 50 upcoming events)</summary>
        /// <remarks>Requires SSO Authentication, using "read_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetEventSummaries(int CharacterID)
        {
            return GetEventSummaries(CharacterID, null);
        }

        /// <summary>Get Calendar Events (Returns the next 50 events after provided event)</summary>
        /// <remarks>Requires SSO Authentication, using "read_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="FromEventID">(Boolean) Starting Event ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetEventSummaries(int CharacterID, int? FromEventID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/calendar/";
            var Data = new { from_event = FromEventID };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get specific Calendar Event</summary>
        /// <remarks>Requires SSO Authentication, using "read_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="EventID">(Int32) EventID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetEvent(int CharacterID, int EventID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/calendar/{EventID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Responsd to Calendar Event</summary>
        /// <remarks>Requires SSO Authentication, using "respond_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="EventID">(Int32) Event ID</param>
        /// <param name="Response">(CalendarResponse) Response</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest RespondToEvent(int CharacterID, int EventID, CalendarResponse Response)
        {
            return RespondToEvent(CharacterID, EventID, Response.Value);
        }

        /// <summary>Responsd to Calendar Event</summary>
        /// <remarks>Requires SSO Authentication, using "respond_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="EventID">(Int32) Event ID</param>
        /// <param name="Response">(String) Response</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest RespondToEvent(int CharacterID, int EventID, string Response)
        {
            var Path = $"/characters/{CharacterID.ToString()}/calendar/{EventID.ToString()}/";
            var Data = new { response = Response };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get specific Calendar Event's Attendees and their responses</summary>
        /// <remarks>Requires SSO Authentication, using "read_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="EventID">(Int32) EventID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAttendees(int CharacterID, int EventID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/calendar/{EventID.ToString()}/attendees/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
