using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Corporations
{
    public class Wallet : ApiPath
    {
        internal Wallet(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/corporations/{corporation_id}/wallets/", WebMethods.GET)]
        public EsiRequest GetBalance(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "wallet" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetJournal(int characterid, int division)
            => GetJournal(characterid, division, 1);

        [Path("/corporations/{corporation_id}/wallets/{division}/journal/", WebMethods.GET)]
        public EsiRequest GetJournal(int corporationid, int division, int page)
        {
            var path = new EsiRequestPath { "characters", corporationid.ToString(), "wallets", division.ToString(), "journal" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetTransactions(int characterid, int division)
            => GetTransactions(characterid, division, -1);

        [Path("/corporations/{corporation_id}/wallets/{division}/transactions/", WebMethods.GET)]
        public EsiRequest GetTransactions(int corporationid, int division, long fromid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "wallet", division.ToString(), "transactions" };
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
