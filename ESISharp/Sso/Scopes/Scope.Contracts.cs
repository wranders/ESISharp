namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Contracts
        {
            public static readonly Scope ReadCharacterContracts = new Scope("esi-contracts.read_character_contracts.v1");
            public static readonly Scope ReadCorporationContracts = new Scope("esi-contracts.read_corporation_contracts.v1");
        }
    }
}
