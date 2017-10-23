using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation
{
    /// <summary>Authenticated Corporation Contracts paths</summary>
    public class CorporationContracts
    {
        protected ESIEve EasyObject;

        internal CorporationContracts(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Contracts</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_contracts" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetContracts(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/contracts/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Corporation's Contract Bids, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_contracts" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="ContractID">(Int32) Contract ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetBids(int CorporationID, int ContractID)
        {
            return GetBids(CorporationID, ContractID, 1);
        }

        /// <summary>Get Corporation's Contract Bids, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_contracts" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="ContractID">(Int32) Contract ID</param>
        /// <param name="Page">(Int32) Page</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetBids(int CorporationID, int ContractID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/contracts/{ContractID.ToString()}/bids/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Corporation's Contract Items</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_contracts" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="ContractID">(Int32) Contract ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetItems(int CorporationID, int ContractID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/contracts/{ContractID.ToString()}/items/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
