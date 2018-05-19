using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Alliances
{
    public class Contacts : ApiPath
    {
        internal Contacts(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetAll(int allianceid)
        {
            return GetAll(allianceid, 1);
        }

        [Path("/alliances/{alliance_id}/contacts/", WebMethods.GET)]
        public EsiRequest GetAll(int allianceid, int page)
        {
            var path = new EsiRequestPath { "alliances", allianceid.ToString(), "contacts" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/alliances/{alliance_id}/contacts/labels/", WebMethods.GET)]
        public EsiRequest GetLabels(int allianceid)
        {
            var path = new EsiRequestPath { "alliances", allianceid.ToString(), "contacts", "labels" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
