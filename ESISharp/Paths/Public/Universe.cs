using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Universe : ApiPath
    {
        internal Universe(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/universe/planets/{planet_id}/", WebMethods.GET)]
        public EsiRequest GetPlanetInfo(int planetid)
        {
            var path = new EsiRequestPath { "universe", "planets", planetid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/universe/stations/{station_id}/", WebMethods.GET)]
        public EsiRequest GetStationInfo(int stationid)
        {
            var path = new EsiRequestPath { "universe", "stations", stationid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetSystemInfo(int systemid)
            => GetSystemInfo(systemid, Language.English);

        [Path("/universe/systems/{system_id}/", WebMethods.GET)]
        public EsiRequest GetSystemInfo(int systemid, Language language)
        {
            var path = new EsiRequestPath { "universe", "systems", systemid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/universe/systems/", WebMethods.GET)]
        public EsiRequest GetSystems()
        {
            var path = new EsiRequestPath { "universe", "systems" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetTypeInfo(int typeid)
            => GetTypeInfo(typeid, Language.English);

        [Path("/universe/types/{type_id}/", WebMethods.GET)]
        public EsiRequest GetTypeInfo(int typeid, Language language)
        {
            var path = new EsiRequestPath { "universe", "types", typeid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetTypes()
            => GetTypes(1);

        [Path("/universe/types/", WebMethods.GET)]
        public EsiRequest GetTypes(int page)
        {
            var path = new EsiRequestPath { "universe", "types" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetItemGroups()
            => GetItemGroups(1);

        [Path("/universe/groups/", WebMethods.GET)]
        public EsiRequest GetItemGroups(int page)
        {
            var path = new EsiRequestPath { "universe", "groups" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetItemGroupInfo(int groupid)
            => GetItemGroupInfo(groupid, Language.English);

        [Path("/universe/groups/{group_id}/", WebMethods.GET)]
        public EsiRequest GetItemGroupInfo(int groupid, Language language)
        {
            var path = new EsiRequestPath { "universe", "groups", groupid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/universe/categories/", WebMethods.GET)]
        public EsiRequest GetItemCategories()
        {
            var path = new EsiRequestPath { "universe", "categories" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetItemCategoryInfo(int categoryid)
            => GetItemCategoryInfo(categoryid, Language.English);

        [Path("/universe/categories/{category_id}/", WebMethods.GET)]
        public EsiRequest GetItemCategoryInfo(int categoryid, Language language)
        {
            var path = new EsiRequestPath { "universe", "categories", categoryid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetItemNameAndCategory(int id)
            => GetItemNameAndCategory(new int[] { id });

        [Path("/universe/names/", WebMethods.POST)]
        public EsiRequest GetItemNameAndCategory(IEnumerable<int> ids)
        {
            var path = new EsiRequestPath { "universe", "names" };
            var data = new EsiRequestData
            {
                Body = ids
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/universe/structures/", WebMethods.GET)]
        public EsiRequest GetPublicStructures()
        {
            var path = new EsiRequestPath { "universe", "structures" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetCharacterRaces()
            => GetCharacterRaces(Language.English);

        [Path("/universe/races/", WebMethods.GET)]
        public EsiRequest GetCharacterRaces(Language language)
        {
            var path = new EsiRequestPath { "universe", "races" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetFactions()
            => GetFactions(Language.English);

        [Path("/universe/factions/", WebMethods.GET)]
        public EsiRequest GetFactions(Language language)
        {
            var path = new EsiRequestPath { "universe", "factions" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetBloodlines()
            => GetBloodlines(Language.English);

        [Path("/universe/bloodlines/", WebMethods.GET)]
        public EsiRequest GetBloodlines(Language language)
        {
            var path = new EsiRequestPath { "universe", "bloodlines" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/universe/regions/", WebMethods.GET)]
        public EsiRequest GetRegions()
        {
            var path = new EsiRequestPath { "universe", "regions" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetRegionInfo(int regionid)
            => GetRegionInfo(regionid, Language.English);

        [Path("/universe/regions/{region_id}/", WebMethods.GET)]
        public EsiRequest GetRegionInfo(int regionid, Language language)
        {
            var path = new EsiRequestPath { "universe", "regions", regionid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/universe/constellations/", WebMethods.GET)]
        public EsiRequest GetConstellations()
        {
            var path = new EsiRequestPath { "universe", "constellations" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetConstellationInfo(int constellationid)
            => GetConstellationInfo(constellationid, Language.English);

        [Path("/universe/constellations/{constellation_id}/", WebMethods.GET)]
        public EsiRequest GetConstellationInfo(int constellationid, Language language)
        {
            var path = new EsiRequestPath { "universe", "constellations", constellationid.ToString() };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/universe/moons/{moon_id}/", WebMethods.GET)]
        public EsiRequest GetMoonInfo(int moonid)
        {
            var path = new EsiRequestPath { "universe", "moons", moonid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/universe/stargates/{stargate_id}/", WebMethods.GET)]
        public EsiRequest GetStargateInfo(int stargateid)
        {
            var path = new EsiRequestPath { "universe", "stargates", stargateid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/universe/graphics/", WebMethods.GET)]
        public EsiRequest GetGraphics()
        {
            var path = new EsiRequestPath { "universe", "graphics" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/universe/graphics/{graphic_id}/", WebMethods.GET)]
        public EsiRequest GetGraphicInfo(int graphicid)
        {
            var path = new EsiRequestPath { "universe", "graphics", graphicid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/universe/system_jumps/", WebMethods.GET)]
        public EsiRequest GetSystemJumps()
        {
            var path = new EsiRequestPath { "universe", "system_jumps" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/universe/system_kills/", WebMethods.GET)]
        public EsiRequest GetSystemKills()
        {
            var path = new EsiRequestPath { "universe", "system_kills" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/universe/stars/{star_id}/", WebMethods.GET)]
        public EsiRequest GetStarInfo(int starid)
        {
            var path = new EsiRequestPath { "universe", "stars", starid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetAncestries()
            => GetAncestries(Language.English);

        [Path("/universe/ancestries/", WebMethods.GET)]
        public EsiRequest GetAncestries(Language language)
        {
            var path = new EsiRequestPath { "universe", "ancestries" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        [Path("/universe/asteroid_belts/{asteroid_belt_id}/", WebMethods.GET)]
        public EsiRequest GetAsteroidBeltInfo(int beltid)
        {
            var path = new EsiRequestPath { "universe", "asteroid_belts", beltid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetIds(string item)
            => GetIds(new List<string> { item });

        [Path("/universe/ids/", WebMethods.POST)]
        public EsiRequest GetIds(IEnumerable<string> items)
        {
            var path = new EsiRequestPath { "universe", "ids" };
            var data = new EsiRequestData
            {
                Body = items
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }
    }
}
