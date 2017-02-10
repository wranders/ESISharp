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
        /// <returns>JSON Array of Objects containing campaign information</returns>
        public string GetCampaigns()
        {
            var Path = "/sovereignty/campaigns/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>Get All Sovereignty Stuctures</summary>
        /// <returns>JSON Array of Objects containing structure information</returns>
        public string GetStructures()
        {
            var Path = "/sovereignty/structures/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return EsiRequest.Get();
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