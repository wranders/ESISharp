using Newtonsoft.Json;

namespace ESISharp.Test.Model.Object
{
    public class DevSecret
    {
        [JsonProperty(PropertyName = "ClientID")]
        public string ClientID { get; set; }

        [JsonProperty(PropertyName = "SecretKey")]
        public string SecretKey { get; set; }

        [JsonProperty(PropertyName = "RefreshToken")]
        public string RefreshToken { get; set; }
    }
}
