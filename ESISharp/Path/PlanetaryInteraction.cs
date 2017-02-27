using ESISharp.Web;
using System.Threading.Tasks;

namespace ESISharp.ESIPath
{
    /// <summary>Public Planetary Interaction (PI) paths</summary>
    public class PlanetaryInteraction
    {
        protected ESIEve EasyObject;

        internal PlanetaryInteraction(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Planetary Interaction Schematic</summary>
        /// <param name="SchematicID">(Int32) Schematic ID</param>
        /// <returns>JSON Object containing Schematic name and cycle time</returns>
        public string GetSchematicInfo(int SchematicID)
        {
            return GetSchematicInfoAsync(SchematicID).Result;
        }

        /// <summary>Get Planetary Interaction Schematic</summary>
        /// <param name="SchematicID">(Int32) Schematic ID</param>
        /// <returns>JSON Object containing Schematic name and cycle time</returns>
        public async Task<string> GetSchematicInfoAsync(int SchematicID)
        {
            var Path = $"/universe/schematics/{SchematicID.ToString()}/";
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync().ConfigureAwait(false);
        }
    }

    /// <summary>Public and Authenticated Planetary Interaction (PI) paths</summary>
    public class AuthPlanetaryInteraction : PlanetaryInteraction
    {
        internal AuthPlanetaryInteraction(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}