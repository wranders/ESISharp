using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Public
{
    public class Incursions : ApiPath
    {
        internal Incursions(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/incursions/", WebMethods.GET)]
        public EsiRequest GetIncursions()
        {
            var path = new EsiRequestPath { "incursions" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
