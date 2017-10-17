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

        /// <summary>Get list of blueprints owned by the character</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetBlueprints(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/blueprints/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
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
