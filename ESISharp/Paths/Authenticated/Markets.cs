using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated
{
    public class Markets : Public.Markets
    {
        internal Markets(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/markets/structures/{structure_id}/", WebMethods.GET)]
        public EsiRequest GetStructureOrders(long structureid)
        {
            var path = new EsiRequestPath { "markets", "structures", structureid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
