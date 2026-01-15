using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpUtil.Motoboy.Helper
{
    public static class JsonFieldHelper
    {
        /// <summary>
        /// Escapa corretamente uma string para uso seguro dentro de JSON.
        /// Trata quebras de linha, aspas, tabs, barras e Unicode.
        /// Retorna apenas o valor escapado (sem aspas externas).
        /// </summary>
        public static string Escape(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            //MessageBox.Show("JsonEscape 1");
            // Serializa como string JSON válida
            // Ex: "texto\nlinha"  →  "\"texto\\nlinha\""
            var json = JsonConvert.SerializeObject(value);

            //MessageBox.Show("JsonEscape 2");

            // Remove as aspas externas
            json = json.Substring(1, json.Length - 2);

            //MessageBox.Show("JsonEscape 3");

            return json.Trim();
            //return json.Substring(1, json.Length - 2);
        }
    }
}
