using ESISharp.ESIPath.Character;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.ESIPath
{
    /// <summary>
    /// Public Character Paths
    /// </summary>
    public class CharacterMain
    {
        protected EveSwagger SwaggerObject;

        internal CharacterMain(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Character's Name
        /// </summary>
        /// <param name="CharacterID">(Int64) CharacterID</param>
        /// <returns>JSON Array with Object containing character ID and name</returns>
        public string GetNames(long CharacterID)
        {
            return GetNames(new List<long>() { CharacterID });
        }

        /// <summary>
        /// Get Character's Name
        /// </summary>
        /// <param name="CharacterIDs">(Int64 List) CharacterIDs</param>
        /// <returns>JSON Array with Objects containing character IDs and names</returns>
        public string GetNames(List<long> CharacterIDs)
        {
            var Path = "/characters/names/";
            var Data = new { character_ids = CharacterIDs.ToArray() };
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get(Data);
        }

        /// <summary>
        /// Get Character's Public Information
        /// </summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Object containing character's public information</returns>
        public string GetPublicInformation(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Character's Corporation History
        /// </summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects containing corporation ID, active status, record ID, and start date</returns>
        public string GetCorporationHistory(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/corporationhistory/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Character's Portraits
        /// </summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Object containing URLs for 64x64, 128x128, 256x256, and 512x512 portraits</returns>
        public string GetPortraits(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/portrait/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }
    }

    /// <summary>
    /// Authenticated Character Paths
    /// </summary>
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
        /// <summary>Mail paths</summary>
        public CharacterMail Mail;
        /// <summary>Planetary Interaction (PI) paths</summary>
        public CharacterPlanetaryInteraction PlanetaryInteraction;
        /// <summary>Skills paths</summary>
        public CharacterSkills Skills;
        /// <summary>Wallet paths</summary>
        public CharacterWallet Wallet;

        internal AuthCharacterMain(EveSwagger e) : base(e)
        {
            SwaggerObject = (EveSwagger.Authenticated)e;

            Assets = new CharacterAssets(SwaggerObject);
            Bookmarks = new CharacterBookmarks(SwaggerObject);
            Calendar = new CharacterCalendar(SwaggerObject);
            Clones = new CharacterClones(SwaggerObject);
            Contacts = new CharacterContacts(SwaggerObject);
            Fittings = new CharacterFittings(SwaggerObject);
            Killmails = new CharacterKillMails(SwaggerObject);
            Mail = new CharacterMail(SwaggerObject);
            PlanetaryInteraction = new CharacterPlanetaryInteraction(SwaggerObject);
            Skills = new CharacterSkills(SwaggerObject);
            Wallet = new CharacterWallet(SwaggerObject);
        }

        /// <summary>
        /// Get CSPA charge
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) CharacterID</param>
        /// <param name="CharacterToCheck">(Int32) Character ID of contact</param>
        /// <returns>JSON Object containing cost in hundredths</returns>
        public string CalculateCSPACharge(int CharacterID, int CharacterToCheck)
        {
            return CalculateCSPACharge(CharacterID, new List<int>() { CharacterToCheck });
        }

        /// <summary>
        /// Get CSPA charge
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) CharacterID</param>
        /// <param name="CharactersToCheck">(Int32) Character IDs of contacts</param>
        /// <returns>JSON Object containing cost in hundredths</returns>
        public string CalculateCSPACharge(int CharacterID, List<int> CharactersToCheck)
        {
            var Path = $"/characters/{CharacterID.ToString()}/cspa/";
            var Data = new { characters = CharactersToCheck.ToArray() };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Post(Data);
        }

        /// <summary>
        /// Get Character's Location
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_location" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Object containing character's current solar system ID, and structure ID if docked</returns>
        public string GetLocation(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/location/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>
        /// Get Character's current ship
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_ship" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Object containing character's current ship id, name, and type ID</returns>
        public string GetCurrentShip(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/ship/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}
