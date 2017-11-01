using ESISharp.ESIPath.Alliance;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.ESIPath
{
    /// <summary>Public Alliance paths</summary>
    public class AllianceMain
    {
        protected ESIEve EasyObject;

        internal AllianceMain(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Alliance IDs</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAll()
        {
            var Path = "/alliances/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Alliance Name from ID</summary>
        /// <param name="AllianceID">(Int64) Alliance ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetNames(long AllianceID)
        {
            return GetNames(new long[] { AllianceID });
        }

        /// <summary>Get Alliance Names from List if IDs</summary>
        /// <param name="AllianceIDs">List(Int64) Alliance IDs</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetNames(IEnumerable<long> AllianceIDs)
        {
            var Path = "/alliances/names/";
            var Data = new { alliance_ids = AllianceIDs.ToArray() };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }

        /// <summary>Get Alliance Information</summary>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetInformation(int AllianceID)
        {
            var Path = $"/alliances/{AllianceID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Alliance's Member Corporations</summary>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetCorporations(int AllianceID)
        {
            var Path = $"/alliances/{AllianceID.ToString()}/corporations/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Alliance Icons</summary>
        /// <param name="AllianceID">(Int32) Alliance ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetIcons(int AllianceID)
        {
            var Path = $"/alliances/{AllianceID.ToString()}/icons/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Public and Authenticated Alliance paths</summary>
    public class AuthAllianceMain : AllianceMain
    {
        /// <summary>Contacts paths</summary>
        public AllianceContacts Contacts;

        internal AuthAllianceMain(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;

            Contacts = new AllianceContacts(EasyObject);
        }
    }
}
