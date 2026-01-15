using System;
using System.Reflection;
using System.Text;

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

        /// <summary>
        /// Retorna a versão atual da DLL.
        /// </summary>
        public static string ObterVersaoDLL()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var version = assembly.GetName().Version;
                return version.ToString();
            }
            catch (Exception ex)
            {
                LogService.Add(ex.Message);
                return "Versão: desconhecida";
            }
        }

        /// <summary>
        /// Retorna informações detalhadas da versão da DLL.
        /// </summary>
        public static string ObterInfoVersao()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var version = assembly.GetName().Version;
                var fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);

                // Calcula a data aproximada do build baseada no Build number (dias desde 01/01/2000)
                var buildDate = new DateTime(2000, 1, 1)
                    .AddDays(version.Build)
                    .AddSeconds(version.Revision * 2);

                return string.Format(
                    "Versão: {0} | Build: {1:dd/MM/yyyy HH:mm}",
                    version.ToString(),
                    buildDate
                );

            }
            catch (Exception ex)
            {
                LogService.Add(ex.Message);
                return "Versão: desconhecida";
            }

        }


    }
}
