namespace ESISharp.Enumerations
{
    /// <summary>
    /// Eve Server data source
    /// </summary>
    public class DataSource
    {
        /// <summary>Tranquility Server</summary>
        public static readonly DataSource Tranquility = new DataSource("tranquility");
        /// <summary>Singularity Test Server</summary>
        public static readonly DataSource Singularity = new DataSource("singularity");

        internal DataSource(string val)
        {
            Value = val;
        }

        /// <summary>Eve Server</summary>
        public string Value { get; }
    }
}