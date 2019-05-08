using ESISharp.Enumeration;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated
{
    public class Search : PathTest
    {
#pragma warning disable S1144

        static readonly object[] SubString_One =
        {
            new object[] { 91105772, "Hasier Parcie", SearchCategory.Agent },
            new object[] { 91105772, "Goonswarm Federation", SearchCategory.Alliance },
            new object[] { 91105772, "The Mittani", SearchCategory.Character },
            new object[] { 91105772, "Kimotoro", SearchCategory.Constellation },
            new object[] { 91105772, "GoonWaffe", SearchCategory.Corporation },
            new object[] { 91105772, "Caldari State", SearchCategory.Faction },
            new object[] { 91105772, "Ion Blaster Cannon II", SearchCategory.InventoryType },
            new object[] { 91105772, "The Forge", SearchCategory.Region },
            new object[] { 91105772, "Jita", SearchCategory.SolarSystem },
            new object[] { 91105772, "Jita IV - Moon 4 - Caldari Navy Assembly Plant", SearchCategory.Station }
        };

        static readonly object[] SubString_Two =
        {
            new object[] { 91105772, "Hasier Parcie", new SearchCategory[] { SearchCategory.Agent, SearchCategory.InventoryType } },
            new object[] { 91105772, "Goonswarm Federation", new SearchCategory[] { SearchCategory.Alliance, SearchCategory.InventoryType } },
            new object[] { 91105772, "The Mittani", new SearchCategory[] { SearchCategory.Character, SearchCategory.InventoryType } },
            new object[] { 91105772, "Kimotoro", new SearchCategory[] { SearchCategory.Constellation, SearchCategory.InventoryType } },
            new object[] { 91105772, "GoonWaffe", new SearchCategory[] { SearchCategory.Corporation, SearchCategory.InventoryType } },
            new object[] { 91105772, "Caldari State", new SearchCategory[] { SearchCategory.Faction, SearchCategory.InventoryType } },
            new object[] { 91105772, "Ion Blaster Cannon II", new SearchCategory[] { SearchCategory.InventoryType, SearchCategory.Character } },
            new object[] { 91105772, "The Forge", new SearchCategory[] { SearchCategory.Region, SearchCategory.InventoryType } },
            new object[] { 91105772, "Jita", new SearchCategory[] { SearchCategory.SolarSystem, SearchCategory.InventoryType } },
            new object[] { 91105772, "Jita IV - Moon 4 - Caldari Navy Assembly Plant", new SearchCategory[] { SearchCategory.Station, SearchCategory.InventoryType } }
        };

        static readonly object[] SubString_Three =
        {
            new object[] { 91105772, "Hasier Parcie", SearchCategory.Agent, true },
            new object[] { 91105772, "Goonswarm Federation", SearchCategory.Alliance, true },
            new object[] { 91105772, "The Mittani", SearchCategory.Character, true },
            new object[] { 91105772, "Kimotoro", SearchCategory.Constellation, true },
            new object[] { 91105772, "GoonWaffe", SearchCategory.Corporation, true },
            new object[] { 91105772, "Caldari State", SearchCategory.Faction, true },
            new object[] { 91105772, "Ion Blaster Cannon II", SearchCategory.InventoryType, true },
            new object[] { 91105772, "The Forge", SearchCategory.Region, true },
            new object[] { 91105772, "Jita", SearchCategory.SolarSystem, true },
            new object[] { 91105772, "Jita IV - Moon 4 - Caldari Navy Assembly Plant", SearchCategory.Station, true }
        };

        static readonly object[] SubString_Four =
        {
            new object[] { 91105772, "Hasier Parcie", new SearchCategory[] { SearchCategory.Agent, SearchCategory.InventoryType }, true },
            new object[] { 91105772, "Goonswarm Federation", new SearchCategory[] { SearchCategory.Alliance, SearchCategory.InventoryType }, true },
            new object[] { 91105772, "The Mittani", new SearchCategory[] { SearchCategory.Character, SearchCategory.InventoryType }, true },
            new object[] { 91105772, "Kimotoro", new SearchCategory[] { SearchCategory.Constellation, SearchCategory.InventoryType }, true },
            new object[] { 91105772, "GoonWaffe", new SearchCategory[] { SearchCategory.Corporation, SearchCategory.InventoryType }, true },
            new object[] { 91105772, "Caldari State", new SearchCategory[] { SearchCategory.Faction, SearchCategory.InventoryType }, true },
            new object[] { 91105772, "Ion Blaster Cannon II", new SearchCategory[] { SearchCategory.InventoryType, SearchCategory.Character }, true },
            new object[] { 91105772, "The Forge", new SearchCategory[] { SearchCategory.Region, SearchCategory.InventoryType }, true },
            new object[] { 91105772, "Jita", new SearchCategory[] { SearchCategory.SolarSystem, SearchCategory.InventoryType }, true },
            new object[] { 91105772, "Jita IV - Moon 4 - Caldari Navy Assembly Plant", new SearchCategory[] { SearchCategory.Station, SearchCategory.InventoryType }, true }
        };

        static readonly object[] SubString_Five =
        {
            new object[] { 91105772, "Hasier Parcie", SearchCategory.Agent, true, Language.Chinese },
            new object[] { 91105772, "Goonswarm Federation", SearchCategory.Alliance, true, Language.French },
            new object[] { 91105772, "The Mittani", SearchCategory.Character, true, Language.German },
            new object[] { 91105772, "Kimotoro", SearchCategory.Constellation, true, Language.Japanese },
            new object[] { 91105772, "GoonWaffe", SearchCategory.Corporation, true, Language.Russian },
            new object[] { 91105772, "Caldari State", SearchCategory.Faction, true, Language.Chinese },
            new object[] { 91105772, "Ion Blaster Cannon II", SearchCategory.InventoryType, true, Language.French },
            new object[] { 91105772, "The Forge", SearchCategory.Region, true, Language.German },
            new object[] { 91105772, "Jita", SearchCategory.SolarSystem, true, Language.Japanese },
            new object[] { 91105772, "Jita IV - Moon 4 - Caldari Navy Assembly Plant", SearchCategory.Station, true, Language.Russian }
        };

        static readonly object[] SubString_Six =
        {
            new object[] { 91105772, "Hasier Parcie", new SearchCategory[] { SearchCategory.Agent, SearchCategory.InventoryType }, true, Language.Chinese },
            new object[] { 91105772, "Goonswarm Federation", new SearchCategory[] { SearchCategory.Alliance, SearchCategory.InventoryType }, true, Language.French },
            new object[] { 91105772, "The Mittani", new SearchCategory[] { SearchCategory.Character, SearchCategory.InventoryType }, true, Language.German },
            new object[] { 91105772, "Kimotoro", new SearchCategory[] { SearchCategory.Constellation, SearchCategory.InventoryType }, true, Language.Japanese },
            new object[] { 91105772, "GoonWaffe", new SearchCategory[] { SearchCategory.Corporation, SearchCategory.InventoryType }, true, Language.Russian },
            new object[] { 91105772, "Caldari State", new SearchCategory[] { SearchCategory.Faction, SearchCategory.InventoryType }, true, Language.Chinese },
            new object[] { 91105772, "Ion Blaster Cannon II", new SearchCategory[] { SearchCategory.InventoryType, SearchCategory.Character }, true, Language.French },
            new object[] { 91105772, "The Forge", new SearchCategory[] { SearchCategory.Region, SearchCategory.InventoryType }, true, Language.German },
            new object[] { 91105772, "Jita", new SearchCategory[] { SearchCategory.SolarSystem, SearchCategory.InventoryType }, true, Language.Japanese },
            new object[] { 91105772, "Jita IV - Moon 4 - Caldari Navy Assembly Plant", new SearchCategory[] { SearchCategory.Station, SearchCategory.InventoryType }, true, Language.Russian }
        };

#pragma warning restore

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_One")]
        public void SubString(int characterid, string searchquery, SearchCategory category)
        {
            var r = Authenticated.Search.SubString(characterid, searchquery, category).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Two")]
        public void SubString(int characterid, string searchquery, IEnumerable<SearchCategory> categories)
        {
            var r = Authenticated.Search.SubString(characterid, searchquery, categories).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Three")]
        public void SubString(int characterid, string searchquery, SearchCategory category, bool strict)
        {
            var r = Authenticated.Search.SubString(characterid, searchquery, category, strict).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Four")]
        public void SubString(int characterid, string searchquery, IEnumerable<SearchCategory> categories, bool strict)
        {
            var r = Authenticated.Search.SubString(characterid, searchquery, categories, strict).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Five")]
        public void SubString(int characterid, string searchquery, SearchCategory category, bool strict, Language language)
        {
            var r = Authenticated.Search.SubString(characterid, searchquery, category, language, strict).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Six")]
        public void SubString(int characterid, string searchquery, IEnumerable<SearchCategory> categories, bool strict, Language language)
        {
            var r = Authenticated.Search.SubString(characterid, searchquery, categories, language, strict).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
