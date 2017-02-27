using ESISharp.Web;
using System.Threading.Tasks;

namespace ESISharp.ESIPath
{
    /// <summary>Public Wars paths</summary>
    public class Wars
    {
        protected ESIEve EasyObject;

        internal Wars(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Wars</summary>
        /// <returns>JSON Array of all War IDs</returns>
        public string GetWars()
        {
            return GetWarsAsync().Result;
        }

        /// <summary>Get All Wars</summary>
        /// <returns>JSON Array of all War IDs</returns>
        public async Task<string> GetWarsAsync()
        {
            var Path = "/wars/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get War Information</summary>
        /// <param name="WarID">(Int32) War ID</param>
        /// <returns>JSON Object containing all war information</returns>
        public string GetWarInfo(int WarID)
        {
            return GetWarInfoAsync(WarID).Result;
        }

        /// <summary>Get War Information</summary>
        /// <param name="WarID">(Int32) War ID</param>
        /// <returns>JSON Object containing all war information</returns>
        public async Task<string> GetWarInfoAsync(int WarID)
        {
            var Path = $"/wars/{WarID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get all War Killmails</summary>
        /// <param name="WarID">(Int32) War ID</param>
        /// <returns>JSON Array of all related Killmail IDs and Base64 Hashes</returns>
        public string GetWarKills(int WarID)
        {
            return GetWarKillsAsync(WarID).Result;
        }

        /// <summary>Get all War Killmails</summary>
        /// <param name="WarID">(Int32) War ID</param>
        /// <returns>JSON Array of all related Killmail IDs and Base64 Hashes</returns>
        public async Task<string> GetWarKillsAsync(int WarID)
        {
            var Path = $"/wars/{WarID.ToString()}/killmails/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }
    }

    /// <summary>Public and Authenticated Wars paths</summary>
    public class AuthWars : Wars
    {
        internal AuthWars(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}