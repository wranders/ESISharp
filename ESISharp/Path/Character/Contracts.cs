using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Contract paths</summary>
    public class CharacterContracts
    {
        protected ESIEve EasyObject;

        internal CharacterContracts(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }
        /// <summary>Get Character's Contracts</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_contracts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetContracts(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contracts/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's Contract Bids</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_contracts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="ContractID">(Int32) Contract ID</param>
        /// <returns><EsiRequest/returns>
        public EsiRequest GetBids(int CharacterID, int ContractID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contracts/{ContractID.ToString()}/bids/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's Contract Items</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_contracts" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="ContractID">(Int32) Contract ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetItems(int CharacterID, int ContractID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/contracts/{ContractID.ToString()}/items/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
