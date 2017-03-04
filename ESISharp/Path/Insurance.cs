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
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPrices()
        {
            var Path = "/insurance/prices/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
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