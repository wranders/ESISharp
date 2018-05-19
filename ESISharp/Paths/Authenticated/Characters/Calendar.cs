using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Calendar : ApiPath
    {
        internal Calendar(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetEventSummaries(int characterid)
            => GetEventSummaries(characterid, -1);

        [Path("/characters/{character_id}/calendar/", WebMethods.GET)]
        public EsiRequest GetEventSummaries(int characterid, int fromeventid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "calendar" };
            if (fromeventid >=0)
            {
                var data = new EsiRequestData
                {
                    Query = new Dictionary<string, dynamic>
                    {
                        ["from_event"] = fromeventid
                    }
                };
                return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
            }
            else
            {
                return new EsiRequest(EsiConnection, path, WebMethods.GET);
            }
        }

        [Path("/characters/{character_id}/calendar/{event_id}/", WebMethods.GET)]
        public EsiRequest GetEvent(int characterid, int eventid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "calendar", eventid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/calendar/{event_id}/", WebMethods.PUT)]
        public EsiRequest RespondToEvent(int characterid, int eventid, CalendarResponse response)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "calendar", eventid.ToString() };
            var data = new EsiRequestData
            {
                BodyKvp = new Dictionary<string, dynamic>
                {
                    ["response"] = response.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.PUT, data);
        }

        [Path("/characters/{character_id}/calendar/{event_id}/attendees/", WebMethods.GET)]
        public EsiRequest GetAttendees(int characterid, int eventid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "calendar", eventid.ToString(), "attendees" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
