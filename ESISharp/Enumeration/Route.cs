namespace ESISharp.Enumeration
{
    public class Route : Model.Abstract.FakeEnumerator
    {
        internal Route(string value) : base(value) { }

        public static readonly Route Latest = new Route("latest");
        public static readonly Route Legacy = new Route("legacy");
        public static readonly Route Development = new Route("dev");
    }
}