using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated
{
    public class Universe : Public.Universe
    {
        internal Universe(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/universe/structures/{structure_id}/", WebMethods.GET)]
        public EsiRequest GetStructureInformation(long structureid)
        {
            var path = new EsiRequestPath { "universe", "structures", structureid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
