using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Public Killmail paths</summary>
    public class Killmails
    {
        protected EveSwagger SwaggerObject;

        internal Killmails(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>Get A Single Killmail</summary>
        /// <param name="KillmailID">(Int32) Killmail ID</param>
        /// <param name="KillmailHash">(String) Base64 Killmail Hash</param>
        /// <returns>JSON Object containing Killmail information</returns>
        public string GetSingle(int KillmailID, string KillmailHash)
        {
            var Path = $"/killmails/{KillmailID.ToString()}/{KillmailHash}/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }
    }

    /// <summary>Public and Authenticated paths</summary>
    public class AuthKillmails : Killmails
    {
        internal AuthKillmails(EveSwagger e) : base(e)
        {
            SwaggerObject = e;
        }
    }
}