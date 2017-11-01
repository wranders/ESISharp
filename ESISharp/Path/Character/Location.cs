using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Location paths</summary>
    public class CharacterLocation
    {
        protected ESIEve EasyObject;

        internal CharacterLocation(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character's Location</summary>
        /// <remarks>Requires SSO Authentication, using "read_location" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetLocation(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/location/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's Online Status</summary>
        /// <remarks>Requires SSO Authentication, using "read_online" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest IsOnline(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/online/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's current ship</summary>
        /// <remarks>Requires SSO Authentication, using "read_ship" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetCurrentShip(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/ship/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
