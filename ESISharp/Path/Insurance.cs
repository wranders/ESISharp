using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>
    /// Public Insurance paths
    /// </summary>
    public class Insurance
    {
        protected EveSwagger SwaggerObject;

        internal Insurance(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Insurace Information
        /// </summary>
        /// <returns>JSON Array of Objects containing Type ID, cost, name, and payout </returns>
        public string GetPrices()
        {
            var Path = "/insurance/prices/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }
    }

    /// <summary>
    /// Public and Authenticated Insurance paths
    /// </summary>
    public class AuthInsurance : Insurance
    {
        internal AuthInsurance(EveSwagger e) : base(e)
        {
            SwaggerObject = e;
        }
    }
}