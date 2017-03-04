using ESISharp.Web;

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
        /// <returns>EsiRequest</returns>
        public EsiRequest GetWallets(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/wallets/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
