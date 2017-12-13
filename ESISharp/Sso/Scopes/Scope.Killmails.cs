namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Killmails
        {
            public static readonly Scope ReadCorporationKillmails = new Scope("esi-killmails.read_corporation_killmails.v1");
            public static readonly Scope ReadKillmails = new Scope("esi-killmails.read_killmails.v1");
        }
    }
}
