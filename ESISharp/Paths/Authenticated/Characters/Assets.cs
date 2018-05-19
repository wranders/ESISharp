using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Characters
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

        public EsiRequest GetAll(int characterid)
            => GetAll(characterid, 1);

        [Path("/characters/{character_id}/assets/", WebMethods.GET)]
        public EsiRequest GetAll(int characterid, int page)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "assets" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetLocations(int characterid, int item)
            => GetLocations(characterid, new long[] { item });

        [Path("/characters/{character_id}/assets/locations/", WebMethods.POST)]
        public EsiRequest GetLocations(int characterid, IEnumerable<long> items)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "assets", "locations" };
            return _GetItemInfo(path, items);
        }

        public EsiRequest GetNames(int characterid, long item)
            => GetNames(characterid, new long[] { item });

        [Path("/characters/{character_id}/assets/names/", WebMethods.POST)]
        public EsiRequest GetNames(int characterid, IEnumerable<long> items)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "assets", "names" };
            return _GetItemInfo(path, items);
        }
    }
}
