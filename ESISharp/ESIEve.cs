using ESISharp.Enumerations;
using ESISharp.ESIPath;
using System.Net.Http;

namespace ESISharp
{
    /// <summary>Object for interfacing with the ESI API</summary>
    public class ESIEve
    {
        internal DataSource DataSource = DataSource.Tranquility;
        internal ResponseType ResponseType = ResponseType.Json;
        internal Route Route = Route.Latest;

        internal HttpClient QueryClient = new HttpClient();
        internal string UserAgent = @"ESISharp (github.com/wranders/ESISharp)";

        internal ESIEve()
        {

        }

        /// <summary>Set the Eve Server to retrieve data from</summary>
        /// <param name="NewDataSource">(DataSource) Eve Server</param>
        public void SetDataSource(DataSource NewDataSource)
        {
            DataSource = NewDataSource;
        }

        /// <summary>Set data response type</summary>
        /// <param name="NewResponseType">(ResponseType) Data Type</param>
        public void SetResponseType(ResponseType NewResponseType)
        {
            ResponseType = NewResponseType;
        }

        /// <summary>Set ESI version to use</summary>
        /// <param name="NewRoute"></param>
        public void SetRoute(Route NewRoute)
        {
            Route = NewRoute;
        }

        /// <summary>Set ESISharp User Agent</summary>
        /// <param name="ApplicationUserAgent">(String) User Agent</param>
        public void SetUserAgent(string ApplicationUserAgent)
        {
            UserAgent = ApplicationUserAgent;
        }

        /// <summary>Public API paths</summary>
        public class Public : ESIEve
        {
            /// <summary>Public Alliance paths</summary>
            public Alliance Alliance;
            /// <summary>Public Character paths</summary>
            public CharacterMain Character;
            /// <summary>Public Corporation paths</summary>
            public Corporation Corporation;
            /// <summary>Public Incursions paths</summary>
            public Incursions Incursions;
            /// <summary>Public Industry paths</summary>
            public Industry Industry;
            /// <summary>Public Insurance paths</summary>
            public Insurance Insurance;
            /// <summary>Public Killmails paths</summary>
            public Killmails Killmails;
            /// <summary>Public Market paths</summary>
            public Market Market;
            /// <summary>Public Planetary Interaction (PI) paths</summary>
            public PlanetaryInteraction PlanetaryInteraction;
            /// <summary>Public Search paths</summary>
            public Search Search;
            /// <summary>Public Sovereignty paths</summary>
            public Sovereignty Sovereignty;
            /// <summary>Public Universe paths</summary>
            public Universe Universe;
            /// <summary>Public Wars paths</summary>
            public Wars Wars;

            /// <summary>Construct Public ESI interface</summary>
            public Public() : base()
            {
                Alliance = new Alliance(this);
                Character = new CharacterMain(this);
                Corporation = new Corporation(this);
                Incursions = new Incursions(this);
                Industry = new Industry(this);
                Insurance = new Insurance(this);
                Killmails = new Killmails(this);
                Market = new Market(this);
                PlanetaryInteraction = new PlanetaryInteraction(this);
                Search = new Search(this);
                Sovereignty = new Sovereignty(this);
                Universe = new Universe(this);
                Wars = new Wars(this);
            }
        }

        /// <summary>Public and Authenticated paths</summary>
        public class Authenticated : ESIEve
        {
            /// <summary>SSO Authentication settings</summary>
            public Sso SSO;
            /// <summary>Public and Authenticated Alliance paths</summary>
            public AuthAlliance Alliance;
            /// <summary>Public and Authenticated Character paths</summary>
            public AuthCharacterMain Character;
            /// <summary>Public and Authenticated Corporation paths</summary>
            public AuthCorporation Corporation;
            /// <summary>Authenticated Fleet paths</summary>
            public Fleet Fleet;
            /// <summary>Public and Authenticated Incursion paths</summary>
            public AuthIncursions Incursions;
            /// <summary>Public and Authenticated Industry paths</summary>
            public AuthIndustry Industry;
            /// <summary>Public and Authenticated Insurance paths</summary>
            public AuthInsurance Insurance;
            /// <summary>Public and Authenticated Killmail paths</summary>
            public AuthKillmails Killmails;
            /// <summary>Public and Authenticated Market paths</summary>
            public AuthMarket Market;
            /// <summary>Public and Authenticated Planetary Interaction (PI) paths</summary>
            public AuthPlanetaryInteraction PlanetaryInteraction;
            /// <summary>Public and Authenticated Search paths</summary>
            public AuthSearch Search;
            /// <summary>Public and Authenticated Sovereignty paths</summary>
            public AuthSovereignty Sovereignty;
            /// <summary>Public and Authenticated Universe paths</summary>
            public AuthUniverse Universe;
            /// <summary>Authenticated User Interface paths</summary>
            public UserInterface UserInterface;
            /// <summary>Public and Authenticated Wars paths</summary>
            public AuthWars Wars;

            /// <summary>Construct Authenticated ESI interface</summary>
            /// <param name="AppClientID">(String) Application Client ID</param>
            public Authenticated(string AppClientID) : base()
            {
                SSO = new Sso(AppClientID);
                AuthInit();
            }

            /// <summary>Construct Authenticated ESI interface</summary>
            /// <param name="AppClientID">(String) Application Client ID</param>
            /// <param name="AppSecretKey">(String) Application Secret Key</param>
            public Authenticated(string AppClientID, string AppSecretKey) : base()
            {
                SSO = new Sso(AppClientID, AppSecretKey);
                AuthInit();
            }

            private void AuthInit()
            {
                Alliance = new AuthAlliance(this);
                Character = new AuthCharacterMain(this);
                Corporation = new AuthCorporation(this);
                Fleet = new Fleet(this);
                Incursions = new AuthIncursions(this);
                Industry = new AuthIndustry(this);
                Insurance = new AuthInsurance(this);
                Killmails = new AuthKillmails(this);
                Market = new AuthMarket(this);
                PlanetaryInteraction = new AuthPlanetaryInteraction(this);
                Search = new AuthSearch(this);
                Sovereignty = new AuthSovereignty(this);
                Universe = new AuthUniverse(this);
                UserInterface = new UserInterface(this);
                Wars = new AuthWars(this);
            }
        }
    }
}
