using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtil.Services
{
    public static class General
    {
        //NewGuid
        public static string NewGuid() {
            try
            {
                return Guid.NewGuid().ToString();
            }
            catch (Exception ex)
            {
                 LogService.Add(ex.Message);
            }

            return "";
        }

        //TextToUtf8
        public static string TextToUtf8(string text)
        {
            try
            {
                var bytes = Encoding.Default.GetBytes(text);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                LogService.Add(ex.Message);
            }

            return "";
        }

        //Utf8ToText
        public static string Utf8ToText(string text)
        {
            try
            {
                var bytes = Encoding.UTF8.GetBytes(text);
                return Encoding.Default.GetString(bytes);
            }
            catch (Exception ex)
            {
                LogService.Add(ex.Message);
            }

            return "";
        }                

    }
}
