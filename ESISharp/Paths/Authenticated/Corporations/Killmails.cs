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
    public class Killmails : ApiPath
    {
        internal Killmails(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest Get(int corporationid)
            => Get(corporationid, -1);

        [Path("/corporations/{corporation_id}/killmails/recent/", WebMethods.GET)]
        public EsiRequest Get(int corporationid, int maxkillid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "killmails", "recent" };
            if (maxkillid > 0)
            {
                var data = new EsiRequestData
                {
                    Query = new Dictionary<string, dynamic>
                    {
                        ["max_kill_id"] = maxkillid
                    }
                };
                return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
            }
            else
            {
                return new EsiRequest(EsiConnection, path, WebMethods.GET);
            }
        }
    }
}
