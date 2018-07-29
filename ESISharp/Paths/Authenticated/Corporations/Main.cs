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

namespace ESISharp.Paths.Authenticated.Corporations
{
    public class Main : Public.Corporations
    {
        public Assets Assets { get; }
        public Bookmarks Bookmarks { get; }
        public Contacts Contacts { get; }
        public Contracts Contracts { get; }
        public FactionWarfare FactionWarfare { get; }
        public Industry Industry { get; }
        public Killmails Killmails { get; }
        public Markets Markets { get; }
        public PlanetaryInteraction PlanetaryInteraction { get; }
        public Wallet Wallet { get; }

        internal Main(EsiConnection esiconnection) : base(esiconnection)
        {
            Assets = new Assets(esiconnection);
            Bookmarks = new Bookmarks(esiconnection);
            Contacts = new Contacts(esiconnection);
            Contracts = new Contracts(esiconnection);
            FactionWarfare = new FactionWarfare(esiconnection);
            Industry = new Industry(esiconnection);
            Killmails = new Killmails(esiconnection);
            Markets = new Markets(esiconnection);
            PlanetaryInteraction = new PlanetaryInteraction(esiconnection);
            Wallet = new Wallet(esiconnection);
        }

        public EsiRequest GetBlueprints(int corporationid)
            => GetBlueprints(corporationid, 1);

        [Path("/corporations/{corporation_id}/blueprints/", WebMethods.GET)]
        public EsiRequest GetBlueprints(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "blueprints" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetContainerLogs(int corporationid)
            => GetContainerLogs(corporationid, 1);

        [Path("/corporations/{corporation_id}/containers/logs/", WebMethods.GET)]
        public EsiRequest GetContainerLogs(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "containers", "logs" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/corporations/{corporation_id}/divisions/", WebMethods.GET)]
        public EsiRequest GetDivisions(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "divisions" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/corporations/{corporation_id}/facilities/", WebMethods.GET)]
        public EsiRequest GetFacilities(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "facilities" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetMedals(int corporationid)
            => GetMedals(corporationid, 1);

        [Path("/corporations/{corporation_id}/medals/", WebMethods.GET)]
        public EsiRequest GetMedals(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "medals" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetMedalsIssued(int corporationid)
            => GetMedalsIssued(corporationid, 1);

        [Path("/corporations/{corporation_id}/medals/issued/", WebMethods.GET)]
        public EsiRequest GetMedalsIssued(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "medals", "issued" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/corporations/{corporation_id}/members/", WebMethods.GET)]
        public EsiRequest GetMembers(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "members" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/corporations/{corporation_id}/members/limit/", WebMethods.GET)]
        public EsiRequest GetMembersLimit(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "members", "limit" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/corporations/{corporation_id}/members/titles/", WebMethods.GET)]
        public EsiRequest GetMembersTitles(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "members", "titles" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/corporations/{corporation_id}/membertracking/", WebMethods.GET)]
        public EsiRequest GetMemberTracking(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "membertracking" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/corporations/{corporation_id}/roles/", WebMethods.GET)]
        public EsiRequest GetRoles(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "roles" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetRolesHistory(int corporationid)
            => GetRolesHistory(corporationid, 1);

        [Path("/corporations/{corporation_id}/roles/history/", WebMethods.GET)]
        public EsiRequest GetRolesHistory(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "roles", "history" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetShareholders(int corporationid)
            => GetShareholders(corporationid, 1);

        [Path("/corporations/{corporation_id}/shareholders/", WebMethods.GET)]
        public EsiRequest GetShareholders(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "shareholders" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetStandings(int corporationid)
            => GetStandings(corporationid, 1);

        [Path("/corporations/{corporation_id}/standings/", WebMethods.GET)]
        public EsiRequest GetStandings(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "standings" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetStarbases(int corporationid)
            => GetStarbases(corporationid, 1);

        [Path("/corporations/{corporation_id}/starbases/", WebMethods.GET)]
        public EsiRequest GetStarbases(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "starbases" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/corporations/{corporation_id}/starbases/{starbase_id}/", WebMethods.GET)]
        public EsiRequest GetStarbasesDetail(int corporationid, int starbaseid, int systemid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "starbases", starbaseid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["system_id"] = systemid
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetStructures(int corporationid)
            => GetStructures(corporationid, Language.English, 1);

        public EsiRequest GetStructures(int corporationid, Language language)
            => GetStructures(corporationid, language, 1);

        public EsiRequest GetStructures(int corporationid, int page)
            => GetStructures(corporationid, Language.English, page);

        [Path("/corporations/{corporation_id}/structures/", WebMethods.GET)]
        public EsiRequest GetStructures(int corporationid, Language language, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "structures" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value,
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/corporations/{corporation_id}/titles/", WebMethods.GET)]
        public EsiRequest GetTitles(int corporationid)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "titles" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
