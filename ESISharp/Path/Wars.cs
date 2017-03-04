using ESISharp.Web;
using System.Threading.Tasks;

namespace ESISharp.ESIPath
{
    /// <summary>Public Wars paths</summary>
    public class Wars
    {
        protected ESIEve EasyObject;

        internal Wars(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Wars</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetWars()
        {
            var Path = "/wars/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get War Information</summary>
        /// <param name="WarID">(Int32) War ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetWarInfo(int WarID)
        {
            var Path = $"/wars/{WarID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get War Killmails (First Page)</summary>
        /// <param name="WarID">(Int32) War ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetWarKills(int WarID)
        {
            return GetWarKills(WarID, 1);
        }

        /// <summary>Get War Killmails</summary>
        /// <param name="WarID">(Int32) War ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetWarKills(int WarID, int Page)
        {
            var Path = $"/wars/{WarID.ToString()}/killmails/";
            var Data = new { page = Page };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }
    }

    /// <summary>Public and Authenticated Wars paths</summary>
    public class AuthWars : Wars
    {
        internal AuthWars(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}