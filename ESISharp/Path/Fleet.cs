using ESISharp.Enumerations;
using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Authenticated Fleet paths</summary>
    public class Fleet
    {
        protected ESIEve EasyObject;

        internal Fleet(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Fleet Information</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetInformation(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Update Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MOTD">(String) Fleet Message of the Day (MOTD)</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Update(long FleetID, string MOTD)
        {
            return Update(FleetID, MOTD, null);
        }

        /// <summary>Update Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="FreeMove">(Boolean) Free-Move status</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Update(long FleetID, bool FreeMove)
        {
            return Update(FleetID, null, FreeMove);
        }

        /// <summary>Update Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MOTD">(String) Fleet Message of the Day (MOTD)</param>
        /// <param name="FreeMove">(Boolean) Free-Move status</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Update(long FleetID, string MOTD, bool? FreeMove)
        {
            var Path = $"/fleets/{FleetID.ToString()}/";
            var Data = new { motd = MOTD, is_free_move = FreeMove };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPut, Data);
        }

        /// <summary>Get Fleet Members</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMembers(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Invite a Character to Fleet as Squad Member</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Invite(long FleetID, int CharacterID)
        {
            return Invite(FleetID, CharacterID, FleetRole.SquadMember.Value, null, null);
        }

        /// <summary>Invite a Character to Fleet as Squad Member in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Invite(long FleetID, int CharacterID, long WingID)
        {
            return Invite(FleetID, CharacterID, FleetRole.SquadMember.Value, WingID, null);
        }

        /// <summary>Invite a Character to Fleet as Squad Member in the specified Wing and Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Invite(long FleetID, int CharacterID, long WingID, long SquadID)
        {
            return Invite(FleetID, CharacterID, FleetRole.SquadMember.Value, WingID, SquadID);
        }

        /// <summary>Invite a Character to Fleet with a specific role</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(FleetRole) Role</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Invite(long FleetID, int CharacterID, FleetRole Role)
        {
            return Invite(FleetID, CharacterID, Role.Value, null, null);
        }

        /// <summary>Invite a Character to Fleet with a specific role</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(String) Role</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Invite(long FleetID, int CharacterID, string Role)
        {
            return Invite(FleetID, CharacterID, Role, null, null);
        }

        /// <summary>Invite a Character to Fleet with a specific role in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(FleetRole) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Invite(long FleetID, int CharacterID, FleetRole Role, long WingID)
        {
            return Invite(FleetID, CharacterID, Role.Value, WingID, null);
        }

        /// <summary>Invite a Character to Fleet with a specific role in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(String) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Invite(long FleetID, int CharacterID, string Role, long WingID)
        {
            return Invite(FleetID, CharacterID, Role, WingID, null);
        }

        /// <summary>Invite a Character to Fleet with a specific role in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(FleetRole) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Invite(long FleetID, int CharacterID, FleetRole Role, long WingID, long SquadID)
        {
            return Invite(FleetID, CharacterID, Role.Value, WingID, SquadID);
        }

        /// <summary>Invite a Character to Fleet with a specific role in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(String) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Invite(long FleetID, int CharacterID, string Role, long? WingID, long? SquadID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/";
            var Data = new
            {
                character_id = CharacterID,
                role = Role,
                squad_id = SquadID,
                wing_id = WingID
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, Data);
        }

        /// <summary>Kick Member from Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest KickMember(long FleetID, int MemberID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/{MemberID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthDelete);
        }

        /// <summary>Move Fleet Member</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest MoveMember(long FleetID, int MemberID, long WingID, long SquadID)
        {
            return MoveMember(FleetID, MemberID, FleetRole.SquadMember.Value, WingID, SquadID);
        }

        /// <summary>Move Fleet Member</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <param name="Role">(FleetRole) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest MoveMember(long FleetID, int MemberID, FleetRole Role, long WingID, long SquadID)
        {
            return MoveMember(FleetID, MemberID, Role.Value, WingID, SquadID);
        }

        /// <summary>Move Fleet Member</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <param name="Role">(String) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest MoveMember(long FleetID, int MemberID, string Role, long WingID, long SquadID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/{MemberID.ToString()}/";
            var Data = new
            {
                role = Role,
                squad_id = SquadID,
                wing_id = WingID
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPut, Data);
        }

        /// <summary>Delete Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest DeleteSquad(long FleetID, long SquadID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/squads/{SquadID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthDelete);
        }

        /// <summary>Rename Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <param name="Name">(String) Squad Name</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest RenameSquad(long FleetID, long SquadID, string Name)
        {
            var Path = $"/fleets/{FleetID.ToString()}/squads/{SquadID.ToString()}/";
            var Data = new
            {
                name = Name
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPut, Data);
        }

        /// <summary>Get Wings in Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetWings(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Create a Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest CreateWing(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/";
            var Data = new { };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, Data);
        }

        /// <summary>Delete Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest DeleteWing(long FleetID, long WingID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/{WingID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthDelete);
        }

        /// <summary>Rename Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="Name">(String) Wing Name</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest RenameWing(long FleetID, long WingID, string Name)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/{WingID.ToString()}/";
            var Data = new { name = Name };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPut, Data);
        }

        /// <summary>Create Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest CreateSquad(long FleetID, long WingID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/{WingID.ToString()}/squads/";
            var Data = new { };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, Data);
        }
    }
}