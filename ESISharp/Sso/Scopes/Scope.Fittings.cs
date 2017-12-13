namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Fittings
        {
            public static readonly Scope ReadFittings = new Scope("esi-fittings.read_fittings.v1");
            public static readonly Scope WriteFittings = new Scope("esi-fittings.write_fittings.v1");
        }
    }
}
