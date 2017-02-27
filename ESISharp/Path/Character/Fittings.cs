using ESISharp.Object;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Fitting paths</summary>
    public class CharacterFittings
    {
        protected ESIEve EasyObject;

        internal CharacterFittings(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Character's Fittings</summary>
        /// <remarks>Requires SSO Authentication, using "read_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing fits</returns>
        public string GetAll(int CharacterID)
        {
            return GetAllAsync(CharacterID).Result;
        }

        /// <summary>Get All Character's Fittings</summary>
        /// <remarks>Requires SSO Authentication, using "read_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing fits</returns>
        public async Task<string> GetAllAsync(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/fittings/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Create A Fitting</summary>
        /// <remarks>Requires SSO Authentication, using "write_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="FittingName">(String) Fitting Name</param>
        /// <param name="Description">(String) Fitting Description</param>
        /// <param name="ShipTypeId">(Int32) Ship Type ID</param>
        /// <param name="FittingItems">(FittingItem List) Fitting Items</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string Create(int CharacterID, string FittingName, string Description, int ShipTypeId, List<FittingItem> FittingItems)
        {
            var Fitting = new Fitting(FittingName, Description, ShipTypeId, FittingItems);
            return Create(CharacterID, Fitting);
        }

        /// <summary>Create A Fitting</summary>
        /// <remarks>Requires SSO Authentication, using "write_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Fitting">(Fitting) Fitting</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string Create(int CharacterID, Fitting Fitting)
        {
            return CreateAsync(CharacterID, Fitting).Result;
        }

        /// <summary>Create A Fitting</summary>
        /// <remarks>Requires SSO Authentication, using "write_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="FittingName">(String) Fitting Name</param>
        /// <param name="Description">(String) Fitting Description</param>
        /// <param name="ShipTypeId">(Int32) Ship Type ID</param>
        /// <param name="FittingItems">(FittingItem List) Fitting Items</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public async Task<string> CreateAsync(int CharacterID, string FittingName, string Description, int ShipTypeId, List<FittingItem> FittingItems)
        {
            var Fitting = new Fitting(FittingName, Description, ShipTypeId, FittingItems);
            return await CreateAsync(CharacterID, Fitting).ConfigureAwait(false);
        }

        /// <summary>Create A Fitting</summary>
        /// <remarks>Requires SSO Authentication, using "write_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Fitting">(Fitting) Fitting</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public async Task<string> CreateAsync(int CharacterID, Fitting Fitting)
        {
            var Path = $"/characters/{CharacterID.ToString()}/fittings/";
            var Data = new
            {
                name = Fitting.Name,
                description = Fitting.Description,
                ship_type_id = Fitting.ShipTypeID,
                items = Fitting.Items.Select(item => new { type_id = item.TypeID, quantity = item.Quantity, flag = item.Flag }).ToArray()
            };
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PostAsync(Data).ConfigureAwait(false);
        }

        /// <summary>Delete A Fitting</summary>
        /// <remarks>Requires SSO Authentication, using "write_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="FittingID">(Int32) Fitting ID</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string Delete(int CharacterID, int FittingID)
        {
            return DeleteAsync(CharacterID, FittingID).Result;
        }

        /// <summary>Delete A Fitting</summary>
        /// <remarks>Requires SSO Authentication, using "write_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="FittingID">(Int32) Fitting ID</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public async Task<string> DeleteAsync(int CharacterID, int FittingID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/fittings/{FittingID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.DeleteAsync().ConfigureAwait(false);
        }
    }
}
