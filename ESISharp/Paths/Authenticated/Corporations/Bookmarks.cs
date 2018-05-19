using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated.Corporations
{
    public class Bookmarks : ApiPath
    {
        internal Bookmarks(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetAll(int corporationid)
            => GetAll(corporationid, 1);

        [Path("/corporations/{corporation_id}/bookmarks/", WebMethods.GET)]
        public EsiRequest GetAll(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "bookmarks" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest GetFolders(int corporationid)
            => GetFolders(corporationid, 1);

        [Path("/corporations/{corporation_id}/bookmarks/folders/", WebMethods.GET)]
        public EsiRequest GetFolders(int corporationid, int page)
        {
            var path = new EsiRequestPath { "corporations", corporationid.ToString(), "bookmarks", "folders" };
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
