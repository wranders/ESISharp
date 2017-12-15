using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Public
{
    public class Status : ApiPath
    {
        internal Status(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/status/", WebMethods.GET)]
        public EsiRequest Get()
        {
            var path = new EsiRequestPath { "status" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
