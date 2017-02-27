using ESISharp.Web;
using System.Threading.Tasks;

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
            return GetFacilitiesAsync().Result;
        }

        /// <summary>Get List of Industry Facilities</summary>
        /// <returns>JSON Array of Objects containing Facility information</returns>
        public async Task<string> GetFacilitiesAsync()
        {
            var Path = "/industry/facilities/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get List of Solar System Cost Indices</summary>
        /// <returns>JSON Array of Objects containing Solar System ID and related activities and cost indices</returns>
        public string GetIndices()
        {
            return GetIndicesAsync().Result;
        }

        /// <summary>Get List of Solar System Cost Indices</summary>
        /// <returns>JSON Array of Objects containing Solar System ID and related activities and cost indices</returns>
        public async Task<string> GetIndicesAsync()
        {
            var Path = "/industry/systems/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
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