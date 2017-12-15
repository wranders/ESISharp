using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Public
{
    public class Sovereignty : ApiPath
    {
        internal Sovereignty(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/sovereignty/structures/", WebMethods.GET)]
        public EsiRequest GetStructures()
        {
            var path = new EsiRequestPath { "sovereignty", "structures" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/sovereignty/campaigns/", WebMethods.GET)]
        public EsiRequest GetCampaigns()
        {
            var path = new EsiRequestPath { "sovereignty", "campaigns" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/sovereignty/map/", WebMethods.GET)]
        public EsiRequest GetSystems()
        {
            var path = new EsiRequestPath { "sovereignty", "map" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
