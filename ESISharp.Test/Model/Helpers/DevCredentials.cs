using ESISharp.Test.Model.Object;
using Newtonsoft.Json;
using System.IO;

namespace ESISharp.Test.Model.Helpers
{
    public static class DevCredentials
    {
        public static bool CredentialsExist()
        {
            return File.Exists("dev_secrets.json");
        }

        public static DevSecret GetCredentials()
        {
            using (StreamReader r = new StreamReader("dev_secret.json"))
            {
                var j = r.ReadToEnd();
                return JsonConvert.DeserializeObject<DevSecret>(j);
            }
        }
    }
}
