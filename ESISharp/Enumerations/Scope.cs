using System.Collections.Generic;

namespace ESISharp.Enumerations
{
    /// <summary>SSO Scopes</summary>
    public class Scope
    {
        internal static readonly Dictionary<string, Scope> Lookup = new Dictionary<string, Scope>();

        internal Scope(string val)
        {
            Value = val;
            
            if(val != string.Empty)
            {
                Lookup.Add(val, this);
            }
        }

        /// <summary>SSO Scope</summary>
        public string Value { get; }

        /// <summary>No Scopes</summary>
        public static readonly Scope None = new Scope("");

        /// <summary>Asset Scopes</summary>
        public static class Assets
        {
            /// <summary>Read Assets Scope</summary>
            public static readonly Scope ReadAssets = new Scope("esi-assets.read_assets.v1");
        }

        /// <summary>Bookmarks Scopes</summary>
        public static class Bookmarks
        {
            /// <summary>Read Character Bookmarks Scope</summary>
            public static readonly Scope ReadCharacterBookmarks = new Scope("esi-bookmarks.read_character_bookmarks.v1");
        }

        /// <summary>Calendar Scopes</summary>
        public static class Calendar
        {
            /// <summary>Read Calendar Events Scope</summary>
            public static readonly Scope ReadCalendarEvents = new Scope("esi-calendar.read_calendar_events.v1");
            /// <summary>Respond Calendar Events Scope</summary>
            public static readonly Scope RespondCalendarEvents = new Scope("esi-calendar.respond_calendar_events.v1");
        }

        /// <summary>Character Scopes</summary>
        public static class Characters
        {
            /// <summary>Read Contacts Scope</summary>
            public static readonly Scope ReadContacts = new Scope("esi-characters.read_contacts.v1");
            /// <summary>Write Scope</summary>
            public static readonly Scope WriteContacts = new Scope("esi-characters.write_contacts.v1");
        }

        /// <summary>Clones Scopes</summary>
        public static class Clones
        {
            /// <summary>Read Clones Scope</summary>
            public static readonly Scope ReadClones = new Scope("esi-clones.read_clones.v1");
        }

        /// <summary>Corporation Scopes</summary>
        public static class Corporations
        {
            /// <summary>Read Corporation Membership Scope</summary>
            public static readonly Scope ReadCorporationMembership = new Scope("esi-corporations.read_corporation_membership.v1");
            /// <summary>Read Corporation Structures Scope</summary>
            public static readonly Scope ReadCorporationStructures = new Scope("esi-corporations.read_structures.v1");
            /// <summary>Write Corporation Structures Scope</summary>
            public static readonly Scope WriteCorporationStructures = new Scope("esi-corporations.write_structures.v1");
        }

        /// <summary>Fitting Scopes</summary>
        public static class Fittings
        {
            /// <summary>Read Fittings Scope</summary>
            public static readonly Scope ReadFittings = new Scope("esi-fittings.read_fittings.v1");
            /// <summary>Write Fittings Scope</summary>
            public static readonly Scope WriteFittings = new Scope("esi-fittings.write_fittings.v1");
        }

        /// <summary>Fleet Scopes</summary>
        public static class Fleets
        {
            /// <summary>Read Fleet Scope</summary>
            public static readonly Scope ReadFleet = new Scope("esi-fleets.read_fleet.v1");
            /// <summary>Write Fleet Scope</summary>
            public static readonly Scope WriteFleet = new Scope("esi-fleets.write_fleet.v1");
        }

        /// <summary>Killmail Scopes</summary>
        public static class Killmails
        {
            /// <summary>Read Killmails Scope</summary>
            public static readonly Scope ReadKillmails = new Scope("esi-killmails.read_killmails.v1");
        }

        /// <summary>Loyalty Point Scopes</summary>
        public static class Loyalty
        {
            /// <summary>Read Character Loyalty Points</summary>
            public static readonly Scope ReadLoyalty = new Scope("esi-characters.read_loyalty.v1");
        }

        /// <summary>Location Scopes</summary>
        public static class Location
        {
            /// <summary>Read Location Scope</summary>
            public static readonly Scope ReadLocation = new Scope("esi-location.read_location.v1");
            /// <summary>Read Ship Type Scope</summary>
            public static readonly Scope ReadShipType = new Scope("esi-location.read_ship_type.v1");
        }

        /// <summary>Mail Scopes</summary>
        public static class Mail
        {
            /// <summary>Organize Mail Scope</summary>
            public static readonly Scope OrganizeMail = new Scope("esi-mail.organize_mail.v1");
            /// <summary>Read Mail Scope</summary>
            public static readonly Scope ReadMail = new Scope("esi-mail.read_mail.v1");
            /// <summary>Send Scope</summary>
            public static readonly Scope SendMail = new Scope("esi-mail.send_mail.v1");
        }

        /// <summary>Market Scopes</summary>
        public static class Markets
        {
            /// <summary>Structure Markets Scope</summary>
            public static readonly Scope StructureMarkets = new Scope("esi-markets.structure_markets.v1");
        }

        /// <summary>Planet Scopes</summary>
        public static class Planets
        {
            /// <summary>Manage Planets Scope</summary>
            public static readonly Scope ManagePlanets = new Scope("esi-planets.manage_planets.v1");
        }

        /// <summary>Search Scopes</summary>
        public static class Search
        {
            /// <summary>Search Scope</summary>
            public static readonly Scope SearchStructures = new Scope("esi-search.search_structures.v1");
        }

        /// <summary>Skill Scopes</summary>
        public static class Skills
        {
            /// <summary>Read Skill Queue Scope</summary>
            public static readonly Scope ReadSkillQueue = new Scope("esi-skills.read_skillqueue.v1");
            /// <summary>Read Skills Scope</summary>
            public static readonly Scope ReadSkills = new Scope("esi-skills.read_skills.v1");
        }

        /// <summary>User Interface Scopes</summary>
        public static class Ui
        {
            /// <summary>Open Window Scope</summary>
            public static readonly Scope OpenWindow = new Scope("esi-ui.open_window.v1");
            /// <summary>Write Waypoint Scope</summary>
            public static readonly Scope WriteWaypoint = new Scope("esi-ui.write_waypoint.v1");
        }

        /// <summary>Universe Scopes</summary>
        public static class Universe
        {
            /// <summary>Read Structure Scope</summary>
            public static readonly Scope ReadStructures = new Scope("esi-universe.read_structures.v1");
        }

        /// <summary>Wallet Scopes</summary>
        public static class Wallet
        {
            /// <summary>Read Character Wallet Scope</summary>
            public static readonly Scope ReadCharacterWallet = new Scope("esi-wallet.read_character_wallet.v1");
        }
    }
}
