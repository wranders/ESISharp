using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Character : ApiPath
    {
        internal Character(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/", WebMethods.GET)]
        public EsiRequest GetInformation(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetAffiliation(int characterid)
        {
            return GetAffiliation(new int[] { characterid });
        }

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

        public EsiRequest GetNames(long characterid)
        {
            return GetNames(new long[] { characterid });
        }

        [Path("/characters/names/", WebMethods.GET)]
        public EsiRequest GetNames(IEnumerable<long> characterids)
        {
            var path = new EsiRequestPath { "characters", "names" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>()
                {
                    ["character_ids"] = characterids
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
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
