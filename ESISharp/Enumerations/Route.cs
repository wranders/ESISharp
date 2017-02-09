namespace ESISharp.Enumerations
{
    /// <summary>
    /// ESI Version
    /// </summary>
    public class Route
    {
        /// <summary>Latest</summary>
        public static readonly Route Latest = new Route("/latest");
        /// <summary>Legacy</summary>
        public static readonly Route Legacy = new Route("/legacy");
        /// <summary>Development</summary>
        public static readonly Route Development = new Route("/dev");

        internal Route(string val)
        {
            Value = val;
        }

        /// <summary>ESI Version</summary>
        public string Value { get; }
    }
}