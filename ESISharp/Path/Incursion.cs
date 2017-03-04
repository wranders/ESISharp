using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Public Incursion paths</summary>
    public class Incursions
    {
        protected ESIEve EasyObject;

        internal Incursions(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get List of Incursions</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetList()
        {
            var Path = "/incursions/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Public and Authenticated Incursion paths</summary>
    public class AuthIncursions : Incursions
    {
        internal AuthIncursions(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}