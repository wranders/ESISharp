using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>
    /// Authenticated Character Planetary Interaction (PI) paths
    /// </summary>
    public class CharacterPlanetaryInteraction
    {
        protected EveSwagger SwaggerObject;

        internal CharacterPlanetaryInteraction(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Character's PI Colonies
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "manage_planets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing planets and their colony information</returns>
        public string GetColonies(int CharacterID)
        {
            string Path = $"/characters/{CharacterID.ToString()}/planets/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>
        /// Get Character's PI Colony Layout
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "manage_planets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="PlanetID">(Int32) Planet ID</param>
        /// <returns>JSON Object containing link, pin, and route arrays</returns>
        public string GetColonyLayout(int CharacterID, int PlanetID)
        {
            string Path = $"/characters/{CharacterID.ToString()}/planets/{PlanetID.ToString()}/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}
