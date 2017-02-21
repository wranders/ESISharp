using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Public Killmail paths</summary>
    public class Loyalty
    {
        protected ESIEve EasyObject;

        internal Loyalty(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation Loyalty Point (LP) store offers</summary>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>JSON array of objects representing items and their associated LP store information</returns>
        public string GetStoreOffers(int CorporationID)
        {
            var Path = $"/loyalty/stores/{CorporationID}/offers/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get();
        }
    }

    /// <summary>Public and Authenticated paths</summary>
    public class AuthLoyalty : Loyalty
    {
        internal AuthLoyalty(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}