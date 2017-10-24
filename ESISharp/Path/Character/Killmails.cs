using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Killmail paths</summary>
    public class CharacterKillMails
    {
        protected ESIEve EasyObject;

        internal CharacterKillMails(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character's Recent Killmails (50 max)</summary>
        /// <remarks>Requires SSO Authentication, using "read_killmails" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRecent(int CharacterID)
        {
            return GetRecent(CharacterID, 50, null);
        }

        /// <summary>Get Character's Recent Killmails</summary>
        /// <remarks>Requires SSO Authentication, using "read_killmails" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MaxCount">(Int32) Max number if killmails to return</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRecent(int CharacterID, int MaxCount)
        {
            return GetRecent(CharacterID, MaxCount, null);
        }

        /// <summary>Get Character's Recent Killmails</summary>
        /// <remarks>Requires SSO Authentication, using "read_killmails" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MaxCount">(Int32) Max number if killmails to return</param>
        /// <param name="MaxKillID">(Int32) Only return killmails with ID that is smaller</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRecent(int CharacterID, int MaxCount, int? MaxKillID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/killmails/recent/";
            var Data = new
            {
                max_count = MaxCount,
                max_kill_id = MaxKillID
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
