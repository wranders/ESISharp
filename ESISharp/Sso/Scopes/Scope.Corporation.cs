namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Corporation
        {
            public static readonly Scope ReadBlueprints = new Scope("esi-corporations.read_blueprints.v1");
            public static readonly Scope ReadContainerLogs = new Scope("esi-corporations.read_container_logs.v1");
            public static readonly Scope ReadContacts = new Scope("esi-corporations.read_contacts.v1");
            public static readonly Scope ReadCorporationMembership = new Scope("esi-corporations.read_corporation_membership.v1");
            public static readonly Scope ReadDivisions = new Scope("esi-corporations.read_divisions.v1");
            public static readonly Scope ReadFacilities = new Scope("esi-corporations.read_facilities.v1");
            public static readonly Scope ReadFactionWarfareStats = new Scope("esi-corporations.read_fw_stats.v1");
            public static readonly Scope ReadMedals = new Scope("esi-corporations.read_medals.v1");
            public static readonly Scope ReadOutposts = new Scope("esi-corporations.read_outposts.v1");
            public static readonly Scope ReadStandings = new Scope("esi-corporations.read_standings.v1");
            public static readonly Scope ReadStarbases = new Scope("esi-corporations.read_starbases.v1");
            public static readonly Scope ReadStructures = new Scope("esi-corporations.read_structures.v1");
            public static readonly Scope ReadTitles = new Scope("esi-corporations.read_titles.v1");
            public static readonly Scope TrackMembers = new Scope("esi-corporations.track_members.v1");
            public static readonly Scope WriteStructures = new Scope("esi-corporations.write_structures.v1");
        }
    }
}
