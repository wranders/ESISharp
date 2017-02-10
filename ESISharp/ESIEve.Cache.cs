using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Utility = ESISharp.CacheUtility;

namespace ESISharp
{
    public class Cache
    {
        internal bool CacheEnabled = false;
        internal string CacheFileExtension = "esicache";
        internal string CacheExtension => string.Join(".", CacheFileExtension);
        internal string CacheDirectory;

        internal Cache()
        {
            
        }

        public void Enabled(bool IsEnabled)
        {
            CacheEnabled = IsEnabled;
        }

        public void SetCacheDirectory(string DirectoryLocation, string DirectoryName) 
            => CacheDirectory = Utility.File.SetCacheDirectory(DirectoryLocation, DirectoryName, true);

        public void SetCacheDirectory(string DirectoryLocation, string DirectoryName, bool Initialize)
            => CacheDirectory = Utility.File.SetCacheDirectory(DirectoryLocation, DirectoryName, Initialize);

        internal bool Get(string PathName, string Arguments, out string CachedFile)
        {
            if(PathName == null)
            {
                CachedFile = string.Empty;
                return false;
            }

            var CacheFileName = Utility.File.PathToFileName(PathName);
            var ArgumentHash = Utility.Encoding.Base64Encode(Arguments);

            string CacheFile;
            if (Utility.File.GetCacheFile(CacheDirectory, CacheFileName, CacheExtension, out CacheFile))
            {
                string FileContents;
                using (var Reader = new StreamReader(Utility.File.ReadFile(CacheFile)))
                {
                    FileContents = Reader.ReadToEnd();
                }
                var CacheObjects = JsonConvert.DeserializeObject<List<CacheObject>>(FileContents);
                var QueryMatch = CacheObjects.Where(p => p.ArgumentsHash == ArgumentHash).ToList();
                if (QueryMatch.Count == 1)
                {
                    var CacheMatch = QueryMatch.FirstOrDefault();
                    var CacheTime = Utility.Time.UnixTimeToDateTime(CacheMatch.Expiration);
                    var CacheAge = DateTime.Now - CacheTime;
                    if (CacheAge.CompareTo(TimeSpan.Zero) < 0)
                    {
                        CachedFile = Utility.Encoding.Base64Decode(CacheMatch.Data);
                        return true;
                    }
                    else
                    {
                        CacheObjects.Remove(CacheMatch);
                        var NewFileContents = JsonConvert.SerializeObject(CacheObjects);
                        Utility.File.OverwriteFile(CacheFile, NewFileContents);
                        CachedFile = string.Empty;
                        return false;
                    }
                }
                else
                {
                    CacheObjects.RemoveAll(o => QueryMatch.Contains(o));
                    var NewFileContents = JsonConvert.SerializeObject(CacheObjects);
                    Utility.File.OverwriteFile(CacheFile, NewFileContents);
                    CachedFile = string.Empty;
                    return false;
                }
            }
            else
            {
                CachedFile = string.Empty;
                return false;
            }
        }
    }

    internal class CacheObject
    {
        internal string ArgumentsHash { get; set; }
        internal string Expiration { get; set; }
        internal string Data { get; set; }
    }
}
