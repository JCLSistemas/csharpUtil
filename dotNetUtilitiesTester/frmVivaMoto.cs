using CSharpUtil.Motoboy;
using CSharpUtil.Motoboy.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace dotNetUtilitiesTester
{
    public partial class frmVivaMoto : Form
    {
        private VivaMotoApiService client;

        public frmVivaMoto()
        {
            InitializeComponent();
            txtbaseUrl.Text = "https://vivamoto.onrender.com/";
            txtUsuario.Text = "admin@vivamoto.com.br";
            txtSenha.Text = "123456"; 
        }

        private void btnInicializar_Click(object sender, EventArgs e)
        {
            try
            {
                string urlApi = txtbaseUrl.Text;
                
                if (string.IsNullOrWhiteSpace(urlApi))
                {
                    MessageBox.Show("Por favor, informe a URL base da API.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                client = new VivaMotoApiService(urlApi);
                txtResult.Text = $"=== API Inicializada ===\r\n\r\n";
                txtResult.Text += $"URL Base: {urlApi}\r\n";
                txtResult.Text += $"Status: Pronta para autenticação\r\n\r\n";
                
                btnLogin.Enabled = true;
                MessageBox.Show("API inicializada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                txtResult.Text = $"❌ Erro ao inicializar API: {ex.Message}\r\n";
                MessageBox.Show($"Erro ao inicializar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                MessageBox.Show("Por favor, inicialize a API primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string email = txtUsuario.Text;
                string senha = txtSenha.Text;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                {
                    MessageBox.Show("Por favor, informe usuário e senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtResult.Text = "=== Executando Login ===\r\n\r\n";
                txtResult.Text += $"Usuário: {email}\r\n";
                txtResult.Text += "Autenticando...\r\n\r\n";

                var logado = client.Login(email, senha);

                if (logado == 1)
                {
                    txtResult.Text += "✅ Login realizado com sucesso!\r\n";
                    txtResult.Text += $"Token: {client.AuthToken.Substring(0, Math.Min(50, client.AuthToken.Length))}...\r\n\r\n";
                    
                    // Habilita os outros botões após login bem-sucedido
                    btnEnviarEmpresa.Enabled = true;
                    btnEnviarOrdem.Enabled = true;
                    btnEnviarUsuario.Enabled = true;
                    btnAtualizarStatus.Enabled = true;
                    
                    MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtResult.Text += $"❌ Falha no login!\r\n";
                    txtResult.Text += $"Erro: {client.UltimoErro}\r\n\r\n";
                    MessageBox.Show($"Falha no login: {client.UltimoErro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                txtResult.Text += $"❌ Exceção: {ex.Message}\r\n";
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarEmpresa_Click(object sender, EventArgs e)
        {
            if (!ValidarClienteAutenticado()) return;

            try
            {
                txtResult.Text = "=== Enviando Empresa ===\r\n\r\n";

                var empresaTeste = new EmpresaSyncDto
                {
                    Id = Guid.NewGuid(),
                    Nome = "Empresa Teste C#",
                    Cnpj = "12.345.678/0001-99",
                    Telefone = "(11) 91234-5678",
                    Ativo = true,
                    DataUltimaOS = DateTime.Now
                };

                txtResult.Text += $"Dados da Empresa:\r\n";
                txtResult.Text += $"  Nome: {empresaTeste.Nome}\r\n";
                txtResult.Text += $"  CNPJ: {empresaTeste.Cnpj}\r\n";
                txtResult.Text += $"  Telefone: {empresaTeste.Telefone}\r\n\r\n";

                // Serializa o objeto empresa para JSON
                string jsonEmpresa = JsonConvert.SerializeObject(empresaTeste, Formatting.Indented);
                txtResult.Text += $"JSON Enviado:\r\n{jsonEmpresa}\r\n\r\n";
                txtResult.Text += "Enviando...\r\n";

                var resultado = client.EnviarEmpresa(jsonEmpresa);

                if (resultado == 1)
                {
                    txtResult.Text += "✅ Empresa enviada com sucesso!\r\n\r\n";
                    MessageBox.Show("Empresa enviada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtResult.Text += $"❌ Erro ao enviar empresa:\r\n{client.UltimoErro}\r\n\r\n";
                    MessageBox.Show($"Erro: {client.UltimoErro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                txtResult.Text += $"❌ Exceção: {ex.Message}\r\n";
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarOrdem_Click(object sender, EventArgs e)
        {
            if (!ValidarClienteAutenticado()) return;

            try
            {
                txtResult.Text = "=== Enviando Ordem de Serviço ===\r\n\r\n";

                var ordemTeste = new OrdemServicoSyncDto
                {
                    Id = Guid.NewGuid(),
                    Numero = new Random().Next(10000, 99999),
                    EmpresaId = 13,
                    EmpresaNome = "Cliente Teste C#",
                    SolicitanteNome = "Sistema de Teste",
                    Departamento = "TI",
                    Telefone = "(11) 99999-9999",
                    MotoboyNome = "Motoboy Exemplo",
                    DataEmissao = DateTime.Now,
                    ValorTotal = 150.00m
                };

                txtResult.Text += $"Dados da Ordem:\r\n";
                txtResult.Text += $"  Número: {ordemTeste.Numero}\r\n";
                txtResult.Text += $"  Empresa: {ordemTeste.EmpresaNome}\r\n";
                txtResult.Text += $"  Solicitante: {ordemTeste.SolicitanteNome}\r\n";
                txtResult.Text += $"  Valor Total: R$ {ordemTeste.ValorTotal:N2}\r\n\r\n";

                // Serializa o objeto ordem para JSON
                string jsonOrdem = JsonConvert.SerializeObject(ordemTeste, Formatting.Indented);
                txtResult.Text += $"JSON Enviado:\r\n{jsonOrdem}\r\n\r\n";
                txtResult.Text += "Enviando...\r\n";

                var resultado = client.EnviarOrdem(jsonOrdem);

                if (resultado == 1)
                {
                    txtResult.Text += "✅ Ordem de Serviço enviada com sucesso!\r\n\r\n";
                    MessageBox.Show("Ordem enviada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtResult.Text += $"❌ Erro ao enviar ordem:\r\n{client.UltimoErro}\r\n\r\n";
                    MessageBox.Show($"Erro: {client.UltimoErro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                txtResult.Text += $"❌ Exceção: {ex.Message}\r\n";
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarClienteAutenticado()) return;

            try
            {
                txtResult.Text = "=== Enviando Usuário ===\r\n\r\n";

                var usuarioTeste = new
                {
                    Email = "teste@vivamoto.com.br",
                    SenhaHash = "hash_senha_exemplo",
                    Nome = "Usuário JCL Sistemas",
                    Ativo = true,
                    EmpresaIds = new List<Guid> { Guid.NewGuid() }
                };

                txtResult.Text += $"Dados do Usuário:\r\n";
                txtResult.Text += $"  Email: {usuarioTeste.Email}\r\n";
                txtResult.Text += $"  Nome: {usuarioTeste.Nome}\r\n";
                txtResult.Text += $"  Ativo: {usuarioTeste.Ativo}\r\n\r\n";

                // Serializa o objeto usuário para JSON
                string jsonUsuario = JsonConvert.SerializeObject(usuarioTeste, Formatting.Indented);
                txtResult.Text += $"JSON Enviado:\r\n{jsonUsuario}\r\n\r\n";
                txtResult.Text += "Enviando...\r\n";

                var resultado = client.EnviarUsuario(jsonUsuario);

                if (resultado == 1)
                {
                    txtResult.Text += "✅ Usuário enviado com sucesso!\r\n\r\n";
                    MessageBox.Show("Usuário enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtResult.Text += $"❌ Erro ao enviar usuário:\r\n{client.UltimoErro}\r\n\r\n";
                    MessageBox.Show($"Erro: {client.UltimoErro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                txtResult.Text += $"❌ Exceção: {ex.Message}\r\n";
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizarStatus_Click(object sender, EventArgs e)
        {
            if (!ValidarClienteAutenticado()) return;

            try
            {
                txtResult.Text = "=== Atualizando Status da OS ===\r\n\r\n";

                var statusUpdate = new
                {
                    IdOs = "12345",
                    EmpresaId = "13",
                    NovoStatus = "EmEntrega",
                    Observacao = "Status atualizado via teste C#"
                };

                txtResult.Text += $"Dados da Atualização:\r\n";
                txtResult.Text += $"  ID OS: {statusUpdate.IdOs}\r\n";
                txtResult.Text += $"  Empresa ID: {statusUpdate.EmpresaId}\r\n";
                txtResult.Text += $"  Novo Status: {statusUpdate.NovoStatus}\r\n";
                txtResult.Text += $"  Observação: {statusUpdate.Observacao}\r\n\r\n";

                // Serializa o objeto status para JSON
                string jsonStatus = JsonConvert.SerializeObject(statusUpdate, Formatting.Indented);
                txtResult.Text += $"JSON Enviado:\r\n{jsonStatus}\r\n\r\n";
                txtResult.Text += "Enviando...\r\n";

                var resultado = client.AtualizarStatus(jsonStatus);

                if (resultado == 1)
                {
                    txtResult.Text += "✅ Status atualizado com sucesso!\r\n\r\n";
                    MessageBox.Show("Status atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtResult.Text += $"❌ Erro ao atualizar status:\r\n{client.UltimoErro}\r\n\r\n";
                    MessageBox.Show($"Erro: {client.UltimoErro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                txtResult.Text += $"❌ Exceção: {ex.Message}\r\n";
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarClienteAutenticado()
        {
            if (client == null)
            {
                MessageBox.Show("Por favor, inicialize a API primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!client.EstaConectado)
            {
                MessageBox.Show("Por favor, faça o login primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
