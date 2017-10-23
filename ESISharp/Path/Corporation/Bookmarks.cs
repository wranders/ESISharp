using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation
{
    /// <summary>Authenticated Corporation Bookmark paths</summary>
    public class CorporationBookmarks
    {
        protected ESIEve EasyObject;

        internal CorporationBookmarks(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Corporation's Bookmarks, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_bookmarks" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAll(int CorporationID)
        {
            return GetAll(CorporationID, 1);
        }

        /// <summary>Get All Corporation's Bookmarks, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_bookmarks" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAll(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/bookmarks/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Corporation's Bookmark Folders, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_bookmarks" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetFolders(int CorporationID)
        {
            return GetFolders(CorporationID, 1);
        }

        /// <summary>Get Corporation's Bookmark Folders, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_bookmarks" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetFolders(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/bookmarks/folders/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
