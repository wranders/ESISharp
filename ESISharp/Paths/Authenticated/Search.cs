using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated
{
    public class Search : ApiPath
    {
        internal Search(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest SubString(int characterid, string search, SearchCategory category)
            => SubString(characterid, search, new SearchCategory[] { category }, Language.English, false);

        public EsiRequest SubString(int characterid, string search, IEnumerable<SearchCategory> categories)
            => SubString(characterid, search, categories, Language.English, false);

        public EsiRequest SubString(int characterid, string search, SearchCategory category, Language language)
            => SubString(characterid, search, new SearchCategory[] { category }, language, false);

        public EsiRequest SubString(int characterid, string search, IEnumerable<SearchCategory> categories, Language language)
            => SubString(characterid, search, categories, language, false);

        public EsiRequest SubString(int characterid, string search, SearchCategory category, bool strict)
            => SubString(characterid, search, new SearchCategory[] { category }, Language.English, strict);

        public EsiRequest SubString(int characterid, string search, IEnumerable<SearchCategory> categories, bool strict)
            => SubString(characterid, search, categories, Language.English, strict);

        public EsiRequest SubString(int characterid, string search, SearchCategory category, Language language, bool strict)
            => SubString(characterid, search, new SearchCategory[] { category }, language, strict);

        [Path("/characters/{character_id}/search/", WebMethods.GET)]
        public EsiRequest SubString(int characterid, string search, IEnumerable<SearchCategory> categories, Language language, bool strict)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "search" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["categories"] = categories,
                    ["language"] = language.Value,
                    ["strict"] = strict
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
