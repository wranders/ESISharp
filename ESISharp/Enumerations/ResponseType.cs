namespace ESISharp.Enumerations
{
    /// <summary>API Response Data Types</summary>
    public class ResponseType
    {
        /// <summary>JSON</summary>
        public static readonly ResponseType Json = new ResponseType("application/json");

        internal ResponseType(string val)
        {
            Value = val;
        }

        /// <summary>Data Type</summary>
        public string Value { get; }
    }
}