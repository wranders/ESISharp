namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Assets
        {
            public static readonly Scope ReadAssets = new Scope("esi-assets.read_assets.v1");
            public static readonly Scope ReadCorporationAssets = new Scope("esi-assets.read_corporation_assets.v1");
        }
    }
}
