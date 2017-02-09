namespace ESISharp.Enumerations
{
    /// <summary>Search Categories</summary>
    public class SearchCategory
    {
        /// <summary>All Categories</summary>
        public static readonly SearchCategory All = new SearchCategory("agent,alliance,character,constellation,corporation,faction,inventorytype,region,solarsystem,station,wormhole");
        /// <summary>Agents</summary>
        public static readonly SearchCategory Agent = new SearchCategory("agent");
        /// <summary>Alliances</summary>
        public static readonly SearchCategory Alliance = new SearchCategory("alliance");
        /// <summary>Characters</summary>
        public static readonly SearchCategory Character = new SearchCategory("character");
        /// <summary>Constellations</summary>
        public static readonly SearchCategory Constellation = new SearchCategory("constellation");
        /// <summary>Corporations</summary>
        public static readonly SearchCategory Corporation = new SearchCategory("corporation");
        /// <summary>Factions</summary>
        public static readonly SearchCategory Faction = new SearchCategory("faction");
        /// <summary>Inventory Types</summary>
        public static readonly SearchCategory InventoryType = new SearchCategory("inventorytype");
        /// <summary>Regions</summary>
        public static readonly SearchCategory Region = new SearchCategory("region");
        /// <summary>Solar Systems</summary>
        public static readonly SearchCategory SolarSystem = new SearchCategory("solarsystem");
        /// <summary>Stations</summary>
        public static readonly SearchCategory Station = new SearchCategory("station");
        /// <summary>Wormholes</summary>
        public static readonly SearchCategory Wormhole = new SearchCategory("wormhole");

        internal SearchCategory(string val)
        {
            Value = val;
        }

        /// <summary>Category</summary>
        public string Value { get; }
    }
}
