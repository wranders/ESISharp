using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Public Industry paths</summary>
    public class Industry
    {
        protected ESIEve EasyObject;

        internal Industry(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get List of Industry Facilities</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetFacilities()
        {
            var Path = "/industry/facilities/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get List of Solar System Cost Indices</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetIndices()
        {
            var Path = "/industry/systems/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Public and Authenticated Industry paths</summary>
    public class AuthIndustry : Industry
    {
        internal AuthIndustry(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}