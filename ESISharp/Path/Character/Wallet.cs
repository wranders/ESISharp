using ESISharp.Web;
using System.Threading.Tasks;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Wallet paths</summary>
    public class CharacterWallet
    {
        protected ESIEve EasyObject;

        internal CharacterWallet(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character's wallets and balances</summary>
        /// <remarks>Requires SSO Authentication, using "read_character_wallet" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects containing related wallet IDs and balances</returns>
        public string GetWallets(int CharacterID)
        {
            return GetWalletsAsync(CharacterID).Result;
        }

        /// <summary>Get Character's wallets and balances</summary>
        /// <remarks>Requires SSO Authentication, using "read_character_wallet" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects containing related wallet IDs and balances</returns>
        public async Task<string> GetWalletsAsync(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/wallets/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }
    }
}
