using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Industry paths</summary>
    public class CharacterIndustry
    {
        protected ESIEve EasyObject;

        internal CharacterIndustry(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Blueprints Owned by a Character, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_blueprints" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetBlueprints(int CharacterID)
        {
            return GetBlueprints(CharacterID, 1);
        }

        /// <summary>Get All Blueprints Owned by a Character, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_blueprints" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetBlueprints(int CharacterID, int Page)
        {
            var Path = $"/characters/{CharacterID.ToString()}/blueprints/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Character's Industry Jobs, Excluding Completed</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_jobs" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetJobs(int CharacterID)
        {
            return GetJobs(CharacterID, false);
        }

        /// <summary>Get list of character's industry jobs</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_jobs" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="IncludeCompleted">(Boolean) Include Completed Jobs</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetJobs(int CharacterID, bool IncludeCompleted)
        {
            var Path = $"/characters/{CharacterID.ToString()}/industry/jobs/";
            var Data = new
            {
                include_completed = IncludeCompleted
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Character's Mining Ledger</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_mining" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMiningLedger(int CharacterID)
        {
            return GetMiningLedger(CharacterID, 1);
        }

        /// <summary>Get Character's Mining Ledger</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_mining" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMiningLedger(int CharacterID, int Page)
        {
            var Path = $"/characters/{CharacterID.ToString()}/mining/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
