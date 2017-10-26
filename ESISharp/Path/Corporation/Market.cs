using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation
{
    public class CorporationMarket
    {
        protected ESIEve EasyObject;

        internal CorporationMarket(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Market Orders, First Page</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_orders" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetOrders(int CorporationID)
        {
            return GetOrders(CorporationID, 1);
        }

        /// <summary>Get Corporation's Market Orders, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_orders" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetOrders(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/orders/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
