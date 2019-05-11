using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ESISharp.Model.Object
{
    public class SsoTokenVerification
    {
        [JsonProperty(PropertyName = "CharacterID")]
        public int CharacterID { get; set; }

        [JsonProperty(PropertyName = "CharacterName")]
        public string CharacterName { get; set; }

        [JsonProperty(PropertyName = "TokenType")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "CharacterOwnerHash")]
        public string CharacterOwnerHash { get; set; }

        [JsonProperty(PropertyName = "ExpiresOn")]
        public DateTime Expires { get; set; }

        [JsonProperty(PropertyName = "Scopes")]
        [JsonConverter(typeof(Sso.Scopes.ScopesSerializer))]
        public IEnumerable<Sso.Scopes.Scope> Scopes { get; set; }

        [JsonProperty(PropertyName = "IntellectualProperty")]
        public string IntellectualProperty { get; set; }
    }
}
