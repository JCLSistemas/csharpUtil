using System;
using System.IO;
using System.Text;

namespace CSharpUtil.Services
{
    public static class DosFiles
    {
        public static bool DirectoryExists(string directoryPath)
        {
            try
            {
                return Directory.Exists(directoryPath.Trim());
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static bool DirectoryCreate(string directoryPath)
        {
            try
            {
                Directory.CreateDirectory(directoryPath.Trim());
                return Directory.Exists(directoryPath.Trim());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DirectoryDelete(string directoryPath, int recursive)
        {

            try{
                var filesAndSubDirectories = Convert.ToBoolean(recursive);
                Directory.Delete(directoryPath.Trim(), filesAndSubDirectories);
                return Directory.Exists(directoryPath.Trim()) == false ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetFiles(string topDirectoryPath, string FileToSearch, int allSubDirectories)
        {
            try
            {
                var files = Directory.GetFiles(topDirectoryPath, FileToSearch, (SearchOption)allSubDirectories);

                StringBuilder searchedFiles = new StringBuilder();
                foreach (var file in files)
                {
                    searchedFiles.Append(file.Trim() + @";");
                }
                return searchedFiles.ToString();
            }
            catch (Exception)
            {
                return "";
            }

        }
        public static bool FileExists(string filePath)
        {
            try
            {
                return File.Exists(filePath.Trim());
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool FileDelete(string filePath)
        {
            try
            {
                File.Delete(filePath.Trim());
                return File.Exists(filePath.Trim()) == false ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetDirectory(string filePath)
        {
            try
            {
                return Path.GetDirectoryName(filePath);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string GetFileName(string filePath)
        {
            try
            {
                return Path.GetFileName(filePath);
            }
            catch (Exception)
            {
                return "";
            }
        }


    }
}
