using ESISharp.Object;
using ESISharp.Web;
using System.Collections.Generic;

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
        /// <param name="CorpID">(Int64) Corporation ID</param>
        /// <returns>JSON Array with Object containing Corporation ID and Name</returns>
        public string GetNames(long CorpID)
        {
            return GetNames(new List<long>() { CorpID });
        }

        /// <summary>Get Corporation Names</summary>
        /// <param name="CorpID">(Int64 List) Corporation ID</param>
        /// <returns>JSON Array with Objects containing Corporation ID and Name</returns>
        public string GetNames(List<long> CorpIDs)
        {
            var Path = "/corporations/names/";
            var Data = new { corporation_ids = CorpIDs.ToArray() };
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get(Data);
        }

        /// <summary>Get Public Corporation Information</summary>
        /// <param name="CorpID">(Int32) Corporation ID</param>
        /// <returns>JSON Object Corporation public information</returns>
        public string GetInformation(int CorpID)
        {
            var Path = $"/corporations/{CorpID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>Get Corporation's Alliance History</summary>
        /// <param name="CorpID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing alliance ID, open status, record ID, and date joined</returns>
        public string GetAllianceHistory(int CorpID)
        {
            var Path = $"/corporations/{CorpID.ToString()}/alliancehistory/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>Get Corporation's Icons</summary>
        /// <param name="CorpID">(Int32) Corporation ID</param>
        /// <returns>JSON Object containing URLs for 64x64, 128x128, ans 256x256 icons</returns>
        public string GetIcons(int CorpID)
        {
            var Path = $"/corporations/{CorpID.ToString()}/icons/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get();
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
        /// <param name="CorpID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing a character ID</returns>
        public string GetMembers(int CorpID)
        {
            var Path = $"/corporations/{CorpID.ToString()}/members/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>Get Corporation Member's Roles</summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_membership" scope</remarks>
        /// <param name="CorpID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing a character ID</returns>
        public string GetMemberRoles(int CorpID)
        {
            var Path = $"/corporations/{CorpID.ToString()}/roles/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return EsiAuthRequest.Get();
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
            var Path = $"/corporations/{CorporationID}/structures/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            var Data = new { page = Page };
            return EsiAuthRequest.Get(Data);
        }

        /// <summary>Update a Structure's Vulnerability windows</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <param name="Periods">(StructureVulnerabilityPeriod List) Vulnerability Periods</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string UpdateStructureVulnerabilitySchedule(int CorporationID, long StructureID, List<StructureVulnerabilityPeriod> Periods)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/structures/{StructureID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return EsiAuthRequest.Put(Periods);
        }
    }
}