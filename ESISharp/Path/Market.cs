using ESISharp.Enumerations;
using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>
    /// Public Market paths
    /// </summary>
    public class Market
    {
        protected EveSwagger SwaggerObject;

        internal Market(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// List Market Prices
        /// </summary>
        /// <returns>JSON Array of Objects containing Type ID, average price and adjusted price</returns>
        public string GetPrices()
        {
            var Path = "/markets/prices/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get historic market statistics in a Region for the specified Type ID
        /// </summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Array with Object containing market statistics</returns>
        public string GetRegionMarketHistory(int RegionID, int TypeID)
        {
            var Path = $"/markets/{RegionID.ToString()}/history/";
            var Data = new { type_id = TypeID };
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get(Data);
        }

        /// <summary>
        /// Get orders in a Region (First Page)
        /// </summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID)
        {
            return GetRegionOrders(RegionID, null, MarketOrderType.All.Value, 1);
        }

        /// <summary>
        /// Get orders in a Region (First Page)
        /// </summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID, int TypeID)
        {
            return GetRegionOrders(RegionID, TypeID, MarketOrderType.All.Value, 1);
        }

        /// <summary>
        /// Get orders in a Region (First Page)
        /// </summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(MarketOrderType) Market Order Type</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID, int TypeID, MarketOrderType OrderType)
        {
            return GetRegionOrders(RegionID, TypeID, OrderType.Value, 1);
        }

        /// <summary>
        /// Get orders in a Region (First Page)
        /// </summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(String) Market Order Type</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID, int TypeID, string OrderType)
        {
            return GetRegionOrders(RegionID, TypeID, OrderType, 1);
        }

        /// <summary>
        /// Get orders in a Region (First Page)
        /// </summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(MarketOrderType) Market Order Type</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID, int TypeID, MarketOrderType OrderType, int Page)
        {
            return GetRegionOrders(RegionID, TypeID, OrderType.Value, Page);
        }

        /// <summary>
        /// Get orders in a Region (First Page)
        /// </summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="OrderType">(String) Market Order Type</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetRegionOrders(int RegionID, int? TypeID, string OrderType, int Page)
        {
            var Path = $"/markets/{RegionID.ToString()}/orders/";
            var Data = new
            {
                type_id = TypeID,
                order_type = OrderType,
                page = Page
            };
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get(Data);
        }
    }

    /// <summary>
    /// Public and Authenticated Market paths
    /// </summary>
    public class AuthMarket : Market
    {
        internal AuthMarket(EveSwagger e) : base(e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Market Orders posted in a Structure (First Page)
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "structure_markets" scope</remarks>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetStructureOrders(long StructureID)
        {
            return GetStructureOrders(StructureID, 1);
        }

        /// <summary>
        /// Get Market Orders posted in a Structure (Specified Page)
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "structure_markets" scope</remarks>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <param name="Page">(Int32) Page number</param>
        /// <returns>JSON Array of Objects representing market orders</returns>
        public string GetStructureOrders(long StructureID, int Page)
        {
            var Path = $"/markets/structures/{StructureID.ToString()}/";
            var Data = new { page = Page };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get(Data);
        }
    }
}