using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.Paths.Public
{
    public class Search : ApiPath
    {
        internal Search(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest SubString(string searchquery, SearchCategory category)
        {
            return SubString(searchquery, new SearchCategory[] { category }, false, Language.English);
        }

        public EsiRequest SubString(string searchquery, IEnumerable<SearchCategory> categories)
        {
            return SubString(searchquery, categories, false, Language.English);
        }

        public EsiRequest SubString(string searchquery, SearchCategory category, bool strict)
        {
            return SubString(searchquery, new SearchCategory[] { category }, strict, Language.English);
        }

        public EsiRequest SubString(string searchquery, IEnumerable<SearchCategory> categories, bool strict)
        {
            return SubString(searchquery, categories, strict, Language.English);
        }

        public EsiRequest SubString(string searchquery, SearchCategory category, bool strict, Language language)
        {
            return SubString(searchquery, new SearchCategory[] { category }, strict, language);
        }

        [Path("/search/", WebMethods.GET)]
        public EsiRequest SubString(string searchquery, IEnumerable<SearchCategory> categories, bool strict, Language language)
        {
            var path = new EsiRequestPath { "search" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["categories"] = string.Join(",", categories.Select(cat => cat.Value)),
                    ["language"] = language.Value,
                    ["search"] = searchquery,
                    ["strict"] = strict
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
