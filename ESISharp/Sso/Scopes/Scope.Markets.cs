namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Markets
        {
            public static readonly Scope ReadCharacterOrders = new Scope("esi-markets.read_character_orders.v1");
            public static readonly Scope ReadCorporationOrders = new Scope("esi-markets.read_corporation_orders.v1");
            public static readonly Scope StructureMarkets = new Scope("esi-markets.structure_markets.v1");
        }
    }
}
