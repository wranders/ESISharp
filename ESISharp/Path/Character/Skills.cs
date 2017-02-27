using ESISharp.Web;
using System.Threading.Tasks;

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

        /// <summary>Get Character's current Skill Queue</summary>
        /// <remarks>Requires SSO Authentication, using "read_skillqueue" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing individual skills in queue</returns>
        public string GetQueue(int CharacterID)
        {
            return GetQueueAsync(CharacterID).Result;
        }

        /// <summary>Get Character's current Skill Queue</summary>
        /// <remarks>Requires SSO Authentication, using "read_skillqueue" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing individual skills in queue</returns>
        public async Task<string> GetQueueAsync(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/skillqueue/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Character's Skills</summary>
        /// <remarks>Requires SSO Authentication, using "read_skills" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Object containing total skill points and Array of Objects representing individual skills</returns>
        public string GetSkills(int CharacterID)
        {
            return GetSkillsAsync(CharacterID).Result;
        }

        /// <summary>Get Character's Skills</summary>
        /// <remarks>Requires SSO Authentication, using "read_skills" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Object containing total skill points and Array of Objects representing individual skills</returns>
        public async Task<string> GetSkillsAsync(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/skills/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }
    }
}
