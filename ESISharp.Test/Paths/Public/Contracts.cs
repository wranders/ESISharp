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
            new object[] { 000000000, 2 },  // Temporary zeros for contract ID until I can figure out how I can test contracts.
            new object[] { 000000000, 3 }   // Temporary zeros for contract ID until I can figure out how I can test contracts.
        };

        static readonly object[] GetContractItems_TestOne =
        {
            new object[] { 000000000, 2 },  // Temporary zeros for contract ID until I can figure out how I can test contracts.
            new object[] { 000000000, 3 }   // Temporary zeros for contract ID until I can figure out how I can test contracts.
        };

#pragma warning restore

        [Property("Public", "Contracts")]
        [TestCase(10000002)]
        public void GetContracts(int regionid)
        {
            // TODO: Figure out how to test contracts.
            Assert.True(false);
        }

        [Property("Public", "Contracts")]
        [Test, TestCaseSource("GetContracts_TestOne")]
        public void GetContracts(int regionid, int page)
        {
            // TODO: Figure out how to test contracts.
            Assert.True(false);
        }

        [Property("Public", "Contracts")]
        [TestCase(000000000)]
        public void GetContractBids(int contractid)
        {
            // TODO: Figure out how to test contracts.
            Assert.True(false);
        }

        [Property("Public", "Contracts")]
        [Test, TestCaseSource("GetContractBids_TestOne")] 
        public void GetContractBids(int contractid, int page)
        {
            // TODO: Figure out how to test contracts.
            Assert.True(false);
        }

        [Property("Public", "Contracts")]
        [TestCase(000000000)]
        public void GetContractItems(int contractid)
        {
            // TODO: Figure out how to test contracts.
            Assert.True(false);
        }

        [Property("Public", "Contracts")]
        [Test, TestCaseSource("GetContractItems_TestOne")]
        public void GetContractItems(int contractid, int page)
        {
            // TODO: Figure out how to test contracts.
            Assert.True(false);
        }
    }
}
