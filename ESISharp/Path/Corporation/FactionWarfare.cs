using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation
{
    public class CorporationFactionWarfare
    {
        protected ESIEve EasyObject;

        internal CorporationFactionWarfare(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Faction Warfare Statistics</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStats(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/fw/stats/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
