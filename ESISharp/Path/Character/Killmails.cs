using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>
    /// Authenticated Character Killmail paths
    /// </summary>
    public class CharacterKillMails
    {
        protected EveSwagger SwaggerObject;

        internal CharacterKillMails(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Recent Killmails (50 max)
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_killmails" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects containing killmail base64 hashes and killmail IDs</returns>
        public string GetRecent(int CharacterID)
        {
            return GetRecent(CharacterID, 50, null);
        }

        /// <summary>
        /// Get Recent Killmails
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_killmails" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MaxCount">(Int32) Max number if killmails to return</param>
        /// <returns>JSON Array of Objects containing killmail base64 hashes and killmail IDs</returns>
        public string GetRecent(int CharacterID, int MaxCount)
        {
            return GetRecent(CharacterID, MaxCount, null);
        }

        /// <summary>
        /// Get Recent Killmails
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_killmails" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MaxCount">(Int32) Max number if killmails to return</param>
        /// <param name="MaxKillID">(Int32) Only return killmails with ID that is smaller</param>
        /// <returns>JSON Array of Objects containing killmail base64 hashes and killmail IDs</returns>
        public string GetRecent(int CharacterID, int MaxCount, int? MaxKillID)
        {
            var Path = $"/characters/{CharacterID}/killmails/recent/";
            var Data = new { max_count = MaxCount, max_kill_id = MaxKillID };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get(Data);
        }
    }
}
