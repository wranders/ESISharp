using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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

            string CacheFile;
            if (Utility.File.GetCacheFile(CacheDirectory, CacheFileName, CacheExtension, out CacheFile))
            {
                string FileContents;
                using (var Reader = new StreamReader(Utility.File.ReadFile(CacheFile)))
                {
                    FileContents = Reader.ReadToEnd();
                }
                var CacheObjects = JsonConvert.DeserializeObject<List<CacheObject>>(FileContents);
                var ArgumentHash = Utility.Encoding.Base64Encode(Arguments);
                var QueryMatch = CacheObjects.Where(p => p.ArgumentsHash == ArgumentHash).ToList();
                if (QueryMatch.Count == 1)
                {
                    var CacheMatch = QueryMatch.FirstOrDefault();
                    var CacheAge = DateTime.Now - Utility.Time.UnixTimeToDateTime(CacheMatch.Expiration);
                    if (CacheAge.CompareTo(TimeSpan.Zero) < 0)
                    {
                        CachedFile = Utility.Encoding.Base64Decode(CacheMatch.DataHash);
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

        internal void Set(string PathName, string Arguments, string Data, HttpResponseHeaders Headers)
        {
            if (string.IsNullOrWhiteSpace(PathName) || string.IsNullOrWhiteSpace(Data))
                return;

            var CacheFileName = Utility.File.PathToFileName(PathName);

            var NewCacheObject = new CacheObject();
            NewCacheObject.ArgumentsHash = Utility.Encoding.Base64Encode(Arguments);
            NewCacheObject.DataHash = Utility.Encoding.Base64Encode(Data);
            NewCacheObject.Expiration = Utility.Time.DateTimeToUnixTime(DateTime.Parse(Headers.GetValues("expires").First()));

            string CacheFile;
            if(Utility.File.GetCacheFile(CacheDirectory, CacheFileName, CacheExtension, out CacheFile))
            {
                string FileContents;
                using (var Reader = new StreamReader(Utility.File.ReadFile(CacheFile)))
                {
                    FileContents = Reader.ReadToEnd();
                }
                var CacheObjects = JsonConvert.DeserializeObject<List<CacheObject>>(FileContents);
                CacheObjects.Add(NewCacheObject);
                var JsonCacheFile = JsonConvert.SerializeObject(CacheObjects);
                Utility.File.OverwriteFile(CacheFileName, JsonCacheFile);
            }
            else
            {
                var JsonCacheFile = JsonConvert.SerializeObject(new List<CacheObject>() { NewCacheObject });
                Utility.File.SaveFile(JsonCacheFile, Path.Combine(CacheDirectory, CacheFileName, CacheExtension));
            }
        }
    }

    internal class CacheObject
    {
        internal string ArgumentsHash { get; set; }
        internal double Expiration { get; set; }
        internal string DataHash { get; set; }
    }
}
