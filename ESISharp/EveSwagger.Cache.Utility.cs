using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.CacheUtility
{
    internal static class Time
    {
        internal static string GetUtcUnixTime()
        {
            var UtcTime = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
            return (UtcTime.Days * 24 * 60 * 60 + UtcTime.Hours * 60 * 60 + UtcTime.Minutes * 60 + UtcTime.Seconds).ToString("G", CultureInfo.InvariantCulture);
        }

        internal static DateTime UnixTimeToDateTime(string UnixTime)
        {
            var UnixTimeEpochUtc = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            double UnixTimeSeconds;
            if (double.TryParse(UnixTime, out UnixTimeSeconds))
            {
                return UnixTimeEpochUtc.AddSeconds(UnixTimeSeconds);
            }
            else
            {
                return UnixTimeEpochUtc;
            }
        }
    }

    internal static class File
    {
        internal static Stream ReadFile(string FileName)
        {
            if (FileName == null)
                return null;
            var Uri = new Uri(FileName);
            if (Uri.IsFile && !System.IO.File.Exists(Uri.LocalPath))
                return null;
            while(true)
            {
                try
                {
                    return new MemoryStream(System.IO.File.ReadAllBytes(Uri.LocalPath));
                }
                catch
                {
                    return null;
                }
            }
        }

        internal static void SaveFile(string FileContents, string FilePath)
        {
            using (StreamWriter Writer = new StreamWriter(FilePath))
            {
                Writer.Write(FileContents);
            }
        }

        internal static bool DeleteFile(string FilePath)
        {
            var Success = false;
            try
            {
                System.IO.File.Delete(FilePath);
                Success = true;
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        internal static string SetCacheDirectory(string DirectoryLocation, string DirectoryName, bool Initialize)
        {
            string CacheDirectory;
            if (string.IsNullOrEmpty(DirectoryLocation))
            {
                if (string.IsNullOrEmpty(DirectoryName))
                {
                    CacheDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "cache");
                }
                else
                {
                    CacheDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), DirectoryName);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(DirectoryLocation))
                {
                    CacheDirectory = Path.Combine(DirectoryLocation, "cache");
                }
                else
                {
                    CacheDirectory = Path.Combine(DirectoryLocation, DirectoryName);
                }
            }
            if (Initialize && !Directory.Exists(CacheDirectory))
                Directory.CreateDirectory(CacheDirectory);

            return CacheDirectory;
        }

        internal static string PathToFileName(string Path)
        {
            var TrimChars = new char[] { '/' };
            var TrimmedPath = Path.Trim(TrimChars);
            var ReplacedPath = TrimmedPath.Replace(TrimChars.First(), '-');

            return ReplacedPath;
        }
    }

    internal static class Encoding
    {
        internal static string Base64Encode(string PlainText)
        {
            var PlainTextBytes = System.Text.Encoding.UTF8.GetBytes(PlainText);
            return Convert.ToBase64String(PlainTextBytes);
        }

        internal static string Base64Decode(string EncodedText)
        {
            var EncodedTextBytes = Convert.FromBase64String(EncodedText);
            return System.Text.Encoding.UTF8.GetString(EncodedTextBytes);
        }
    }
}
