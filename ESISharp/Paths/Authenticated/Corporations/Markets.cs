using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Corporations
{
    public class Markets : ApiPath
    {
        internal Markets(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/corporations/{corporation_id}/orders/", WebMethods.GET)]
        public EsiRequest GetOpenOrders(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "orders" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetOrdersHistory(int corporationid)
            => GetOrdersHistory(corporationid, 1);

        [Path("/corporations/{corporation_id}/orders/history/", WebMethods.GET)]
        public EsiRequest GetOrdersHistory(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "orders", "history" };
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
