using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Opportunities : ApiPath
    {
        internal Opportunities(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/opportunities/groups/", WebMethods.GET)]
        public EsiRequest GetGroups()
        {
            var path = new EsiRequestPath { "opportunities", "groups" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetGroupInfo(int groupid)
            => GetGroupInfo(groupid, Language.English);

        [Path("/opportunities/groups/{group_id}/", WebMethods.GET)]
        public EsiRequest GetGroupInfo(int groupid, Language language)
        {
            var path = new EsiRequestPath { "opportunities", "groups", groupid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/opportunities/tasks/", WebMethods.GET)]
        public EsiRequest GetTasks()
        {
            var path = new EsiRequestPath { "opportunities", "tasks" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/opportunities/tasks/{task_id}/", WebMethods.GET)]
        public EsiRequest GetTaskInfo(int taskid)
        {
            var path = new EsiRequestPath { "opportunities", "tasks", taskid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
