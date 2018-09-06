using ESISharp.Enumeration;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Markets : PathTest
    {
#pragma warning disable S1144

        static readonly object[] GetRegionOrders_TestOne =
        {
            new object[] { 10000068, MarketOrderType.All },
            new object[] { 10000068, MarketOrderType.Buy },
            new object[] { 10000068, MarketOrderType.Sell }
        };

        static readonly object[] GetRegionOrders_TestTwo =
        {
            new object[] { 10000068, 1230, MarketOrderType.All },
            new object[] { 10000068, 1230, MarketOrderType.Buy },
            new object[] { 10000068, 1230, MarketOrderType.Sell }
        };

        static readonly object[] GetRegionOrders_TestThree =
        {
            new object[] { 10000068, 1230, MarketOrderType.All, 1 },
            new object[] { 10000068, 1230, MarketOrderType.Buy, 2 },
            new object[] { 10000068, 1230, MarketOrderType.Sell, 3 }
        };

        static readonly object[] GetGroupInfo_TestOne =
        {
            new object[] { 516, Language.English },
            new object[] { 516, Language.German },
            new object[] { 516, Language.French },
            new object[] { 516, Language.Russian },
            new object[] { 516, Language.Japanese },
            new object[] { 516, Language.Chinese },
        };

#pragma warning restore

        [Property("Public", "Markets")]
        [Test]
        public void GetStoreOffers()
        {
            var r = Public.Markets.GetPrices().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [TestCase(10000068)]
        public void GetRegionOrders(int regionid)
        {
            var r = Public.Markets.GetRegionOrders(regionid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [Test, TestCaseSource("GetRegionOrders_TestOne")]
        public void GetRegionOrders(int regionid, MarketOrderType ordertype)
        {
            var r = Public.Markets.GetRegionOrders(regionid, ordertype).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [TestCase(10000068, 1230)]
        public void GetRegionOrders(int regionid, int typeid)
        {
            var r = Public.Markets.GetRegionOrders(regionid, typeid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [Test, TestCaseSource("GetRegionOrders_TestTwo")]
        public void GetRegionOrders(int regionid, int typeid, MarketOrderType ordertype)
        {
            var r = Public.Markets.GetRegionOrders(regionid, typeid, ordertype).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [Test, TestCaseSource("GetRegionOrders_TestThree")]
        public void GetRegionOrders(int regionid, int typeid, MarketOrderType ordertype, int page)
        {
            var r = Public.Markets.GetRegionOrders(regionid, typeid, ordertype, page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [TestCase(10000068, 1230)]
        public void GetRegionMarketHistory(int regionid, int typeid)
        {
            var r = Public.Markets.GetRegionMarketHistory(regionid, typeid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [Test]
        public void GetGroups()
        {
            var r = Public.Markets.GetGroups().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [TestCase(516)]
        public void GetGroupInfo(int groupid)
        {
            var r = Public.Markets.GetGroupInfo(groupid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [Test, TestCaseSource("GetGroupInfo_TestOne")]
        public void GetGroupInfo(int groupid, Language language)
        {
            var r = Public.Markets.GetGroupInfo(groupid, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [TestCase(10000068)]
        public void GetTypes(int regionid)
        {
            var r = Public.Markets.GetTypes(regionid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Markets")]
        [TestCase(10000068, 1)]
        [TestCase(10000068, 1)]
        public void GetTypes(int regionid, int page)
        {
            var r = Public.Markets.GetTypes(regionid, page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
