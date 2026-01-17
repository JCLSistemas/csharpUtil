using CSharpUtil.Services;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace CSharpUtil.Motoboy
{
    public class VivaMotoApiService
    {
        private HttpClient _httpClient = null;
        private string _baseUrl = "";
        private string _authToken = "";
        private string _ultimoErro = "";
        private string _ultimaResposta = "";
        private bool _inicializado = false;

        public string UltimoErro => _ultimoErro;
        public string UltimaResposta => _ultimaResposta;
        public string AuthToken => _authToken;
        public bool EstaConectado => _inicializado && !string.IsNullOrEmpty(_authToken);

        /// <summary>
        /// Inicializa o serviço VivaMoto com a URL base da API.
        /// Configura o HttpClient com timeout de 60 segundos e headers padrão para JSON.
        /// </summary>
        public VivaMotoApiService(string baseUrl)
        {
            try
            {
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls12 |
                    SecurityProtocolType.Tls11 |
                    SecurityProtocolType.Tls;

                _baseUrl = baseUrl.TrimEnd('/');
                _httpClient = new HttpClient
                {
                    BaseAddress = new Uri(_baseUrl),
                    Timeout = TimeSpan.FromSeconds(60)
                };
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                _inicializado = true;
                _ultimoErro = "";

                //LogService.AddToSubfolder("VivaMotoApiService inicializado. BaseUrl: " + _baseUrl, "VivaMoto_Inicio");
            }
            catch (Exception ex)
            {
                _inicializado = false;
                _ultimoErro = $"Erro ao inicializar: {ex.Message}";
                LogService.AddToSubfolder("ERRO ao inicializar: " + ex.ToString(), "VivaMoto_Inicio");
            }
        }

        private void LogDebug(string mensagem)
        {
            LogService.AddToSubfolder(mensagem, "VivaMoto_Debug");
        }

        private void LogHttpDetails(string method, string endpoint, string requestBody, HttpResponseMessage response, string responseBody)
        {
            try
            {
                var requestHeaders = new StringBuilder();
                if (_httpClient?.DefaultRequestHeaders != null)
                {
                    foreach (var header in _httpClient.DefaultRequestHeaders)
                    {
                        requestHeaders.AppendLine(string.Format("{0}: {1}", header.Key, string.Join(", ", header.Value)));
                    }
                }

                var responseHeaders = new StringBuilder();
                if (response?.Headers != null)
                {
                    foreach (var header in response.Headers)
                    {
                        responseHeaders.AppendLine(string.Format("{0}: {1}", header.Key, string.Join(", ", header.Value)));
                    }
                }
                if (response?.Content?.Headers != null)
                {
                    foreach (var header in response.Content.Headers)
                    {
                        responseHeaders.AppendLine(string.Format("{0}: {1}", header.Key, string.Join(", ", header.Value)));
                    }
                }

                string responseStatus = response != null
                    ? string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase)
                    : "N/A";

                LogService.LogHttpRequest(
                    method,
                    _baseUrl + endpoint,
                    requestHeaders.ToString(),
                    requestBody ?? "",
                    responseStatus,
                    responseHeaders.ToString(),
                    responseBody ?? ""
                );
            }
            catch (Exception ex)
            {
                LogDebug("Erro ao gravar log HTTP: " + ex.Message);
            }
        }

        /// <summary>
        /// Realiza login na API VivaMoto.
        /// </summary>
        public int Login(string email, string senha)
        {
            LogDebug("=== INICIANDO LOGIN ===");
            LogDebug("Email: " + email);

            if (!_inicializado || _httpClient == null)
            {
                _ultimoErro = "Cliente não inicializado.";
                LogDebug("ERRO: " + _ultimoErro);
                return 0;
            }

            try
            {
                var loginData = new { Email = email, Senha = senha, LembrarMe = false };
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                LogDebug("Enviando requisição de login...");

                var response = _httpClient.PostAsync("/api/v1/auth/login", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                _ultimaResposta = responseString;

                LogHttpDetails("POST", "/api/v1/auth/login", json, response, responseString);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = Newtonsoft.Json.Linq.JObject.Parse(responseString);

                    var sucessoToken = loginResponse["sucesso"];
                    var tokenToken = loginResponse["token"];
                    
                    var sucesso = sucessoToken != null && (bool)sucessoToken;
                    var token = tokenToken?.ToString();

                    if (sucesso && !string.IsNullOrEmpty(token))
                    {
                        _authToken = token;
                        _httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", _authToken);

                        LogDebug("Login bem-sucedido. Token obtido (primeiros 20 chars): " +
                            (_authToken.Length > 20 ? _authToken.Substring(0, 20) + "..." : _authToken));

                        _ultimoErro = "";
                        return 1;
                    }

                    var mensagemToken = loginResponse["mensagem"];
                    _ultimoErro = mensagemToken?.ToString() ?? "Login falhou sem mensagem de erro.";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                LogDebug("ERRO: " + _ultimoErro);
                return 0;
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção no login: {ex.Message}";
                LogDebug("EXCEÇÃO: " + ex.ToString());
                return 0;
            }
        }

        /// <summary>
        /// Envia uma requisição POST genérica para um endpoint da API.
        /// O JSON deve estar no formato esperado pela API (responsabilidade do backend tratar).
        /// </summary>
        public int EnviarPost(string endpoint, string jsonPayload)
        {
            _ultimaResposta = "";

            LogDebug("=== ENVIANDO POST ===");
            LogDebug("Endpoint: " + endpoint);
            LogDebug("Payload: " + jsonPayload);

            //MessageBox.Show("(!_inicializado || _httpClient == null)");

            if (!_inicializado || _httpClient == null)
            {
                _ultimoErro = "Cliente não inicializado.";
                LogDebug("ERRO: " + _ultimoErro);
                return 0;
            }

            //MessageBox.Show("(string.IsNullOrEmpty(_authToken))");

            if (string.IsNullOrEmpty(_authToken))
            {
                _ultimoErro = "Não autenticado. Chame Login primeiro.";
                LogDebug("ERRO: " + _ultimoErro);
                return 0;
            }

            //MessageBox.Show("try catch");

            try
            {
                //MessageBox.Show("var content = new StringContent(jsonPayload ?? \"{}\", Encoding.UTF8, \"application/json\");");

                var content = new StringContent(jsonPayload ?? "{}", Encoding.UTF8, "application/json");

                // Log dos headers para diagnóstico
                LogDebug("Headers da requisição:");
                LogDebug("  Content-Type: " + content.Headers.ContentType?.ToString());
                LogDebug("  Accept: " + string.Join(", ", _httpClient.DefaultRequestHeaders.Accept));

                //MessageBox.Show("if (_httpClient.DefaultRequestHeaders.Authorization != null)");

                if (_httpClient.DefaultRequestHeaders.Authorization != null)
                {
                    LogDebug("  Authorization: Bearer [TOKEN PRESENTE]");
                }
                LogDebug("Enviando requisição POST...");

                //MessageBox.Show("var response = _httpClient.PostAsync(endpoint, content).Result;");

                var response = _httpClient.PostAsync(endpoint, content).Result;
                _ultimaResposta = response.Content.ReadAsStringAsync().Result;

                LogHttpDetails("POST", endpoint, jsonPayload, response, _ultimaResposta);

                //MessageBox.Show("if (response.IsSuccessStatusCode) = "+ response.IsSuccessStatusCode);

                if (response.IsSuccessStatusCode)
                {
                    //MessageBox.Show("Requisição bem-sucedida");

                    LogDebug("Requisição bem-sucedida");
                    _ultimoErro = "";
                    return 1;
                }
                else
                {
                    _ultimoErro = $"HTTP {(int)response.StatusCode}: {_ultimaResposta}";

                    //MessageBox.Show("_ultimoErro = " + _ultimoErro);

                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao enviar POST: {ex.Message}";

                //MessageBox.Show("catch _ultimoErro = " + _ultimoErro);

                LogDebug("EXCEÇÃO: " + ex.ToString());
                return 0;
            }
        }

        /// <summary>
        /// Envia dados para o endpoint de sincronização de ordens.
        /// </summary>
        public int EnviarOrdens(string jsonOrdens)
        {
            LogDebug("EnviarPost(\"/api/v1/sync/ordens \""+jsonOrdens+")");

            return EnviarPost("/api/v1/sync/ordens", jsonOrdens);
        }

        /// <summary>
        /// Envia dados para o endpoint de sincronização de empresas.
        /// </summary>
        public int EnviarEmpresas(string jsonEmpresas)
        {
            return EnviarPost("/api/v1/sync/empresas", jsonEmpresas);
        }

        /// <summary>
        /// Envia dados para o endpoint de sincronização de usuários.
        /// </summary>
        public int EnviarUsuarios(string jsonUsuarios)
        {
            return EnviarPost("/api/v1/sync/usuarios", jsonUsuarios);
        }

        /// <summary>
        /// Envia dados para o endpoint de atualização de status.
        /// </summary>
        public int AtualizarStatus(string jsonStatus)
        {
            return EnviarPost("/api/v1/sync/status", jsonStatus);
        }

        /// <summary>
        /// Gera um hash SHA-256 da senha fornecida e retorna em formato Base64.
        /// </summary>
        public string ObterSenhaHash(string password)
        {
            //MessageBox.Show("Entre ObterSenhaHash: " + password);

            if (string.IsNullOrEmpty(password))
                return "";

            SHA256 sha256 = SHA256.Create();
            //MessageBox.Show("Senha: " + password);
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var result = Convert.ToBase64String(hashedBytes);
            //MessageBox.Show("Senha Hash: " + result);
            return result;
            

            //using (var sha256 = SHA256.Create())
            //{
            //    MessageBox.Show("Senha: " + password);
            //    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            //    var result = Convert.ToBase64String(hashedBytes);
            //    MessageBox.Show("Senha Hash: " + result);
            //    return result;
            //}
        }

        /// <summary>
        /// Obtém a última mensagem de erro ocorrida.
        /// </summary>
        public string ObterUltimoErro()
        {
            return _ultimoErro;
        }

        /// <summary>
        /// Obtém o JSON da última resposta recebida da API.
        /// </summary>
        public string ObterUltimaResposta()
        {
            return _ultimaResposta;
        }


        /// <summary>
        /// Finaliza o serviço e libera recursos.
        /// </summary>
        public void Finalizar()
        {
            LogDebug("=== FINALIZANDO VIVAMOTOAPISERVICE ===");
            _httpClient?.Dispose();
            _httpClient = null;
            _authToken = "";
            _ultimoErro = "";
            _ultimaResposta = "";
            _inicializado = false;
        }
    }
}
