using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Corporations
{
    public class Assets : ApiPath
    {
        internal Assets(EsiConnection esiconnection) : base(esiconnection) { }

        private EsiRequest _GetItemInfo(EsiRequestPath path, IEnumerable<long> items)
        {
            var data = new EsiRequestData
            {
                Body = items
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        public EsiRequest GetAll(int corporationid)
            => GetAll(corporationid, 1);

        [Path("/corporations/{corporation_id}/assets/", WebMethods.GET)]
        public EsiRequest GetAll(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "assets" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetLocations(int corporationid, long item)
            => GetLocations(corporationid, new long[] { item });

        [Path("/corporations/{corporation_id}/assets/locations/", WebMethods.POST)]
        public EsiRequest GetLocations(int corporationid, IEnumerable<long> items)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "assets", "locations" };
            return _GetItemInfo(path, items);
        }

        public EsiRequest GetNames(int corporationid, long item)
            => GetNames(corporationid, new long[] { item });

        [Path("/corporations/{corporation_id}/assets/names/", WebMethods.POST)]
        public EsiRequest GetNames(int corporationid, IEnumerable<long> items)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "assets", "names" };
            return _GetItemInfo(path, items);
        }
    }
}
