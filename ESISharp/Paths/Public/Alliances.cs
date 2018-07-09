using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Public
{
    public class Alliances : ApiPath
    {
        internal Alliances(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/alliances/{alliance_id}/", WebMethods.GET)]
        public EsiRequest GetInformation(int allianceid)
        {
            var path = new EsiRequestPath { "alliances", allianceid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/alliances/{alliance_id}/corporations/", WebMethods.GET)]
        public EsiRequest GetCorporations(int allianceid)
        {
            var path = new EsiRequestPath { "alliances", allianceid.ToString(), "corporations" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/alliances/{alliance_id}/icons/", WebMethods.GET)]
        public EsiRequest GetIcons(int allianceid)
        {
            var path = new EsiRequestPath { "alliances", allianceid.ToString(), "icons" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/alliances/", WebMethods.GET)]
        public EsiRequest GetAll()
        {
            var path = new EsiRequestPath { "alliances" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
