using ESISharp.Enumeration;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Universe : PathTest
    {
#pragma warning disable S1144

        static object[] GetSystemInfo_One =
        {
            new object[] { 30000142, Language.Chinese },
            new object[] { 30000142, Language.French },
            new object[] { 30000142, Language.German },
            new object[] { 30000142, Language.Japanese },
            new object[] { 30000142, Language.Russian }
        };

        static object[] GetTypeInfo_One =
        {
            new object[] { 34, Language.Chinese },
            new object[] { 34, Language.French },
            new object[] { 34, Language.German },
            new object[] { 34, Language.Japanese },
            new object[] { 34, Language.Russian }
        };

        static object[] GetItemGroupInfo_One =
        {
            new object[] { 10, Language.Chinese },
            new object[] { 10, Language.French },
            new object[] { 10, Language.German },
            new object[] { 10, Language.Japanese },
            new object[] { 10, Language.Russian }
        };

        static object[] GetCharacterRaces_One =
        {
            new object[] { Language.Chinese },
            new object[] { Language.French },
            new object[] { Language.German },
            new object[] { Language.Japanese },
            new object[] { Language.Russian }
        };

        static object[] GetRegionInfo_One =
        {
            new object[] { 10000002, Language.Chinese },
            new object[] { 10000003, Language.French },
            new object[] { 10000004, Language.German },
            new object[] { 10000005, Language.Japanese },
            new object[] { 10000006, Language.Russian }
        };

        static object[] GetConstellationInfo_One =
        {
            new object[] { 20000002, Language.Chinese },
            new object[] { 20000003, Language.French },
            new object[] { 20000004, Language.German },
            new object[] { 20000005, Language.Japanese },
            new object[] { 20000006, Language.Russian }
        };

#pragma warning restore

        [Property("Public", "Universe")]
        [TestCase(40009082)]
        public void GetPlanetInfo(int planetid)
        {
            var r = Public.Universe.GetPlanetInfo(planetid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(60003760)]
        public void GetStationInfo(int stationid)
        {
            var r = Public.Universe.GetStationInfo(stationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(30000142)]
        public void GetSystemInfo(int systemid)
        {
            var r = Public.Universe.GetSystemInfo(systemid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test, TestCaseSource("GetSystemInfo_One")]
        public void GetSystemInfo(int systemid, Language language)
        {
            var r = Public.Universe.GetSystemInfo(systemid, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetSystems()
        {
            var r = Public.Universe.GetSystems().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(34)]
        public void GetTypeInfo(int typeid)
        {
            var r = Public.Universe.GetTypeInfo(typeid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test, TestCaseSource("GetTypeInfo_One")]
        public void GetTypeInfo(int typeid, Language language)
        {
            var r = Public.Universe.GetTypeInfo(typeid, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetTypes()
        {
            var r = Public.Universe.GetTypes().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(2)]
        public void GetTypes(int page)
        {
            var r = Public.Universe.GetTypes(page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetItemGroups()
        {
            var r = Public.Universe.GetItemGroups().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(2)]
        public void GetItemGroups(int page)
        {
            var r = Public.Universe.GetItemGroups(page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(10)]
        public void GetItemGroupInfo(int groupid)
        {
            var r = Public.Universe.GetItemGroupInfo(groupid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test, TestCaseSource("GetItemGroupInfo_One")]
        public void GetItemGroupInfo(int groupid, Language language)
        {
            var r = Public.Universe.GetItemGroupInfo(groupid, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetItemCategories()
        {
            var r = Public.Universe.GetItemCategories().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(10)]
        public void GetItemCategoryInfo(int categoryid)
        {
            var r = Public.Universe.GetItemCategoryInfo(categoryid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test, TestCaseSource("GetItemGroupInfo_One")]
        public void GetItemCategoryInfo(int categoryid, Language language)
        {
            var r = Public.Universe.GetItemCategoryInfo(categoryid, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(23913)]
        public void GetItemNameAndCategory(int id)
        {
            var r = Public.Universe.GetItemNameAndCategory(id).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(new int[] { 23913, 22852 })]
        public void GetItemNameAndCategory(IEnumerable<int> id)
        {
            var r = Public.Universe.GetItemNameAndCategory(id).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetPublicStructures()
        {
            var r = Public.Universe.GetPublicStructures().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetCharacterRaces()
        {
            var r = Public.Universe.GetCharacterRaces().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test, TestCaseSource("GetCharacterRaces_One")]
        public void GetCharacterRaces(Language language)
        {
            var r = Public.Universe.GetCharacterRaces(language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetFactions()
        {
            var r = Public.Universe.GetFactions().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test, TestCaseSource("GetCharacterRaces_One")]
        public void GetFactions(Language language)
        {
            var r = Public.Universe.GetFactions(language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetBloodlines()
        {
            var r = Public.Universe.GetBloodlines().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test, TestCaseSource("GetCharacterRaces_One")]
        public void GetBloodlines(Language language)
        {
            var r = Public.Universe.GetBloodlines(language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetRegions()
        {
            var r = Public.Universe.GetRegions().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(10000001)]
        public void GetRegionInfo(int categoryid)
        {
            var r = Public.Universe.GetRegionInfo(categoryid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test, TestCaseSource("GetRegionInfo_One")]
        public void GetRegionInfo(int regionid, Language language)
        {
            var r = Public.Universe.GetRegionInfo(regionid, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetConstellations()
        {
            var r = Public.Universe.GetConstellations().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(20000001)]
        public void GetConstellationInfo(int constellationid)
        {
            var r = Public.Universe.GetConstellationInfo(constellationid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test, TestCaseSource("GetConstellationInfo_One")]
        public void GetConstellationInfo(int constellationid, Language language)
        {
            var r = Public.Universe.GetConstellationInfo(constellationid, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(40000042)]
        public void GetMoonInfo(int moonid)
        {
            var r = Public.Universe.GetMoonInfo(moonid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(50000342)]
        public void GetStargateInfo(int stargateid)
        {
            var r = Public.Universe.GetStargateInfo(stargateid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetGraphics()
        {
            var r = Public.Universe.GetGraphics().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(10)]
        public void GetGraphicInfo(int graphicid)
        {
            var r = Public.Universe.GetGraphicInfo(graphicid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetSystemJumps()
        {
            var r = Public.Universe.GetSystemJumps().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [Test]
        public void GetSystemKills()
        {
            var r = Public.Universe.GetSystemKills().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Universe")]
        [TestCase(40009076)]
        public void GetStarInfo(int starid)
        {
            var r = Public.Universe.GetStarInfo(starid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
