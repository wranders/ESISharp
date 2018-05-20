using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Skills : ApiPath
    {
        internal Skills(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/attributes/", WebMethods.GET)]
        public EsiRequest GetAttributes(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "attributes" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/skillqueue/", WebMethods.GET)]
        public EsiRequest GetSkillQueue(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "skillqueue" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/skills/", WebMethods.GET)]
        public EsiRequest GetSkills(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "skills" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
