using ESISharp.Enumerations;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.ESIPath
{
    /// <summary>
    /// Public Search paths
    /// </summary>
    public class Search
    {
        protected EveSwagger SwaggerObject;

        internal Search(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query)
        {
            return SearchPublic(Query, new List<string>() { SearchCategory.All.Value }, false, Language.English);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, bool Strict)
        {
            return SearchPublic(Query, new List<string>() { SearchCategory.All.Value }, Strict, Language.English);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, SearchCategory Category)
        {
            return SearchPublic(Query, new List<string>() { Category.Value }, false, Language.English);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, string Category)
        {
            return SearchPublic(Query, new List<string>() { Category }, false, Language.English);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, List<SearchCategory> Categories)
        {
            return SearchPublic(Query, Categories.ConvertAll(c => c.ToString()).ToList(), false, Language.English);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, List<string> Categories)
        {
            return SearchPublic(Query, Categories, false, Language.English);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, SearchCategory Category, bool Strict)
        {
            return SearchPublic(Query, new List<string>() { Category.Value }, Strict, Language.English);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, string Category, bool Strict)
        {
            return SearchPublic(Query, new List<string>() { Category }, Strict, Language.English);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, List<SearchCategory> Categories, bool Strict)
        {
            return SearchPublic(Query, Categories.ConvertAll(c => c.ToString()).ToList(), Strict, Language.English);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, List<string> Categories, bool Strict)
        {
            return SearchPublic(Query, Categories, Strict, Language.English);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, SearchCategory Category, bool Strict, Language Language)
        {
            return SearchPublic(Query, new List<string>() { Category.Value }, Strict, Language.Value);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, string Category, bool Strict, Language Language)
        {
            return SearchPublic(Query, new List<string>() { Category }, Strict, Language.Value);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, List<SearchCategory> Categories, bool Strict, Language Language)
        {
            return SearchPublic(Query, Categories.ConvertAll(c => c.ToString()).ToList(), Strict, Language.Value);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categoired to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, List<string> Categories, bool Strict, Language Language)
        {
            return SearchPublic(Query, Categories, Strict, Language.Value);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, SearchCategory Category, bool Strict, string Language)
        {
            return SearchPublic(Query, new List<string>() { Category.Value }, Strict, Language);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, string Category, bool Strict, string Language)
        {
            return SearchPublic(Query, new List<string>() { Category }, Strict, Language);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, List<SearchCategory> Categories, bool Strict, string Language)
        {
            return SearchPublic(Query, Categories.ConvertAll(c => c.ToString()).ToList(), Strict, Language);
        }

        /// <summary>
        /// Perform Public Search
        /// </summary>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchPublic(string Query, List<string> Categories, bool Strict, string Language)
        {
            string Path = "/search/";
            object Data = new
            {
                search = Query,
                categories = Categories.ToArray(),
                language = Language,
                strict = Strict
            };
            EsiRequest EsiRequest = new EsiRequest(SwaggerObject, Path);
            return EsiRequest.Get(Data);
        }
    }

    /// <summary>
    /// Public and Authenticated Search paths
    /// </summary>
    public class AuthSearch : Search
    {
        internal AuthSearch(EveSwagger e) : base(e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { SearchCategory.All.Value }, false, Language.English.Value);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, bool Strict)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { SearchCategory.All.Value }, Strict, Language.English.Value);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(SearchCategory) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, SearchCategory Category)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { Category.Value }, false, Language.English.Value);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, List<SearchCategory> Categories)
        {
            return SearchAuthenticated(CharacterID, Query, Categories.ConvertAll(c => c.ToString()).ToList(), false, Language.English.Value);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Category">(String) Category to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, string Category)
        {
            return SearchAuthenticated(CharacterID, Query, new List<string>() { Category }, false, Language.English.Value);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, List<string> Categories)
        {
            return SearchAuthenticated(CharacterID, Query, Categories, false, Language.English.Value);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
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

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, List<SearchCategory> Categories, bool Strict)
        {
            return SearchAuthenticated(CharacterID, Query, Categories.ConvertAll(c => c.ToString()).ToList(), Strict, Language.English.Value);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
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

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, List<string> Categories, bool Strict)
        {
            return SearchAuthenticated(CharacterID, Query, Categories, Strict, Language.English.Value);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
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

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, List<SearchCategory> Categories, bool Strict, Language Language)
        {
            return SearchAuthenticated(CharacterID, Query, Categories.ConvertAll(c => c.ToString()).ToList(), Strict, Language.Value);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
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

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(Language) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, List<string> Categories, bool Strict, Language Language)
        {
            return SearchAuthenticated(CharacterID, Query, Categories, Strict, Language.Value);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
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

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(SearchCategory List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, List<SearchCategory> Categories, bool Strict, string Language)
        {
            return SearchAuthenticated(CharacterID, Query, Categories.ConvertAll(c => c.ToString()).ToList(), Strict, Language);
        }

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
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

        /// <summary>
        /// Perform Authenticated search
        /// </summary>
        /// <remarks>Requires SSO Authentication, including "search_structures" scope</remarks>
        /// <param name="CharacterID">(Int32) Chracter ID</param>
        /// <param name="Query">(String) Search Query</param>
        /// <param name="Categories">(String List) Categories to search</param>
        /// <param name="Strict">(Boolean) Strictly match query</param>
        /// <param name="Language">(String) Language</param>
        /// <returns>JSON Object containing search results</returns>
        public string SearchAuthenticated(int CharacterID, string Query, List<string> Categories, bool Strict, string Language)
        {
            string Path = $"/characters/{CharacterID.ToString()}/search/";
            object Data = new
            {
                search = Query,
                categories = Categories.ToArray(),
                language = Language,
                strict = Strict
            };
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get(Data);
        }
    }
}