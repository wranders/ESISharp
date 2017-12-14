using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Public
{
    public class Loyalty : ApiPath
    {
        internal Loyalty(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/loyalty/stores/{corporation_id}/offers/", WebMethods.GET)]
        public EsiRequest GetStoreOffers(int corporationid)
        {
            var path = new EsiRequestPath { "loyalty", "stores", corporationid.ToString(), "offers" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
