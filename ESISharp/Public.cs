using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Paths.Public;

namespace ESISharp
{
    public class Public : EsiConnection
    {
        internal new Access Access = Access.Public;

        private readonly Alliance _Alliance;
        private readonly Character _Character;
        private readonly Corporation _Corporation;
        private readonly Dogma _Dogma;
        private readonly FactionWarfare _FactionWarfare;
        private readonly Incursions _Incursions;
        private readonly Industry _Industry;
        private readonly Insurance _Insurance;
        private readonly Killmails _Killmails;
        private readonly Loyalty _Loyalty;
        private readonly Markets _Markets;
        private readonly Opportunities _Opportunities;
        private readonly PlanetaryInteraction _PlanetaryInteraction;
        private readonly Routes _Routes;
        private readonly Search _Search;
        private readonly Sovereignty _Sovereignty;
        private readonly Status _Status;
        private readonly Universe _Universe;
        private readonly Wars _Wars;

        public Alliance Alliance => _Alliance;
        public Character Character => _Character;
        public Corporation Corporation => _Corporation;
        public Dogma Dogma => _Dogma;
        public FactionWarfare FactionWarfare => _FactionWarfare;
        public Incursions Incursions => _Incursions;
        public Industry Industry => _Industry;
        public Insurance Insurance => _Insurance;
        public Killmails Killmails => _Killmails;
        public Loyalty Loyalty => _Loyalty;
        public Markets Markets => _Markets;
        public Opportunities Opportunities => _Opportunities;
        public PlanetaryInteraction PlanetaryInteraction => _PlanetaryInteraction;
        public Routes Routes => _Routes;
        public Search Search => _Search;
        public Sovereignty Sovereignty => _Sovereignty;
        public Status Status => _Status;
        public Universe Universe => _Universe;
        public Wars Wars => _Wars;

        public Public() : base()
        {
            _Alliance = new Alliance(this);
            _Character = new Character(this);
            _Corporation = new Corporation(this);
            _Dogma = new Dogma(this);
            _FactionWarfare = new FactionWarfare(this);
            _Incursions = new Incursions(this);
            _Industry = new Industry(this);
            _Insurance = new Insurance(this);
            _Killmails = new Killmails(this);
            _Loyalty = new Loyalty(this);
            _Markets = new Markets(this);
            _Opportunities = new Opportunities(this);
            _PlanetaryInteraction = new PlanetaryInteraction(this);
            _Routes = new Routes(this);
            _Search = new Search(this);
            _Sovereignty = new Sovereignty(this);
            _Status = new Status(this);
            _Universe = new Universe(this);
            _Wars = new Wars(this);
        }
    }
}
