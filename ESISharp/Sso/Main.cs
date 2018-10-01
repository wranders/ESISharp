using ESISharp.Enumeration;
using ESISharp.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Sso
{
    public class Main
    {
        public Authentication Authentication { get; }
        public Client Client { get; }

        internal string _ClientId;
        internal string _SecretKey;
        internal string _RefreshToken;

        internal string AuthRelayDirectory => Client._AuthRelayFileDirectory;

        private Main()
        {
            Client = new Client(this);
            Authentication = new Authentication(this);
        }

        internal Main(string clientid) : this()
        {
            _ClientId = clientid;
        }

        internal Main(string clientid, string secretkey) : this()
        {
            _ClientId = clientid;
            _SecretKey = secretkey;
        }

        public bool ForceAuthentication()
        {
            var v = Authentication.VerifyCredentials(true);
            return Client.Token != null && v;
        }
    }
}
