using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation
{
    /// <summary>Authenticated Corporation Industry paths</summary>
    public class CorporationIndustry
    {
        protected ESIEve EasyObject;

        internal CorporationIndustry(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Blueprints, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_blueprints" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetBlueprints(int CorporationID)
        {
            return GetBlueprints(CorporationID, 1);
        }

        /// <summary>Get Corporation's Blueprints, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_blueprints" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetBlueprints(int CorporationID, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/blueprints/";
            var Data = new
            {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Corporation's Industry Jobs, Excluding Completed, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_jobs" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetJobs(int CorporationID)
        {
            return GetJobs(CorporationID, false, 1);
        }

        /// <summary>Get Corporation's Industry Jobs, First Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_jobs" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="IncludeCompleted">(Boolean) Include Completed Jobs</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetJobs(int CorporationID, bool IncludeCompleted)
        {
            return GetJobs(CorporationID, IncludeCompleted, 1);
        }

        /// <summary>Get Corporation's Industry Jobs, Specified Page</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_jobs" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="IncludeCompleted">(Boolean) Include Completed Jobs</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetJobs(int CorporationID, bool IncludeCompleted, int Page)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/industry/jobs/";
            var Data = new
            {
                include_completed = IncludeCompleted,
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
