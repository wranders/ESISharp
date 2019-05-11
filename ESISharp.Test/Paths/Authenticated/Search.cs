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
            new object[] { 91105772, "Hasier Parcie", SearchCategory.Agent, Language.Chinese },
            new object[] { 91105772, "Goonswarm Federation", SearchCategory.Alliance, Language.French },
            new object[] { 91105772, "The Mittani", SearchCategory.Character, Language.German },
            new object[] { 91105772, "Kimotoro", SearchCategory.Constellation, Language.Japanese },
            new object[] { 91105772, "GoonWaffe", SearchCategory.Corporation, Language.Russian },
            new object[] { 91105772, "Caldari State", SearchCategory.Faction, Language.Chinese },
            new object[] { 91105772, "Ion Blaster Cannon II", SearchCategory.InventoryType, Language.French },
            new object[] { 91105772, "The Forge", SearchCategory.Region, Language.German },
            new object[] { 91105772, "Jita", SearchCategory.SolarSystem, Language.Japanese },
            new object[] { 91105772, "Jita IV - Moon 4 - Caldari Navy Assembly Plant", SearchCategory.Station, Language.Russian }
        };

        static readonly object[] SubString_Four =
        {
            new object[] { 91105772, "Hasier Parcie", new SearchCategory[] { SearchCategory.Agent, SearchCategory.InventoryType }, Language.Chinese },
            new object[] { 91105772, "Goonswarm Federation", new SearchCategory[] { SearchCategory.Alliance, SearchCategory.InventoryType }, Language.French },
            new object[] { 91105772, "The Mittani", new SearchCategory[] { SearchCategory.Character, SearchCategory.InventoryType }, Language.German },
            new object[] { 91105772, "Kimotoro", new SearchCategory[] { SearchCategory.Constellation, SearchCategory.InventoryType }, Language.Japanese },
            new object[] { 91105772, "GoonWaffe", new SearchCategory[] { SearchCategory.Corporation, SearchCategory.InventoryType }, Language.Russian },
            new object[] { 91105772, "Caldari State", new SearchCategory[] { SearchCategory.Faction, SearchCategory.InventoryType }, Language.Chinese },
            new object[] { 91105772, "Ion Blaster Cannon II", new SearchCategory[] { SearchCategory.InventoryType, SearchCategory.Character }, Language.French },
            new object[] { 91105772, "The Forge", new SearchCategory[] { SearchCategory.Region, SearchCategory.InventoryType }, Language.German },
            new object[] { 91105772, "Jita", new SearchCategory[] { SearchCategory.SolarSystem, SearchCategory.InventoryType }, Language.Japanese },
            new object[] { 91105772, "Jita IV - Moon 4 - Caldari Navy Assembly Plant", new SearchCategory[] { SearchCategory.Station, SearchCategory.InventoryType }, Language.Russian }
        };

        static readonly object[] SubString_Five =
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

        static readonly object[] SubString_Six =
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

        static readonly object[] SubString_Seven =
        {
            new object[] { 91105772, "Hasier Parcie", SearchCategory.Agent, Language.Chinese, true },
            new object[] { 91105772, "Goonswarm Federation", SearchCategory.Alliance, Language.French, true },
            new object[] { 91105772, "The Mittani", SearchCategory.Character, Language.German, true },
            new object[] { 91105772, "Kimotoro", SearchCategory.Constellation, Language.Japanese, true },
            new object[] { 91105772, "GoonWaffe", SearchCategory.Corporation, Language.Russian, true },
            new object[] { 91105772, "Caldari State", SearchCategory.Faction, Language.Chinese, true },
            new object[] { 91105772, "Ion Blaster Cannon II", SearchCategory.InventoryType, Language.French, true },
            new object[] { 91105772, "The Forge", SearchCategory.Region, Language.German, true },
            new object[] { 91105772, "Jita", SearchCategory.SolarSystem, Language.Japanese, true },
            new object[] { 91105772, "Jita IV - Moon 4 - Caldari Navy Assembly Plant", SearchCategory.Station, Language.Russian, true }
        };

        static readonly object[] SubString_Eight =
        {
            new object[] { 91105772, "Hasier Parcie", new SearchCategory[] { SearchCategory.Agent, SearchCategory.InventoryType }, Language.Chinese, true },
            new object[] { 91105772, "Goonswarm Federation", new SearchCategory[] { SearchCategory.Alliance, SearchCategory.InventoryType }, Language.French, true },
            new object[] { 91105772, "The Mittani", new SearchCategory[] { SearchCategory.Character, SearchCategory.InventoryType }, Language.German, true },
            new object[] { 91105772, "Kimotoro", new SearchCategory[] { SearchCategory.Constellation, SearchCategory.InventoryType }, Language.Japanese, true },
            new object[] { 91105772, "GoonWaffe", new SearchCategory[] { SearchCategory.Corporation, SearchCategory.InventoryType }, Language.Russian, true },
            new object[] { 91105772, "Caldari State", new SearchCategory[] { SearchCategory.Faction, SearchCategory.InventoryType }, Language.Chinese, true },
            new object[] { 91105772, "Ion Blaster Cannon II", new SearchCategory[] { SearchCategory.InventoryType, SearchCategory.Character }, Language.French, true },
            new object[] { 91105772, "The Forge", new SearchCategory[] { SearchCategory.Region, SearchCategory.InventoryType }, Language.German, true },
            new object[] { 91105772, "Jita", new SearchCategory[] { SearchCategory.SolarSystem, SearchCategory.InventoryType }, Language.Japanese, true },
            new object[] { 91105772, "Jita IV - Moon 4 - Caldari Navy Assembly Plant", new SearchCategory[] { SearchCategory.Station, SearchCategory.InventoryType }, Language.Russian, true }
        };

#pragma warning restore

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_One")]
        public void SubString(int characterid, string search, SearchCategory category)
        {
            var r = Authenticated.Search.SubString(characterid, search, category).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Two")]
        public void SubString(int characterid, string search, IEnumerable<SearchCategory> categories)
        {
            var r = Authenticated.Search.SubString(characterid, search, categories).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Three")]
        public void SubString(int characterid, string search, SearchCategory category, Language language)
        {
            var r = Authenticated.Search.SubString(characterid, search, category, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Four")]
        public void SubString(int characterid, string search, IEnumerable<SearchCategory> categories, Language language)
        {
            var r = Authenticated.Search.SubString(characterid, search, categories, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Five")]
        public void SubString(int characterid, string search, SearchCategory category, bool strict)
        {
            var r = Authenticated.Search.SubString(characterid, search, category, strict).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Six")]
        public void SubString(int characterid, string search, IEnumerable<SearchCategory> categories, bool strict)
        {
            var r = Authenticated.Search.SubString(characterid, search, categories, strict).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Seven")]
        public void SubString(int characterid, string search, SearchCategory category, Language language, bool strict)
        {
            var r = Authenticated.Search.SubString(characterid, search, category, language, strict).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Search")]
        [Test, TestCaseSource("SubString_Eight")]
        public void SubString(int characterid, string search, IEnumerable<SearchCategory> categories, Language language, bool strict)
        {
            var r = Authenticated.Search.SubString(characterid, search, categories, language, strict).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
