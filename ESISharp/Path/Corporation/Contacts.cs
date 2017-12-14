using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation
{
    /// <summary>Authenticated Corporation Contacts Paths</summary>
    public class CorporationContacts
    {
        protected ESIEve EasyObject;

        internal CorporationContacts(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Contacts, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_contacts" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetContacts(int CorporationID)
        {
            return GetContacts(CorporationID, 1);
        }

        /// <summary>Get Corporation's Contacts, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_contacts" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetContacts(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/contacts/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
