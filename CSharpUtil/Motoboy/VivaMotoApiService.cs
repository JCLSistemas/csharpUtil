using CSharpUtil.Motoboy.Dto;
using CSharpUtil.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CSharpUtil.Motoboy
{
    public class VivaMotoApiService
    {
        private HttpClient _httpClient = null;
        private string _baseUrl = "";
        private string _authToken = "";
        private string _ultimoErro = "";
        private bool _inicializado = false;
        private bool _debugAtivo = false;

        public string UltimoErro => _ultimoErro;
        public string AuthToken => _authToken;
        public bool EstaConectado => _inicializado && !string.IsNullOrEmpty(_authToken);

        /// <summary>
        /// Inicializa o serviço VivaMoto com a URL base da API.
        /// Configura o HttpClient com timeout de 60 segundos e headers padrão para JSON.
        /// </summary>
        /// <param name="baseUrl">URL base da API VivaMoto 
        /// (ex: http://localhost:5000 
        ///     ou https://vivamoto.onrender.com 
        ///     ou https://api.vivamoto.com)</param>
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

                // Sempre grava log de inicialização (mesmo sem debug ativo)
                LogService.AddToSubfolder("VivaMotoApiService inicializado. BaseUrl: " + _baseUrl, "VivaMoto_Inicio");
            }
            catch (Exception ex)
            {
                _inicializado = false;
                _ultimoErro = $"Erro ao inicializar: {ex.Message}";
                LogService.AddToSubfolder("ERRO ao inicializar: " + ex.ToString(), "VivaMoto_Inicio");
            }

        }

        /// <summary>
        /// Ativa ou desativa o modo debug que grava logs detalhados em arquivo.
        /// Os logs são gravados na pasta \Log dentro do diretório da DLL.
        /// </summary>
        /// <param name="ativar">1 para ativar, 0 para desativar</param>
        public void ConfigurarDebug(int ativar)
        {
            _debugAtivo = (ativar == 1);
            
            // Sempre grava este log, independente do estado do debug
            LogService.AddToSubfolder(
                string.Format("Debug {0}", _debugAtivo ? "ATIVADO" : "DESATIVADO"), 
                "VivaMoto_Config"
            );
        }

        private void LogDebug(string mensagem)
        {
            if (_debugAtivo)
            {
                LogService.AddToSubfolder(mensagem, "VivaMoto_Debug");
            }
        }

        private void LogHttpDetails(string method, string endpoint, string requestBody, HttpResponseMessage response, string responseBody)
        {
            if (!_debugAtivo) return;

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

        public int Login(string email, string senha)
        {
            LogDebug("=== INICIANDO LOGIN ===");
            LogDebug("Email: " + email);

            if (!_inicializado || _httpClient == null)
            {
                _ultimoErro = "Cliente não inicializado. Chame Inicializar primeiro.";
                LogDebug("ERRO: " + _ultimoErro);
                return 0;
            }

            try
            {
                var loginData = new { Email = email, Senha = senha, LembrarMe = false };
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                LogDebug("Request Body: " + json);
                LogDebug("Content-Type: " + content.Headers.ContentType?.ToString());

                var response = _httpClient.PostAsync("/api/v1/auth/login", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                LogHttpDetails("POST", "/api/v1/auth/login", json, response, responseString);

                if (response.IsSuccessStatusCode)
                {
                    LogDebug("Response IsSuccessStatusCode: True");

                    var loginResponse = JsonConvert.DeserializeObject<LoginResponseDto>(responseString);

                    if (loginResponse?.Sucesso == true && !string.IsNullOrEmpty(loginResponse.Token))
                    {
                        _authToken = loginResponse.Token;
                        _httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", _authToken);

                        LogDebug("Login bem-sucedido. Token obtido (primeiros 20 chars): " + 
                            (_authToken.Length > 20 ? _authToken.Substring(0, 20) + "..." : _authToken));

                        _ultimoErro = "";
                        return 1;
                    }

                    _ultimoErro = loginResponse?.Mensagem ?? "Login falhou sem mensagem de erro.";
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

        public int EnviarOrdem(string jsonOrdem)
        {
            LogDebug("=== ENVIANDO ORDEM ===");
            LogDebug("JSON Recebido: " + jsonOrdem);

            if (ValidarAutenticacao() == 0) return 0;

            try
            {
                OrdemServicoSyncDto ordem = null;

                // Verifica se o JSON já vem no formato {"Ordens": [...]} do Clarion
                if (jsonOrdem.TrimStart().StartsWith("{") && jsonOrdem.Contains("\"Ordens\""))
                {
                    // JSON está no formato wrapper - extrair a primeira ordem
                    var wrapper = JsonConvert.DeserializeObject<OrdemRequestWrapper>(jsonOrdem);
                    if (wrapper?.Ordens != null && wrapper.Ordens.Count > 0)
                    {
                        ordem = wrapper.Ordens[0];
                        LogDebug("Ordem extraída do wrapper - Id: " + ordem.Id + ", Numero: " + ordem.Numero + ", EmpresaId: " + ordem.EmpresaId);
                    }
                }
                else
                {
                    // JSON é de uma ordem única (sem wrapper)
                    ordem = JsonConvert.DeserializeObject<OrdemServicoSyncDto>(jsonOrdem);
                }

                if (ordem == null)
                {
                    _ultimoErro = "JSON da Ordem de Serviço inválido ou vazio.";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                LogDebug("Ordem a enviar - Id: " + ordem.Id + ", Numero: " + ordem.Numero + ", EmpresaId: " + ordem.EmpresaId);

                var request = new { Ordens = new[] { ordem } };
                
                // Configurar para ignorar valores null na serialização
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                var json = JsonConvert.SerializeObject(request, settings);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                LogDebug("Request Body: " + json);
                LogDebug("Request Body Length: " + json.Length);
                LogDebug("Content-Type: " + content.Headers.ContentType?.ToString());

                var response = _httpClient.PostAsync("/api/v1/sync/ordens", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                LogHttpDetails("POST", "/api/v1/sync/ordens", json, response, responseString);

                if (response.IsSuccessStatusCode)
                {
                    var syncResponse = JsonConvert.DeserializeObject<SyncResponseDto>(responseString);
                    if (syncResponse != null && syncResponse.Sucesso)
                    {
                        LogDebug("Ordem enviada com sucesso");
                        _ultimoErro = "";
                        return 1;
                    }
                    else
                    {
                        _ultimoErro = syncResponse?.Mensagem ?? "Sincronização falhou.";
                        if (syncResponse?.Erros?.Count > 0)
                        {
                            _ultimoErro += " Detalhes: " + string.Join("; ", syncResponse.Erros);
                        }
                        LogDebug("ERRO: " + _ultimoErro);
                        return 0;
                    }
                }
                else
                {
                    _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao enviar ordem: {ex.Message}";
                LogDebug("EXCEÇÃO: " + ex.ToString());
                return 0;
            }
        }

        public int EnviarOrdensLote(string jsonOrdens)
        {
            LogDebug("=== ENVIANDO ORDENS EM LOTE ===");

            if (ValidarAutenticacao() == 0) return 0;

            try
            {
                var ordens = JsonConvert.DeserializeObject<List<OrdemServicoSyncDto>>(jsonOrdens);

                if (ordens == null || ordens.Count == 0)
                {
                    _ultimoErro = "Lista de ordens vazia ou JSON inválido.";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                LogDebug("Quantidade de ordens: " + ordens.Count);

                var request = new { Ordens = ordens };
                
                // Configurar para ignorar valores null na serialização
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                var json = JsonConvert.SerializeObject(request, settings);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                LogDebug("Request Body Length: " + json.Length);
                LogDebug("Content-Type: " + content.Headers.ContentType?.ToString());

                var response = _httpClient.PostAsync("/api/v1/sync/ordens", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                LogHttpDetails("POST", "/api/v1/sync/ordens", json, response, responseString);

                if (response.IsSuccessStatusCode)
                {
                    var syncResponse = JsonConvert.DeserializeObject<SyncResponseDto>(responseString);
                    if (syncResponse != null)
                    {
                        if (syncResponse.Erros?.Count > 0)
                        {
                            _ultimoErro = string.Join("; ", syncResponse.Erros);
                            LogDebug("ERROS: " + _ultimoErro);
                        }
                        else
                        {
                            _ultimoErro = "";
                            LogDebug("Lote enviado com sucesso. Total Sucesso: " + syncResponse.TotalSucesso);
                        }
                        return syncResponse.TotalSucesso > 0 ? 1 : 0;
                    }
                }

                _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                LogDebug("ERRO: " + _ultimoErro);
                return 0;
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao enviar lote: {ex.Message}";
                LogDebug("EXCEÇÃO: " + ex.ToString());
                return 0;
            }
        }

        public int AtualizarStatus(string jsonStatus)
        {
            LogDebug("=== ATUALIZANDO STATUS ===");

            if (ValidarAutenticacao() == 0) return 0;

            try
            {
                var statusUpdate = JsonConvert.DeserializeObject<StatusUpdateSyncDto>(jsonStatus);

                if (statusUpdate == null)
                {
                    _ultimoErro = "JSON de status inválido.";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                var request = new { Updates = new[] { statusUpdate } };
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                LogDebug("Request Body: " + json);
                LogDebug("Content-Type: " + content.Headers.ContentType?.ToString());

                var response = _httpClient.PostAsync("/api/v1/sync/status", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                LogHttpDetails("POST", "/api/v1/sync/status", json, response, responseString);

                if (response.IsSuccessStatusCode)
                {
                    var syncResponse = JsonConvert.DeserializeObject<SyncResponseDto>(responseString);
                    if (syncResponse != null && syncResponse.Sucesso)
                    {
                        LogDebug("Status atualizado com sucesso");
                        _ultimoErro = "";
                        return 1;
                    }
                    else
                    {
                        _ultimoErro = syncResponse?.Mensagem ?? "Atualização de status falhou.";
                        LogDebug("ERRO: " + _ultimoErro);
                        return 0;
                    }
                }
                else
                {
                    _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao atualizar status: {ex.Message}";
                LogDebug("EXCEÇÃO: " + ex.ToString());
                return 0;
            }
        }

        public int EnviarEmpresa(string jsonEmpresa)
        {
            LogDebug("=== ENVIANDO EMPRESA ===");
            LogDebug("JSON Original do Clarion: " + jsonEmpresa);

            if (ValidarAutenticacao() == 0) return 0;

            try
            {
                EmpresaSyncDto empresa = null;

                // Verifica se o JSON já vem no formato {"Empresas": [...]} do Clarion
                if (jsonEmpresa.TrimStart().StartsWith("{") && jsonEmpresa.Contains("\"Empresas\""))
                {
                    // JSON está no formato wrapper - extrair a primeira empresa
                    var wrapper = JsonConvert.DeserializeObject<EmpresaRequestWrapper>(jsonEmpresa);
                    if (wrapper?.Empresas != null && wrapper.Empresas.Count > 0)
                    {
                        empresa = wrapper.Empresas[0];
                        LogDebug("Empresa extraída do wrapper - Id: " + empresa.Id + ", Nome: " + empresa.Nome);
                    }
                }
                else
                {
                    // JSON é de uma empresa única (sem wrapper)
                    empresa = JsonConvert.DeserializeObject<EmpresaSyncDto>(jsonEmpresa);
                }

                if (empresa == null)
                {
                    _ultimoErro = "JSON da Empresa inválido ou vazio.";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                LogDebug("Empresa a enviar - Id: " + empresa.Id + ", Nome: " + empresa.Nome + ", Cnpj: " + empresa.Cnpj);

                var request = new { Empresas = new[] { empresa } };
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                LogDebug("Request Body: " + json);
                LogDebug("Content-Type: " + content.Headers.ContentType?.ToString());

                var response = _httpClient.PostAsync("/api/v1/sync/empresas", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                LogHttpDetails("POST", "/api/v1/sync/empresas", json, response, responseString);

                if (response.IsSuccessStatusCode)
                {
                    var syncResponse = JsonConvert.DeserializeObject<SyncResponseDto>(responseString);
                    if (syncResponse != null && syncResponse.Sucesso)
                    {
                        LogDebug("Empresa enviada com sucesso");
                        _ultimoErro = "";
                        return 1;
                    }
                    else
                    {
                        _ultimoErro = syncResponse?.Mensagem ?? "Sincronização de empresa falhou.";
                        LogDebug("ERRO: " + _ultimoErro);
                        return 0;
                    }
                }
                else
                {
                    _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao sincronizar empresa: {ex.Message}";
                LogDebug("EXCEÇÃO: " + ex.ToString());
                return 0;
            }
        }

        public int EnviarUsuario(string jsonUsuario)
        {
            LogDebug("=== ENVIANDO USUÁRIO ===");

            if (ValidarAutenticacao() == 0) return 0;

            try
            {
                var usuario = JsonConvert.DeserializeObject<UsuarioSyncDto>(jsonUsuario);

                if (usuario == null)
                {
                    _ultimoErro = "JSON do usuário inválido.";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }

                var request = new { Usuarios = new[] { usuario } };
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                LogDebug("Request Body: " + json);
                LogDebug("Content-Type: " + content.Headers.ContentType?.ToString());

                var response = _httpClient.PostAsync("/api/v1/sync/usuarios", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                LogHttpDetails("POST", "/api/v1/sync/usuarios", json, response, responseString);

                if (response.IsSuccessStatusCode)
                {
                    var syncResponse = JsonConvert.DeserializeObject<SyncResponseDto>(responseString);
                    if (syncResponse != null && syncResponse.Sucesso)
                    {
                        LogDebug("Usuário enviado com sucesso");
                        _ultimoErro = "";
                        return 1;
                    }
                    else
                    {
                        _ultimoErro = syncResponse?.Mensagem ?? "Sincronização de usuário falhou.";
                        LogDebug("ERRO: " + _ultimoErro);
                        return 0;
                    }
                }
                else
                {
                    _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                    LogDebug("ERRO: " + _ultimoErro);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao sincronizar usuário: {ex.Message}";
                LogDebug("EXCEÇÃO: " + ex.ToString());
                return 0;
            }
        } 

        /// <summary>
        /// Gera um hash SHA-256 da senha fornecida e retorna em formato Base64.
        /// Utilizado para criar senhas seguras antes de enviar à API.
        /// </summary>
        /// <param name="password">Senha em texto plano a ser hasheada</param>
        /// <returns>Hash SHA-256 da senha codificado em Base64</returns>
        public string ObterSenhaHash(string password)
        {
            var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        /// <summary>
        /// Obtém a última mensagem de erro ocorrida.
        /// Método alternativo para compatibilidade COM/Interop com Clarion.
        /// </summary>
        /// <returns>String com a mensagem de erro ou vazia se não houver erro</returns>
        public string ObterUltimoErro()
        {
            return _ultimoErro;
        }

        private int ValidarAutenticacao()
        {
            if (!_inicializado || _httpClient == null)
            {
                _ultimoErro = "Cliente não inicializado.";
                LogDebug("ERRO ValidarAutenticacao: " + _ultimoErro);
                return 0;
            }

            if (string.IsNullOrEmpty(_authToken))
            {
                _ultimoErro = "Não autenticado. Chame Login primeiro.";
                LogDebug("ERRO ValidarAutenticacao: " + _ultimoErro);
                return 0;
            }

            return 1;
        }

        public void Finalizar()
        {
            LogDebug("=== FINALIZANDO VIVAMOTOAPISERVICE ===");
            _httpClient?.Dispose();
            _httpClient = null;
            _authToken = "";
            _ultimoErro = "";
            _inicializado = false;
        }
    }
}
