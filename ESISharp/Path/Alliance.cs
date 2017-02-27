using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESISharp.ESIPath
{
    /// <summary>Public Alliance paths</summary>
    public class Alliance
    {
        protected ESIEve EasyObject;

        internal Alliance(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Alliance IDs</summary>
        /// <returns>JSON Array of Alliance IDs</returns>
        public string GetAll()
        {
            return GetAllAsync().Result;
        }

        /// <summary>Get All Alliance IDs</summary>
        /// <returns>JSON Array of Alliance IDs</returns>
        public async Task<string> GetAllAsync()
        {
            var Path = "/alliances/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Alliance Name from ID</summary>
        /// <param name="AllianceID">(Int64) Alliance ID</param>
        /// <returns>JSON Array of associated ID and Name</returns>
        public string GetNames(long AllianceID)
        {
            return GetNames(new List<long>() { AllianceID });
        }

        /// <summary>Get Alliance Names from List if IDs</summary>
        /// <param name="AllianceIDs">List(Int64) Alliance IDs</param>
        /// <returns>JSON Array of associated IDs and Names</returns>
        public string GetNames(IEnumerable<long> AllianceIDs)
        {
            return GetNamesAsync(AllianceIDs).Result;
        }

        /// <summary>Get Alliance Name from ID</summary>
        /// <param name="AllianceID">(Int64) Alliance ID</param>
        /// <returns>JSON Array of associated ID and Name</returns>
        public async Task<string> GetNamesAsync(long AllianceID)
        {
            return await GetNamesAsync(new List<long>() { AllianceID }).ConfigureAwait(false);
        }

        /// <summary>Get Alliance Names from List if IDs</summary>
        /// <param name="AllianceIDs">List(Int64) Alliance IDs</param>
        /// <returns>JSON Array of associated IDs and Names</returns>
        public async Task<string> GetNamesAsync(IEnumerable<long> AllianceIDs)
        {
            var Path = "/alliances/names/";
            var Data = new { alliance_ids = AllianceIDs.ToArray() };
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Get Alliance Information</summary>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <returns>JSON Object containing Alliance Name, Date Founded, Executor Corporation, and Ticker</returns>
        public string GetInformation(int AllianceID)
        {
            return GetInformationAsync(AllianceID).Result;
        }

        /// <summary>Get Alliance Information</summary>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <returns>JSON Object containing Alliance Name, Date Founded, Executor Corporation, and Ticker</returns>
        public async Task<string> GetInformationAsync(int AllianceID)
        {
            var Path = $"/alliances/{AllianceID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Alliance's Member Corporations</summary>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <returns>JSON Array of Member Corporations</returns>
        public string GetCorporations(int AllianceID)
        {
            return GetCorporationsAsync(AllianceID).Result;
        }

        /// <summary>Get Alliance's Member Corporations</summary>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <returns>JSON Array of Member Corporations</returns>
        public async Task<string> GetCorporationsAsync(int AllianceID)
        {
            var Path = $"/alliances/{AllianceID.ToString()}/corporations/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Alliance Icons</summary>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <returns>JSON Object containing URLs for 64x64 and 128x128 Alliance Icons</returns>
        public string GetIcons(int AllianceID)
        {
            return GetIconsAsync(AllianceID).Result;
        }

        /// <summary>Get Alliance Icons</summary>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <returns>JSON Object containing URLs for 64x64 and 128x128 Alliance Icons</returns>
        public async Task<string> GetIconsAsync(int AllianceID)
        {
            var Path = $"/alliances/{AllianceID.ToString()}/icons/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }
    }

    /// <summary>Public and Authenticated Alliance paths</summary>
    public class AuthAlliance : Alliance
    {
        internal AuthAlliance(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}
