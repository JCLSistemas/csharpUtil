using Newtonsoft.Json;
using System;
using System.Text;

namespace CSharpUtil.Motoboy.Helper
{
    public static class JsonFieldHelper
    {
        /// <summary>
        /// Escapa corretamente uma string para uso seguro dentro de JSON.
        /// Trata quebras de linha, aspas, tabs, barras e caracteres Unicode.
        /// Retorna apenas o valor escapado (sem aspas externas).
        /// </summary>
        public static string Escape(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var json = JsonConvert.SerializeObject(value);
            if (json.Length >= 2 && json.StartsWith("\"") && json.EndsWith("\""))
            {
                json = json.Substring(1, json.Length - 2);
            }

            return json.Trim();
        }
    }
}
