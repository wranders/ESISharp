using ESISharp.Enumeration;
using ESISharp.Model.Abstract;

namespace ESISharp
{
    public class Public : EsiConnection
    {
        public Paths.Public.Alliances Alliances { get; }
        public Paths.Public.Characters Characters { get; }
        public Paths.Public.Contracts Contracts { get; }
        public Paths.Public.Corporations Corporations { get; }
        public Paths.Public.Dogma Dogma { get; }
        public Paths.Public.FactionWarfare FactionWarfare { get; }
        public Paths.Public.Incursions Incursions { get; }
        public Paths.Public.Industry Industry { get; }
        public Paths.Public.Insurance Insurance { get; }
        public Paths.Public.Killmails Killmails { get; }
        public Paths.Public.Loyalty Loyalty { get; }
        public Paths.Public.Markets Markets { get; }
        public Paths.Public.Opportunities Opportunities { get; }
        public Paths.Public.PlanetaryInteraction PlanetaryInteraction { get; }
        public Paths.Public.Routes Routes { get; }
        public Paths.Public.Search Search { get; }
        public Paths.Public.Sovereignty Sovereignty { get; }
        public Paths.Public.Status Status { get; }
        public Paths.Public.Universe Universe { get; }
        public Paths.Public.Wars Wars { get; }

        public Public() : base()
        {
            Alliances = new Paths.Public.Alliances(this);
            Characters = new Paths.Public.Characters(this);
            Contracts = new Paths.Public.Contracts(this);
            Corporations = new Paths.Public.Corporations(this);
            Dogma = new Paths.Public.Dogma(this);
            FactionWarfare = new Paths.Public.FactionWarfare(this);
            Incursions = new Paths.Public.Incursions(this);
            Industry = new Paths.Public.Industry(this);
            Insurance = new Paths.Public.Insurance(this);
            Killmails = new Paths.Public.Killmails(this);
            Loyalty = new Paths.Public.Loyalty(this);
            Markets = new Paths.Public.Markets(this);
            Opportunities = new Paths.Public.Opportunities(this);
            PlanetaryInteraction = new Paths.Public.PlanetaryInteraction(this);
            Routes = new Paths.Public.Routes(this);
            Search = new Paths.Public.Search(this);
            Sovereignty = new Paths.Public.Sovereignty(this);
            Status = new Paths.Public.Status(this);
            Universe = new Paths.Public.Universe(this);
            Wars = new Paths.Public.Wars(this);
        }
    }
}
