using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace CSharpUtil.Services
{
    public static class ReceitaWS
    {
        public static string ConsultarCNPJ(string _CNPJ)
        {
            string CNPJ = new String(_CNPJ.Where(Char.IsDigit).ToArray());

            if (CNPJ.Length != 14)
            {
                string msg = $"Número do CNPJ: {CNPJ}, inválido";
                LogService.Add(msg);
                MessageBox.Show(msg);
                return "";
            }


            try
            {
                string urlAPI = $"https://www.receitaws.com.br/v1/cnpj/{CNPJ}";
                var request = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                request.BaseAddress = new Uri(urlAPI);
                var result = request.GetAsync(urlAPI).Result;
                var jsonoutput = result.Content.ReadAsStringAsync().Result;
                var xmldoc = JsonConvert.DeserializeXmlNode(jsonoutput,"root");

                return xmldoc.InnerXml.ToString() ;

            }
            catch (Exception ex)
            {
                LogService.Add(ex.Message);
                return "";
            }
                        
        }

    }
}
