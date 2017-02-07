using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.ESIPath
{
    /// <summary>
    /// Public Corporation paths
    /// </summary>
    public class Corporation
    {
        protected EveSwagger SwaggerObject;

        internal Corporation(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Corporation Name
        /// </summary>
        /// <param name="CorpID">(Int64) Corporation ID</param>
        /// <returns>JSON Array with Object containing Corporation ID and Name</returns>
        public string GetNames(long CorpID)
        {
            return GetNames(new List<long>() { CorpID });
        }

        /// <summary>
        /// Get Corporation Names
        /// </summary>
        /// <param name="CorpID">(Int64 List) Corporation ID</param>
        /// <returns>JSON Array with Objects containing Corporation ID and Name</returns>
        public string GetNames(List<long> CorpIDs)
        {
            var Path = "/corporations/names/";
            var Data = new { corporation_ids = CorpIDs.ToArray() };
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get(Data);
        }

        /// <summary>
        /// Get Public Corporation Information
        /// </summary>
        /// <param name="CorpID">(Int32) Corporation ID</param>
        /// <returns>JSON Object containing alliance ID, CEO ID, name, member count, and ticker</returns>
        public string GetInformation(int CorpID)
        {
            var Path = $"/corporations/{CorpID.ToString()}/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Corporation's Alliance History
        /// </summary>
        /// <param name="CorpID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing alliance ID, open status, record ID, and date joined</returns>
        public string GetAllianceHistory(int CorpID)
        {
            var Path = $"/corporations/{CorpID.ToString()}/alliancehistory/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Corporation's Icons
        /// </summary>
        /// <param name="CorpID">(Int32) Corporation ID</param>
        /// <returns>JSON Object containing URLs for 64x64, 128x128, ans 256x256 icons</returns>
        public string GetIcons(int CorpID)
        {
            var Path = $"/corporations/{CorpID.ToString()}/icons/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }
    }

    /// <summary>
    /// Public and Authenticated Corporation paths
    /// </summary>
    public class AuthCorporation : Corporation
    {
        internal AuthCorporation(EveSwagger e) : base(e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Corporation's Members
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_membership" scope</remarks>
        /// <param name="CorpID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing a character ID</returns>
        public string GetMembers(int CorpID)
        {
            var Path = $"/corporations/{CorpID.ToString()}/members/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>
        /// Get Corporation Member's Roles
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_corporation_membership" scope</remarks>
        /// <param name="CorpID">(Int32) Corporation ID</param>
        /// <returns>JSON Array of Objects containing a character ID</returns>
        public string GetMemberRoles(int CorpID)
        {
            var Path = $"/corporations/{CorpID.ToString()}/roles/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}