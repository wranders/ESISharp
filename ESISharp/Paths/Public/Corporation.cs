using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Corporation : ApiPath
    {
        internal Corporation(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/corporations/{corporation_id}/", WebMethods.GET)]
        public EsiRequest GetInformation(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/corporations/{corporation_id}/alliancehistory/", WebMethods.GET)]
        public EsiRequest GetAllianceHistory(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "alliancehistory" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetNames(long corporationid)
        {
            return GetNames(new long[] { corporationid });
        }

        [Path("/corporations/names/", WebMethods.GET)]
        public EsiRequest GetNames(IEnumerable<long> corporationids)
        {
            var path = new EsiRequestPath { "corporations", "names" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>()
                {
                    ["corporation_ids"] = corporationids
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/corporations/{corporation_id}/icons/", WebMethods.GET)]
        public EsiRequest GetIcons(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "icons" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/corporations/npccorps/", WebMethods.GET)]
        public EsiRequest GetNpcCorps()
        {
            var path = new EsiRequestPath { "corporations", "npccorps" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
