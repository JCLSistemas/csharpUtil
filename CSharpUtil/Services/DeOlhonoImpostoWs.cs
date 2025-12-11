using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace CSharpUtil.Services
{
    public static class DeOlhonoImpostoWs
    {        
        public static string ConsultarIBPTProdutos(string _token, string _cnpj, string _NCM, string _uf, string _ex, 
                                                   string _codigoInterno, string _descricaoItem, string _unidadeMedida, string _valor, string _gtin)
        {
            try
            {
                string urlAPI = $"https://apidoni.ibpt.org.br/api/v1/produtos?token={_token.Trim()}&cnpj={_cnpj.Trim()}&codigo={_NCM.Trim()}"+
                                    "&uf={_uf.Trim()}&ex={_ex.Trim()}&codigoInterno={_codigoInterno.Trim()}&descricao={_descricaoItem.Trim()}"+
                                    "&unidadeMedida={_unidadeMedida.Trim()}&valor={_valor.Trim()}&gtin={_gtin.Trim()}";
                var request = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                request.BaseAddress = new Uri(urlAPI);
                var result = request.GetAsync(urlAPI).Result;               

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    if (result.StatusCode == HttpStatusCode.Forbidden){ MessageBox.Show("403 - Token expirado ou inválido", "Tabela IBPT");}
                    if (result.StatusCode == HttpStatusCode.InternalServerError) { MessageBox.Show("500 - Erro interno na api de produtos", "Tabela IBPT"); }
                    return null;
                }

                var jsonoutput = result.Content.ReadAsStringAsync().Result;
                var xmldoc = JsonConvert.DeserializeXmlNode(jsonoutput, "root");
                string xmlResult = xmldoc.InnerXml;

                if (xmlResult.Contains("<root><Codigo /><UF />")) { MessageBox.Show("Nenhum resultado para a pesquisa consulta realizada", "Tabela IBPT"); return null;}                
                return xmlResult;

            }
            catch (Exception ex)
            {
                LogService.Add(ex.Message);
                return null;
            }
                        
        }

    }
}
