using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Skill paths</summary>
    public class CharacterSkills
    {
        protected ESIEve EasyObject;

        internal CharacterSkills(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character's Attributes</summary>
        /// <remarks>Requires SSO Authentication, using "read_skills" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAttributes(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/attributes/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's current Skill Queue</summary>
        /// <remarks>Requires SSO Authentication, using "read_skillqueue" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetQueue(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/skillqueue/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's Skills</summary>
        /// <remarks>Requires SSO Authentication, using "read_skills" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetSkills(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/skills/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
