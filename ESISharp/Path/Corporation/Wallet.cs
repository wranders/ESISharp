using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation
{
    public class CorporationWallet
    {
        protected ESIEve EasyObject;

        internal CorporationWallet(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Wallet Balances</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_wallets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetBalances(int CorporationID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/wallets/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Corporation's Wallet Division Journal</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_wallets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Division">(Int32) Division ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetJournal(int CorporationID, int Division)
        {
            return GetJournal(CorporationID, Division, null);
        }

        /// <summary>Get Corporation's Wallet Division Journal</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_wallets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Division">(Int32) Division ID</param>
        /// <param name="FromID">(Int64) Oldest Transaction ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetJournal(int CorporationID, int Division, long? FromID)
        {
            var Path = $"/corporations/{CorporationID.ToString()}/wallets/{Division.ToString()}/journal/";
            var Data = new
            {
                from_id = FromID
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Corporation's Wallet Division Transactions</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_wallets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Division">(Int32) Division ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTransactions(int CorporationID, int Division)
        {
            return GetTransactions(CorporationID, Division, null);
        }

        /// <summary>Get Corporation's Wallet Division Transactions</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation_wallets" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="Division">(Int32) Division ID</param>
        /// <param name="FromID">(Int64) Oldest Transaction ID</param>
        /// <returns>EsiRequest</returns
        public EsiRequest GetTransactions(int CorporationID, int Division, long? FromID)
        {
            var Path = $"";
            var Data = new
            {
                from_id = FromID
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
