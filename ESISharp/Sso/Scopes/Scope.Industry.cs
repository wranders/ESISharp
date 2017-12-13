namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Industry
        {
            public static readonly Scope ReadCharacterJobs = new Scope("esi-industry.read_character_jobs.v1");
            public static readonly Scope ReadCharacterMining = new Scope("esi-industry.read_character_mining.v1");
            public static readonly Scope ReadCorporationJobs = new Scope("esi-industry.read_corporation_jobs.v1");
            public static readonly Scope ReadCorporationMining = new Scope("esi-industry.read_corporation_mining.v1");
        }
    }
}
