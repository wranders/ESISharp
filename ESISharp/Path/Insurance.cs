using ESISharp.Enumerations;
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

        /// <summary>Get Insurance Information</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPrices()
        {
            return GetPrices(Language.English);
        }

        /// <summary>Get Insurace Information</summary>
        /// <param name="Language">(Language) Result Language</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPrices(Language Language)
        {
            var Path = "/insurance/prices/";
            var Data = new
            {
                language = Language.Value
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
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