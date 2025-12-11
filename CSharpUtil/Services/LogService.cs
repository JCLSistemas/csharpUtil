using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    }
}
