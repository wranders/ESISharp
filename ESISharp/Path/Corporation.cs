using ESISharp.Object;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESISharp.ESIPath
{
    /// <summary>Public Corporation paths</summary>
    public class Corporation
    {
        protected ESIEve EasyObject;

        internal Corporation(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation Name</summary>
        /// <param name="CorporationID">(Int64) Corporation ID</param>
        /// <returns>JSON Array with Object containing Corporation ID and Name</returns>
        public string GetNames(long CorporationID)
        {
            return GetNames(new List<long>() { CorporationID });
        }

        /// <summary>Get Corporation Names</summary>
        /// <param name="CorporationID">(Int64 List) Corporation ID</param>
        /// <returns>JSON Array with Objects containing Corporation ID and Name</returns>
        public string GetNames(IEnumerable<long> CorporationIDs)
        {
            return GetNamesAsync(CorporationIDs).Result;
        }

        /// <summary>Get Corporation Name</summary>
        /// <param name="CorporationID">(Int64) Corporation ID</param>
        /// <returns>JSON Array with Object containing Corporation ID and Name</returns>
        public async Task<string> GetNamesAsync(long CorporationID)
        {
            return await GetNamesAsync(new List<long>() { CorporationID }).ConfigureAwait(false);
        }

        /// <summary>Get Corporation Names</summary>
        /// <param name="CorporationID">(Int64 List) Corporation ID</param>
        /// <returns>JSON Array with Objects containing Corporation ID and Name</returns>
        public async Task<string> GetNamesAsync(IEnumerable<long> CorporationIDs)
        {
            var Path = "/corporations/names/";
            var Data = new { corporation_ids = CorporationIDs.ToArray() };
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Get Public Corporation Information</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Object Corporation public information</returns>
        public string GetInformation(int CorporationID)
        {
            return GetInformationAsync(CorporationID).Result;
        }

        /// <summary>Get Public Corporation Information</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Object Corporation public information</returns>
        public async Task<string> GetInformationAsync(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Corporation's Alliance History</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing alliance ID, open status, record ID, and date joined</returns>
        public string GetAllianceHistory(int CorporationID)
        {
            return GetAllianceHistoryAsync(CorporationID).Result;
        }

        /// <summary>Get Corporation's Alliance History</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing alliance ID, open status, record ID, and date joined</returns>
        public async Task<string> GetAllianceHistoryAsync(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/alliancehistory/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Corporation's Icons</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Object containing URLs for 64x64, 128x128, ans 256x256 icons</returns>
        public string GetIcons(int CorporationID)
        {
            return GetIconsAsync(CorporationID).Result;
        }

        /// <summary>Get Corporation's Icons</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Object containing URLs for 64x64, 128x128, ans 256x256 icons</returns>
        public async Task<string> GetIconsAsync(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/icons/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }
    }

    /// <summary>Public and Authenticated Corporation paths</summary>
    public class AuthCorporation : Corporation
    {
        internal AuthCorporation(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Members</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_membership" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing a character ID</returns>
        public string GetMembers(int CorporationID)
        {
            return GetMembersAsync(CorporationID).Result;
        }

        /// <summary>Get Corporation's Members</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_membership" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing a character ID</returns>
        public async Task<string> GetMembersAsync(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/members/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Corporation Member's Roles</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_membership" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing a character ID</returns>
        public string GetMemberRoles(int CorporationID)
        {
            return GetMemberRolesAsync(CorporationID).Result;
        }

        /// <summary>Get Corporation Member's Roles</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_membership" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing a character ID</returns>
        public async Task<string> GetMemberRolesAsync(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/roles/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Corporation Stuctures (First Page)</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of objects representing stuctures and their information</returns>
        public string GetStructures(int CorporationID)
        {
            return GetStructures(CorporationID, 1);
        }

        /// <summary>Get Corporation Stuctures</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>JSON Array of objects representing stuctures and their information</returns>
        public string GetStructures(int CorporationID, int Page)
        {
            return GetStructuresAsync(CorporationID, Page).Result;
        }

        /// <summary>Get Corporation Stuctures (First Page)</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of objects representing stuctures and their information</returns>
        public async Task<string> GetStructuresAsync(int CorporationID)
        {
            return await GetStructuresAsync(CorporationID, 1).ConfigureAwait(false);
        }

        /// <summary>Get Corporation Stuctures</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>JSON Array of objects representing stuctures and their information</returns>
        public async Task<string> GetStructuresAsync(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID}/structures/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            var Data = new { page = Page };
            return await EsiAuthRequest.GetAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Update a Structure's Vulnerability windows</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <param name="Periods">(StructureVulnerabilityPeriod List) Vulnerability Periods</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string UpdateStructureVulnerabilitySchedule(int CorporationID, long StructureID, IEnumerable<StructureVulnerabilityPeriod> Periods)
        {
            return UpdateStructureVulnerabilityScheduleAsync(CorporationID, StructureID, Periods).Result;
        }

        /// <summary>Update a Structure's Vulnerability windows</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <param name="Periods">(StructureVulnerabilityPeriod List) Vulnerability Periods</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public async Task<string> UpdateStructureVulnerabilityScheduleAsync(int CorporationID, long StructureID, IEnumerable<StructureVulnerabilityPeriod> Periods)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/structures/{StructureID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PutAsync(Periods).ConfigureAwait(false);
        }
    }
}