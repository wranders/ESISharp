using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Clone paths</summary>
    public class CharacterClones
    {
        protected ESIEve EasyObject;

        internal CharacterClones(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character's Clones</summary>
        /// <remarks>Requires SSO Authentication, using "read_clones" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetClones(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/clones/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's Current Clone's Implants</summary>
        /// <remarks>Requires SSO Authentication, uses "read_implants" scope</remarks>
        /// <param name="CharacterID">(Int32) CharacterID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetImplants(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/implants/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
