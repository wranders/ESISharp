using ESISharp.Enumerations;
using ESISharp.Web;
using System.Threading.Tasks;

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
        /// <returns>JSON Array of Objects containing Type ID, average price and adjusted price</returns>
        public string GetPrices()
        {
            return GetPricesAsync().Result;
        }

        /// <summary>List Market Prices</summary>
        /// <returns>JSON Array of Objects containing Type ID, average price and adjusted price</returns>
        public async Task<string> GetPricesAsync()
        {
            var Path = "/markets/prices/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get historic market statistics in a Region for the specified Type ID</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Array with Object containing market statistics</returns>
        public string GetRegionMarketHistory(int RegionID, int TypeID)
        {
            return GetRegionMarketHistoryAsync(RegionID, TypeID).Result;
        }

        /// <summary>Get historic market statistics in a Region for the specified Type ID</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Array with Object containing market statistics</returns>
        public async Task<string> GetRegionMarketHistoryAsync(int RegionID, int TypeID)
        {
            var Path = $"/markets/{RegionID.ToString()}/history/";
            var Data = new { type_id = TypeID };
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID)
        {
            return GetRegionOrders(RegionID, null, MarketOrderType.All.Value, 1);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID, int TypeID)
        {
            return GetRegionOrders(RegionID, TypeID, MarketOrderType.All.Value, 1);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(MarketOrderType) Market Order Type</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID, int TypeID, MarketOrderType OrderType)
        {
            return GetRegionOrders(RegionID, TypeID, OrderType.Value, 1);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(String) Market Order Type</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID, int TypeID, string OrderType)
        {
            return GetRegionOrders(RegionID, TypeID, OrderType, 1);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(MarketOrderType) Market Order Type</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID, int TypeID, MarketOrderType OrderType, int Page)
        {
            return GetRegionOrders(RegionID, TypeID, OrderType.Value, Page);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(String) Market Order Type</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID, int? TypeID, string OrderType, int Page)
        {
            return GetRegionOrdersAsync(RegionID, TypeID, OrderType, Page).Result;
        }


        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public async Task<string> GetRegionOrdersAsync(int RegionID)
        {
            return await GetRegionOrdersAsync(RegionID, null, MarketOrderType.All.Value, 1).ConfigureAwait(false);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public async Task<string> GetRegionOrdersAsync(int RegionID, int TypeID)
        {
            return await GetRegionOrdersAsync(RegionID, TypeID, MarketOrderType.All.Value, 1).ConfigureAwait(false);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(MarketOrderType) Market Order Type</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public async Task<string> GetRegionOrdersAsync(int RegionID, int TypeID, MarketOrderType OrderType)
        {
            return await GetRegionOrdersAsync(RegionID, TypeID, OrderType.Value, 1).ConfigureAwait(false);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(String) Market Order Type</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public async Task<string> GetRegionOrdersAsync(int RegionID, int TypeID, string OrderType)
        {
            return await GetRegionOrdersAsync(RegionID, TypeID, OrderType, 1).ConfigureAwait(false);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(MarketOrderType) Market Order Type</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public async Task<string> GetRegionOrdersAsync(int RegionID, int TypeID, MarketOrderType OrderType, int Page)
        {
            return await GetRegionOrdersAsync(RegionID, TypeID, OrderType.Value, Page).ConfigureAwait(false);
        }

        /// <summary>Get orders in a Region (First Page)</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(String) Market Order Type</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public async Task<string> GetRegionOrdersAsync(int RegionID, int? TypeID, string OrderType, int Page)
        {
            var Path = $"/markets/{RegionID.ToString()}/orders/";
            var Data = new
            {
                type_id = TypeID,
                order_type = OrderType,
                page = Page
            };
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync(Data).ConfigureAwait(false);
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
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetStructureOrders(long StructureID)
        {
            return GetStructureOrders(StructureID, 1);
        }

        /// <summary>Get Market Orders posted in a Structure (Specified Page)</summary>
        /// <remarks>Requires SSO Authentication, using "structure_markets" scope</remarks>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetStructureOrders(long StructureID, int Page)
        {
            return GetStructureOrdersAsync(StructureID, Page).Result;
        }

        /// <summary>Get Market Orders posted in a Structure (First Page)</summary>
        /// <remarks>Requires SSO Authentication, using "structure_markets" scope</remarks>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public async Task<string> GetStructureOrdersAsync(long StructureID)
        {
            return await GetStructureOrdersAsync(StructureID, 1).ConfigureAwait(false);
        }

        /// <summary>Get Market Orders posted in a Structure (Specified Page)</summary>
        /// <remarks>Requires SSO Authentication, using "structure_markets" scope</remarks>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public async Task<string> GetStructureOrdersAsync(long StructureID, int Page)
        {
            var Path = $"/markets/structures/{StructureID.ToString()}/";
            var Data = new { page = Page };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync(Data).ConfigureAwait(false);
        }
    }
}