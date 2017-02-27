using ESISharp.Web;
using System.Threading.Tasks;

namespace ESISharp.ESIPath
{
    public class Dogma
    {
        protected ESIEve EasyObject;

        internal Dogma(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Dogma attribute IDs</summary>
        /// <returns>JSON Array of attribute ID integers</returns>
        public string GetAttributes()
        {
            return GetAttributesAsync().Result;
        }

        /// <summary>Get Dogma attribute IDs</summary>
        /// <returns>JSON Array of attribute ID integers</returns>
        public async Task<string> GetAttributesAsync()
        {
            var Path = "/dogma/attributes/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Dogma Attribute information</summary>
        /// <param name="AttributeID">(Int32) Attribute ID</param>
        /// <returns>JSON Object containing Dogma attribute information</returns>
        public string GetAttributeInformation(int AttributeID)
        {
            return GetAttributeInformationAsync(AttributeID).Result;
        }

        /// <summary>Get Dogma Attribute information</summary>
        /// <param name="AttributeID">(Int32) Attribute ID</param>
        /// <returns>JSON Object containing Dogma attribute information</returns>
        public async Task<string> GetAttributeInformationAsync(int AttributeID)
        {
            var Path = $"/dogma/attributes/{AttributeID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Dogma effect IDs</summary>
        /// <returns>JSON Array of effect ID integers</returns>
        public string GetEffects()
        {
            return GetEffectsAsync().Result;
        }

        /// <summary>Get Dogma effect IDs</summary>
        /// <returns>JSON Array of effect ID integers</returns>
        public async Task<string> GetEffectsAsync()
        {
            var Path = "/dogma/effects/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Dogma Effect information</summary>
        /// <param name="EffectID">(Int32) Effect ID</param>
        /// <returns>JOSN Object containing Dogma effect information</returns>
        public string GetEffectInformation(int EffectID)
        {
            return GetEffectInformationAsync(EffectID).Result;
        }

        /// <summary>Get Dogma Effect information</summary>
        /// <param name="EffectID">(Int32) Effect ID</param>
        /// <returns>JOSN Object containing Dogma effect information</returns>
        public async Task<string> GetEffectInformationAsync(int EffectID)
        {
            var Path = $"/dogma/effects/{EffectID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }
    }

    public class AuthDogma : Dogma
    {
        internal AuthDogma(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}
