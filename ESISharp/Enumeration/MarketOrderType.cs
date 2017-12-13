namespace ESISharp.Enumeration
{
    public class MarketOrderType : Model.Abstract.FakeEnumerator
    {
        internal MarketOrderType(string value) : base(value) { }

        public static readonly MarketOrderType All = new MarketOrderType("all");
        public static readonly MarketOrderType Buy = new MarketOrderType("buy");
        public static readonly MarketOrderType Sell = new MarketOrderType("sell");
    }
}
