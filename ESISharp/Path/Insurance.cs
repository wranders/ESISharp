using ESISharp.Web;
using System.Threading.Tasks;

namespace ESISharp.ESIPath
{
    /// <summary>Public Insurance paths</summary>
    public class Insurance
    {
        protected ESIEve EasyObject;

        internal Insurance(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Insurace Information</summary>
        /// <returns>JSON Array of Objects containing Type ID, cost, name, and payout </returns>
        public string GetPrices()
        {
            return GetPricesAsync().Result;
        }

        /// <summary>Get Insurace Information</summary>
        /// <returns>JSON Array of Objects containing Type ID, cost, name, and payout </returns>
        public async Task<string> GetPricesAsync()
        {
            var Path = "/insurance/prices/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }
    }

    /// <summary>Public and Authenticated Insurance paths</summary>
    public class AuthInsurance : Insurance
    {
        internal AuthInsurance(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}