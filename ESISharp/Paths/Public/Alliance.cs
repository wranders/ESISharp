using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Alliance : ApiPath
    {
        internal Alliance(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/alliances/{alliance_id}/", WebMethods.GET)]
        public EsiRequest GetInformation(int allianceid)
        {
            var path = new EsiRequestPath() { "alliances", allianceid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/alliances/{alliance_id}/corporations/", WebMethods.GET)]
        public EsiRequest GetCorporations(int allianceid)
        {
            var path = new EsiRequestPath() { "alliances", allianceid.ToString(), "corporations" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetNames(long allianceid)
        {
            return GetNames(new long[] { allianceid });
        }

        [Path("/alliances/names/", WebMethods.GET)]
        public EsiRequest GetNames(IEnumerable<long> allianceids)
        {
            var path = new EsiRequestPath() { "alliances", "names" };
            var data = new EsiRequestData()
            {
                Query = new Dictionary<string, dynamic>()
                {
                    ["alliance_ids"] = allianceids
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/alliances/{alliance_id}/icons/", WebMethods.GET)]
        public EsiRequest GetIcons(int allianceid)
        {
            var path = new EsiRequestPath() { "alliances", allianceid.ToString(), "icons" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/alliances/", WebMethods.GET)]
        public EsiRequest GetAll()
        {
            var path = new EsiRequestPath() { "alliances" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
