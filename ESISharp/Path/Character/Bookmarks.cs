using ESISharp.Web;

namespace ESISharp.ESIPath.Character
{
    /// <summary>
    /// Authenticated Character Bookmark paths
    /// </summary>
    public class CharacterBookmarks
    {
        protected EveSwagger SwaggerObject;

        internal CharacterBookmarks(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Get All Character's Bookmarks
        /// </summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_bookmarks" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing bookmarks</returns>
        public string GetAll(int CharacterID)
        {
            string Path = $"/characters/{CharacterID.ToString()}/bookmarks/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>
        /// Get Character's Bookmark Folders
        /// </summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_bookmarks" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing folders</returns>
        public string GetFolders(int CharacterID)
        {
            string Path = $"/characters/{CharacterID.ToString()}/bookmarks/folders/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }
    }
}