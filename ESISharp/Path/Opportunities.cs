using ESISharp.Web;

namespace ESISharp.ESIPath
{
    public class Opportunities
    {
        protected ESIEve EasyObject;

        internal Opportunities(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Opportunity Groups</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetGroups()
        {
            var Path = $"/opportunities/groups/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Opportunity Group Information</summary>
        /// <param name="GroupID">(Int32) Group ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetGroupInfo(int GroupID)
        {
            var Path = $"/opportunities/groups/{GroupID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Opportunities Tasks</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTasks()
        {
            var Path = $"/opportunities/tasks/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Opportunity Task Information</summary>
        /// <param name="TaskID">(Int32) Task ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTaskInfo(int TaskID)
        {
            var Path = $"/opportunities/tasks/{TaskID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    public class AuthOpportunities : Opportunities
    {
        internal AuthOpportunities(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = (ESIEve.Authenticated)EasyEve;
        }
    }
}
