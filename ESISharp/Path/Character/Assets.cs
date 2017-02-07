using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>
    /// Authenticated Character Asset paths
    /// </summary>
    public class CharacterAssets
    {
        protected EveSwagger SwaggerObject;

        internal CharacterAssets(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get All Character's Assets
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_assets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns></returns>
        public string GetAll(int CharacterID)
        {
            string Path = $"/characters/{CharacterID}/assets/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}
