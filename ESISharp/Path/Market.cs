using ESISharp.Enumerations;
using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Public Market paths</summary>
    public class Market
    {
        protected ESIEve EasyObject;

        internal Market(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>List Market Prices</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPrices()
        {
            var Path = "/markets/prices/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get historic market statistics in a Region for the specified Type ID</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRegionMarketHistory(int RegionID, int TypeID)
        {
            var Path = $"/markets/{RegionID.ToString()}/history/";
            var Data = new { type_id = TypeID };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRegionOrders(int RegionID)
        {
            return GetRegionOrders(RegionID, null, MarketOrderType.All.Value, 1);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRegionOrders(int RegionID, int TypeID)
        {
            return GetRegionOrders(RegionID, TypeID, MarketOrderType.All.Value, 1);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(MarketOrderType) Market Order Type</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRegionOrders(int RegionID, int TypeID, MarketOrderType OrderType)
        {
            return GetRegionOrders(RegionID, TypeID, OrderType.Value, 1);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(String) Market Order Type</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRegionOrders(int RegionID, int TypeID, string OrderType)
        {
            return GetRegionOrders(RegionID, TypeID, OrderType, 1);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(MarketOrderType) Market Order Type</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRegionOrders(int RegionID, int TypeID, MarketOrderType OrderType, int Page)
        {
            return GetRegionOrders(RegionID, TypeID, OrderType.Value, Page);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(String) Market Order Type</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRegionOrders(int RegionID, int? TypeID, string OrderType, int Page)
        {
            var Path = $"/markets/{RegionID.ToString()}/orders/";
            var Data = new
            {
                type_id = TypeID,
                order_type = OrderType,
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }

        /// <summary>Get Market Groups</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMarketGroups()
        {
            var Path = "/markets/groups/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Market Group Information</summary>
        /// <param name="GroupID">(Int32) Market Group ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMarketGroupInfo(int GroupID)
        {
            var Path = $"/markets/groups/{GroupID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Public and Authenticated Market paths</summary>
    public class AuthMarket : Market
    {
        internal AuthMarket(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Market Orders posted in a Structure (First Page)</summary>
        /// <remarks>Requires SSO Authentication, using "structure_markets" scope</remarks>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStructureOrders(long StructureID)
        {
            return GetStructureOrders(StructureID, 1);
        }

        /// <summary>Get Market Orders posted in a Structure (Specified Page)</summary>
        /// <remarks>Requires SSO Authentication, using "structure_markets" scope</remarks>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStructureOrders(long StructureID, int Page)
        {
            var Path = $"/markets/structures/{StructureID.ToString()}/";
            var Data = new { page = Page };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}