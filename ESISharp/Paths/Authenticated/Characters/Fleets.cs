using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Fleets : ApiPath
    {
        internal Fleets(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/fleet/", WebMethods.GET)]
        public EsiRequest GetInfo(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "fleet" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
