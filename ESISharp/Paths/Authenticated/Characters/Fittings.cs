using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Fittings : ApiPath
    {
        internal Fittings(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/fittings/", WebMethods.GET)]
        public EsiRequest GetAll(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "fittings" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/fittings/", WebMethods.POST)]
        public EsiRequest Create(int characterid, Fitting fitting)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "fittings" };
            var data = new EsiRequestData
            {
                Body = fitting
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/characters/{character_id}/fittings/{fitting_id}/", WebMethods.DELETE)]
        public EsiRequest Delete(int characterid, int fittingid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "fittings", fittingid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.DELETE);
        }
    }
}
