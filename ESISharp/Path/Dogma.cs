using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Public Dogma Information Paths</summary>
    public class Dogma
    {
        protected ESIEve EasyObject;

        internal Dogma(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Dogma attribute IDs</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAttributes()
        {
            var Path = "/dogma/attributes/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Dogma Attribute information</summary>
        /// <param name="AttributeID">(Int32) Attribute ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAttributeInformation(int AttributeID)
        {
            var Path = $"/dogma/attributes/{AttributeID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Dogma effect IDs</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetEffects()
        {
            var Path = "/dogma/effects/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Dogma Effect information</summary>
        /// <param name="EffectID">(Int32) Effect ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetEffectInformation(int EffectID)
        {
            var Path = $"/dogma/effects/{EffectID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Public and Authenticated Dogma Information Paths</summary>
    public class AuthDogma : Dogma
    {
        internal AuthDogma(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}
