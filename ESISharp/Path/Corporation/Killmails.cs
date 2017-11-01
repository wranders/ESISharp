using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation
{
    /// <summary>Authenticated Corporation Killmail paths</summary>
    public class CorporationKillmails
    {
        protected ESIEve EasyObject;

        internal CorporationKillmails(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Recent Killmails</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_killmails" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRecent(int CorporationID)
        {
            return GetRecent(CorporationID, null);
        }

        /// <summary>Get Corporation's Recent Killmails</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_killmails" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="MaxKillID">(Int32) Max Killmail ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRecent(int CorporationID, int? MaxKillID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/killmails/recent/";
            var Data = new
            {
                max_kill_id = MaxKillID
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
