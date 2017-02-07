using ESISharp.Object;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.ESIPath.Character
{
    /// <summary>
    /// Authenticated Character Fitting paths
    /// </summary>
    public class CharacterFittings
    {
        protected EveSwagger SwaggerObject;

        internal CharacterFittings(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get All Character's Fittings
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing fits</returns>
        public string GetAll(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/fittings/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>
        /// Create A Fitting
        /// </summary>
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

        /// <summary>
        /// Create A Fitting
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "write_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Fitting">(Fitting) Fitting</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string Create(int CharacterID, Fitting Fitting)
        {
            var Path = $"/characters/{CharacterID.ToString()}/fittings/";
            var Data = new
            {
                name = Fitting.Name,
                description = Fitting.Description,
                ship_type_id = Fitting.ShipTypeID,
                items = Fitting.Items.Select(item => new { type_id = item.TypeID, quantity = item.Quantity, flag = item.Flag }).ToArray()
            };
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Post(Data);
        }

        /// <summary>
        /// Delete A Fitting
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "write_fittings" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="FittingID">(Int32) Fitting ID</param>
        /// <returns>Normally nothing, error if one is encountered</returns>
        public string Delete(int CharacterID, int FittingID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/fittings/{FittingID.ToString()}/";
            var EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Delete();
        }
    }
}
