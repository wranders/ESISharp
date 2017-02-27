using ESISharp.Enumerations;
using ESISharp.Web;
using System.Threading.Tasks;

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
        /// <returns>JSON Object containing free move status, registered status, voice enabled status, and MOTD</returns>
        public string GetInformation(long FleetID)
        {
            return GetInformationAsync(FleetID).Result;
        }

        /// <summary>Get Fleet Information</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>JSON Object containing free move status, registered status, voice enabled status, and MOTD</returns>
        public async Task<string> GetInformationAsync(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
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
            return UpdateAsync(FleetID, MOTD, FreeMove).Result;
        }

        /// <summary>Update Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MOTD">(String) Fleet Message of the Day (MOTD)</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public async Task<string> UpdateAsync(long FleetID, string MOTD)
        {
            return await UpdateAsync(FleetID, MOTD, null).ConfigureAwait(false);
        }

        /// <summary>Update Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="FreeMove">(Boolean) Free-Move status</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public async Task<string> UpdateAsync(long FleetID, bool FreeMove)
        {
            return await UpdateAsync(FleetID, null, FreeMove).ConfigureAwait(false);
        }

        /// <summary>Update Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MOTD">(String) Fleet Message of the Day (MOTD)</param>
        /// <param name="FreeMove">(Boolean) Free-Move status</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public async Task<string> UpdateAsync(long FleetID, string MOTD, bool? FreeMove)
        {
            var Path = $"/fleets/{FleetID.ToString()}/";
            var Data = new { motd = MOTD, is_free_move = FreeMove };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PutAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Get Fleet Members</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>JSON Array of Objects containing member information</returns>
        public string GetMembers(long FleetID)
        {
            return GetMembersAsync(FleetID).Result;
        }

        /// <summary>Get Fleet Members</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>JSON Array of Objects containing member information</returns>
        public async Task<string> GetMembersAsync(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
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
            return InviteAsync(FleetID, CharacterID, Role, WingID, SquadID).Result;
        }

        /// <summary>Invite a Character to Fleet as Squad Member</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> InviteAsync(long FleetID, int CharacterID)
        {
            return await InviteAsync(FleetID, CharacterID, FleetRole.SquadMember.Value, null, null).ConfigureAwait(false);
        }

        /// <summary>Invite a Character to Fleet as Squad Member in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> InviteAsync(long FleetID, int CharacterID, long WingID)
        {
            return await InviteAsync(FleetID, CharacterID, FleetRole.SquadMember.Value, WingID, null).ConfigureAwait(false);
        }

        /// <summary>Invite a Character to Fleet as Squad Member in the specified Wing and Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> InviteAsync(long FleetID, int CharacterID, long WingID, long SquadID)
        {
            return await InviteAsync(FleetID, CharacterID, FleetRole.SquadMember.Value, WingID, SquadID).ConfigureAwait(false);
        }

        /// <summary>Invite a Character to Fleet with a specific role</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(FleetRole) Role</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> InviteAsync(long FleetID, int CharacterID, FleetRole Role)
        {
            return await InviteAsync(FleetID, CharacterID, Role.Value, null, null).ConfigureAwait(false);
        }

        /// <summary>Invite a Character to Fleet with a specific role</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(String) Role</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> InviteAsync(long FleetID, int CharacterID, string Role)
        {
            return await InviteAsync(FleetID, CharacterID, Role, null, null).ConfigureAwait(false);
        }

        /// <summary>Invite a Character to Fleet with a specific role in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(FleetRole) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> InviteAsync(long FleetID, int CharacterID, FleetRole Role, long WingID)
        {
            return await InviteAsync(FleetID, CharacterID, Role.Value, WingID, null).ConfigureAwait(false);
        }

        /// <summary>Invite a Character to Fleet with a specific role in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(String) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> InviteAsync(long FleetID, int CharacterID, string Role, long WingID)
        {
            return await InviteAsync(FleetID, CharacterID, Role, WingID, null).ConfigureAwait(false);
        }

        /// <summary>Invite a Character to Fleet with a specific role in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(FleetRole) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> InviteAsync(long FleetID, int CharacterID, FleetRole Role, long WingID, long SquadID)
        {
            return await InviteAsync(FleetID, CharacterID, Role.Value, WingID, SquadID).ConfigureAwait(false);
        }

        /// <summary>Invite a Character to Fleet with a specific role in the specified Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Role">(String) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> InviteAsync(long FleetID, int CharacterID, string Role, long? WingID, long? SquadID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/";
            var Data = new
            {
                character_id = CharacterID,
                role = Role,
                squad_id = SquadID,
                wing_id = WingID
            };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PostAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Kick Member from Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string KickMember(long FleetID, int MemberID)
        {
            return KickMemberAsync(FleetID, MemberID).Result;
        }

        /// <summary>Kick Member from Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> KickMemberAsync(long FleetID, int MemberID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/{MemberID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.DeleteAsync().ConfigureAwait(false);
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
            return MoveMemberAsync(FleetID, MemberID, Role, WingID, SquadID).Result;
        }

        /// <summary>Move Fleet Member</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> MoveMemberAsync(long FleetID, int MemberID, long WingID, long SquadID)
        {
            return await MoveMemberAsync(FleetID, MemberID, FleetRole.SquadMember.Value, WingID, SquadID).ConfigureAwait(false);
        }

        /// <summary>Move Fleet Member</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <param name="Role">(FleetRole) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> MoveMemberAsync(long FleetID, int MemberID, FleetRole Role, long WingID, long SquadID)
        {
            return await MoveMemberAsync(FleetID, MemberID, Role.Value, WingID, SquadID).ConfigureAwait(false);
        }

        /// <summary>Move Fleet Member</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="MemberID">(Int32) Member's Character ID</param>
        /// <param name="Role">(String) Role</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> MoveMemberAsync(long FleetID, int MemberID, string Role, long WingID, long SquadID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/members/{MemberID.ToString()}/";
            var Data = new
            {
                role = Role,
                squad_id = SquadID,
                wing_id = WingID
            };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PutAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Delete Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string DeleteSquad(long FleetID, long SquadID)
        {
            return DeleteSquadAsync(FleetID, SquadID).Result;
        }

        /// <summary>Delete Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> DeleteSquadAsync(long FleetID, long SquadID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/squads/{SquadID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.DeleteAsync().ConfigureAwait(false);
        }

        /// <summary>Rename Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <param name="Name">(String) Squad Name</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string RenameSquad(long FleetID, long SquadID, string Name)
        {
            return RenameSquadAsync(FleetID, SquadID, Name).Result;
        }

        /// <summary>Rename Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="SquadID">(Int32) Squad ID</param>
        /// <param name="Name">(String) Squad Name</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> RenameSquadAsync(long FleetID, long SquadID, string Name)
        {
            var Path = $"/fleets/{FleetID.ToString()}/squads/{SquadID.ToString()}/";
            var Data = new
            {
                name = Name
            };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PutAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Get Wings in Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string GetWings(long FleetID)
        {
            return GetWingsAsync(FleetID).Result;
        }

        /// <summary>Get Wings in Fleet</summary>
        /// <remarks>Requires SSO Authentication, using "read_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> GetWingsAsync(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Create a Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string CreateWing(long FleetID)
        {
            return CreateWingAsync(FleetID).Result;
        }

        /// <summary>Create a Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> CreateWingAsync(long FleetID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PostAsync(new { }).ConfigureAwait(false);
        }

        /// <summary>Delete Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string DeleteWing(long FleetID, long WingID)
        {
            return DeleteWingAsync(FleetID, WingID).Result;
        }

        /// <summary>Delete Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> DeleteWingAsync(long FleetID, long WingID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/{WingID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.DeleteAsync().ConfigureAwait(false);
        }

        /// <summary>Rename Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="Name">(String) Wing Name</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string RenameWing(long FleetID, long WingID, string Name)
        {
            return RenameWingAsync(FleetID, WingID, Name).Result;
        }

        /// <summary>Rename Wing</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <param name="Name">(String) Wing Name</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> RenameWingAsync(long FleetID, long WingID, string Name)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/{WingID.ToString()}/";
            var Data = new { name = Name };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PutAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Create Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public string CreateSquad(long FleetID, long WingID)
        {
            return CreateSquadAsync(FleetID, WingID).Result;
        }

        /// <summary>Create Squad</summary>
        /// <remarks>Requires SSO Authentication, using "write_fleet" scope</remarks>
        /// <param name="FleetID">(Int64) Fleet ID</param>
        /// <param name="WingID">(Int32) Wing ID</param>
        /// <returns>Normally nothing, error is one was encountered</returns>
        public async Task<string> CreateSquadAsync(long FleetID, long WingID)
        {
            var Path = $"/fleets/{FleetID.ToString()}/wings/{WingID.ToString()}/squads/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PostAsync(new { }).ConfigureAwait(false);
        }
    }
}