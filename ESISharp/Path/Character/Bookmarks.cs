using ESISharp.Web;

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
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAll(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/bookmarks/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character's Bookmark Folders</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character_bookmarks" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetFolders(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/bookmarks/folders/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}