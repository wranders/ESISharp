using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated.Corporations
{
    public class FactionWarfare : ApiPath
    {
        internal FactionWarfare(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/corporations/{character_id}/fw/stats/", WebMethods.GET)]
        public EsiRequest GetOverview(int characterid)
        {
            var path = new EsiRequestPath { "corporations", characterid.ToString(), "fw", "stats" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
