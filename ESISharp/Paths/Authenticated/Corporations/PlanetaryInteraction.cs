using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Corporations
{
    public class PlanetaryInteraction : ApiPath
    {
        internal PlanetaryInteraction(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetColonies(int corporationid)
            => GetColonies(corporationid, 1);

        [Path("/corporations/{corporation_id}/customs_offices/", WebMethods.GET)]
        public EsiRequest GetColonies(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "customs_offices" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
