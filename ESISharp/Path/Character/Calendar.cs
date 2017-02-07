using ESISharp.Enumerations;
using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>
    /// Authenticated Character Calendar paths
    /// </summary>
    public class CharacterCalendar
    {
        protected EveSwagger SwaggerObject;

        internal CharacterCalendar(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Calendar Events (Returns the next 50 upcoming events)
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of objects representing calendar events</returns>
        public string GetEventSummaries(int CharacterID)
        {
            return GetEventSummaries(CharacterID, null);
        }

        /// <summary>
        /// Get Calendar Events (Returns the next 50 events after provided event)
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="FromEventID">(Boolean) Starting Event ID</param>
        /// <returns>JSON Array of objects representing calendar events</returns>
        public string GetEventSummaries(int CharacterID, int? FromEventID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/calendar/";
            var Data = new { from_event = FromEventID };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get(Data);
        }

        /// <summary>
        /// Get specific Calendar Event
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="EventID">(Int32) EventID</param>
        /// <returns>JSON Object containing event information</returns>
        public string GetEvent(int CharacterID, int EventID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/calendar/{EventID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>
        /// Responsd to Calendar Event
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "respond_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="EventID">(Int32) Event ID</param>
        /// <param name="Response">(CalendarResponse) Response</param>
        /// <returns>Nothing normally, error if one is encountered</returns>
        public string RespondToEvent(int CharacterID, int EventID, CalendarResponse Response)
        {
            return RespondToEvent(CharacterID, EventID, Response.Value);
        }

        /// <summary>
        /// Responsd to Calendar Event
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "respond_calendar_events" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="EventID">(Int32) Event ID</param>
        /// <param name="Response">(String) Response</param>
        /// <returns>Nothing normally, error if one is encountered</returns>
        public string RespondToEvent(int CharacterID, int EventID, string Response)
        {
            var Path = $"/characters/{CharacterID.ToString()}/calendar/{EventID.ToString()}/";
            var Data = new { response = Response };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Put(Data);
        }
    }
}
