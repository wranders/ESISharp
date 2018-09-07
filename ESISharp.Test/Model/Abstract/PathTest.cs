using ESISharp.Enumeration;
using ESISharp.Test.Model.Helpers;

namespace ESISharp.Test.Model.Abstract
{
    public abstract class PathTest
    {
        public readonly bool CredsExist;
        public readonly string ClientID;
        public readonly string SecretKey;
        public readonly string RefreshToken;

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
                RefreshToken = c.RefreshToken;
                Authenticated = new Authenticated(ClientID, SecretKey);
                Authenticated.SetUserAgent(@"ESISharp Test (github.com/wranders/ESISharp)");
                Authenticated.Sso.Client.SetRefreshToken(RefreshToken);
                Authenticated.Sso.Client.SetGrantType(OAuthGrant.Authorization);
                Authenticated.Sso.Client.Registry.EnsureKey();
            }
        }
    }
}
