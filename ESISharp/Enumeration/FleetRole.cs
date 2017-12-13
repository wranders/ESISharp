namespace ESISharp.Enumeration
{
    public class FleetRole : Model.Abstract.FakeEnumerator
    {
        internal FleetRole(string value) : base(value) { }

        public static readonly FleetRole FleetCommander = new FleetRole("fleet_commander");
        public static readonly FleetRole WingCommander = new FleetRole("wing_commander");
        public static readonly FleetRole SquadCommander = new FleetRole("squad_commander");
        public static readonly FleetRole SquadMember = new FleetRole("squad_member");
    }
}
