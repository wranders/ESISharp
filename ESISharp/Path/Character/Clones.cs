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
        /// <returns>JSON Object containing home location type, location ID, and an array of objects representing clones</returns>
        public string GetClones(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/clones/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}
