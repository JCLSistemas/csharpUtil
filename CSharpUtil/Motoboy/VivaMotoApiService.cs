using CSharpUtil.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpUtil.Motoboy
{
    public class VivaMotoApiService : IDisposable
    {
        private HttpClient _httpClient = null;
        private string _baseUrl = "";
        private string _syncKey = "";
        private string _ultimoErro = "";
        private string _ultimaResposta = "";
        private bool _inicializado = false;

        public string UltimoErro => _ultimoErro;
        public string UltimaResposta => _ultimaResposta;
        public string AuthToken => _syncKey;
        public bool EstaConectado => _inicializado && !string.IsNullOrEmpty(_syncKey);

        /// <summary>
        /// Inicializa o serviço com a URL base da API e opcionalmente a chave de sincronização.
        /// Configura TLS moderno (TLS 1.2 / 1.3), timeout e headers padrão.
        /// </summary>
        public VivaMotoApiService(string baseUrl, string syncKey = "")
        {
            Inicializar(baseUrl, syncKey);
        }

        public void Inicializar(string baseUrl, string syncKey = "")
        {
            try
            {
                // Configuração segura de TLS (TLS 1.2 e TLS 1.3)
                const SecurityProtocolType Tls13 = (SecurityProtocolType)12288;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | Tls13;

                _baseUrl = (baseUrl ?? "").Trim().TrimEnd('/') + "/";
                _syncKey = (syncKey ?? "").Trim();

                _httpClient?.Dispose();
                _httpClient = new HttpClient
                {
                    BaseAddress = new Uri(_baseUrl),
                    Timeout = TimeSpan.FromSeconds(60)
                };

                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(_syncKey))
                {
                    _httpClient.DefaultRequestHeaders.Remove("X-Sync-Key");
                    _httpClient.DefaultRequestHeaders.Add("X-Sync-Key", _syncKey);
                }

                _inicializado = true;
                _ultimoErro = "";
            }
            catch (Exception ex)
            {
                _inicializado = false;
                _ultimoErro = $"Erro ao inicializar: {ex.Message}";
                LogService.AddToSubfolder("ERRO ao inicializar: " + ex, "VivaMoto_Inicio");
            }
        }

        /// <summary>
        /// Define ou atualiza a chave de integração X-Sync-Key.
        /// </summary>
        public void ConfigurarChave(string syncKey)
        {
            _syncKey = (syncKey ?? "").Trim();
            if (_httpClient != null && !string.IsNullOrEmpty(_syncKey))
            {
                _httpClient.DefaultRequestHeaders.Remove("X-Sync-Key");
                _httpClient.DefaultRequestHeaders.Add("X-Sync-Key", _syncKey);
            }
        }

        /// <summary>
        /// Realiza o login configurando e validando a chave de integração (X-Sync-Key) na API.
        /// Envia uma sonda de teste para comprovar conectividade e autorização na API.
        /// </summary>
        /// <param name="chaveSync">Chave de integração secreta (X-Sync-Key) configurada no portal.</param>
        /// <param name="usuario">Identificador opcional de usuário/operador para fins de auditoria.</param>
        /// <returns>1 se a chave for válida e a API responder com sucesso; 0 em caso de erro.</returns>
        public int Login(string chaveSync, string usuario = "")
        {
            LogDebug("=== INICIANDO LOGIN / VALIDAÇÃO DE CHAVE ===");

            if (!_inicializado || _httpClient == null)
            {
                _ultimoErro = "Cliente não inicializado. Chame MtbInicializarAPI primeiro.";
                LogDebug("ERRO: " + _ultimoErro);
                return 0;
            }

            string chave = !string.IsNullOrWhiteSpace(chaveSync) ? chaveSync.Trim() : (usuario ?? "").Trim();

            if (string.IsNullOrEmpty(chave))
            {
                _ultimoErro = "Chave de integração (X-Sync-Key) não informada.";
                LogDebug("ERRO: " + _ultimoErro);
                return 0;
            }

            _syncKey = chave;
            _httpClient.DefaultRequestHeaders.Remove("X-Sync-Key");
            _httpClient.DefaultRequestHeaders.Add("X-Sync-Key", _syncKey);

            try
            {
                LogDebug("Testando conexão e validando chave X-Sync-Key na API...");

                // Faz um probe seguro enviando um lote vazio de empresas para validar a chave
                var content = new StringContent("{\"empresas\":[]}", Encoding.UTF8, "application/json");

                var response = Task.Run(async () =>
                    await _httpClient.PostAsync("api/sync/empresas", content).ConfigureAwait(false)
                ).GetAwaiter().GetResult();

                var responseString = Task.Run(async () =>
                    await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                ).GetAwaiter().GetResult();

                _ultimaResposta = responseString;
                LogHttpDetails("POST", "api/sync/empresas", "{\"empresas\":[]}", response, responseString);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _syncKey = "";
                    _httpClient.DefaultRequestHeaders.Remove("X-Sync-Key");
                    _ultimoErro = "Chave de integração inválida (HTTP 401 Unauthorized). Verifique a chave configurada.";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                if (!response.IsSuccessStatusCode)
                {
                    _syncKey = "";
                    _httpClient.DefaultRequestHeaders.Remove("X-Sync-Key");
                    _ultimoErro = $"Erro ao validar conexão com a API (HTTP {(int)response.StatusCode}): {responseString}";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                _ultimoErro = "";
                LogDebug("Login OK: Chave X-Sync-Key validada com sucesso na API.");
                return 1;
            }
            catch (Exception ex)
            {
                _syncKey = "";
                _httpClient.DefaultRequestHeaders.Remove("X-Sync-Key");
                _ultimoErro = $"Exceção ao conectar à API: {ex.Message}";
                LogDebug("EXCEÇÃO: " + ex);
                return 0;
            }
        }

        /// <summary>
        /// Envia uma requisição POST com validação de resposta estruturada.
        /// </summary>
        public int EnviarPost(string endpoint, string jsonPayload)
        {
            _ultimaResposta = "";

            if (!_inicializado || _httpClient == null)
            {
                _ultimoErro = "Cliente não inicializado.";
                LogDebug("ERRO: " + _ultimoErro);
                return 0;
            }

            if (string.IsNullOrEmpty(_syncKey))
            {
                _ultimoErro = "Não autenticado. Chame MtbLogin informando a chave de integração (X-Sync-Key).";
                LogDebug("ERRO: " + _ultimoErro);
                return 0;
            }

            try
            {
                string relativePath = endpoint.TrimStart('/');
                var content = new StringContent(jsonPayload ?? "{}", Encoding.UTF8, "application/json");

                LogDebug("=== ENVIANDO POST ===");
                LogDebug("Endpoint: " + relativePath);
                LogDebug("Payload: " + RedigirDadosSensiveis(jsonPayload));

                HttpResponseMessage response = Task.Run(async () =>
                    await _httpClient.PostAsync(relativePath, content).ConfigureAwait(false)
                ).GetAwaiter().GetResult();

                string responseString = Task.Run(async () =>
                    await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                ).GetAwaiter().GetResult();

                _ultimaResposta = responseString;
                LogHttpDetails("POST", relativePath, jsonPayload, response, responseString);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _ultimoErro = "HTTP 401: Chave de integração inválida ou ausente (X-Sync-Key).";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                if ((int)response.StatusCode == 413)
                {
                    _ultimoErro = "HTTP 413: Lote ou tamanho de payload excedeu os limites suportados pela API.";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                if (!response.IsSuccessStatusCode)
                {
                    _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                // Analisa o retorno estruturado da API PHP para verificar se houve erros em itens
                try
                {
                    var obj = JObject.Parse(responseString);
                    bool sucesso = obj["sucesso"] != null && (bool)obj["sucesso"];
                    int totalErros = obj["totalErros"] != null ? (int)obj["totalErros"] : 0;

                    if (!sucesso || totalErros > 0)
                    {
                        string msg = obj["mensagem"]?.ToString() ?? "Erros no processamento do lote.";
                        _ultimoErro = $"Aviso ({totalErros} erros): {msg}";
                        LogDebug("AVISO: " + _ultimoErro);
                        return 0;
                    }

                    _ultimoErro = "";
                    LogDebug("Requisição processada com 100% de sucesso.");
                    return 1;
                }
                catch (JsonException)
                {
                    _ultimoErro = "";
                    return 1;
                }
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao enviar POST: {ex.Message}";
                LogDebug("EXCEÇÃO: " + ex);
                return 0;
            }
        }

        private string EnveloparSeNecessario(string json, string containerKey)
        {
            if (string.IsNullOrWhiteSpace(json)) return "{\"" + containerKey + "\":[]}";
            string trimmed = json.Trim();
            if (trimmed.StartsWith("["))
            {
                return "{\"" + containerKey + "\":" + trimmed + "}";
            }
            return trimmed;
        }

        public int EnviarOrdens(string jsonOrdens)
        {
            string payload = EnveloparSeNecessario(jsonOrdens, "ordens");
            return EnviarPost("api/sync/ordens", payload);
        }

        public int EnviarEmpresas(string jsonEmpresas)
        {
            string payload = EnveloparSeNecessario(jsonEmpresas, "empresas");
            return EnviarPost("api/sync/empresas", payload);
        }

        public int EnviarUsuarios(string jsonUsuarios)
        {
            string payload = EnveloparSeNecessario(jsonUsuarios, "usuarios");
            return EnviarPost("api/sync/usuarios", payload);
        }

        public int AtualizarStatus(string jsonStatus)
        {
            string payload = EnveloparSeNecessario(jsonStatus, "updates");
            return EnviarPost("api/sync/status", payload);
        }

        public string ObterSenhaHash(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public string ObterUltimoErro() => _ultimoErro;
        public string ObterUltimaResposta() => _ultimaResposta;

        private void LogDebug(string mensagem)
        {
            LogService.AddToSubfolder(mensagem, "VivaMoto_Debug");
        }

        private string RedigirDadosSensiveis(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            var sanitizado = Regex.Replace(
                texto,
                @"(X-Sync-Key:\s*)([^\r\n]+)",
                "$1[REDACTED]",
                RegexOptions.IgnoreCase);
            sanitizado = Regex.Replace(
                sanitizado,
                @"(""senha""\s*:\s*"")[^""]+("")",
                "$1[REDACTED]$2",
                RegexOptions.IgnoreCase);
            return sanitizado;
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
                        string valor = header.Key.Equals("X-Sync-Key", StringComparison.OrdinalIgnoreCase)
                            ? "[REDACTED]"
                            : string.Join(", ", header.Value);
                        requestHeaders.AppendLine($"{header.Key}: {valor}");
                    }
                }

                string responseStatus = response != null
                    ? $"{(int)response.StatusCode} ({response.ReasonPhrase})"
                    : "N/A";

                string safeBody = RedigirDadosSensiveis(requestBody);

                LogService.LogHttpRequest(
                    method,
                    _baseUrl + endpoint,
                    requestHeaders.ToString(),
                    safeBody,
                    responseStatus,
                    "",
                    responseBody ?? ""
                );
            }
            catch (Exception ex)
            {
                LogDebug("Erro ao gravar log HTTP: " + ex.Message);
            }
        }

        public void Finalizar()
        {
            _httpClient?.Dispose();
            _httpClient = null;
            _syncKey = "";
            _ultimoErro = "";
            _ultimaResposta = "";
            _inicializado = false;
        }

        public void Dispose()
        {
            Finalizar();
        }
    }
}
