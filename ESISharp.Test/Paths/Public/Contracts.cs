using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Contracts : PathTest
    {
#pragma warning disable S1144

        static readonly object[] GetContracts_TestOne =
        {
            new object[] { 10000002, 2 },
            new object[] { 10000002, 3 }
        };

        static readonly object[] GetContractBids_TestOne =
        {
            new object[] { 135977182, 2 },
            new object[] { 135977182, 3 }
        };

        static readonly object[] GetContractItems_TestOne =
        {
            new object[] { 135473800, 2 },
            new object[] { 135473800, 3 }
        };

#pragma warning restore

        [Property("Public", "Contracts")]
        [TestCase(10000002)]
        public void GetContracts(int regionid)
        {
            var r = Public.Contracts.GetContracts(regionid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Contracts")]
        [Test, TestCaseSource("GetContracts_TestOne")]
        public void GetContracts(int regionid, int page)
        {
            var r = Public.Contracts.GetContracts(regionid, page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Contracts")]
        [TestCase(135977182)]
        public void GetContractBids(int contractid)
        {
            var r = Public.Contracts.GetContractBids(contractid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Contracts")]
        [Test, TestCaseSource("GetContractBids_TestOne")] 
        public void GetContractBids(int contractid, int page)
        {
            var r = Public.Contracts.GetContractBids(contractid, page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Contracts")]
        [TestCase(135473800)]
        public void GetContractItems(int contractid)
        {
            var r = Public.Contracts.GetContractItems(contractid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Contracts")]
        [Test, TestCaseSource("GetContractItems_TestOne")]
        public void GetContractItems(int contractid, int page)
        {
            var r = Public.Contracts.GetContractItems(contractid, page).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
