using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Public
{
    public class Industry : ApiPath
    {
        internal Industry(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/industry/facilities/", WebMethods.GET)]
        public EsiRequest GetFacilities()
        {
            var path = new EsiRequestPath { "industry", "facilities" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/industry/systems/", WebMethods.GET)]
        public EsiRequest GetSystemIndicies()
        {
            var path = new EsiRequestPath { "industry", "systems" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
