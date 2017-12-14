using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Markets : ApiPath
    {
        internal Markets(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/markets/prices/", WebMethods.GET)]
        public EsiRequest GetPrices()
        {
            var path = new EsiRequestPath { "markets", "prices" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetRegionOrders(int regionid)
        {
            return GetRegionOrders(regionid, null, MarketOrderType.All, 1);
        }

        public EsiRequest GetRegionOrders(int regionid, MarketOrderType ordertype)
        {
            return GetRegionOrders(regionid, null, ordertype, 1);
        }

        public EsiRequest GetRegionOrders(int regionid, int typeid)
        {
            return GetRegionOrders(regionid, typeid, MarketOrderType.All, 1);
        }

        public EsiRequest GetRegionOrders(int regionid, int typeid, MarketOrderType ordertype)
        {
            return GetRegionOrders(regionid, typeid, ordertype, 1);
        }

        [Path("/markets/{region_id}/orders/", WebMethods.GET)]
        public EsiRequest GetRegionOrders(int regionid, int? typeid, MarketOrderType ordertype, int page)
        {
            var path = new EsiRequestPath { "markets", regionid.ToString(), "orders" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["type_id"] = typeid,
                    ["order_type"] = ordertype.Value,
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/markets/{region_id}/history/", WebMethods.GET)]
        public EsiRequest GetRegionMarketHistory(int regionid, int typeid)
        {
            var path = new EsiRequestPath { "markets", regionid.ToString(), "history" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["type_id"] = typeid
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/markets/groups/", WebMethods.GET)]
        public EsiRequest GetGroups()
        {
            var path = new EsiRequestPath { "markets", "groups" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetGroupInfo(int groupid)
        {
            return GetGroupInfo(groupid, Language.English);
        }

        [Path("/markets/groups/{market_group_id}/", WebMethods.GET)]
        public EsiRequest GetGroupInfo(int groupid, Language language)
        {
            var path = new EsiRequestPath { "markets", "groups", groupid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetTypes(int regionid)
        {
            return GetTypes(regionid, 1);
        }

        [Path("/markets/{region_id}/types/", WebMethods.GET)]
        public EsiRequest GetTypes(int regionid, int page)
        {
            var path = new EsiRequestPath { "markets", regionid.ToString(), "types" };
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
