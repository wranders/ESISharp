using ESISharp.Web;
using System.Threading.Tasks;

namespace ESISharp.ESIPath
{
    /// <summary>Public Killmail paths</summary>
    public class Killmails
    {
        protected ESIEve EasyObject;

        internal Killmails(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get A Single Killmail</summary>
        /// <param name="KillmailID">(Int32) Killmail ID</param>
        /// <param name="KillmailHash">(String) Base64 Killmail Hash</param>
        /// <returns>JSON Object containing Killmail information</returns>
        public string GetSingle(int KillmailID, string KillmailHash)
        {
            return GetSingleAsync(KillmailID, KillmailHash).Result;
        }

        /// <summary>Get A Single Killmail</summary>
        /// <param name="KillmailID">(Int32) Killmail ID</param>
        /// <param name="KillmailHash">(String) Base64 Killmail Hash</param>
        /// <returns>JSON Object containing Killmail information</returns>
        public async Task<string> GetSingleAsync(int KillmailID, string KillmailHash)
        {
            var Path = $"/killmails/{KillmailID.ToString()}/{KillmailHash}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }
    }

    /// <summary>Public and Authenticated paths</summary>
    public class AuthKillmails : Killmails
    {
        internal AuthKillmails(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}