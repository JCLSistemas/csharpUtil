using CSharpUtil.Motoboy;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace dotNetUtilitiesTester
{
    public partial class frmVivaMoto : Form
    {
        public VivaMotoApiService client;

        public frmVivaMoto()
        {
            InitializeComponent();
            txtbaseUrl.Text = "https://vivamoto.onrender.com/";
            txtUsuario.Text = "admin@fewwords.com.br";
            txtSenha.Text = "fwords10";
            cboTipoEnvio.SelectedIndex = 0;
        }


        private void btnEnviarJsonManual_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonManual = txtJsonManual.Text.Trim();

                if (string.IsNullOrWhiteSpace(jsonManual))
                {
                    MessageBox.Show("Por favor, insira o JSON a ser enviado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar se é JSON válido
                try
                {
                    var obj = JsonConvert.DeserializeObject(jsonManual);
                }
                catch (JsonException)
                {
                    MessageBox.Show("O JSON informado não é válido. Verifique a sintaxe.", "JSON Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Inicializar e fazer login automaticamente
                if (!InicializarELogar())
                    return;

                string tipoSelecionado = cboTipoEnvio.SelectedItem?.ToString() ?? "";
                int resultado = 0;

                txtResult.Text = $"=== Enviando JSON Manual ===\r\n\r\n";
                txtResult.Text += $"Tipo: {tipoSelecionado}\r\n";
                txtResult.Text += $"JSON:\r\n{jsonManual}\r\n\r\n";
                txtResult.Text += "Enviando...\r\n\r\n";

                switch (cboTipoEnvio.SelectedIndex)
                {
                    case 0: // Empresas
                        resultado = client.EnviarEmpresas(jsonManual);
                        break;
                    case 1: // Ordens
                        resultado = client.EnviarOrdens(jsonManual);
                        break;
                    case 2: // Usuários
                        resultado = client.EnviarUsuarios(jsonManual);
                        break;
                    case 3: // Status
                        resultado = client.AtualizarStatus(jsonManual);
                        break;
                    default:
                        MessageBox.Show("Selecione um tipo de envio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                if (resultado == 1)
                {
                    txtResult.Text += "✅ JSON enviado com sucesso!\r\n\r\n";
                    txtResult.Text += $"=== RESPOSTA DA API ===\r\n{FormatarJson(client.ObterUltimaResposta())}\r\n";
                    MessageBox.Show("JSON enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtResult.Text += $"❌ Erro ao enviar JSON:\r\n{client.UltimoErro}\r\n\r\n";
                    txtResult.Text += $"=== RESPOSTA DA API ===\r\n{FormatarJson(client.ObterUltimaResposta())}\r\n";
                    MessageBox.Show($"Erro: {client.UltimoErro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                txtResult.Text += $"❌ Exceção: {ex.Message}\r\n";
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimparJson_Click(object sender, EventArgs e)
        {
            txtJsonManual.Clear();
            txtResult.Clear();
        }

        private string FormatarJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return "(vazio)";

            try
            {
                var obj = JsonConvert.DeserializeObject(json);
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            catch
            {
                return json;
            }
        }

        /// <summary>
        /// Inicializa a API e realiza o login automaticamente
        /// </summary>
        private bool InicializarELogar()
        {
            try
            {
                // Validar campos obrigatórios
                if (string.IsNullOrWhiteSpace(txtbaseUrl.Text))
                {
                    MessageBox.Show("Por favor, informe a URL base da API.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    MessageBox.Show("Por favor, informe usuário e senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Inicializar o cliente
                client = new VivaMotoApiService(txtbaseUrl.Text.Trim());

                // Realizar login
                txtResult.Text = "Conectando à API...\r\n";
                txtResult.Text += $"URL: {txtbaseUrl.Text.Trim()}\r\n";
                txtResult.Text += $"Usuário: {txtUsuario.Text.Trim()}\r\n\r\n";

                int loginResult = client.Login(txtUsuario.Text.Trim(), txtSenha.Text);

                if (loginResult == 1)
                {
                    txtResult.Text += "✅ Login realizado com sucesso!\r\n\r\n";
                    return true;
                }
                else
                {
                    txtResult.Text += $"❌ Erro no login: {client.UltimoErro}\r\n";
                    MessageBox.Show($"Erro no login: {client.UltimoErro}", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                txtResult.Text += $"❌ Exceção ao conectar: {ex.Message}\r\n";
                MessageBox.Show($"Erro ao conectar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
