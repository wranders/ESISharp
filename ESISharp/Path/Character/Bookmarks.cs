using ESISharp.Web;
using System.Threading.Tasks;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Bookmark paths</summary>
    public class CharacterBookmarks
    {
        protected ESIEve EasyObject;

        internal CharacterBookmarks(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get All Character's Bookmarks</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_bookmarks" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing bookmarks</returns>
        public string GetAll(int CharacterID)
        {
            return GetAllAsync(CharacterID).Result;
        }

        /// <summary>Get All Character's Bookmarks</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_bookmarks" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing bookmarks</returns>
        public async Task<string> GetAllAsync(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/bookmarks/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }

        /// <summary>Get Character's Bookmark Folders</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_bookmarks" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing folders</returns>
        public string GetFolders(int CharacterID)
        {
            return GetFoldersAsync(CharacterID).Result;
        }

        /// <summary>Get Character's Bookmark Folders</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_bookmarks" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing folders</returns>
        public async Task<string> GetFoldersAsync(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/bookmarks/folders/";
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.GetAsync().ConfigureAwait(false);
        }
    }
}