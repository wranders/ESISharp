using ESISharp.Test.Model.Helpers;

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
            Public.SetUserAgent(@"ESISharp Test (github.com/wranders/ESISharp)");

            CredsExist = DevCredentials.CredentialsExist();
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
