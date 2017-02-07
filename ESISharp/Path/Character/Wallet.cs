using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>
    /// Authenticated Character Wallet paths
    /// </summary>
    public class CharacterWallet
    {
        protected EveSwagger SwaggerObject;

        internal CharacterWallet(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Character's wallets and balances
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_character_wallet" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects containing related wallet IDs and balances</returns>
        public string GetWallets(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/wallets/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();

        }
    }
}
