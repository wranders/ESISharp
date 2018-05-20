using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Paths.Authenticated.Corporations
{
    public class Industry : ApiPath
    {
        internal Industry(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetMoonExtractionTimers(int corporationid)
            => GetMoonExtractionTimers(corporationid, 1);

        [Path("/corporation/{corporation_id}/mining/extractions/", WebMethods.GET)]
        public EsiRequest GetMoonExtractionTimers(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporation", corporationid.ToString(), "mining", "extractions" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetMiningObservers(int corporationid)
            => GetMiningObservers(corporationid, 1);

        [Path("/corporation/{corporation_id}/mining/observers/", WebMethods.GET)]
        public EsiRequest GetMiningObservers(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporation", corporationid.ToString(), "mining", "observers" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetMiningObserversRecord(int corporationid, int observerid)
            => GetMiningObserversRecord(corporationid, observerid, 1);

        [Path("/corporation/{corporation_id}/mining/observers/{observer_id}/", WebMethods.GET)]
        public EsiRequest GetMiningObserversRecord(int corporationid, int observerid, int page)
        {
            var path = new EsiRequestPath { "corporation", corporationid.ToString(), "mining", "observers", observerid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetJobs(int characterid)
            => GetJobs(characterid, false);

        [Path("/corporations/{corporation_id}/industry/jobs/", WebMethods.GET)]
        public EsiRequest GetJobs(int corporationid, bool includecompleted)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "industry", "jobs" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["include_completed"] = includecompleted
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
