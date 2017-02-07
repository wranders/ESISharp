using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>
    /// Authenticated Character Skill paths
    /// </summary>
    public class CharacterSkills
    {
        protected EveSwagger SwaggerObject;

        internal CharacterSkills(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Character's current Skill Queue
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_skillqueue" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing individual skills in queue</returns>
        public string GetQueue(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/skillqueue/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>
        /// Get Character's Skills
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_skills" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Object containing total skill points and Array of Objects representing individual skills</returns>
        public string GetSkills(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/skills/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}
