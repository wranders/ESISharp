using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Industry paths</summary>
    public class CharacterMarket
    {
        protected ESIEve EasyObject;

        internal CharacterMarket(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get list of character's market orders</summary>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetOrders(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/orders/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
