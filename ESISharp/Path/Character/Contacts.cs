using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Contact paths</summary>
    public class CharacterContacts
    {
        protected ESIEve EasyObject;

        internal CharacterContacts(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Delete Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="CharacterToDelete">(Int32) CharacterID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest DeleteContacts(int CharacterID, int CharacterToDelete)
        {
            return DeleteContacts(CharacterID, new int[] { CharacterToDelete });
        }

        /// <summary>Delete a Character's Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="CharactersToDelete">(Int32 List) CharacterID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest DeleteContacts(int CharacterID, IEnumerable<int> CharactersToDelete)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contacts/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthDelete, CharactersToDelete);
        }

        /// <summary>Get Character's Contacts (First Page)</summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetContacts(int CharacterID)
        {
            return GetContacts(CharacterID, 1);
        }

        /// <summary>Get Character's Contacts (Specified Page)</summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Page">(Int32) Page</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetContacts(int CharacterID, int Page)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contacts/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest AddContacts(int CharacterID, float Standing, int NewContactCharacterID)
        {
            return AddContacts(CharacterID, Standing, new int[] { NewContactCharacterID }, false, null);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterID">(Int32) Character ID</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest AddContacts(int CharacterID, float Standing, int NewContactCharacterID, bool Watch)
        {
            return AddContacts(CharacterID, Standing, new int[] { NewContactCharacterID }, Watch, null);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterID">(Int32) Character ID</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <param name="LabelID">(Int64) Contact Label</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest AddContacts(int CharacterID, float Standing, int NewContactCharacterID, bool Watch, long LabelID)
        {
            return AddContacts(CharacterID, Standing, new int[] { NewContactCharacterID }, Watch, LabelID);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterIDs">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest AddContacts(int CharacterID, float Standing, IEnumerable<int> NewContactCharacterIDs)
        {
            return AddContacts(CharacterID, Standing, NewContactCharacterIDs, false, null);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterIDs">(Int32) Character ID</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest AddContacts(int CharacterID, float Standing, IEnumerable<int> NewContactCharacterIDs, bool Watch)
        {
            return AddContacts(CharacterID, Standing, NewContactCharacterIDs, Watch, null);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterIDs">(Int32) Character ID</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <param name="LabelID">(Int64) Contact Label</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest AddContacts(int CharacterID, float Standing, IEnumerable<int> NewContactCharacterIDs, bool Watch, long? LabelID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contacts/";
            var PostData = NewContactCharacterIDs.ToArray();
            var Label = (LabelID == null) ? 0 : LabelID;
            var UrlData = new
            {
                standing = Standing.ToString("N2"),
                watched = Watch.ToString(),
                label_id = Label.ToString()
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, PostData, UrlData);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterID">(Int32) Character ID<</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest EditContactsAsync(int CharacterID, float Standing, int ContactCharacterID)
        {
            return EditContactsAsync(CharacterID, Standing, new int[] { ContactCharacterID }, false, null);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterID">(Int32) Character ID<</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest EditContactsAsync(int CharacterID, float Standing, int ContactCharacterID, bool Watch)
        {
            return EditContactsAsync(CharacterID, Standing, new int[] { ContactCharacterID }, Watch, null);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterID">(Int32) Character ID<</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <param name="LabelID">(Int64) Contact Label</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest EditContactsAsync(int CharacterID, float Standing, int ContactCharacterID, bool Watch, long LabelID)
        {
            return EditContactsAsync(CharacterID, Standing, new int[] { ContactCharacterID }, Watch, LabelID);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterIDs">(Int32 List) Character ID<</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest EditContactsAsync(int CharacterID, float Standing, IEnumerable<int> ContactCharacterIDs)
        {
            return EditContactsAsync(CharacterID, Standing, ContactCharacterIDs, false, null);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterIDs">(Int32 List) Character ID<</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest EditContactsAsync(int CharacterID, float Standing, IEnumerable<int> ContactCharacterIDs, bool Watch)
        {
            return EditContactsAsync(CharacterID, Standing, ContactCharacterIDs, Watch, null);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterIDs">(Int32 List) Character ID<</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <param name="LabelID">(Int64) Contact Label</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest EditContactsAsync(int CharacterID, float Standing, IEnumerable<int> ContactCharacterIDs, bool Watch, long? LabelID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contacts/";
            var PutData = ContactCharacterIDs.ToArray();
            var Label = (LabelID == null) ? 0 : LabelID;
            var UrlData = new
            {
                standing = Standing.ToString("N2"),
                watched = Watch.ToString(),
                label_id = Label.ToString()
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPut, PutData, UrlData);
        }

        /// <summary>Get Contact Labels</summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetLabels(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contacts/labels/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
