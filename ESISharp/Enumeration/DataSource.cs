namespace ESISharp.Enumeration
{
    public class DataSource : Model.Abstract.FakeEnumerator
    {
        internal DataSource(string value) : base(value) { }

        public static readonly DataSource Tranquility = new DataSource("tranquility");
        public static readonly DataSource Singularity = new DataSource("singularity");
    }
}
