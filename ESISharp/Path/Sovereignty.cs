using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>
    /// Public Sovereignty path
    /// </summary>
    public class Sovereignty
    {
        protected EveSwagger SwaggerObject;

        internal Sovereignty(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get All Sovereignty Campaigns
        /// </summary>
        /// <returns>JSON Array of Objects containing campaign information</returns>
        public string GetCampaigns()
        {
            var Path = "/sovereignty/campaigns/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get All Sovereignty Stuctures
        /// </summary>
        /// <returns>JSON Array of Objects containing structure information</returns>
        public string GetStructures()
        {
            var Path = "/sovereignty/structures/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }
    }

    /// <summary>
    /// Public and Authenticated paths
    /// </summary>
    public class AuthSovereignty : Sovereignty
    {
        internal AuthSovereignty(EveSwagger e) : base(e)
        {
            SwaggerObject = e;
        }
    }
}