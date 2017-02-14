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
        /// <returns>JSON Array of Objects representing planets and their colony information</returns>
        public string GetColonies(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/planets/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>Get Character's PI Colony Layout</summary>
        /// <remarks>Requires SSO Authentication, using "manage_planets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="PlanetID">(Int32) Planet ID</param>
        /// <returns>JSON Object containing link, pin, and route arrays</returns>
        public string GetColonyLayout(int CharacterID, int PlanetID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/planets/{PlanetID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}
