using ESISharp.Web;

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
            var Path = "/insurance/prices/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get();
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