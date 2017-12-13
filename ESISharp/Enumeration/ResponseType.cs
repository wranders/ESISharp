namespace ESISharp.Enumeration
{
    public class ResponseType : Model.Abstract.FakeEnumerator
    {
        internal ResponseType(string value) : base(value) { }

        public static readonly ResponseType Json = new ResponseType("application/json");
    }
}
