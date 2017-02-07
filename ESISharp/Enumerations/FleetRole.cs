namespace ESISharp.Enumerations
{
    /// <summary>
    /// Fleet Roles
    /// </summary>
    public class FleetRole
    {
        /// <summary>Fleet Commander Role</summary>
        public static readonly FleetRole FleetCommander = new FleetRole("fleet_commander");
        /// <summary>Wing Commander Role</summary>
        public static readonly FleetRole WingCommander = new FleetRole("wing_commander");
        /// <summary>Squad Commander Role</summary>
        public static readonly FleetRole SquadCommander = new FleetRole("squad_commander");
        /// <summary>Squad Member Role</summary>
        public static readonly FleetRole SquadMember = new FleetRole("squad_member");

        internal FleetRole(string val)
        {
            Value = val;
        }

        /// <summary>Fleet Role</summary>
        public string Value { get; }
    }
}
