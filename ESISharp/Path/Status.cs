using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Public Server Status Paths</summary>
    public class Status
    {
        protected ESIEve EasyObject;

        internal Status(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Requested Server Status</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStatus()
        {
            var Path = "/status/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Public and Authenticated Server Status paths</summary>
    public class AuthStatus : Status
    {
        internal AuthStatus(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}
