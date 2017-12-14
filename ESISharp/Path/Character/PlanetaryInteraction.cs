using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Planetary Interaction (PI) paths</summary>
    public class CharacterPlanetaryInteraction
    {
        protected ESIEve EasyObject;

        internal CharacterPlanetaryInteraction(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character's PI Colonies</summary>
        /// <remarks>Requires SSO Authentication, using "manage_planets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetColonies(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/planets/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's PI Colony Layout</summary>
        /// <remarks>Requires SSO Authentication, using "manage_planets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="PlanetID">(Int32) Planet ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetColonyLayout(int CharacterID, int PlanetID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/planets/{PlanetID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
