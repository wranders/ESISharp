using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Bookmarks : ApiPath
    {
        internal Bookmarks(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetAll(int characterid)
            => GetAll(characterid, 1);

        [Path("/characters/{character_id}/bookmarks/", WebMethods.GET)]
        public EsiRequest GetAll(int characterid, int page)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "bookmarks" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetFolders(int characterid)
            => GetFolders(characterid, 1);

        [Path("/characters/{character_id}/bookmarks/folders/", WebMethods.GET)]
        public EsiRequest GetFolders(int characterid, int page)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "bookmarks", "folders" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
