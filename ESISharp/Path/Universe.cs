using ESISharp.Enumerations;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

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
        /// <returns>EsiRequest</returns>
        public EsiRequest GetBloodlines()
        {
            var Path = "/universe/bloodlines/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Item Categories</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetItemCategories()
        {
            var Path = "/universe/categories/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Item Category information</summary>
        /// <param name="CategoryID">(Int32) Catergory ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetItemCategoryInfo(int CategoryID)
        {
            var Path = $"/universe/categories/{CategoryID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Constellations</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetConstellations()
        {
            var Path = "/universe/constellations/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Constellation Information</summary>
        /// <param name="ConstellationID">(Int32) Constellation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetConstellationInfo(int ConstellationID)
        {
            var Path = $"/universe/constellations/{ConstellationID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Factions</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetFactions()
        {
            var Path = "/universe/factions/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Graphic IDs</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetGraphics()
        {
            var Path = "/universe/graphics/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Graphic information</summary>
        /// <param name="GraphicID">(Int32) Graphic ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetGraphicInformation(int GraphicID)
        {
            var Path = $"/universe/graphics/{GraphicID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Item Groups</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetItemGroups()
        {
            return GetItemGroups(1);
        }

        /// <summary>Get Item Groups</summary>
        /// /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetItemGroups(int Page)
        {
            var Path = "/universe/groups/";
            var Data = new { page = Page.ToString() };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }

        /// <summary>Get Item Group Information</summary>
        /// <param name="GroupID">(Int32) Item Group ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetItemGroupInfo(int GroupID)
        {
            var Path = $"/universe/groups/{GroupID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Moon Information</summary>
        /// <param name="MoonID">(Int32) Moon ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMoonInformation(int MoonID)
        {
            var Path = $"/universe/moons/{MoonID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Type Name and Category</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTypeNamesAndCategories(int TypeID)
        {
            return GetTypeNamesAndCategories(new int[] { TypeID });
        }

        /// <summary>Get Type Names and Categories</summary>
        /// <param name="TypeID">(Int32 List) Type ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTypeNamesAndCategories(IEnumerable<int> TypeIDs)
        {
            var Path = "/universe/names/";
            var Data = TypeIDs.ToArray();
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Post, Data);
        }

        /// <summary>Get Planet Information</summary>
        /// <param name="PlanetID">(Int32) Planet ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPlanetInformation(int PlanetID)
        {
            var Path = $"/universe/planets/{PlanetID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Races</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRaces()
        {
            var Path = "/universe/races/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Regions</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRegions()
        {
            var Path = "/universe/regions/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Region Information</summary>
        /// <param name="RegionID">(Int32) Region ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRegionInformation(int RegionID)
        {
            var Path = $"/universe/regions/{RegionID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Stargate Information</summary>
        /// <param name="StargateID">(Int32) Stargate ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStargateInformation(int StargateID)
        {
            var Path = $"/universe/stargates/{StargateID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Station Information</summary>
        /// <param name="StationID">(Int32) Station ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStationInfo(int StationID)
        {
            var Path = $"/universe/stations/{StationID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Public Structures</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPublicStructures()
        {
            var Path = "/universe/structures/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get System Jumps</summary>
        /// <returns></returns>
        public EsiRequest GetSystemJumps()
        {
            var Path = "/universe/system_jumps/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get System Kills (NPC, Ship, & Pod)</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetSystemKills()
        {
            var Path = "/universe/system_kills/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Solar Systems</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetSystems()
        {
            var Path = "/universe/systems/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get Solar System Information</summary>
        /// <param name="SystemID">(Int32) System ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetSystemInfo(int SystemID)
        {
            var Path = $"/universe/systems/{SystemID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get All Type IDs (First Page)</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTypes()
        {
            return GetTypes(1);
        }

        /// <summary>Get All Type IDs (Specified Page)</summary>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTypes(int Page)
        {
            var Path = "/universe/types/";
            var Data = new { page = Page.ToString() };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }

        /// <summary>Get Type Information</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTypeInfo(int TypeID)
        {
            return GetTypeInfo(TypeID, Language.English.Value);
        }

        /// <summary>Get Type Information</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTypeInfo(int TypeID, Language Language)
        {
            return GetTypeInfo(TypeID, Language.Value);
        }

        /// <summary>Get Type Information</summary>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetTypeInfo(int TypeID, string Language)
        {
            var Path = $"/universe/types/{TypeID.ToString()}/";
            var Data = new { language = Language };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
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
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStructureInfo(long StructureID)
        {
            var Path = $"/universe/structures/{StructureID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}