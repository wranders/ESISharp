using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Contracts : ApiPath
    {
        internal Contracts(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetContracts(int contractid)
        {
            return GetContracts(contractid, 1);
        }

        [Path("/contracts/public/{region_id}/", WebMethods.GET)]
        public EsiRequest GetContracts(int regionid, int page)
        {
            var path = new EsiRequestPath { "contracts", "public", regionid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetContractBids(int contractid)
        {
            return GetContractBids(contractid, 1);
        }

        [Path("/contracts/public/bids/{contract_id}/", WebMethods.GET)]
        public EsiRequest GetContractBids(int contractid, int page)
        {
            var path = new EsiRequestPath { "contracts", "public", "bids", contractid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetContractItems(int contractid)
        {
            return GetContractItems(contractid, 1);
        }

        [Path("/contracts/public/items/{contract_id}/", WebMethods.GET)]
        public EsiRequest GetContractItems(int contractid, int page)
        {
            var path = new EsiRequestPath { "contracts", "public", "items", contractid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
