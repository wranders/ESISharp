namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Bookmarks
        {
            public static readonly Scope ReadCharacterBookmarks = new Scope("esi-bookmarks.read_character_bookmarks.v1");
            public static readonly Scope ReadCorporationBookmarks = new Scope("esi-bookmarks.read_corporation_bookmarks.v1");
        }
    }
}
