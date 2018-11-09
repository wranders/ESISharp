using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Contacts : ApiPath
    {
        internal Contacts(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest DeleteContact(int characterid, int contactid)
            => DeleteContact(characterid, new int[] { contactid });

        [Path("/characters/{character_id}/contacts/", WebMethods.DELETE)]
        public EsiRequest DeleteContact(int characterid, IEnumerable<int> contactids)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "contacts" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["contact_ids"] = contactids
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.DELETE, data);
        }

        public EsiRequest GetContacts(int characterid)
            => GetContacts(characterid, 1);

        [Path("/characters/{character_id}/contacts/", WebMethods.GET)]
        public EsiRequest GetContacts(int characterid, int page)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "contacts" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest AddContacts(int characterid, int contactid, float standing)
            => AddContacts(characterid, new int[] { contactid }, standing, 0, false);

        public EsiRequest AddContacts(int characterid, IEnumerable<int> contactids, float standing)
            => AddContacts(characterid, contactids, standing, 0, false);

        public EsiRequest AddContacts(int characterid, int contactid, float standing, int labelid)
            => AddContacts(characterid, new int[] { contactid }, standing, labelid, false);

        public EsiRequest AddContacts(int characterid, IEnumerable<int> contactids, float standing, int labelid)
            => AddContacts(characterid, contactids, standing, labelid, false);

        public EsiRequest AddContacts(int characterid, int contactid, float standing, bool watched)
            => AddContacts(characterid, new int[] { contactid }, standing, 0, watched);

        public EsiRequest AddContacts(int characterid, IEnumerable<int> contactids, float standing, bool watched)
            => AddContacts(characterid, contactids, standing, 0, watched);

        public EsiRequest AddContacts(int characterid, int contactid, float standing, int labelid, bool watched)
            => AddContacts(characterid, new int[] { contactid }, standing, labelid, watched);

        [Path("/characters/{character_id}/contacts/", WebMethods.POST)]
        public EsiRequest AddContacts(int characterid, IEnumerable<int> contactids, float standing, int labelid, bool watched)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "contacts" };
            var data = new EsiRequestData
            {
                Body = contactids,
                Query = new Dictionary<string, dynamic>
                {
                    ["standing"] = standing,
                    ["label_id"] = labelid,
                    ["watched"] = watched
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        public EsiRequest EditContacts(int characterid, int contactid, float standing)
            => EditContacts(characterid, new int[] { contactid }, standing, 0, false);

        public EsiRequest EditContacts(int characterid, IEnumerable<int> contactids, float standing)
            => EditContacts(characterid, contactids, standing, 0, false);

        public EsiRequest EditContacts(int characterid, int contactid, float standing, int labelid)
            => EditContacts(characterid, new int[] { contactid }, standing, labelid, false);

        public EsiRequest EditContacts(int characterid, IEnumerable<int> contactids, float standing, int labelid)
            => EditContacts(characterid, contactids, standing, labelid, false);

        public EsiRequest EditContacts(int characterid, int contactid, float standing, bool watched)
            => EditContacts(characterid, new int[] { contactid }, standing, 0, watched);

        public EsiRequest EditContacts(int characterid, IEnumerable<int> contactids, float standing, bool watched)
            => EditContacts(characterid, contactids, standing, 0, watched);

        public EsiRequest EditContacts(int characterid, int contactid, float standing, int labelid, bool watched)
            => EditContacts(characterid, new int[] { contactid }, standing, labelid, watched);

        [Path("/characters/{character_id}/contacts/", WebMethods.PUT)]
        public EsiRequest EditContacts(int characterid, IEnumerable<int> contactids, float standing, int labelid, bool watched)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "contacts" };
            var data = new EsiRequestData
            {
                Body = contactids,
                Query = new Dictionary<string, dynamic>
                {
                    ["standing"] = standing,
                    ["label_id"] = labelid,
                    ["watched"] = watched
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.PUT, data);
        }

        [Path("/characters/{character_id}/contacts/labels/", WebMethods.GET)]
        public EsiRequest GetLabels(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "contacts", "labels" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}