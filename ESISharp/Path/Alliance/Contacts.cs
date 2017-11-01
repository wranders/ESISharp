using ESISharp.Web;

namespace ESISharp.ESIPath.Alliance
{
    /// <summary></summary>
    public class AllianceContacts
    {
        protected ESIEve EasyObject;

        internal AllianceContacts(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Alliance Contacts, First Page</summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Get(int AllianceID)
        {
            return Get(AllianceID, 1);
        }

        /// <summary>Get Alliance Contacts, First Page</summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Get(int AllianceID, int Page)
        {
            var Path = $"/alliances/{AllianceID.ToString()}/contacts/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
