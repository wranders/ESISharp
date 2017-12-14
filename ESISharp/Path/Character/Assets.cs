using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Asset paths</summary>
    public class CharacterAssets
    {
        protected ESIEve EasyObject;

        internal CharacterAssets(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Character's Assets, First Page</summary>
        /// <remarks>Requires SSO Authentication, using "read_assets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAll(int CharacterID)
        {
            return GetAll(CharacterID, 1);
        }

        /// <summary>Get All Character's Assets, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, using "read_assets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAll(int CharacterID, int Page)
        {
            var Path = $"/characters/{CharacterID.ToString()}/assets/";
            var Data = new { page = Page };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Asset Location</summary>
        /// <remarks>Requires SSO Authentication, using "read_assets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="ItemID">(Int64) Item ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetLocation(int CharacterID, long ItemID)
        {
            return GetLocation(CharacterID, new long[] { ItemID });
        }

        /// <summary>Get Asset Locations</summary>
        /// <remarks>Requires SSO Authentication, using "read_assets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="ItemID">(Int64 List) Item ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetLocation(int CharacterID, IEnumerable<long> ItemIDs)
        {
            var Path = $"/characters/{CharacterID.ToString()}/assets/locations/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, ItemIDs);
        }

        /// <summary>Get Asset Name</summary>
        /// <remarks>Requires SSO Authentication, using "read_assets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="ItemID">(Int64) Item ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetName(int CharacterID, long ItemID)
        {
            return GetName(CharacterID, new long[] { ItemID });
        }

        /// <summary>Get Asset Names</summary>
        /// <remarks>Requires SSO Authentication, using "read_assets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="ItemID">(Int64 List) Item ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetName(int CharacterID, IEnumerable<long> ItemIDs)
        {
            var Path = $"/characters/{CharacterID.ToString()}/assets/names/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, ItemIDs);
        }
    }
}
