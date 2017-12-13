namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Character
        {
            public static readonly Scope ReadAgentsResearch = new Scope("esi-characters.read_agents_research.v1");
            public static readonly Scope ReadBlueprints = new Scope("esi-characters.read_blueprints.v1");
            public static readonly Scope ReadChatChannels = new Scope("esi-characters.read_chat_channels.v1");
            public static readonly Scope ReadContacts = new Scope("esi-characters.read_contacts.v1");
            public static readonly Scope ReadCorporationRoles = new Scope("esi-characters.read_corporation_roles.v1");
            public static readonly Scope ReadFatigue = new Scope("esi-characters.read_fatigue.v1");
            public static readonly Scope ReadFactionWarfareStats = new Scope("esi-characters.read_fw_stats.v1");
            public static readonly Scope ReadLoyalty = new Scope("esi-characters.read_loyalty.v1");
            public static readonly Scope ReadMedals = new Scope("esi-characters.read_medals.v1");
            public static readonly Scope ReadNotifications = new Scope("esi-characters.read_notifications.v1");
            public static readonly Scope ReadOpportunities = new Scope("esi-characters.read_opportunities.v1");
            public static readonly Scope ReadStandings = new Scope("esi-characters.read_standings.v1");
            public static readonly Scope ReadTitles = new Scope("esi-characters.read_titles.v1");
            public static readonly Scope WriteContacts = new Scope("esi-characters.write_contacts.v1");
            public static readonly Scope ReadStats = new Scope("esi-characterstats.read.v1");
        }
    }
}
