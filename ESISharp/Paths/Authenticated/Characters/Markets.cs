using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Markets : ApiPath
    {
        internal Markets(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/orders/", WebMethods.GET)]
        public EsiRequest GetOpenOrders(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "orders" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetOrdersHistory(int characterid)
            => GetOrdersHistory(characterid, 1);

        [Path("/characters/{character_id}/orders/history/", WebMethods.GET)]
        public EsiRequest GetOrdersHistory(int characterid, int page)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "orders", "history" };
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
