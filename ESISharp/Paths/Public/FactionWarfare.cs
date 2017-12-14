using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Public
{
    public class FactionWarfare : ApiPath
    {
        internal FactionWarfare(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/fw/wars/", WebMethods.GET)]
        public EsiRequest GetWars()
        {
            var path = new EsiRequestPath { "fw", "wars" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/fw/stats/", WebMethods.GET)]
        public EsiRequest GetStats()
        {
            var path = new EsiRequestPath { "fw", "stats" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/fw/systems/", WebMethods.GET)]
        public EsiRequest GetSystems()
        {
            var path = new EsiRequestPath { "fw", "systems" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/fw/leaderboards/", WebMethods.GET)]
        public EsiRequest GetLeaderboards()
        {
            var path = new EsiRequestPath { "fw", "leaderboards" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/fw/leaderboards/characters/", WebMethods.GET)]
        public EsiRequest GetCharacterLeaderboards()
        {
            var path = new EsiRequestPath { "fw", "leaderboards", "characters" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/fw/leaderboards/corporations/", WebMethods.GET)]
        public EsiRequest GetCorporationLeaderboards()
        {
            var path = new EsiRequestPath { "fw", "leaderboards", "corporations" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
