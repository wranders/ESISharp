using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    public class CharacterFactionWarfare
    {
        protected ESIEve EasyObject;

        internal CharacterFactionWarfare(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character's Faction Warfare Statistics</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStats(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/fw/stats/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
