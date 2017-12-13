namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Calendar
        {
            public static readonly Scope ReadCalendarEvents = new Scope("esi-calendar.read_calendar_events.v1");
            public static readonly Scope RespondCalendarEvents = new Scope("esi-calendar.respond_calendar_events.v1");
        }
    }
}
