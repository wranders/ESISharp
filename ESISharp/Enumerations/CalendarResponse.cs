namespace ESISharp.Enumerations
{
    /// <summary>Calendar Responses</summary>
    public class CalendarResponse
    {
        /// <summary>Accept Event</summary>
        public static readonly CalendarResponse Accepted = new CalendarResponse("accepted");
        /// <summary>Decline Event</summary>
        public static readonly CalendarResponse Declined = new CalendarResponse("declined");
        /// <summary>Possibly Attend Event</summary>
        public static readonly CalendarResponse Tentative = new CalendarResponse("tentative");

        internal CalendarResponse(string val)
        {
            Value = val;
        }

        /// <summary>Calendar Response</summary>
        public string Value { get; }
    }
}
