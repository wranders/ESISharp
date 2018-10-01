using ESISharp.Test.Model.Abstract;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
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

        private int GetContractIDbyType(int regionid, string type)
        {
            var page = 1;
            var output = -1;
            while(output < 0)
            {
                var r = Public.Contracts.GetContracts(regionid, page).Execute();
                if (r.Code == HttpStatusCode.OK)
                {
                    List<Dictionary<string, dynamic>> body = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(r.Body);
                    foreach (Dictionary<string, dynamic> contract in body)
                    {
                        if (contract["type"] == type)
                        {
                            output = (int)contract["contract_id"];
                        }
                    }
                    page++;
                }
                else
                {
                    break;
                }
            }
            return output;
        }

        [Property("Public", "Contracts")]
        [Test]
        public void GetContractBids()
        {
            var cid = GetContractIDbyType(10000002, "auction");
            var r = Public.Contracts.GetContractBids(cid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Contracts")]
        [Test]
        public void GetContractItems()
        {
            var cid = GetContractIDbyType(10000002, "item_exchange");
            var r = Public.Contracts.GetContractItems(cid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
