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

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Killmails : ApiPath
    {
        internal Killmails(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest Get(int characterid)
            => Get(characterid, 50, -1);

        public EsiRequest Get(int characterid, int maxcount)
            => Get(characterid, maxcount, -1);

        [Path("/characters/{character_id}/killmails/recent/", WebMethods.GET)]
        public EsiRequest Get(int characterid, int maxcount, int maxkillid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "killmails", "recent" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["max_count"] = maxcount
                }
            };
            if (maxkillid > 0)
                data.Query["max_kill_id"] = maxkillid;
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
