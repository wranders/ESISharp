using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Industry : ApiPath
    {
        internal Industry(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetJobs(int characterid)
            => GetJobs(characterid, false);

        [Path("/characters/{character_id}/industry/jobs/", WebMethods.GET)]
        public EsiRequest GetJobs(int characterid, bool includecompleted)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "industry", "jobs" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["include_completed"] = includecompleted
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetMiningLedger(int characterid)
            => GetMiningLedger(characterid, 1);

        [Path("/characters/{character_id}/mining/", WebMethods.GET)]
        public EsiRequest GetMiningLedger(int characterid, int page)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "mining" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
