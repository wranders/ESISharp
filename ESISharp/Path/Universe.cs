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
            string Path = "/universe/bloodlines/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Item Categories
        /// </summary>
        /// <returns>JSON Array of item categories</returns>
        public string GetItemCategories()
        {
            string Path = "/universe/categories/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Item Category information
        /// </summary>
        /// <param name="CategoryID">(Int32) Catergory ID</param>
        /// <returns>JSON Object containing category name, groups, ID and published status</returns>
        public string GetItemCategoryInfo(int CategoryID)
        {
            string Path = $"/universe/categories/{CategoryID.ToString()}/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Factions
        /// </summary>
        /// <returns>JSON Object containing Faction base attributes</returns>
        public string GetFactions()
        {
            string Path = "/universe/factions/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Item Groups
        /// </summary>
        /// <returns>JSON Array containing Item Group IDs</returns>
        public string GetItemGroups()
        {
            string Path = "/universe/groups/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Item Group Information
        /// </summary>
        /// <param name="CategoryID">(Int32) Item Group ID</param>
        /// <returns>JSON Object containing Group name, Group ID, Category ID, containing types, and published status</returns>
        public string GetItemGroupInfo(int GroupID)
        {
            string Path = $"/universe/groups/{GroupID.ToString()}/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
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
            string Path = "/universe/names/";
            object Data = new { ids = TypeIDs.ToArray() };
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Post(Data);
        }

        /// <summary>
        /// Get Races
        /// </summary>
        /// <returns>JSON Array of objects containing Race's Alliance ID, description, name, and Race ID</returns>
        public string GetRaces()
        {
            string Path = "/universe/races/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Station Information
        /// </summary>
        /// <param name="StationID">(Int32) Station ID</param>
        /// <returns>JSON Object containing station name and solar system ID where it's located</returns>
        public string GetStationInfo(int StationID)
        {
            string Path = $"/universe/stations/{StationID.ToString()}/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Public Structures
        /// </summary>
        /// <returns>JSON Array containing Structure IDs</returns>
        public string GetPublicStructures()
        {
            string Path = "/universe/structures/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }

        /// <summary>
        /// Get Solar System Information
        /// </summary>
        /// <param name="SystemID">(Int32) System ID</param>
        /// <returns>JSON Object containing solar system name</returns>
        public string GetSystemInfo(int SystemID)
        {
            string Path = $"/universe/systems/{SystemID.ToString()}/";
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
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
            string Path = "/universe/types/";
            object Data = new { page = Page.ToString() };
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
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
            string Path = $"/universe/types/{TypeID.ToString()}/";
            object Data = new { language = Language };
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
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
            string Path = $"/universe/structures/{StructureID.ToString()}/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}