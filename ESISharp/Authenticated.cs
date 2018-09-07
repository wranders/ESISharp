using ESISharp.Enumeration;
using ESISharp.Model.Abstract;

namespace ESISharp
{
    public class Authenticated : EsiConnection
    {
        public Sso.Main Sso { get; }
        public Paths.Authenticated.Alliances.Main Alliances { get; }
        public Paths.Authenticated.Characters.Main Characters { get; }
        public Paths.Authenticated.Corporations.Main Corporations { get; }
        public Paths.Authenticated.Fleets Fleets { get; }
        public Paths.Authenticated.Markets Markets { get; }
        public Paths.Authenticated.Search Search { get; }
        public Paths.Authenticated.Universe Universe { get; }
        public Paths.Authenticated.UserInterface UserInterface { get; }

        private Authenticated() : base()
        {
            Alliances = new Paths.Authenticated.Alliances.Main(this);
            Characters = new Paths.Authenticated.Characters.Main(this);
            Corporations = new Paths.Authenticated.Corporations.Main(this);
            Fleets = new Paths.Authenticated.Fleets(this);
            Markets = new Paths.Authenticated.Markets(this);
            Search = new Paths.Authenticated.Search(this);
            Universe = new Paths.Authenticated.Universe(this);
            UserInterface = new Paths.Authenticated.UserInterface(this);
        }

        public Authenticated(string clientid) : this()
        {
            Sso = new Sso.Main(clientid);
        }

        public Authenticated(string clientid, string secretkey) : this()
        {
            Sso = new Sso.Main(clientid, secretkey);
        }
    }
}
