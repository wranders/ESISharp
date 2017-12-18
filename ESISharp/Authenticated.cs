using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Sso;

namespace ESISharp
{
    public class Authenticated : EsiConnection
    {
        internal new Access Access = Access.Authenticated;

        private readonly Paths.Authenticated.Alliance.Main _Alliance;
        private readonly Paths.Authenticated.Character.Main _Character;

        public Paths.Authenticated.Alliance.Main Alliance => _Alliance;
        public Paths.Authenticated.Character.Main Character => _Character;

        private Authenticated() : base()
        {
            _Alliance = new Paths.Authenticated.Alliance.Main(this);
            _Character = new Paths.Authenticated.Character.Main(this);
        }

        public Authenticated(string clientid) : this()
        {

        }

        public Authenticated(string clientid, string secretkey) : this()
        {

        }
    }
}
