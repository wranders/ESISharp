using ESISharp.ESIPath.Corporation;
using ESISharp.Object;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.ESIPath
{
    /// <summary>Public Corporation paths</summary>
    public class CorporationMain
    {
        protected ESIEve EasyObject;

        internal CorporationMain(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation Name</summary>
        /// <param name="CorporationID">(Int64) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetNames(long CorporationID)
        {
            return GetNames(new long[] { CorporationID });
        }

        /// <summary>Get Corporation Names</summary>
        /// <param name="CorporationID">(Int64 List) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetNames(IEnumerable<long> CorporationIDs)
        {
            var Path = "/corporations/names/";
            var Data = new { corporation_ids = CorporationIDs.ToArray() };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }

        /// <summary>Get NPC Corporation IDs</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetNPCCorps()
        {
            var Path = "/corporations/npccorps/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Public Corporation Information</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetInformation(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Corporation's Alliance History</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAllianceHistory(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/alliancehistory/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Corporation's Icons</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetIcons(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/icons/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Public and Authenticated Corporation paths</summary>
    public class AuthCorporationMain : CorporationMain
    {
        /// <summary>Assets paths</summary>
        public CorporationAssets Assets;
        /// <summary>Bookmark paths</summary>
        public CorporationBookmarks Bookmarks;
        /// <summary>Contacts paths</summary>
        public CorporationContacts Contacts;
        /// <summary>Contracts paths</summary>
        public CorporationContracts Contracts;
        /// <summary>Industry paths</summary>
        public CorporationIndustry Industry;

        internal AuthCorporationMain(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = (ESIEve.Authenticated)EasyEve;

            Assets = new CorporationAssets(EasyObject);
            Bookmarks = new CorporationBookmarks(EasyObject);
            Contacts = new CorporationContacts(EasyObject);
            Contracts = new CorporationContracts(EasyObject);
            Industry = new CorporationIndustry(EasyObject);
        }

        /// <summary>Get Corporation's Container Logs, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_container_logs" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetContainerLogs(int CorporationID)
        {
            return GetContainerLogs(CorporationID, 1);
        }

        /// <summary>Get Corporation's Container Logs, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_container_logs" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetContainerLogs(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/containers/logs/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Corporation Hanger and Wallet Divisions</summary>
        /// <remarks>Requires SSO Authentication, uses "read_divisions" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetDivisions(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/divisions/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Corporation's Members</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_membership" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMembers(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/members/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Corporation's Member Limit, exluding CEO</summary>
        /// <param name="CorporationID"></param>
        /// <returns></returns>
        public EsiRequest GetMembersLimit(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/members/limit/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Corporation's Member Status, including Character ID, Location, Last Logoff and Logon, Current Ship Type, and Start Date.</summary>
        /// <remarks>Requires SSO Authentication, uses "track_members" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMemberStatus(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/membertracking/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Corporation Member's Roles</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_membership" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMemberRoles(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/roles/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Corporation's Shareholders, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_wallets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetShareholders(int CorporationID)
        {
            return GetShareholders(CorporationID, 1);
        }

        /// <summary>Get Corporation's Shareholders, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_wallets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetShareholders(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/shareholders/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Corporation's Standings, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_standings" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStandings(int CorporationID)
        {
            return GetStandings(CorporationID, 1);
        }

        /// <summary>Get Corporation's Standings, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_standings" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStandings(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/standings/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Corporation Stuctures (First Page)</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStructures(int CorporationID)
        {
            return GetStructures(CorporationID, 1);
        }

        /// <summary>Get Corporation Stuctures</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStructures(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/structures/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Update a Structure's Vulnerability windows</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <param name="Periods">(StructureVulnerabilityPeriod List) Vulnerability Periods</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest UpdateStructureVulnerabilitySchedule(int CorporationID, long StructureID, IEnumerable<StructureVulnerabilityPeriod> Periods)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/structures/{StructureID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPut, Periods);
        }

        /// <summary>Get Corporation's Titles</summary>
        /// <remarks>Requires SSO Authentication, uses "read_titles" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTitles(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/titles/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}