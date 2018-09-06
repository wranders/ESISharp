using ESISharp.Enumeration;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Search : PathTest
    {
#pragma warning disable S1144

        static readonly object[] SubString_One =
        {
            new object[] { "Hasier Parcie", SearchCategory.Agent },
            new object[] { "Goonswarm Federation", SearchCategory.Alliance },
            new object[] { "The Mittani", SearchCategory.Character },
            new object[] { "Kimotoro", SearchCategory.Constellation },
            new object[] { "GoonWaffe", SearchCategory.Corporation },
            new object[] { "Caldari State", SearchCategory.Faction },
            new object[] { "Ion Blaster Cannon II", SearchCategory.InventoryType },
            new object[] { "The Forge", SearchCategory.Region },
            new object[] { "Jita", SearchCategory.SolarSystem },
            new object[] { "Jita IV - Moon 4 - Caldari Navy Assembly Plant", SearchCategory.Station }
        };

        static readonly object[] SubString_Two =
        {
            new object[] { "Hasier Parcie", new SearchCategory[] { SearchCategory.Agent, SearchCategory.InventoryType } },
            new object[] { "Goonswarm Federation", new SearchCategory[] { SearchCategory.Alliance, SearchCategory.InventoryType } },
            new object[] { "The Mittani", new SearchCategory[] { SearchCategory.Character, SearchCategory.InventoryType } },
            new object[] { "Kimotoro", new SearchCategory[] { SearchCategory.Constellation, SearchCategory.InventoryType } },
            new object[] { "GoonWaffe", new SearchCategory[] { SearchCategory.Corporation, SearchCategory.InventoryType } },
            new object[] { "Caldari State", new SearchCategory[] { SearchCategory.Faction, SearchCategory.InventoryType } },
            new object[] { "Ion Blaster Cannon II", new SearchCategory[] { SearchCategory.InventoryType, SearchCategory.Character } },
            new object[] { "The Forge", new SearchCategory[] { SearchCategory.Region, SearchCategory.InventoryType } },
            new object[] { "Jita", new SearchCategory[] { SearchCategory.SolarSystem, SearchCategory.InventoryType } },
            new object[] { "Jita IV - Moon 4 - Caldari Navy Assembly Plant", new SearchCategory[] { SearchCategory.Station, SearchCategory.InventoryType } }
        };

        static readonly object[] SubString_Three =
        {
            new object[] { "Hasier Parcie", SearchCategory.Agent, true },
            new object[] { "Goonswarm Federation", SearchCategory.Alliance, true },
            new object[] { "The Mittani", SearchCategory.Character, true },
            new object[] { "Kimotoro", SearchCategory.Constellation, true },
            new object[] { "GoonWaffe", SearchCategory.Corporation, true },
            new object[] { "Caldari State", SearchCategory.Faction, true },
            new object[] { "Ion Blaster Cannon II", SearchCategory.InventoryType, true },
            new object[] { "The Forge", SearchCategory.Region, true },
            new object[] { "Jita", SearchCategory.SolarSystem, true },
            new object[] { "Jita IV - Moon 4 - Caldari Navy Assembly Plant", SearchCategory.Station, true }
        };

        static readonly object[] SubString_Four =
        {
            new object[] { "Hasier Parcie", new SearchCategory[] { SearchCategory.Agent, SearchCategory.InventoryType }, true },
            new object[] { "Goonswarm Federation", new SearchCategory[] { SearchCategory.Alliance, SearchCategory.InventoryType }, true },
            new object[] { "The Mittani", new SearchCategory[] { SearchCategory.Character, SearchCategory.InventoryType }, true },
            new object[] { "Kimotoro", new SearchCategory[] { SearchCategory.Constellation, SearchCategory.InventoryType }, true },
            new object[] { "GoonWaffe", new SearchCategory[] { SearchCategory.Corporation, SearchCategory.InventoryType }, true },
            new object[] { "Caldari State", new SearchCategory[] { SearchCategory.Faction, SearchCategory.InventoryType }, true },
            new object[] { "Ion Blaster Cannon II", new SearchCategory[] { SearchCategory.InventoryType, SearchCategory.Character }, true },
            new object[] { "The Forge", new SearchCategory[] { SearchCategory.Region, SearchCategory.InventoryType }, true },
            new object[] { "Jita", new SearchCategory[] { SearchCategory.SolarSystem, SearchCategory.InventoryType }, true },
            new object[] { "Jita IV - Moon 4 - Caldari Navy Assembly Plant", new SearchCategory[] { SearchCategory.Station, SearchCategory.InventoryType }, true }
        };

        static readonly object[] SubString_Five =
        {
            new object[] { "Hasier Parcie", SearchCategory.Agent, true, Language.Chinese },
            new object[] { "Goonswarm Federation", SearchCategory.Alliance, true, Language.French },
            new object[] { "The Mittani", SearchCategory.Character, true, Language.German },
            new object[] { "Kimotoro", SearchCategory.Constellation, true, Language.Japanese },
            new object[] { "GoonWaffe", SearchCategory.Corporation, true, Language.Russian },
            new object[] { "Caldari State", SearchCategory.Faction, true, Language.Chinese },
            new object[] { "Ion Blaster Cannon II", SearchCategory.InventoryType, true, Language.French },
            new object[] { "The Forge", SearchCategory.Region, true, Language.German },
            new object[] { "Jita", SearchCategory.SolarSystem, true, Language.Japanese },
            new object[] { "Jita IV - Moon 4 - Caldari Navy Assembly Plant", SearchCategory.Station, true, Language.Russian }
        };

        static readonly object[] SubString_Six =
        {
            new object[] { "Hasier Parcie", new SearchCategory[] { SearchCategory.Agent, SearchCategory.InventoryType }, true, Language.Chinese },
            new object[] { "Goonswarm Federation", new SearchCategory[] { SearchCategory.Alliance, SearchCategory.InventoryType }, true, Language.French },
            new object[] { "The Mittani", new SearchCategory[] { SearchCategory.Character, SearchCategory.InventoryType }, true, Language.German },
            new object[] { "Kimotoro", new SearchCategory[] { SearchCategory.Constellation, SearchCategory.InventoryType }, true, Language.Japanese },
            new object[] { "GoonWaffe", new SearchCategory[] { SearchCategory.Corporation, SearchCategory.InventoryType }, true, Language.Russian },
            new object[] { "Caldari State", new SearchCategory[] { SearchCategory.Faction, SearchCategory.InventoryType }, true, Language.Chinese },
            new object[] { "Ion Blaster Cannon II", new SearchCategory[] { SearchCategory.InventoryType, SearchCategory.Character }, true, Language.French },
            new object[] { "The Forge", new SearchCategory[] { SearchCategory.Region, SearchCategory.InventoryType }, true, Language.German },
            new object[] { "Jita", new SearchCategory[] { SearchCategory.SolarSystem, SearchCategory.InventoryType }, true, Language.Japanese },
            new object[] { "Jita IV - Moon 4 - Caldari Navy Assembly Plant", new SearchCategory[] { SearchCategory.Station, SearchCategory.InventoryType }, true, Language.Russian }
        };

#pragma warning restore

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_One")]
        public void SubString(string searchquery, SearchCategory category)
        {
            var r = Public.Search.SubString(searchquery, category).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Two")]
        public void SubString(string searchquery, IEnumerable<SearchCategory> categories)
        {
            var r = Public.Search.SubString(searchquery, categories).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Three")]
        public void SubString(string searchquery, SearchCategory category, bool strict)
        {
            var r = Public.Search.SubString(searchquery, category, strict).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Four")]
        public void SubString(string searchquery, IEnumerable<SearchCategory> categories, bool strict)
        {
            var r = Public.Search.SubString(searchquery, categories, strict).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Five")]
        public void SubString(string searchquery, SearchCategory category, bool strict, Language language)
        {
            var r = Public.Search.SubString(searchquery, category, strict, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Six")]
        public void SubString(string searchquery, IEnumerable<SearchCategory> categories, bool strict, Language language)
        {
            var r = Public.Search.SubString(searchquery, categories, strict, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
