using ESISharp.Web;

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
        /// <returns>EsiRequest</returns>
        public EsiRequest GetSchematicInfo(int SchematicID)
        {
            var Path = $"/universe/schematics/{SchematicID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
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