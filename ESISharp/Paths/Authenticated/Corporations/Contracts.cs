using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Corporations
{
    public class Contracts : ApiPath
    {
        internal Contracts(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetContracts(int corporationid)
            => GetContracts(corporationid, 1);

        [Path("/corporations/{corporation_id}/contracts/", WebMethods.GET)]
        public EsiRequest GetContracts(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "contracts" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/corporations/{corporation_id}/contracts/{contract_id}/bids/", WebMethods.GET)]
        public EsiRequest GetContractBids(int corporationid, int contractid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "contracts", contractid.ToString(), "bids" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/corporations/{corporation_id}/contracts/{contract_id}/items/", WebMethods.GET)]
        public EsiRequest GetContractItems(int corporationid, int contractid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "contracts", contractid.ToString(), "items" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
