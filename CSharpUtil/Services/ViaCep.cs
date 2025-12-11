using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace CSharpUtil.Services
{
    public static class ViaCep
    {
        public static string GetAddressbyCep (string cep) {

            try
            {
                string url = $"https://viacep.com.br/ws/{cep}/xml/";
                var request = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                request.BaseAddress = new Uri(url);
                var response = request.GetAsync(url).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                LogService.Add(ex.Message);
                return ex.Message;
            }
        }

        public static string GetCepByAddress(string uf, string cidade, string endereco) {
            try
            {
                string url = $"https://viacep.com.br/ws/{uf}/{cidade}/{endereco}/xml/";
                var request = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                request.BaseAddress = new Uri(url);
                var response = request.GetAsync(url).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                LogService.Add(ex.Message);
                return ex.Message;
            }


        }


    }
}
