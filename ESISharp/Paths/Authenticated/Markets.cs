using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated
{
    public class Markets : Public.Markets
    {
        internal Markets(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetStructureOrders(long structureid)
            => GetStructureOrders(structureid, 1);

        [Path("/markets/structures/{structure_id}/", WebMethods.GET)]
        public EsiRequest GetStructureOrders(long structureid, int page)
        {
            var path = new EsiRequestPath { "markets", "structures", structureid.ToString() };
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
