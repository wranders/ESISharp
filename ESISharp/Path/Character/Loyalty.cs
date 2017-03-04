using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Loyalty Points Paths</summary>
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
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAll(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/loyalty/points/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
