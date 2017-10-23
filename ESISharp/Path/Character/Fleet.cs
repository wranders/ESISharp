using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Fleet paths</summary>
    public class CharacterFleet
    {
        protected ESIEve EasyObject;

        internal CharacterFleet(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character's Fleet ID</summary>
        /// <remarks>Requires SSO Authentication, uses "read_fleet" scope</remarks>
        /// <param name="CharacterID">(Int32) CharacterID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetFleetID(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/fleet/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
