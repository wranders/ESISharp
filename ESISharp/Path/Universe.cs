using ESISharp.Enumerations;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.ESIPath
{
    /// <summary>
    /// Public Universe paths
    /// </summary>
    public class Universe
    {
        protected EveSwagger SwaggerObject;

        internal Universe(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Bloodlines
        /// </summary>
        /// <returns>JSON Object containing Bloodline base attributes</returns>
        public string GetBloodlines()
        {
            var Path = "/universe/bloodlines/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Item Categories
        /// </summary>
        /// <returns>JSON Array of item categories</returns>
        public string GetItemCategories()
        {
            var Path = "/universe/categories/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Item Category information
        /// </summary>
        /// <param name="CategoryID">(Int32) Catergory ID</param>
        /// <returns>JSON Object containing category name, groups, ID and published status</returns>
        public string GetItemCategoryInfo(int CategoryID)
        {
            var Path = $"/universe/categories/{CategoryID.ToString()}/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Factions
        /// </summary>
        /// <returns>JSON Object containing Faction base attributes</returns>
        public string GetFactions()
        {
            var Path = "/universe/factions/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Item Groups
        /// </summary>
        /// <returns>JSON Array containing Item Group IDs</returns>
        public string GetItemGroups()
        {
            var Path = "/universe/groups/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Item Group Information
        /// </summary>
        /// <param name="CategoryID">(Int32) Item Group ID</param>
        /// <returns>JSON Object containing Group name, Group ID, Category ID, containing types, and published status</returns>
        public string GetItemGroupInfo(int GroupID)
        {
            var Path = $"/universe/groups/{GroupID.ToString()}/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Type Name and Category
        /// </summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Array with Object containing Category ID, Type ID, and name</returns>
        public string GetTypeNamesAndCategories(int TypeID)
        {
            return GetTypeNamesAndCategories(new List<int>() { TypeID });
        }

        /// <summary>
        /// Get Type Names and Categories
        /// </summary>
        /// <param name="TypeID">(Int32 List) Type ID</param>
        /// <returns>JSON Array of Objects containing Category ID, Type ID, and name</returns>
        public string GetTypeNamesAndCategories(List<int> TypeIDs)
        {
            var Path = "/universe/names/";
            var Data = new { ids = TypeIDs.ToArray() };
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Post(Data);
        }

        /// <summary>
        /// Get Races
        /// </summary>
        /// <returns>JSON Array of objects containing Race's Alliance ID, description, name, and Race ID</returns>
        public string GetRaces()
        {
            var Path = "/universe/races/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Station Information
        /// </summary>
        /// <param name="StationID">(Int32) Station ID</param>
        /// <returns>JSON Object containing station name and solar system ID where it's located</returns>
        public string GetStationInfo(int StationID)
        {
            var Path = $"/universe/stations/{StationID.ToString()}/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Public Structures
        /// </summary>
        /// <returns>JSON Array containing Structure IDs</returns>
        public string GetPublicStructures()
        {
            var Path = "/universe/structures/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Solar System Information
        /// </summary>
        /// <param name="SystemID">(Int32) System ID</param>
        /// <returns>JSON Object containing solar system name</returns>
        public string GetSystemInfo(int SystemID)
        {
            var Path = $"/universe/systems/{SystemID.ToString()}/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get All Type IDs (First Page)
        /// </summary>
        /// <returns>JSON Array containing Type IDs</returns>
        public string GetTypes()
        {
            return GetTypes(1);
        }

        /// <summary>
        /// Get All Type IDs (Specified Page)
        /// </summary>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>JSON Array containing Type IDs</returns>
        public string GetTypes(int Page)
        {
            var Path = "/universe/types/";
            var Data = new { page = Page.ToString() };
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get(Data);
        }

        /// <summary>
        /// Get Type Information
        /// </summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>JSON Object containing Type description, Group ID, name, Type ID, and published status</returns>
        public string GetTypeInfo(int TypeID)
        {
            return GetTypeInfo(TypeID, Language.English.Value);
        }

        /// <summary>
        /// Get Type Information
        /// </summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing Type description, Group ID, name, Type ID, and published status</returns>
        public string GetTypeInfo(int TypeID, Language Language)
        {
            return GetTypeInfo(TypeID, Language.Value);
        }

        /// <summary>
        /// Get Type Information
        /// </summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing Type description, Group ID, name, Type ID, and published status</returns>
        public string GetTypeInfo(int TypeID, string Language)
        {
            var Path = $"/universe/types/{TypeID.ToString()}/";
            var Data = new { language = Language };
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get(Data);
        }
    }

    /// <summary>
    /// Public and Authenticated Universe paths
    /// </summary>
    public class AuthUniverse : Universe
    {
        internal AuthUniverse(EveSwagger e) : base(e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get Structure Information
        /// </summary>
        /// <remarks>Requires SSO Authentication with "read_structurs" scope.</remarks>
        /// <param name="StructureID">(Int64) Structure ID</param>
        /// <returns>JSON Object containing structure name and solar system ID where it's located</returns>
        public string GetStructureInfo(long StructureID)
        {
            var Path = $"/universe/structures/{StructureID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}