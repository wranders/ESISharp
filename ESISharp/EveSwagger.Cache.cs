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
                CachedFile = "";
                return false;
            }

            CachedFile = "";
            return true;
        }
    }

    internal class CacheObject
    {
        public string ArgumentsHash;
        public string Expiration;
        public string Data;

        internal CacheObject()
        {

        }
    }
}
