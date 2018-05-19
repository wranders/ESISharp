using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Contracts : ApiPath
    {
        internal Contracts(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetContracts(int characterid)
            => GetContracts(characterid, 1);

        [Path("/characters/{character_id}/contracts/", WebMethods.GET)]
        public EsiRequest GetContracts(int characterid, int page)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "contracts" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/characters/{character_id}/contracts/{contract_id}/bids/", WebMethods.GET)]
        public EsiRequest GetContractBids(int characterid, int contractid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "contracts", contractid.ToString(), "bids" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/contracts/{contract_id}/items/", WebMethods.GET)]
        public EsiRequest GetContractItems(int characterid, int contractid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "contracts", contractid.ToString(), "items" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
