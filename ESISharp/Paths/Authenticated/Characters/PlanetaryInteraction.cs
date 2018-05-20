using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class PlanetaryInteraction : ApiPath
    {
        internal PlanetaryInteraction(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/planets/", WebMethods.GET)]
        public EsiRequest GetColonies(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "planets" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/planets/{planet_id}/", WebMethods.GET)]
        public EsiRequest GetColonyLayout(int characterid, int planetid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "planets", planetid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
