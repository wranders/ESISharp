using ESISharp.Enumeration;
using ESISharp.Model.Abstract;

namespace ESISharp
{
    public class Authenticated : EsiConnection
    {
        internal new Access Access = Access.Authenticated;

        private readonly Sso.Client _SsoClient;
        private readonly Paths.Authenticated.Alliances.Main _Alliances;
        private readonly Paths.Authenticated.Characters.Main _Characters;
        private readonly Paths.Authenticated.Corporations.Main _Corporations;
        private readonly Paths.Authenticated.Fleets _Fleets;

        public Sso.Client SsoClient => _SsoClient;
        public Paths.Authenticated.Alliances.Main Alliances => _Alliances;
        public Paths.Authenticated.Characters.Main Characters => _Characters;
        public Paths.Authenticated.Corporations.Main Corporations => _Corporations;
        public Paths.Authenticated.Fleets Fleets => _Fleets;

        private Authenticated() : base()
        {
            _Alliances = new Paths.Authenticated.Alliances.Main(this);
            _Characters = new Paths.Authenticated.Characters.Main(this);
            _Corporations = new Paths.Authenticated.Corporations.Main(this);
            _Fleets = new Paths.Authenticated.Fleets(this);
        }

        public Authenticated(string clientid) : this()
        {
            _SsoClient = new Sso.Client(clientid);
        }

        public Authenticated(string clientid, string secretkey) : this()
        {
            _SsoClient = new Sso.Client(clientid, secretkey);
        }
    }
}
