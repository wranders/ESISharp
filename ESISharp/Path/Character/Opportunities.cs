using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    public class CharacterOpportunities
    {
        protected ESIEve EasyObject;

        internal CharacterOpportunities(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character's Completed Opportunities</summary>
        /// <remarks>Requires SSO Authentication, using "read_opportunities" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetCompleted(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/opportunities/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}
