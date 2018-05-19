using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Paths.Authenticated
{
    public class Fleets : ApiPath
    {
        internal Fleets(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/fleets/{fleet_id}/", WebMethods.GET)]
        public EsiRequest GetInformation(long fleetid)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest Update(long fleetid, string motd)
            => Update(fleetid, motd, -1);

        public EsiRequest Update(long fleetid, bool freemove)
            => Update(fleetid, null, -1);

        [Path("/fleets/{fleet_id}/", WebMethods.PUT)]
        public EsiRequest Update(long fleetid, string motd, bool freemove)
            => Update(fleetid, motd, Convert.ToInt32(freemove));

        private EsiRequest Update(long fleetid, string motd, int freemove)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString() };
            var data = new EsiRequestData
            {
                BodyKvp = new Dictionary<string, dynamic>
                {
                    ["motd"] = motd
                }
            };
            if (freemove == 0)
            {
                data.BodyKvp["is_free_move"] = false;
            }
            else if (freemove > 1)
            {
                data.BodyKvp["is_free_move"] = true;
            }
            return new EsiRequest(EsiConnection, path, WebMethods.PUT, data);
        }

        public EsiRequest GetMembers(long fleetid)
            => GetMembers(fleetid, Language.English);

        [Path("/fleets/{fleet_id}/members/", WebMethods.GET)]
        public EsiRequest GetMembers(long fleetid, Language language)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "members" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest InviteMember(long fleetid, int characterid, FleetRole role)
            => InviteMember(fleetid, characterid, role, -1, -1);

        public EsiRequest InviteMember(long fleetid, int characterid, FleetRole role, long wingid)
            => InviteMember(fleetid, characterid, role, wingid, -1);

        [Path("/fleets/{fleet_id}/members/", WebMethods.POST)]
        public EsiRequest InviteMember(long fleetid, int characterid, FleetRole role, long wingid, long squadid)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "members" };
            var data = new EsiRequestData
            {
                BodyKvp = new Dictionary<string, dynamic>
                {
                    ["character_id"] = characterid,
                    ["role"] = role.Value
                }
            };
            if (wingid >= 0)
                data.BodyKvp["wing_id"] = wingid;
            if (squadid >= 0)
                data.BodyKvp["squad_id"] = squadid;
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/fleets/{fleet_id}/members/{member_id}/", WebMethods.DELETE)]
        public EsiRequest KickMember(long fleetid, int memberid)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "members", memberid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.DELETE);
        }

        public EsiRequest MoveMember(long fleetid, int characterid, FleetRole role)
            => MoveMember(fleetid, characterid, role, -1, -1);

        public EsiRequest MoveMember(long fleetid, int characterid, FleetRole role, long wingid)
            => MoveMember(fleetid, characterid, role, wingid, -1);

        [Path("/fleets/{fleet_id}/members/{member_id}/", WebMethods.PUT)]
        public EsiRequest MoveMember(long fleetid, int memberid, FleetRole role, long wingid, long squadid)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "members", memberid.ToString() };
            var data = new EsiRequestData
            {
                BodyKvp = new Dictionary<string, dynamic>
                {
                    ["role"] = role.Value
                }
            };
            if (wingid >= 0)
                data.BodyKvp["wing_id"] = wingid;
            if (squadid >= 0)
                data.BodyKvp["squad_id"] = squadid;
            return new EsiRequest(EsiConnection, path, WebMethods.PUT, data);
        }

        [Path("/fleets/{fleet_id}/squads/{squad_id}/", WebMethods.DELETE)]
        public EsiRequest DeleteSquad(long fleetid, long squadid)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "squads", squadid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.DELETE);
        }

        [Path("/fleets/{fleet_id}/squads/{squad_id}/", WebMethods.PUT)]
        public EsiRequest RenameSquad(long fleetid, long squadid, string name)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "squads", squadid.ToString() };
            var data = new EsiRequestData
            {
                BodyKvp = new Dictionary<string, dynamic>
                {
                    ["name"] = name
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.PUT, data);
        }

        public EsiRequest GetWings(long fleetid)
            => GetWings(fleetid, Language.English);

        [Path("/fleets/{fleet_id}/wings/", WebMethods.GET)]
        public EsiRequest GetWings(long fleetid, Language language)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "wings" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/fleets/{fleet_id}/wings/", WebMethods.POST)]
        public EsiRequest CreateWing(long fleetid)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "wings" };
            return new EsiRequest(EsiConnection, path, WebMethods.POST);
        }

        [Path("/fleets/{fleet_id}/wings/{wing_id}/", WebMethods.DELETE)]
        public EsiRequest DeleteWing(long fleetid, long wingid)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "wings", wingid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.DELETE);
        }

        [Path("/fleets/{fleet_id}/wings/{wing_id}/", WebMethods.PUT)]
        public EsiRequest RenameWing(long fleetid, long wingid, string name)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "squads", wingid.ToString() };
            var data = new EsiRequestData
            {
                BodyKvp = new Dictionary<string, dynamic>
                {
                    ["name"] = name
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.PUT, data);
        }

        [Path("/fleets/{fleet_id}/wings/{wing_id}/squads/", WebMethods.POST)]
        public EsiRequest CreateSquad(long fleetid, long wingid)
        {
            var path = new EsiRequestPath { "fleets", fleetid.ToString(), "wings", wingid.ToString(), "squads" };
            return new EsiRequest(EsiConnection, path, WebMethods.POST);
        }
    }
}
