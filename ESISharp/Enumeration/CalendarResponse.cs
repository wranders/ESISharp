namespace ESISharp.Enumeration
{
    public class CalendarResponse : Model.Abstract.FakeEnumerator
    {
        internal CalendarResponse(string value) : base(value) { }

        public static readonly CalendarResponse Accepted = new CalendarResponse("accepted");
        public static readonly CalendarResponse Declined = new CalendarResponse("declined");
        public static readonly CalendarResponse Tentative = new CalendarResponse("tentative");
    }
}
