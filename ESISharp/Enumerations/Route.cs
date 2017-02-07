namespace ESISharp.Enumerations
{
    /// <summary>
    /// ESI Version
    /// </summary>
    public class Route
    {
        /// <summary>Latest</summary>
        public static readonly Route Latest = new Route("/latest");
        /// <summary>Version 1</summary>
        public static readonly Route V1 = new Route("/v1");
        /// <summary>Version 3</summary>
        public static readonly Route V3 = new Route("/v3");
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