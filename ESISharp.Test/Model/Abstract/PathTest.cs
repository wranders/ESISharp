using ESISharp.Test.Model.Helpers;
using System;

namespace ESISharp.Test.Model.Abstract
{
    public abstract class PathTest
    {
        public readonly bool CredsExist;
        public readonly string ClientID;
        public readonly string SecretKey;
        public string RefreshToken;

        public readonly Public Public;
        public readonly Authenticated Authenticated;

        protected PathTest()
        {
            Public = new Public();

            CredsExist = DevCredentials.CredentialsExist();

            Console.WriteLine("=== Dev Credentials Present: " + CredsExist.ToString() + " ===");

            if (CredsExist)
            {
                var c = DevCredentials.GetCredentials();
                ClientID = c.ClientID;
                SecretKey = c.SecretKey;
                Authenticated = new Authenticated(ClientID, SecretKey);
            }
        }
    }
}
