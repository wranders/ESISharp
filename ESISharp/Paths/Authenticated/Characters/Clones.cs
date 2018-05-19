using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Clones : ApiPath
    {
        internal Clones(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/clones/", WebMethods.GET)]
        public EsiRequest GetAll(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "clones" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/implants/", WebMethods.GET)]
        public EsiRequest GetActiveImplants(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "implants" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
