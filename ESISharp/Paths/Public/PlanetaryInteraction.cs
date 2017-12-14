using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Public
{
    public class PlanetaryInteraction : ApiPath
    {
        internal PlanetaryInteraction(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/universe/schematics/{schematic_id}/", WebMethods.GET)]
        public EsiRequest GetSchematicInfo(int schematicid)
        {
            var path = new EsiRequestPath { "universe", "schematics", schematicid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
