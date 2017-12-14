using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Public
{
    public class Dogma : ApiPath
    {
        internal Dogma(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/dogma/attributes/", WebMethods.GET)]
        public EsiRequest GetAttributes()
        {
            var path = new EsiRequestPath { "dogma", "attributes" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/dogma/attributes/{attribute_id}/", WebMethods.GET)]
        public EsiRequest GetAttributeInformation(int attributeid)
        {
            var path = new EsiRequestPath { "dogma", "attributes", attributeid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/dogma/effects/", WebMethods.GET)]
        public EsiRequest GetEffects()
        {
            var path = new EsiRequestPath { "dogma", "effects" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/dogma/effects/{effect_id}/", WebMethods.GET)]
        public EsiRequest GetEffectInformation(int effectid)
        {
            var path = new EsiRequestPath { "dogma", "effects", effectid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
