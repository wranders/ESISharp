using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Characters : ApiPath
    {
        internal Characters(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/", WebMethods.GET)]
        public EsiRequest GetInformation(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetAffiliation(int characterid)
            => GetAffiliation(new int[] { characterid });

        [Path("/characters/affiliation/", WebMethods.POST)]
        public EsiRequest GetAffiliation(IEnumerable<int> characterids)
        {
            var path = new EsiRequestPath { "characters", "affiliation" };
            var data = new EsiRequestData
            {
                Body = characterids
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/characters/{character_id}/portrait/", WebMethods.GET)]
        public EsiRequest GetPortraits(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "portrait" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/corporationhistory/", WebMethods.GET)]
        public EsiRequest GetCorporationHistory(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "corporationhistory" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
