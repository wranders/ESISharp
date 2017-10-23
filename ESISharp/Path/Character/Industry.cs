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
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Page);
        }

        /// <summary>Get list of character's industry jobs</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetJobs(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/industry/jobs/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
