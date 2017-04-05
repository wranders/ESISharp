using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Public Sovereignty path</summary>
    public class Sovereignty
    {
        protected ESIEve EasyObject;

        internal Sovereignty(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Sovereignty Campaigns</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetCampaigns()
        {
            var Path = "/sovereignty/campaigns/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get System and their Sovereignty information</summary>
        /// <returns></returns>
        public EsiRequest GetSystems()
        {
            var Path = "/sovereignty/map/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get All Sovereignty Stuctures</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStructures()
        {
            var Path = "/sovereignty/structures/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Public and Authenticated paths</summary>
    public class AuthSovereignty : Sovereignty
    {
        internal AuthSovereignty(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}