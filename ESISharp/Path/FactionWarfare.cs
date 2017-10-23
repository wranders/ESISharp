using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Public Faction Warfare paths</summary>
    public class FactionWarfare
    {
        protected ESIEve EasyObject;

        internal FactionWarfare(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        public EsiRequest GetLeaderboards()
        {
            var Path = "/fw/leaderboards/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        public EsiRequest GetCharacterLeaderboards()
        {
            var Path = "/fw/leaderboards/characters/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        public EsiRequest GetCorporationLeaderboards()
        {
            var Path = "/fw/leaderboards/corporations/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        public EsiRequest GetStats()
        {
            var Path = "/fw/stats/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        public EsiRequest GetSystems()
        {
            var Path = "/fw/systems/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        public EsiRequest GetWars()
        {
            var Path = "/fw/wars/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Public and Authenticated Faction Warfare paths</summary>
    public class AuthFactionWarfare : FactionWarfare
    {
        internal AuthFactionWarfare(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}
