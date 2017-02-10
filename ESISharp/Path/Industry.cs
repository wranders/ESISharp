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
        /// <returns>JSON Array of Objects containing Facility information</returns>
        public string GetFacilities()
        {
            var Path = "/industry/facilities/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>Get List of Solar System Cost Indices</summary>
        /// <returns>JSON Array of Objects containing Solar System ID and related activities and cost indices</returns>
        public string GetIndices()
        {
            var Path = "/industry/systems/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get();
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