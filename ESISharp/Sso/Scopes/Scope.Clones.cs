namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Clones
        {
            public static readonly Scope ReadClones = new Scope("esi-clones.read_clones.v1");
            public static readonly Scope ReadImplants = new Scope("esi-clones.read_implants.v1");
        }
    }
}
