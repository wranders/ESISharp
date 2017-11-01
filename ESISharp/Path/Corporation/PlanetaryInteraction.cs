using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation
{
    public class CorporationPlanetaryInteraction
    {
        protected ESIEve EasyObject;

        internal CorporationPlanetaryInteraction(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Customs Offices</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetCustomsOffices(int CorporationID)
        {
            return GetCustomsOffices(CorporationID, 1);
        }

        /// <summary>Get Corporation's Customs Offices</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetCustomsOffices(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/customs_offices/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
