namespace ESISharp.Enumeration
{
    public class RouteFlag : Model.Abstract.FakeEnumerator
    {
        internal RouteFlag(string value) : base(value) { }

        public static readonly RouteFlag Shortest = new RouteFlag("shortest");
        public static readonly RouteFlag Secure = new RouteFlag("secure");
        public static readonly RouteFlag Insecure = new RouteFlag("insecure");
    }
}
