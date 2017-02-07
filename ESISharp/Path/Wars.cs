using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>
    /// Public Wars paths
    /// </summary>
    public class Wars
    {
        protected EveSwagger SwaggerObject;

        internal Wars(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get All Wars
        /// </summary>
        /// <returns>JSON Array of all War IDs</returns>
        public string GetWars()
        {
            var Path = "/wars/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get War Information
        /// </summary>
        /// <param name="WarID">(Int32) War ID</param>
        /// <returns>JSON Object containing all war information</returns>
        public string GetWarInfo(int WarID)
        {
            var Path = $"/wars/{WarID.ToString()}/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get all War Killmails
        /// </summary>
        /// <param name="WarID">(Int32) War ID</param>
        /// <returns>JSON Array of all related Killmail IDs and Base64 Hashes</returns>
        public string GetWarKills(int WarID)
        {
            var Path = $"/wars/{WarID.ToString()}/killmails/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }
    }

    /// <summary>
    /// Public and Authenticated Wars paths
    /// </summary>
    public class AuthWars : Wars
    {
        internal AuthWars(EveSwagger e) : base(e)
        {
            SwaggerObject = e;
        }
    }
}