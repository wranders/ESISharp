using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.CacheUtility
{
    internal static class File
    {
        internal static Stream ReadFile(string FileName)
        {
            if (FileName == null)
                return null;
            var Uri = new Uri(FileName);
            if (Uri.IsFile && !System.IO.File.Exists(Uri.LocalPath))
                return null;
            while (true)
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

        private static FileStream GetFileStream(string FilePath, FileMode Mode, FileAccess Access)
            => new FileStream(FilePath, Mode, Access, FileShare.None, 4096, true);

        private static void Copy(string SourceFileName, string DestinationFileName)
        {
            using (var SourceStream = GetFileStream(SourceFileName, FileMode.Open, FileAccess.Read))
            using (var DestinationStream = GetFileStream(DestinationFileName, FileMode.Create, FileAccess.Write))
                SourceStream.CopyTo(DestinationStream);
        }

        private static bool MakeWritable(FileInfo File)
        {
            if (!File.IsReadOnly)
                return true;

            File.IsReadOnly = false;
            return true;
        }

        private static bool EnsureWritable(string FileName)
        {
            var File = new FileInfo(FileName);
            return !File.Exists || MakeWritable(File);
        }

        internal static void CopyFile(string SourceFileName, string DestinationFileName)
        {
            if (!EnsureWritable(DestinationFileName))
                return;
            Copy(SourceFileName, DestinationFileName);
            var DestinationFile = new FileInfo(DestinationFileName);
            DestinationFile.Refresh();
            DestinationFile.IsReadOnly = false;
        }

        internal static void OverwriteFile(string DestinationFile, string FileContents)
        {
            if (DestinationFile == null)
                return;
            if (FileContents == null)
                return;
            var TemporaryFileName = Path.GetTempFileName();
            SaveFile(FileContents, TemporaryFileName);
            CopyFile(TemporaryFileName, DestinationFile);
            DeleteFile(TemporaryFileName);
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
            return TrimmedPath.Replace(TrimChars.First(), '-');
        }

        internal static bool GetCacheFile(string CacheDirectory, string FileName, string FileExtension, out string CacheFile)
        {
            var CacheFiles = Directory.EnumerateFiles(CacheDirectory, FileName, SearchOption.AllDirectories)
                .Where(f => f.EndsWith(FileExtension)).ToList();
            
            if(CacheFiles.Any())
            {
                if(CacheFiles.Count == 1)
                {
                    CacheFile = CacheFiles.FirstOrDefault();
                    return true;
                }
                else
                {
                    CacheFiles.ForEach(f => File.DeleteFile(f));
                    CacheFile = string.Empty;
                    return false;
                }
            }
            else
            {
                CacheFile = string.Empty;
                return false;
            }
        }
    }
}
