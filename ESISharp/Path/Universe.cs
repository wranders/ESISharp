using ESISharp.Enumerations;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESISharp.ESIPath
{
    /// <summary>Public Universe paths</summary>
    public class Universe
    {
        protected ESIEve EasyObject;

        internal Universe(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Bloodlines</summary>
        /// <returns>JSON Object containing Bloodline base attributes</returns>
        public string GetBloodlines()
        {
            return GetBloodlinesAsync().Result;
        }

        /// <summary>Get Bloodlines</summary>
        /// <returns>JSON Object containing Bloodline base attributes</returns>
        public async Task<string> GetBloodlinesAsync()
        {
            var Path = "/universe/bloodlines/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Item Categories</summary>
        /// <returns>JSON Array of item categories</returns>
        public string GetItemCategories()
        {
            return GetItemCategoriesAsync().Result;
        }

        /// <summary>Get Item Categories</summary>
        /// <returns>JSON Array of item categories</returns>
        public async Task<string> GetItemCategoriesAsync()
        {
            var Path = "/universe/categories/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Item Category information</summary>
        /// <param name="CategoryID">(Int32) Catergory ID</param>
        /// <returns>JSON Object containing category name, groups, ID and published status</returns>
        public string GetItemCategoryInfo(int CategoryID)
        {
            return GetItemCategoryInfoAsync(CategoryID).Result;
        }

        /// <summary>Get Item Category information</summary>
        /// <param name="CategoryID">(Int32) Catergory ID</param>
        /// <returns>JSON Object containing category name, groups, ID and published status</returns>
        public async Task<string> GetItemCategoryInfoAsync(int CategoryID)
        {
            var Path = $"/universe/categories/{CategoryID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Constellations</summary>
        /// <returns>JSON Array of constellation IDs</returns>
        public string GetConstellations()
        {
            return GetConstellationsAsync().Result;
        }

        /// <summary>Get Constellations</summary>
        /// <returns>JSON Array of constellation IDs</returns>
        public async Task<string> GetConstellationsAsync()
        {
            var Path = "/universe/constellations/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Constellation Information</summary>
        /// <param name="ConstellationID">(Int32) Constellation ID</param>
        /// <returns>JSON Object containing constellatio name, constellation ID, region ID, array of system IDs, and an object containing XYZ position.</returns>
        public string GetConstellationInfo(int ConstellationID)
        {
            return GetConstellationInfoAsync(ConstellationID).Result;
        }

        /// <summary>Get Constellation Information</summary>
        /// <param name="ConstellationID">(Int32) Constellation ID</param>
        /// <returns>JSON Object containing constellatio name, constellation ID, region ID, array of system IDs, and an object containing XYZ position.</returns>
        public async Task<string> GetConstellationInfoAsync(int ConstellationID)
        {
            var Path = $"/universe/constellations/{ConstellationID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Factions</summary>
        /// <returns>JSON Object containing Faction base attributes</returns>
        public string GetFactions()
        {
            return GetFactionsAsync().Result;
        }

        /// <summary>Get Factions</summary>
        /// <returns>JSON Object containing Faction base attributes</returns>
        public async Task<string> GetFactionsAsync()
        {
            var Path = "/universe/factions/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Graphic IDs</summary>
        /// <returns>JSON Array of graphic ID integers</returns>
        public string GetGraphics()
        {
            return GetGraphicsAsync().Result;
        }

        /// <summary>Get Graphic IDs</summary>
        /// <returns>JSON Array of graphic ID integers</returns>
        public async Task<string> GetGraphicsAsync()
        {
            var Path = "/universe/graphics/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Graphic information</summary>
        /// <param name="GraphicID">(Int32) Graphic ID</param>
        /// <returns>JSON Object containing the graphic ID and graphic file path</returns>
        public string GetGraphicInformation(int GraphicID)
        {
            return GetGraphicInformationAsync(GraphicID).Result;
        }

        /// <summary>Get Graphic information</summary>
        /// <param name="GraphicID">(Int32) Graphic ID</param>
        /// <returns>JSON Object containing the graphic ID and graphic file path</returns>
        public async Task<string> GetGraphicInformationAsync(int GraphicID)
        {
            var Path = $"/universe/graphics/{GraphicID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Item Groups</summary>
        /// <returns>JSON Array containing Item Group IDs</returns>
        public string GetItemGroups()
        {
            return GetItemGroups(1);
        }

        /// <summary>Get Item Groups</summary>
        /// /// <param name="Page">(Int32) Page Number</param>
        /// <returns>JSON Array containing Item Group IDs</returns>
        public string GetItemGroups(int Page)
        {
            return GetItemGroupsAsync(Page).Result;
        }

        /// <summary>Get Item Groups</summary>
        /// <returns>JSON Array containing Item Group IDs</returns>
        public async Task<string> GetItemGroupsAsync()
        {
            return await GetItemGroupsAsync(1).ConfigureAwait(false);
        }

        /// <summary>Get Item Groups</summary>
        /// /// <param name="Page">(Int32) Page Number</param>
        /// <returns>JSON Array containing Item Group IDs</returns>
        public async Task<string> GetItemGroupsAsync(int Page)
        {
            var Path = "/universe/groups/";
            var Data = new { page = Page.ToString() };
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Get Item Group Information</summary>
        /// <param name="GroupID">(Int32) Item Group ID</param>
        /// <returns>JSON Object containing Group name, Group ID, Category ID, containing types, and published status</returns>
        public string GetItemGroupInfo(int GroupID)
        {
            return GetItemGroupInfoAsync(GroupID).Result;
        }

        /// <summary>Get Item Group Information</summary>
        /// <param name="GroupID">(Int32) Item Group ID</param>
        /// <returns>JSON Object containing Group name, Group ID, Category ID, containing types, and published status</returns>
        public async Task<string> GetItemGroupInfoAsync(int GroupID)
        {
            var Path = $"/universe/groups/{GroupID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Moon Information</summary>
        /// <param name="MoonID">(Int32) Moon ID</param>
        /// <returns>JSON Object containing moon ID, moon name, system ID, and an object containing XYZ position.</returns>
        public string GetMoonInformation(int MoonID)
        {
            return GetMoonInformationAsync(MoonID).Result;
        }

        /// <summary>Get Moon Information</summary>
        /// <param name="MoonID">(Int32) Moon ID</param>
        /// <returns>JSON Object containing moon ID, moon name, system ID, and an object containing XYZ position.</returns>
        public async Task<string> GetMoonInformationAsync(int MoonID)
        {
            var Path = $"/universe/moons/{MoonID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Type Name and Category</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Array with Object containing Category ID, Type ID, and name</returns>
        public string GetTypeNamesAndCategories(int TypeID)
        {
            return GetTypeNamesAndCategories(new List<int>() { TypeID });
        }

        /// <summary>Get Type Names and Categories</summary>
        /// <param name="TypeID">(Int32 List) Type ID</param>
        /// <returns>JSON Array of Objects containing Category ID, Type ID, and name</returns>
        public string GetTypeNamesAndCategories(IEnumerable<int> TypeIDs)
        {
            return GetTypeNamesAndCategoriesAsync(TypeIDs).Result;
        }

        /// <summary>Get Type Name and Category</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Array with Object containing Category ID, Type ID, and name</returns>
        public async Task<string> GetTypeNamesAndCategoriesAsync(int TypeID)
        {
            return await GetTypeNamesAndCategoriesAsync(new List<int>() { TypeID }).ConfigureAwait(false);
        }

        /// <summary>Get Type Names and Categories</summary>
        /// <param name="TypeID">(Int32 List) Type ID</param>
        /// <returns>JSON Array of Objects containing Category ID, Type ID, and name</returns>
        public async Task<string> GetTypeNamesAndCategoriesAsync(IEnumerable<int> TypeIDs)
        {
            var Path = "/universe/names/";
            var Data = new { ids = TypeIDs.ToArray() };
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.PostAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Get Planet Information</summary>
        /// <param name="PlanetID">(Int32) Planet ID</param>
        /// <returns>JSON Object conatining planet name, planet ID, system ID, type ID, and an objecting containing XYZ position.</returns>
        public string GetPlanetInformation(int PlanetID)
        {
            return GetPlanetInformationAsync(PlanetID).Result;
        }

        /// <summary>Get Planet Information</summary>
        /// <param name="PlanetID">(Int32) Planet ID</param>
        /// <returns>JSON Object conatining planet name, planet ID, system ID, type ID, and an objecting containing XYZ position.</returns>
        public async Task<string> GetPlanetInformationAsync(int PlanetID)
        {
            var Path = $"/universe/planets/{PlanetID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Races</summary>
        /// <returns>JSON Array of objects containing Race's Alliance ID, description, name, and Race ID</returns>
        public string GetRaces()
        {
            return GetRacesAsync().Result;
        }

        /// <summary>Get Races</summary>
        /// <returns>JSON Array of objects containing Race's Alliance ID, description, name, and Race ID</returns>
        public async Task<string> GetRacesAsync()
        {
            var Path = "/universe/races/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Regions</summary>
        /// <returns>JSON Array containing region IDs</returns>
        public string GetRegions()
        {
            return GetRegionsAsync().Result;
        }

        /// <summary>Get Regions</summary>
        /// <returns>JSON Array containing region IDs</returns>
        public async Task<string> GetRegionsAsync()
        {
            var Path = "/universe/regions/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Region Information</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <returns>JSON Object containing region ID, name, description, and an array of constellations.</returns>
        public string GetRegionInformation(int RegionID)
        {
            return GetRegionInformationAsync(RegionID).Result;
        }

        /// <summary>Get Region Information</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <returns>JSON Object containing region ID, name, description, and an array of constellations.</returns>
        public async Task<string> GetRegionInformationAsync(int RegionID)
        {
            var Path = $"/universe/regions/{RegionID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Stargate Information</summary>
        /// <param name="StargateID">(Int32) Stargate ID</param>
        /// <returns>JSON Object containing stargate ID, system ID, type ID, name, object containing destination system ID and stargate ID, and an object containing XYZ position.</returns>
        public string GetStargateInformation(int StargateID)
        {
            return GetStargateInformationAsync(StargateID).Result;
        }

        /// <summary>Get Stargate Information</summary>
        /// <param name="StargateID">(Int32) Stargate ID</param>
        /// <returns>JSON Object containing stargate ID, system ID, type ID, name, object containing destination system ID and stargate ID, and an object containing XYZ position.</returns>
        public async Task<string> GetStargateInformationAsync(int StargateID)
        {
            var Path = $"/universe/stargates/{StargateID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Station Information</summary>
        /// <param name="StationID">(Int32) Station ID</param>
        /// <returns>JSON Object containing station name and solar system ID where it's located</returns>
        public string GetStationInfo(int StationID)
        {
            return GetStationInfoAsync(StationID).Result;
        }

        /// <summary>Get Station Information</summary>
        /// <param name="StationID">(Int32) Station ID</param>
        /// <returns>JSON Object containing station name and solar system ID where it's located</returns>
        public async Task<string> GetStationInfoAsync(int StationID)
        {
            var Path = $"/universe/stations/{StationID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Public Structures</summary>
        /// <returns>JSON Array containing Structure IDs</returns>
        public string GetPublicStructures()
        {
            return GetPublicStructuresAsync().Result;
        }

        /// <summary>Get Public Structures</summary>
        /// <returns>JSON Array containing Structure IDs</returns>
        public async Task<string> GetPublicStructuresAsync()
        {
            var Path = "/universe/structures/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Solar Systems</summary>
        /// <returns>JSON Array containing system IDs</returns>
        public string GetSystems()
        {
            return GetSystemsAsync().Result;
        }

        /// <summary>Get Solar Systems</summary>
        /// <returns>JSON Array containing system IDs</returns>
        public async Task<string> GetSystemsAsync()
        {
            var Path = "/universe/systems/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Solar System Information</summary>
        /// <param name="SystemID">(Int32) System ID</param>
        /// <returns>JSON Object containing solar system name</returns>
        public string GetSystemInfo(int SystemID)
        {
            return GetSystemInfoAsync(SystemID).Result;
        }

        /// <summary>Get Solar System Information</summary>
        /// <param name="SystemID">(Int32) System ID</param>
        /// <returns>JSON Object containing solar system name</returns>
        public async Task<string> GetSystemInfoAsync(int SystemID)
        {
            var Path = $"/universe/systems/{SystemID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get All Type IDs (First Page)</summary>
        /// <returns>JSON Array containing Type IDs</returns>
        public string GetTypes()
        {
            return GetTypes(1);
        }

        /// <summary>Get All Type IDs (Specified Page)</summary>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>JSON Array containing Type IDs</returns>
        public string GetTypes(int Page)
        {
            return GetTypesAsync(Page).Result;
        }

        /// <summary>Get All Type IDs (First Page)</summary>
        /// <returns>JSON Array containing Type IDs</returns>
        public async Task<string> GetTypesAsync()
        {
            return await GetTypesAsync(1).ConfigureAwait(false);
        }

        /// <summary>Get All Type IDs (Specified Page)</summary>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>JSON Array containing Type IDs</returns>
        public async Task<string> GetTypesAsync(int Page)
        {
            var Path = "/universe/types/";
            var Data = new { page = Page.ToString() };
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Get Type Information</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Object containing Type description, Group ID, name, Type ID, and published status</returns>
        public string GetTypeInfo(int TypeID)
        {
            return GetTypeInfo(TypeID, Language.English.Value);
        }

        /// <summary>Get Type Information</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing Type description, Group ID, name, Type ID, and published status</returns>
        public string GetTypeInfo(int TypeID, Language Language)
        {
            return GetTypeInfo(TypeID, Language.Value);
        }

        /// <summary>Get Type Information</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing Type description, Group ID, name, Type ID, and published status</returns>
        public string GetTypeInfo(int TypeID, string Language)
        {
            return GetTypeInfoAsync(TypeID, Language).Result;
        }

        /// <summary>Get Type Information</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Object containing Type description, Group ID, name, Type ID, and published status</returns>
        public async Task<string> GetTypeInfoAsync(int TypeID)
        {
            return await GetTypeInfoAsync(TypeID, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Get Type Information</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing Type description, Group ID, name, Type ID, and published status</returns>
        public async Task<string> GetTypeInfoAsync(int TypeID, Language Language)
        {
            return await GetTypeInfoAsync(TypeID, Language.Value).ConfigureAwait(false);
        }

        /// <summary>Get Type Information</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing Type description, Group ID, name, Type ID, and published status</returns>
        public async Task<string> GetTypeInfoAsync(int TypeID, string Language)
        {
            var Path = $"/universe/types/{TypeID.ToString()}/";
            var Data = new { language = Language };
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync(Data).ConfigureAwait(false);
        }
    }

    /// <summary>Public and Authenticated Universe paths</summary>
    public class AuthUniverse : Universe
    {
        internal AuthUniverse(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Structure Information</summary>
        /// <remarks>Requires SSO Authentication with "read_structurs" scope.</remarks>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <returns>JSON Object containing structure name and solar system ID where it's located</returns>
        public string GetStructureInfo(long StructureID)
        {
            return GetStructureInfoAsync(StructureID).Result;
        }

        /// <summary>Get Structure Information</summary>
        /// <remarks>Requires SSO Authentication with "read_structurs" scope.</remarks>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <returns>JSON Object containing structure name and solar system ID where it's located</returns>
        public async Task<string> GetStructureInfoAsync(long StructureID)
        {
            var Path = $"/universe/structures/{StructureID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }
    }
}