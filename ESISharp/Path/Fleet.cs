using ESISharp.Enumerations;
using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Authenticated Fleet paths</summary>
    public class Fleet
    {
        protected EveSwagger SwaggerObject;

        internal Fleet(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>Get Fleet Information</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>JSON Object containing free move status, registered status, voice enabled status, and MOTD</returns>
        public string GetInformation(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>Update Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MOTD">(String) Fleet Message of the Day (MOTD)</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string Update(long FleetID, string MOTD)
        {
            return Update(FleetID, MOTD, null);
        }

        /// <summary>Update Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="FreeMove">(Boolean) Free-Move status</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string Update(long FleetID, bool FreeMove)
        {
            return Update(FleetID, null, FreeMove);
        }

        /// <summary>Update Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MOTD">(String) Fleet Message of the Day (MOTD)</param>
        /// <param name="FreeMove">(Boolean) Free-Move status</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string Update(long FleetID, string MOTD, bool? FreeMove)
        {
            var Path = $"/fleets/{FleetID.ToString()}/";
            var Data = new { motd = MOTD, is_free_move = FreeMove };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Put(Data);
        }

        /// <summary>Get Fleet Members</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>JSON Array of Objects containing member information</returns>
        public string GetMembers(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>Invite a Character to Fleet as Squad Member</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string Invite(long FleetID, int CharacterID)
        {
            return Invite(FleetID, CharacterID, FleetRole.SquadMember.Value, null, null);
        }

        /// <summary>Invite a Character to Fleet as Squad Member in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string Invite(long FleetID, int CharacterID, long WingID)
        {
            return Invite(FleetID, CharacterID, FleetRole.SquadMember.Value, WingID, null);
        }

        /// <summary>Invite a Character to Fleet as Squad Member in the specified Wing and Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string Invite(long FleetID, int CharacterID, long WingID, long SquadID)
        {
            return Invite(FleetID, CharacterID, FleetRole.SquadMember.Value, WingID, SquadID);
        }

        /// <summary>Invite a Character to Fleet with a specific role</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(FleetRole) Role</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string Invite(long FleetID, int CharacterID, FleetRole Role)
        {
            return Invite(FleetID, CharacterID, Role.Value, null, null);
        }

        /// <summary>Invite a Character to Fleet with a specific role</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(String) Role</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string Invite(long FleetID, int CharacterID, string Role)
        {
            return Invite(FleetID, CharacterID, Role, null, null);
        }

        /// <summary>Invite a Character to Fleet with a specific role in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(FleetRole) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string Invite(long FleetID, int CharacterID, FleetRole Role, long WingID)
        {
            return Invite(FleetID, CharacterID, Role.Value, WingID, null);
        }

        /// <summary>Invite a Character to Fleet with a specific role in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(String) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string Invite(long FleetID, int CharacterID, string Role, long WingID)
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
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string Invite(long FleetID, int CharacterID, FleetRole Role, long WingID, long SquadID)
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
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string Invite(long FleetID, int CharacterID, string Role, long? WingID, long? SquadID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/";
            var Data = new
            {
                character_id = CharacterID,
                role = Role,
                squad_id = SquadID,
                wing_id = WingID
            };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Post(Data);
        }

        /// <summary>Kick Member from Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string KickMember(long FleetID, int MemberID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/{MemberID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Delete();
        }

        /// <summary>Move Fleet Member</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string MoveMember(long FleetID, int MemberID, long WingID, long SquadID)
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
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string MoveMember(long FleetID, int MemberID, FleetRole Role, long WingID, long SquadID)
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
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string MoveMember(long FleetID, int MemberID, string Role, long WingID, long SquadID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/{MemberID.ToString()}/";
            var Data = new
            {
                role = Role,
                squad_id = SquadID,
                wing_id = WingID
            };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Put(Data);
        }

        /// <summary>Delete Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string DeleteSquad(long FleetID, long SquadID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/squads/{SquadID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Delete();
        }

        /// <summary>Rename Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <param name="Name">(String) Squad Name</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string RenameSquad(long FleetID, long SquadID, string Name)
        {
            var Path = $"/fleets/{FleetID.ToString()}/squads/{SquadID.ToString()}/";
            var Data = new
            {
                name = Name
            };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Put(Data);
        }

        /// <summary>Get Wings in Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string GetWings(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>Create a Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string CreateWing(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Post(new { });
        }

        /// <summary>Delete Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string DeleteWing(long FleetID, long WingID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/{WingID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Delete();
        }

        /// <summary>Rename Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="Name">(String) Wing Name</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string RenameWing(long FleetID, long WingID, string Name)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/{WingID.ToString()}/";
            var Data = new { name = Name };
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Put(Data);
        }

        /// <summary>Create Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string CreateSquad(long FleetID, long WingID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/{WingID.ToString()}/squads/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Post(new { });
        }
    }
}