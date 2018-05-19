using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Wars : ApiPath
    {
        internal Wars(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest Get()
            => Get(-1);

        [Path("/wars/", WebMethods.GET)]
        public EsiRequest Get(int maxwarid)
        {
            var path = new EsiRequestPath { "wars" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>()
            };
            if (maxwarid > -1)
                data.Query.Add("max_war_id", maxwarid);
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/wars/{war_id}/", WebMethods.GET)]
        public EsiRequest GetInfo(int warid)
        {
            var path = new EsiRequestPath { "wars", warid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetKillmails(int warid)
            => GetKillmails(warid, 1);

        [Path("/wars/{war_id}/killmails/", WebMethods.GET)]
        public EsiRequest GetKillmails(int warid, int page)
        {
            var path = new EsiRequestPath { "wars", warid.ToString(), "killmails" };
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
