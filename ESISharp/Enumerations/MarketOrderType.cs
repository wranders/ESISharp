namespace ESISharp.Enumerations
{
    /// <summary>Market Order Types</summary>
    public class MarketOrderType
    {
        /// <summary>All Orders</summary>
        public static readonly MarketOrderType All = new MarketOrderType("all");
        /// <summary>Buy Orders</summary>
        public static readonly MarketOrderType Buy = new MarketOrderType("buy");
        /// <summary>Sell Orders</summary>
        public static readonly MarketOrderType Sell = new MarketOrderType("sell");

        internal MarketOrderType(string val)
        {
            Value = val;
        }

        /// <summary>Order Type</summary>
        public string Value { get; }
    }
}
