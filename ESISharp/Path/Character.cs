using ESISharp.ESIPath.Character;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.ESIPath
{
    /// <summary>Public Character Paths</summary>
    public class CharacterMain
    {
        protected ESIEve EasyObject;

        internal CharacterMain(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character's Name</summary>
        /// <param name="CharacterID">(Int64) CharacterID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetNames(long CharacterID)
        {
            return GetNames(new long[] { CharacterID });
        }

        /// <summary>Get Character's Name</summary>
        /// <param name="CharacterIDs">(Int64 List) CharacterIDs</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetNames(IEnumerable<long> CharacterIDs)
        {
            var Path = "/characters/names/";
            var Data = new { character_ids = CharacterIDs.ToArray() };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }

        /// <summary>Get Character's Public Information</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPublicInformation(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Character's Corporation History</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetCorporationHistory(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/corporationhistory/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Character's Portraits</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPortraits(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/portrait/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Authenticated Character Paths</summary>
    public class AuthCharacterMain : CharacterMain
    {
        /// <summary>Assets paths</summary>
        public CharacterAssets Assets;
        /// <summary>Bookmarks paths</summary>
        public CharacterBookmarks Bookmarks;
        /// <summary>Calendar paths</summary>
        public CharacterCalendar Calendar;
        /// <summary>Clones paths</summary>
        public CharacterClones Clones;
        /// <summary>Contacts paths</summary>
        public CharacterContacts Contacts;
        /// <summary>Fittings paths</summary>
        public CharacterFittings Fittings;
        /// <summary>Killmails paths</summary>
        public CharacterKillMails Killmails;
        /// <summary>Loyalty Point paths</summary>
        public CharacterLoyalty Loyalty;
        /// <summary>Mail paths</summary>
        public CharacterMail Mail;
        /// <summary>Planetary Interaction (PI) paths</summary>
        public CharacterPlanetaryInteraction PlanetaryInteraction;
        /// <summary>Skills paths</summary>
        public CharacterSkills Skills;
        /// <summary>Wallet paths</summary>
        public CharacterWallet Wallet;

        internal AuthCharacterMain(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = (ESIEve.Authenticated)EasyEve;

            Assets = new CharacterAssets(EasyObject);
            Bookmarks = new CharacterBookmarks(EasyObject);
            Calendar = new CharacterCalendar(EasyObject);
            Clones = new CharacterClones(EasyObject);
            Contacts = new CharacterContacts(EasyObject);
            Fittings = new CharacterFittings(EasyObject);
            Loyalty = new CharacterLoyalty(EasyObject);
            Killmails = new CharacterKillMails(EasyObject);
            Mail = new CharacterMail(EasyObject);
            PlanetaryInteraction = new CharacterPlanetaryInteraction(EasyObject);
            Skills = new CharacterSkills(EasyObject);
            Wallet = new CharacterWallet(EasyObject);
        }

        /// <summary>Get list of agent research infromation</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAgentResearch(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/agents_research/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Chat Channels that the Character is owner or operator of</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetChatChannels(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/chat_channels/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get CSPA charge</summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) CharacterID</param>
        /// <param name="CharacterToCheck">(Int32) Character ID of contact</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest CalculateCSPACharge(int CharacterID, int CharacterToCheck)
        {
            return CalculateCSPACharge(CharacterID, new int[] { CharacterToCheck });
        }

        /// <summary>Get CSPA charge</summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) CharacterID</param>
        /// <param name="CharactersToCheck">(Int32) Character IDs of contacts</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest CalculateCSPACharge(int CharacterID, IEnumerable<int> CharactersToCheck)
        {
            var Path = $"/characters/{CharacterID.ToString()}/cspa/";
            var Data = new { characters = CharactersToCheck.ToArray() };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, Data);
        }

        /// <summary>Get Character's Location</summary>
        /// <remarks>Requires SSO Authentication, using "read_location" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetLocation(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/location/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's Medals</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMedals(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/medals/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's current ship</summary>
        /// <remarks>Requires SSO Authentication, using "read_ship" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetCurrentShip(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/ship/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's NPC standings</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStandings(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/standings/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
