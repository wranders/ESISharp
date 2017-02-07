using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>
    /// Public Incursion paths
    /// </summary>
    public class Incursions
    {
        protected EveSwagger SwaggerObject;

        internal Incursions(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get List of Incursions
        /// </summary>
        /// <returns>JSON Array of Objects containing incursion information</returns>
        public string GetList()
        {
            string Path = "/incursions/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }
    }

    /// <summary>
    /// Public and Authenticated Incursion paths
    /// </summary>
    public class AuthIncursions : Incursions
    {
        internal AuthIncursions(EveSwagger e) : base(e)
        {
            SwaggerObject = e;
        }
    }
}