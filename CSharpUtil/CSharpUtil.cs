using System;
using System.Runtime.InteropServices;
using System.Text;
using CSharpUtil.Services;
using RGiesecke.DllExport;
//using System.Windows.Forms;

namespace CSharpUtil
{
    internal static class CSharpUtil
    {
        [DllExport("ExportPdf", CallingConvention = CallingConvention.StdCall)]

        public static string ExportPdf(string imagesPath, string destinationPath, int landscape, int pdfOpen)
        {
            return Pdf.Generate(imagesPath.Trim(), destinationPath.Trim(), landscape, pdfOpen);
        }

        [DllExport("ExportExcel", CallingConvention = CallingConvention.StdCall)]
        public static string ExportExcel(string fileTxtPath, string destinationPath, string reportName, int excelOpen)
        {
            return new Excel().Generate(fileTxtPath.Trim(), destinationPath.Trim(), reportName.Trim(), excelOpen);
        }

        [DllExport("SendEmail", CallingConvention = CallingConvention.StdCall)]
        public static bool SendEmail(string fromName, string from, string to, string cc, string bcc, string subject,
                                     string body, string attachments, string user, string password, string smtpHost, 
                                     int port, int autentication, int enableSsl, int useDefaultCredentials)
        {
            var result = new EmailKit().Send(fromName, from, to, cc, bcc, subject, body, attachments,
                                       user, password, smtpHost, port, autentication, enableSsl, useDefaultCredentials);
            return result;
        }

        [DllExport("NewGuid", CallingConvention = CallingConvention.StdCall)]
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        [DllExport("TextToUtf8", CallingConvention = CallingConvention.StdCall)]
        public static string TextToUtf8(string text)
        {
            var bytes = Encoding.Default.GetBytes(text);
            return Encoding.UTF8.GetString(bytes);
        }

        [DllExport("Utf8ToText", CallingConvention = CallingConvention.StdCall)]
        public static string Utf8ToText(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            return Encoding.Default.GetString(bytes);
        }

        [DllExport("Code128", CallingConvention = CallingConvention.StdCall)]
        public static string Code128(string text, string destinationPath)
        {
            return new Code128().Generate(text, destinationPath);
        }

        [DllExport("CodeInter25", CallingConvention = CallingConvention.StdCall)]
        public static string CodeInter25(string text, string destinationPath)
        {
            return new CodeInter25().Generate(text, destinationPath);
        }

        [DllExport("DirectoryExists", CallingConvention = CallingConvention.StdCall)]
        public static bool DirectoryExists(string directoryPath)
        {
            return DosFiles.DirectoryExists(directoryPath);
        }

        [DllExport("DirectoryCreate", CallingConvention = CallingConvention.StdCall)]
        public static bool DirectoryCreate(string directoryPath)
        {
            return DosFiles.DirectoryCreate(directoryPath);
        }

        [DllExport("DirectoryDelete", CallingConvention = CallingConvention.StdCall)]
        public static bool DirectoryDelete(string directoryPath, int recursive)
        {
            return DosFiles.DirectoryDelete(directoryPath, recursive);
        }

        [DllExport("GetFiles", CallingConvention = CallingConvention.StdCall)]
        public static string GetFiles(string topDirectoryPath, string FileToSearch, int allSubDirectories)
        {
            return DosFiles.GetFiles(topDirectoryPath, FileToSearch, allSubDirectories);
        }

        [DllExport("FileExists", CallingConvention = CallingConvention.StdCall)]
        public static bool FileExists(string filePath)
        {
            return DosFiles.FileExists(filePath);
        }

        [DllExport("FileDelete", CallingConvention = CallingConvention.StdCall)]
        public static bool FileDelete(string filePath)
        {
            return DosFiles.FileDelete(filePath);
        }
        [DllExport("GetDirectory", CallingConvention = CallingConvention.StdCall)]
        public static string GetDirectory(string filePath)
        {
            return DosFiles.GetDirectory(filePath);
        }
        [DllExport("GetFileName", CallingConvention = CallingConvention.StdCall)]
        public static string GetFileName(string filePath)
        {
            return DosFiles.GetFileName(filePath);
        }
        [DllExport("GMapsLatLongByAddress", CallingConvention = CallingConvention.StdCall)]
        public static string GMapsLatLongByAddress(string token, string address)
        {
            //MessageBox.Show("token:" + token + " address:" + address,"csharp.dll");

            GoogleMaps googleMaps = new GoogleMaps(token);
            //MessageBox.Show("estanciei classe GoogleMaps ","CSharp.dll");
            return googleMaps.GetLatLongByAddress(address);
        }

        [DllExport("GMapsLatLongByCEP", CallingConvention = CallingConvention.StdCall)]
        public static string GMapsLatLongByCEP(string token, string CEP)
        {
            GoogleMaps googleMaps = new GoogleMaps(token);
            return googleMaps.GetLatLongByCEP(CEP);
        }

        [DllExport("GMapsGetAddressByCEP", CallingConvention = CallingConvention.StdCall)]
        public static string GMapsGetAddressByCEP(string token, string CEP)
        {
            GoogleMaps googleMaps = new GoogleMaps(token);
            return googleMaps.GetAddressByCEP(CEP);
        }

    }
}

