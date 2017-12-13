namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Planets
        {
            public static readonly Scope ManagePlanets = new Scope("esi-planets.manage_planets.v1");
            public static readonly Scope ReadCustomsOffices = new Scope("esi-planets.read_customs_offices.v1");
        }
    }
}
