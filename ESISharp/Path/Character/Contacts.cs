using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Contact paths</summary>
    public class CharacterContacts
    {
        protected EveSwagger SwaggerObject;

        internal CharacterContacts(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>Delete Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="CharacterToDelete">(Int32) CharacterID</param>
        /// <returns>Normally nothing, error id one is encountered</returns>
        public string DeleteContacts(int CharacterID, int CharacterToDelete)
        {
            return DeleteContacts(CharacterID, new List<int>() { CharacterToDelete });
        }

        /// <summary>Delete a Character's Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="CharactersToDelete">(Int32 List) CharacterID</param>
        /// <returns>Normally nothing, error id one is encountered</returns>
        public string DeleteContacts(int CharacterID, List<int> CharactersToDelete)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contacts/";
            var Data = CharactersToDelete.ToArray();
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Delete(Data);
        }

        /// <summary>Get Character's Contacts (First Page)</summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of objects representing contacts</returns>
        public string GetContacts(int CharacterID)
        {
            return GetContacts(CharacterID, null);
        }

        /// <summary>Get Character's Contacts (Specified Page)</summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Page">(Int32) Page</param>
        /// <returns>JSON Array of objects representing contacts</returns>
        public string GetContacts(int CharacterID, int? Page)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contacts/";
            var Data = new { page = Page };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get(Data);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterID">(Int32) Character ID</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string AddContacts(int CharacterID, float Standing, int NewContactCharacterID)
        {
            return AddContacts(CharacterID, Standing, new List<int>() { NewContactCharacterID }, false, null);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterID">(Int32) Character ID</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string AddContacts(int CharacterID, float Standing, int NewContactCharacterID, bool Watch)
        {
            return AddContacts(CharacterID, Standing, new List<int>() { NewContactCharacterID }, Watch, null);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterID">(Int32) Character ID</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <param name="LabelID">(Int64) Contact Label</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string AddContacts(int CharacterID, float Standing, int NewContactCharacterID, bool Watch, long LabelID)
        {
            return AddContacts(CharacterID, Standing, new List<int>() { NewContactCharacterID }, Watch, LabelID);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterIDs">(Int32) Character ID</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string AddContacts(int CharacterID, float Standing, List<int> NewContactCharacterIDs)
        {
            return AddContacts(CharacterID, Standing, NewContactCharacterIDs, false, null);
        }

        /// <summary>Add Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="NewContactCharacterIDs">(Int32) Character ID</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string AddContacts(int CharacterID, float Standing, List<int> NewContactCharacterIDs, bool Watch)
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
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string AddContacts(int CharacterID, float Standing, List<int> NewContactCharacterIDs, bool Watch, long? LabelID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contacts/";
            var PostData = NewContactCharacterIDs.ToArray();
            var Label = (LabelID == null) ? 0 : LabelID;
            var UrlData = new { standing = Standing.ToString("N2"), watched = Watch.ToString(), label_id = Label.ToString() };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Post(PostData, UrlData);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterID">(Int32) Character ID<</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string EditContacts(int CharacterID, float Standing, int ContactCharacterID)
        {
            return EditContacts(CharacterID, Standing, new List<int>() { ContactCharacterID }, false, null);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterID">(Int32) Character ID<</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string EditContacts(int CharacterID, float Standing, int ContactCharacterID, bool Watch)
        {
            return EditContacts(CharacterID, Standing, new List<int>() { ContactCharacterID }, Watch, null);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterID">(Int32) Character ID<</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <param name="LabelID">(Int64) Contact Label</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string EditContacts(int CharacterID, float Standing, int ContactCharacterID, bool Watch, long LabelID)
        {
            return EditContacts(CharacterID, Standing, new List<int>() { ContactCharacterID }, Watch, LabelID);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterIDs">(Int32 List) Character ID<</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string EditContacts(int CharacterID, float Standing, List<int> ContactCharacterIDs)
        {
            return EditContacts(CharacterID, Standing, ContactCharacterIDs, false, null);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterIDs">(Int32 List) Character ID<</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string EditContacts(int CharacterID, float Standing, List<int> ContactCharacterIDs, bool Watch)
        {
            return EditContacts(CharacterID, Standing, ContactCharacterIDs, Watch, null);
        }

        /// <summary>Edit Contact</summary>
        /// <remarks>Requires SSO Authentication, using "write_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Standing">(Float) Standing, -10 to 10</param>
        /// <param name="ContactCharacterIDs">(Int32 List) Character ID<</param>
        /// <param name="Watch">(Boolean) Watch</param>
        /// <param name="LabelID">(Int64) Contact Label</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string EditContacts(int CharacterID, float Standing, List<int> ContactCharacterIDs, bool Watch, long? LabelID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contacts/";
            var PutData = ContactCharacterIDs.ToArray();
            var Label = (LabelID == null) ? 0 : LabelID;
            var UrlData = new { standing = Standing.ToString("N2"), watched = Watch.ToString(), label_id = Label.ToString() };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Put(PutData, UrlData);
        }

        /// <summary>Get Contact Labels</summary>
        /// <remarks>Requires SSO Authentication, using "read_contacts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array containing Objects containing label ID and label name</returns>
        public string GetLabels(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contacts/labels/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}
