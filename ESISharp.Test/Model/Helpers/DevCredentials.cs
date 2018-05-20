using ESISharp.Test.Model.Object;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ESISharp.Test.Model.Helpers
{
    public static class DevCredentials
    {
        public static bool CredentialsExist()
        {
            return File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dev_secret.json"));
        }

        public static DevSecret GetCredentials()
        {
            using (StreamReader r = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dev_secret.json")))
            {
                var j = r.ReadToEnd();
                return JsonConvert.DeserializeObject<DevSecret>(j);
            }
        }
    }
}
