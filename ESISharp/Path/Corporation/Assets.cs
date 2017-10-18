using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.ESIPath.Corporation
{
    /// <summary>Authenticated Corporation Asset paths</summary>
    public class CorporationAssets
    {
        protected ESIEve EasyObject;

        internal CorporationAssets(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Corporation's Assets, First Page</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_assets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAll(int CorporationID)
        {
            return GetAll(CorporationID, 1);
        }

        /// <summary>Get All Corporation's Assets, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_assets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAll(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/assets/";
            var Data = new { page = Page };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Asset Location</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_assets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="ItemID">(Int64) Item ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetLocation(int CorporationID, long ItemID)
        {
            return GetLocation(CorporationID, new long[] { ItemID });
        }

        /// <summary>Get Asset Locations</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_assets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="ItemID">(Int64 List) Item ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetLocation(int CorporationID, IEnumerable<long> ItemIDs)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/assets/locations/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, ItemIDs);
        }

        /// <summary>Get Asset Name</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_assets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="ItemID">(Int64) Item ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetName(int CorporationID, long ItemID)
        {
            return GetName(CorporationID, new long[] { ItemID });
        }

        /// <summary>Get Asset Names</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_assets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="ItemID">(Int64 List) Item ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetName(int CorporationID, IEnumerable<long> ItemIDs)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/assets/names/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, ItemIDs);
        }
    }
}
