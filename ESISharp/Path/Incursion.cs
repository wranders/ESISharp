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
        /// <returns>JSON Array of Objects containing incursion information</returns>
        public string GetList()
        {
            var Path = "/incursions/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get();
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