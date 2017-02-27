using ESISharp.Web;
using System.Threading.Tasks;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Asset paths</summary>
    public class CharacterAssets
    {
        protected ESIEve EasyObject;

        internal CharacterAssets(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Character's Assets</summary>
        /// <remarks>Requires SSO Authentication, using "read_assets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of objects representing items</returns>
        public string GetAll(int CharacterID)
        {
            return GetAllAsync(CharacterID).Result;
        }

        /// <summary>Get All Character's Assets</summary>
        /// <remarks>Requires SSO Authentication, using "read_assets" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of objects representing items</returns>
        public async Task<string> GetAllAsync(int CharacterID)
        {
            var Path = $"/characters/{CharacterID}/assets/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }
    }
}
