using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Wallet : ApiPath
    {
        internal Wallet(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/wallet/", WebMethods.GET)]
        public EsiRequest GetBalance(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "wallet" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetJournal(int characterid)
            => GetJournal(characterid, 1);

        [Path("/characters/{character_id}/wallet/journal/", WebMethods.GET)]
        public EsiRequest GetJournal(int characterid, int page)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "wallet" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetTransactions(int characterid)
            => GetTransactions(characterid, -1);

        [Path("/characters/{character_id}/wallet/transactions/", WebMethods.GET)]
        public EsiRequest GetTransactions(int characterid, long fromid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "wallet", "transactions" };
            if (fromid >= 0)
            {
                var data = new EsiRequestData
                {
                    Query = new Dictionary<string, dynamic>
                    {
                        ["from_id"] = fromid
                    }
                };
                return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
            }
            else
            {
                return new EsiRequest(EsiConnection, path, WebMethods.GET);
            }
        }
    }
}
