using ESISharp.Enumerations;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESISharp.ESIPath
{
    /// <summary>Public Search paths</summary>
    public class Search
    {
        protected ESIEve EasyObject;

        internal Search(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query)
        {
            return SearchPublic(Query, new List<string>() { SearchCategory.All.Value }, false, Language.English);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, bool Strict)
        {
            return SearchPublic(Query, new List<string>() { SearchCategory.All.Value }, Strict, Language.English);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, SearchCategory Category)
        {
            return SearchPublic(Query, new List<string>() { Category.Value }, false, Language.English);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, string Category)
        {
            return SearchPublic(Query, new List<string>() { Category }, false, Language.English);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, IEnumerable<SearchCategory> Categories)
        {
            return SearchPublic(Query, Categories.Select(c => c.ToString()).ToList(), false, Language.English);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, IEnumerable<string> Categories)
        {
            return SearchPublic(Query, Categories, false, Language.English);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, SearchCategory Category, bool Strict)
        {
            return SearchPublic(Query, new List<string>() { Category.Value }, Strict, Language.English);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, string Category, bool Strict)
        {
            return SearchPublic(Query, new List<string>() { Category }, Strict, Language.English);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, IEnumerable<SearchCategory> Categories, bool Strict)
        {
            return SearchPublic(Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language.English);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, IEnumerable<string> Categories, bool Strict)
        {
            return SearchPublic(Query, Categories, Strict, Language.English);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, SearchCategory Category, bool Strict, Language Language)
        {
            return SearchPublic(Query, new List<string>() { Category.Value }, Strict, Language.Value);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, string Category, bool Strict, Language Language)
        {
            return SearchPublic(Query, new List<string>() { Category }, Strict, Language.Value);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, IEnumerable<SearchCategory> Categories, bool Strict, Language Language)
        {
            return SearchPublic(Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language.Value);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categoired to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, IEnumerable<string> Categories, bool Strict, Language Language)
        {
            return SearchPublic(Query, Categories, Strict, Language.Value);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, SearchCategory Category, bool Strict, string Language)
        {
            return SearchPublic(Query, new List<string>() { Category.Value }, Strict, Language);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, string Category, bool Strict, string Language)
        {
            return SearchPublic(Query, new List<string>() { Category }, Strict, Language);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, IEnumerable<SearchCategory> Categories, bool Strict, string Language)
        {
            return SearchPublic(Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, IEnumerable<string> Categories, bool Strict, string Language)
        {
            return SearchPublicAsync(Query, Categories, Strict, Language).Result;
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query)
        {
            return await SearchPublicAsync(Query, new List<string>() { SearchCategory.All.Value }, false, Language.English).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, bool Strict)
        {
            return await SearchPublicAsync(Query, new List<string>() { SearchCategory.All.Value }, Strict, Language.English).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, SearchCategory Category)
        {
            return await SearchPublicAsync(Query, new List<string>() { Category.Value }, false, Language.English).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, string Category)
        {
            return await SearchPublicAsync(Query, new List<string>() { Category }, false, Language.English).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, IEnumerable<SearchCategory> Categories)
        {
            return await SearchPublicAsync(Query, Categories.Select(c => c.ToString()).ToList(), false, Language.English).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, IEnumerable<string> Categories)
        {
            return await SearchPublicAsync(Query, Categories, false, Language.English).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, SearchCategory Category, bool Strict)
        {
            return await SearchPublicAsync(Query, new List<string>() { Category.Value }, Strict, Language.English).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, string Category, bool Strict)
        {
            return await SearchPublicAsync(Query, new List<string>() { Category }, Strict, Language.English).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, IEnumerable<SearchCategory> Categories, bool Strict)
        {
            return await SearchPublicAsync(Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language.English).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, IEnumerable<string> Categories, bool Strict)
        {
            return await SearchPublicAsync(Query, Categories, Strict, Language.English).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, SearchCategory Category, bool Strict, Language Language)
        {
            return await SearchPublicAsync(Query, new List<string>() { Category.Value }, Strict, Language.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, string Category, bool Strict, Language Language)
        {
            return await SearchPublicAsync(Query, new List<string>() { Category }, Strict, Language.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, IEnumerable<SearchCategory> Categories, bool Strict, Language Language)
        {
            return await SearchPublicAsync(Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categoired to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, IEnumerable<string> Categories, bool Strict, Language Language)
        {
            return await SearchPublicAsync(Query, Categories, Strict, Language.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, SearchCategory Category, bool Strict, string Language)
        {
            return await SearchPublicAsync(Query, new List<string>() { Category.Value }, Strict, Language).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, string Category, bool Strict, string Language)
        {
            return await SearchPublicAsync(Query, new List<string>() { Category }, Strict, Language).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, IEnumerable<SearchCategory> Categories, bool Strict, string Language)
        {
            return await SearchPublicAsync(Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language).ConfigureAwait(false);
        }

        /// <summary>Perform Public Search</summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchPublicAsync(string Query, IEnumerable<string> Categories, bool Strict, string Language)
        {
            var Path = "/search/";
            var Data = new
            {
                search = Query,
                categories = Categories.ToArray(),
                language = Language,
                strict = Strict
            };
            var EsiRequest = new EsiRequest(EasyObject, Path);
            return await EsiRequest.GetAsync(Data).ConfigureAwait(false);
        }
    }

    /// <summary>Public and Authenticated Search paths</summary>
    public class AuthSearch : Search
    {
        internal AuthSearch(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { SearchCategory.All.Value }, false, Language.English.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, bool Strict)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { SearchCategory.All.Value }, Strict, Language.English.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, SearchCategory Category)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { Category.Value }, false, Language.English.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, IEnumerable<SearchCategory> Categories)
        {
            return SearchAuthenticated(CharacterID, Query, Categories.Select(c => c.ToString()).ToList(), false, Language.English.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, string Category)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { Category }, false, Language.English.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, IEnumerable<string> Categories)
        {
            return SearchAuthenticated(CharacterID, Query, Categories, false, Language.English.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, SearchCategory Category, bool Strict)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { Category.Value }, Strict, Language.English.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, IEnumerable<SearchCategory> Categories, bool Strict)
        {
            return SearchAuthenticated(CharacterID, Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language.English.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, string Category, bool Strict)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { Category }, Strict, Language.English.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, IEnumerable<string> Categories, bool Strict)
        {
            return SearchAuthenticated(CharacterID, Query, Categories, Strict, Language.English.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, SearchCategory Category, bool Strict, Language Language)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { Category.Value }, Strict, Language.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, IEnumerable<SearchCategory> Categories, bool Strict, Language Language)
        {
            return SearchAuthenticated(CharacterID, Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, string Category, bool Strict, Language Language)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { Category }, Strict, Language.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, IEnumerable<string> Categories, bool Strict, Language Language)
        {
            return SearchAuthenticated(CharacterID, Query, Categories, Strict, Language.Value);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, SearchCategory Category, bool Strict, string Language)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { Category.Value }, Strict, Language);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, IEnumerable<SearchCategory> Categories, bool Strict, string Language)
        {
            return SearchAuthenticated(CharacterID, Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, string Category, bool Strict, string Language)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { Category }, Strict, Language);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, IEnumerable<string> Categories, bool Strict, string Language)
        {
            return SearchAuthenticatedAsync(CharacterID, Query, Categories, Strict, Language).Result;
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, new List<string>() { SearchCategory.All.Value }, false, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, bool Strict)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, new List<string>() { SearchCategory.All.Value }, Strict, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, SearchCategory Category)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, new List<string>() { Category.Value }, false, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, IEnumerable<SearchCategory> Categories)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, Categories.Select(c => c.ToString()).ToList(), false, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, string Category)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, new List<string>() { Category }, false, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, IEnumerable<string> Categories)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, Categories, false, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, SearchCategory Category, bool Strict)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, new List<string>() { Category.Value }, Strict, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, IEnumerable<SearchCategory> Categories, bool Strict)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, string Category, bool Strict)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, new List<string>() { Category }, Strict, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, IEnumerable<string> Categories, bool Strict)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, Categories, Strict, Language.English.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, SearchCategory Category, bool Strict, Language Language)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, new List<string>() { Category.Value }, Strict, Language.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, IEnumerable<SearchCategory> Categories, bool Strict, Language Language)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, string Category, bool Strict, Language Language)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, new List<string>() { Category }, Strict, Language.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, IEnumerable<string> Categories, bool Strict, Language Language)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, Categories, Strict, Language.Value).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, SearchCategory Category, bool Strict, string Language)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, new List<string>() { Category.Value }, Strict, Language).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, IEnumerable<SearchCategory> Categories, bool Strict, string Language)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, Categories.Select(c => c.ToString()).ToList(), Strict, Language).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, string Category, bool Strict, string Language)
        {
            return await SearchAuthenticatedAsync(CharacterID, Query, new List<string>() { Category }, Strict, Language).ConfigureAwait(false);
        }

        /// <summary>Perform Authenticated search</summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public async Task<string> SearchAuthenticatedAsync(int CharacterID, string Query, IEnumerable<string> Categories, bool Strict, string Language)
        {
            var Path = $"/characters/{CharacterID.ToString()}/search/";
            var Data = new
            {
                search = Query,
                categories = Categories.ToArray(),
                language = Language,
                strict = Strict
            };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync(Data).ConfigureAwait(false);
        }
    }
}