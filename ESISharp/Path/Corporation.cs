using ESISharp.Object;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

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
    public class AuthCorporation : Corporation
    {
        internal AuthCorporation(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
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

        /// <summary>Get Corporation Member's Roles</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_membership" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMemberRoles(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/roles/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
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
            var Data = new { page = Page };
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
    }
}