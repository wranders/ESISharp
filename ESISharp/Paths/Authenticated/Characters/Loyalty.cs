using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Loyalty : ApiPath
    {
        internal Loyalty(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/loyalty/points/", WebMethods.GET)]
        public EsiRequest GetPoints(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "loyalty", "points" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
