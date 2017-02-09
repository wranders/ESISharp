using ESISharp.Web;

namespace ESISharp.ESIPath
{
    /// <summary>Public Planetary Interaction (PI) paths</summary>
    public class PlanetaryInteraction
    {
        protected EveSwagger SwaggerObject;

        internal PlanetaryInteraction(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>Get Planetary Interaction Schematic</summary>
        /// <param name="SchematicID">(Int32) Schematic ID</param>
        /// <returns>JSON Object containing Schematic name and cycle time</returns>
        public string GetSchematicInfo(int SchematicID)
        {
            var Path = $"/universe/schematics/{SchematicID.ToString()}/";
            var EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get();
        }
    }

    /// <summary>Public and Authenticated Planetary Interaction (PI) paths</summary>
    public class AuthPlanetaryInteraction : PlanetaryInteraction
    {
        internal AuthPlanetaryInteraction(EveSwagger e) : base(e)
        {
            SwaggerObject = e;
        }
    }
}