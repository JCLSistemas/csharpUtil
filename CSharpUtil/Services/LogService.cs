using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtil.Services
{
    public static class LogService
    {
        public static void Add(string _errorMessage)
        {

            string path = string.Concat(Environment.CurrentDirectory,@"\");            
            string nameFile = "CsharpDLL.log";
            
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if (!File.Exists(path + nameFile)) File.CreateText(path + nameFile).Close();

            using (StreamWriter sw = new StreamWriter(path + nameFile, true, Encoding.UTF8))
            {                
                _errorMessage = DateTime.Now.ToString() + " " + _errorMessage;
                sw.WriteLine(_errorMessage);
            }            

            
        }

        /// <summary>
        /// Grava log em subpasta \Log na mesma pasta da DLL
        /// </summary>
        /// <param name="message">Mensagem a ser gravada</param>
        /// <param name="prefix">Prefixo do arquivo (ex: VivaMoto, API, Debug)</param>
        public static void AddToSubfolder(string message, string prefix = "Log")
        {
            try
            {
                string dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string logPath = Path.Combine(dllPath, "Log");
                string nameFile = string.Format("{0}_{1:yyyyMMdd}.log", prefix, DateTime.Now);
                string fullPath = Path.Combine(logPath, nameFile);

                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                string logEntry = string.Format("[{0:yyyy-MM-dd HH:mm:ss.fff}] {1}", DateTime.Now, message);

                using (StreamWriter sw = new StreamWriter(fullPath, true, Encoding.UTF8))
                {
                    sw.WriteLine(logEntry);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Grava log detalhado de requisição HTTP em subpasta \Log
        /// </summary>
        public static void LogHttpRequest(string method, string url, string requestHeaders, string requestBody, string responseStatus, string responseHeaders, string responseBody)
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("========== HTTP REQUEST ==========");
                sb.AppendLine(string.Format("{0} {1}", method, url));
                sb.AppendLine("--- Request Headers ---");
                sb.AppendLine(requestHeaders);
                sb.AppendLine("--- Request Body ---");
                sb.AppendLine(requestBody);
                sb.AppendLine("--- Response Status ---");
                sb.AppendLine(responseStatus);
                sb.AppendLine("--- Response Headers ---");
                sb.AppendLine(responseHeaders);
                sb.AppendLine("--- Response Body ---");
                sb.AppendLine(responseBody);
                sb.AppendLine("==================================");
                sb.AppendLine("");

                AddToSubfolder(sb.ToString(), "VivaMoto_HTTP");
            }
            catch
            {
            }
        }

    }
}
