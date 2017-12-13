namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Location
        {
            public static readonly Scope ReadLocation = new Scope("esi-location.read_location.v1");
            public static readonly Scope ReadOnline = new Scope("esi-location.read_online.v1");
            public static readonly Scope ReadShipType = new Scope("esi-location.read_ship_type.v1");
        }
    }
}
