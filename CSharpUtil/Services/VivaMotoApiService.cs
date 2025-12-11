using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpUtil.VivaMoto
{
    public class VivaMotoApiService
    {
        private HttpClient _httpClient = null;
        private string _baseUrl = "";
        private string _authToken = "";
        private string _ultimoErro = "";
        private bool _inicializado = false;

        public string UltimoErro => _ultimoErro;
        public string AuthToken => _authToken;
        public bool EstaConectado => _inicializado && !string.IsNullOrEmpty(_authToken);

        /// <summary>
        /// Inicializa o serviço VivaMoto com a URL base da API.
        /// Configura o HttpClient com timeout de 60 segundos e headers padrão para JSON.
        /// </summary>
        /// <param name="baseUrl">URL base da API VivaMoto (ex: http://localhost:5000 ou https://vivamoto.onrender.com ou https://api.vivamoto.com)</param>
        public VivaMotoApiService(string baseUrl)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                _inicializado = false;
                _ultimoErro = $"Erro ao inicializar: {ex.Message}";
            }

        }

        /// <summary>
        /// Autentica o usuário na API VivaMoto e obtém o token de autenticação Bearer.
        /// O token é armazenado automaticamente e usado nas próximas requisições.
        /// </summary>
        /// <param name="email">Email do usuário para login</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>True se o login foi bem-sucedido, False caso contrário. Verifique UltimoErro em caso de falha.</returns>
        public bool Login(string email, string senha)
        {
            if (!_inicializado || _httpClient == null)
            {
                _ultimoErro = "Cliente não inicializado. Chame Inicializar primeiro.";
                return false;
            }

            try
            {
                var loginData = new { Email = email, Senha = senha, LembrarMe = false };
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync("/api/v1/auth/login", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = JsonConvert.DeserializeObject<LoginResponseDto>(responseString);

                    if (loginResponse?.Sucesso == true && !string.IsNullOrEmpty(loginResponse.Token))
                    {
                        _authToken = loginResponse.Token;
                        _httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", _authToken);
                        _ultimoErro = "";
                        return true;
                    }

                    _ultimoErro = loginResponse?.Mensagem ?? "Login falhou sem mensagem de erro.";
                    return false;
                }

                _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                return false;
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção no login: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Envia uma ordem de serviço para sincronização.
        /// </summary>
        /// <param name="jsonOrdem">JSON da ordem no formato OrdemServicoDto</param>
        /// <returns>1 = sucesso, 0 = falha</returns>
        public bool EnviarOrdem(string jsonOrdem)
        {
            if (!ValidarAutenticacao()) return false;

            try
            {
                // Deserializa a ordem individual
                var ordem = JsonConvert.DeserializeObject<OrdemServicoSyncDto>(jsonOrdem);

                if (ordem == null)
                {
                    _ultimoErro = "JSON da Ordem de Serviço inválido.";
                    return false;
                }

                // Envolve em um array conforme API espera
                var request = new { Ordens = new[] { ordem } };
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync("/api/v1/sync/ordens", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    var syncResponse = JsonConvert.DeserializeObject<SyncResponseDto>(responseString);
                    if (syncResponse != null && syncResponse.Sucesso)
                    {
                        _ultimoErro = "";
                        return true;
                    }
                    else
                    {
                        _ultimoErro = syncResponse?.Mensagem ?? "Sincronização falhou.";
                        if (syncResponse?.Erros?.Count > 0)
                        {
                            _ultimoErro += " Detalhes: " + string.Join("; ", syncResponse.Erros);
                        }
                        return false;
                    }
                }
                else
                {
                    _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                    return false;
                }
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao enviar ordem: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Envia múltiplas ordens de serviço em lote.
        /// </summary>
        /// <param name="jsonOrdens">JSON array de ordens no formato [OrdemServicoDto, ...]</param>
        /// <returns>Quantidade de ordens processadas com sucesso, -1 = erro</returns>
        public int EnviarOrdensLote(string jsonOrdens)
        {
            if (!ValidarAutenticacao()) return -1;

            try
            {
                var ordens = JsonConvert.DeserializeObject<List<OrdemServicoSyncDto>>(jsonOrdens);

                if (ordens == null || ordens.Count == 0)
                {
                    _ultimoErro = "Lista de ordens vazia ou JSON inválido.";
                    return -1;
                }

                var request = new { Ordens = ordens };
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync("/api/v1/sync/ordens", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    var syncResponse = JsonConvert.DeserializeObject<SyncResponseDto>(responseString);
                    if (syncResponse != null)
                    {
                        if (syncResponse.Erros?.Count > 0)
                        {
                            _ultimoErro = string.Join("; ", syncResponse.Erros);
                        }
                        else
                        {
                            _ultimoErro = "";
                        }
                        return syncResponse.TotalSucesso;
                    }
                }

                _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                return -1;
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao enviar lote: {ex.Message}";
                return -1;
            }
        }

        /// <summary>
        /// Atualiza o status de uma ordem de serviço.
        /// </summary>
        /// <param name="jsonStatus">JSON do update no formato StatusUpdateDto</param>
        /// <returns>1 = sucesso, 0 = falha</returns>
        public bool AtualizarStatus(string jsonStatus)
        {
            if (!ValidarAutenticacao()) return false;

            try
            {
                var statusUpdate = JsonConvert.DeserializeObject<StatusUpdateDto>(jsonStatus);

                if (statusUpdate == null)
                {
                    _ultimoErro = "JSON de status inválido.";
                    return false;
                }

                var request = new { Updates = new[] { statusUpdate } };
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync("/api/v1/sync/status", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    var syncResponse = JsonConvert.DeserializeObject<SyncResponseDto>(responseString);
                    if (syncResponse != null && syncResponse.Sucesso)
                    {
                        _ultimoErro = "";
                        return true;
                    }
                    else
                    {
                        _ultimoErro = syncResponse?.Mensagem ?? "Atualização de status falhou.";
                        return false;
                    }
                }
                else
                {
                    _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                    return false;
                }
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao atualizar status: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Sincroniza dados de empresa.
        /// </summary>
        /// <param name="jsonEmpresa">JSON da empresa no formato EmpresaDto</param>
        /// <returns>1 = sucesso, 0 = falha</returns>
        public bool EnviarEmpresa(string jsonEmpresa)
        {
            if (!ValidarAutenticacao()) return false;

            try
            {
                var empresa = JsonConvert.DeserializeObject<EmpresaDto>(jsonEmpresa);

                if (empresa == null)
                {
                    _ultimoErro = "JSON da empresa inválido.";
                    return false;
                }

                var request = new { Empresas = new[] { empresa } };
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync("/api/v1/sync/empresas", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    var syncResponse = JsonConvert.DeserializeObject<SyncResponseDto>(responseString);
                    if (syncResponse != null && syncResponse.Sucesso)
                    {
                        _ultimoErro = "";
                        return true;
                    }
                    else
                    {
                        _ultimoErro = syncResponse?.Mensagem ?? "Sincronização de empresa falhou.";
                        return false;
                    }
                }
                else
                {
                    _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                    return false;
                }
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao sincronizar empresa: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Sincroniza dados de usuário.
        /// </summary>
        /// <param name="jsonUsuario">JSON do usuário no formato UsuarioSyncDto</param>
        /// <returns>1 = sucesso, 0 = falha</returns>
        public bool EnviarUsuario(string jsonUsuario)
        {
            if (!ValidarAutenticacao()) return false;

            try
            {
                var usuario = JsonConvert.DeserializeObject<UsuarioSyncDto>(jsonUsuario);

                if (usuario == null)
                {
                    _ultimoErro = "JSON do usuário inválido.";
                    return false;
                }

                var request = new { Usuarios = new[] { usuario } };
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync("/api/v1/sync/usuarios", content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    var syncResponse = JsonConvert.DeserializeObject<SyncResponseDto>(responseString);
                    if (syncResponse != null && syncResponse.Sucesso)
                    {
                        _ultimoErro = "";
                        return true;
                    }
                    else
                    {
                        _ultimoErro = syncResponse?.Mensagem ?? "Sincronização de usuário falhou.";
                        return false;
                    }
                }
                else
                {
                    _ultimoErro = $"HTTP {(int)response.StatusCode}: {responseString}";
                    return false;
                }
            }
            catch (Exception ex)
            {
                _ultimoErro = $"Exceção ao sincronizar usuário: {ex.Message}";
                return false;
            }
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

        /// <summary>
        /// Valida se o serviço está inicializado e autenticado.
        /// Define a propriedade UltimoErro com mensagem apropriada em caso de falha.
        /// </summary>
        /// <returns>True se está inicializado e autenticado, False caso contrário</returns>
        private bool ValidarAutenticacao()
        {
            if (!_inicializado || _httpClient == null)
            {
                _ultimoErro = "Cliente não inicializado.";
                return false;
            }

            if (string.IsNullOrEmpty(_authToken))
            {
                _ultimoErro = "Não autenticado. Chame Login primeiro.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Finaliza o cliente e libera recursos.
        /// </summary>
        public void Finalizar()
        {
            _httpClient?.Dispose();
            _httpClient = null;
            _authToken = "";
            _ultimoErro = "";
            _inicializado = false;
        }


    }

    #region DTOs Internos

    internal class LoginResponseDto
    {
        public bool Sucesso { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
    }

    internal class SyncResponseDto
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public int TotalProcessados { get; set; }
        public int TotalSucesso { get; set; }
        public int TotalErros { get; set; }
        public List<string> Erros { get; set; } = new List<string>();
    }

    /// <summary>
    /// DTO para sincronização de Ordem de Serviço.
    /// Espelha o OrdemServicoDto da API.
    /// </summary>
    internal class OrdemServicoSyncDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime? DataEmissao { get; set; }
        public int EmpresaId { get; set; }
        public string EmpresaNome { get; set; } = string.Empty;
        public string SolicitanteNome { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Ramal { get; set; } = string.Empty;
        public string EnderecoEntrega { get; set; } = string.Empty;
        public int? MotoboyId { get; set; }
        public string MotoboyNome { get; set; } = string.Empty;

        // Datas e Horários
        public string HoraInicial { get; set; } = string.Empty; // TimeSpan como string "HH:mm:ss"
        public DateTime? DataFinal { get; set; }
        public string HoraFinal { get; set; } = string.Empty;

        // Tempos (TimeSpan como string "HH:mm:ss")
        public string TempoTotal { get; set; } = string.Empty;
        public string TempoMinimo { get; set; } = string.Empty;
        public string TempoExecucao { get; set; } = string.Empty;
        public string HorasServico { get; set; } = string.Empty;
        public string HorasExtras { get; set; } = string.Empty;
        public string HorasAdicional { get; set; } = string.Empty;
        public string HorasEspera { get; set; } = string.Empty;

        // Quantidades
        public decimal? QuantidadeKm { get; set; }
        public decimal? QuantidadePontos { get; set; }
        public decimal? QuantidadePontosAdicionais { get; set; }

        // Valores Unitários
        public decimal? ValorHora { get; set; }
        public decimal? ValorExtra { get; set; }
        public decimal? ValorHoraEspera { get; set; }
        public decimal? ValorViagem { get; set; }
        public decimal? ValorPonto { get; set; }
        public decimal? ValorAdicional { get; set; }
        public decimal? ValorKm { get; set; }

        // Totais
        public decimal? TotalHoras { get; set; }
        public decimal? TotalHorasEspera { get; set; }
        public decimal? TotalExtras { get; set; }
        public decimal? TotalKm { get; set; }
        public decimal? TotalPontos { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorTotal { get; set; }

        // Faturamento
        public string CondicaoFaturamento { get; set; } = string.Empty;
        public int? PrazoPagamento { get; set; }
        public int? NumeroFatura { get; set; }
        public DateTime? DataFaturamento { get; set; }
        public DateTime? DataVencimento { get; set; }

        // Sistema
        public string Usuario { get; set; } = string.Empty;
        public DateTime? DataAtualizacao { get; set; }

        // Status: usar valor inteiro do enum ou string
        // 0=Pendente, 1=EmAndamento, 2=EmEntrega, 3=Entregue, 4=Cancelada, 5=Retornada
        public int Status { get; set; }
    }

    internal class StatusUpdateDto
    {
        public string IdOs { get; set; } = string.Empty;
        public string EmpresaId { get; set; } = string.Empty;
        public string NovoStatus { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
    }

    internal class EmpresaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }

    internal class UsuarioSyncDto
    {
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public List<int> EmpresaIds { get; set; } = new List<int>();
    }
    #endregion DTOs Internos
}
