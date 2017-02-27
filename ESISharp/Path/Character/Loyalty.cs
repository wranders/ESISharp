using ESISharp.Web;
using System.Threading.Tasks;

namespace ESISharp.ESIPath.Character
{
    public class CharacterLoyalty
    {
        protected ESIEve EasyObject;

        internal CharacterLoyalty(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Character's Loyalty Points</summary>
        /// <remarks>Requires SSO Authentication, using "read_loyalty" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of objects representing corporations and it's associated loyalty points</returns>
        public string GetAll(int CharacterID)
        {
            return GetAllAsync(CharacterID).Result;
        }

        /// <summary>Get All Character's Loyalty Points</summary>
        /// <remarks>Requires SSO Authentication, using "read_loyalty" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of objects representing corporations and it's associated loyalty points</returns>
        public async Task<string> GetAllAsync(int CharacterID)
        {
            var Path = $"/characters/{CharacterID}/loyalty/points/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }
    }
}
