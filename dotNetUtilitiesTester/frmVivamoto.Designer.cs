namespace dotNetUtilitiesTester
{
    partial class frmVivaMoto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelBaseURL = new System.Windows.Forms.Label();
            this.btnInicializar = new System.Windows.Forms.Button();
            this.txtbaseUrl = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.LabelUsuario = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnEnviarEmpresa = new System.Windows.Forms.Button();
            this.btnEnviarOrdem = new System.Windows.Forms.Button();
            this.btnEnviarUsuario = new System.Windows.Forms.Button();
            this.btnAtualizarStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBaseURL
            // 
            this.labelBaseURL.AutoSize = true;
            this.labelBaseURL.Location = new System.Drawing.Point(17, 19);
            this.labelBaseURL.Name = "labelBaseURL";
            this.labelBaseURL.Size = new System.Drawing.Size(47, 13);
            this.labelBaseURL.TabIndex = 0;
            this.labelBaseURL.Text = "Base Url";
            // 
            // btnInicializar
            // 
            this.btnInicializar.Location = new System.Drawing.Point(20, 120);
            this.btnInicializar.Name = "btnInicializar";
            this.btnInicializar.Size = new System.Drawing.Size(140, 35);
            this.btnInicializar.TabIndex = 1;
            this.btnInicializar.Text = "Inicializar API";
            this.btnInicializar.UseVisualStyleBackColor = true;
            this.btnInicializar.Click += new System.EventHandler(this.btnInicializar_Click);
            // 
            // txtbaseUrl
            // 
            this.txtbaseUrl.Location = new System.Drawing.Point(66, 15);
            this.txtbaseUrl.Name = "txtbaseUrl";
            this.txtbaseUrl.Size = new System.Drawing.Size(258, 20);
            this.txtbaseUrl.TabIndex = 2;
            // 
            // txtResult
            // 
            this.txtResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtResult.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtResult.Location = new System.Drawing.Point(12, 238);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(760, 300);
            this.txtResult.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 220);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Resultado da Consulta";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(66, 56);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(258, 20);
            this.txtUsuario.TabIndex = 15;
            // 
            // LabelUsuario
            // 
            this.LabelUsuario.AutoSize = true;
            this.LabelUsuario.Location = new System.Drawing.Point(17, 55);
            this.LabelUsuario.Name = "LabelUsuario";
            this.LabelUsuario.Size = new System.Drawing.Size(46, 13);
            this.LabelUsuario.TabIndex = 16;
            this.LabelUsuario.Text = "Usuário:";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(66, 83);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(258, 20);
            this.txtSenha.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Senha:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(166, 120);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(140, 35);
            this.btnLogin.TabIndex = 20;
            this.btnLogin.Text = "1. Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnEnviarEmpresa
            // 
            this.btnEnviarEmpresa.Enabled = false;
            this.btnEnviarEmpresa.Location = new System.Drawing.Point(312, 120);
            this.btnEnviarEmpresa.Name = "btnEnviarEmpresa";
            this.btnEnviarEmpresa.Size = new System.Drawing.Size(140, 35);
            this.btnEnviarEmpresa.TabIndex = 21;
            this.btnEnviarEmpresa.Text = "2. Enviar Empresa";
            this.btnEnviarEmpresa.UseVisualStyleBackColor = true;
            this.btnEnviarEmpresa.Click += new System.EventHandler(this.btnEnviarEmpresa_Click);
            // 
            // btnEnviarOrdem
            // 
            this.btnEnviarOrdem.Enabled = false;
            this.btnEnviarOrdem.Location = new System.Drawing.Point(20, 171);
            this.btnEnviarOrdem.Name = "btnEnviarOrdem";
            this.btnEnviarOrdem.Size = new System.Drawing.Size(140, 35);
            this.btnEnviarOrdem.TabIndex = 22;
            this.btnEnviarOrdem.Text = "3. Enviar Ordem";
            this.btnEnviarOrdem.UseVisualStyleBackColor = true;
            this.btnEnviarOrdem.Click += new System.EventHandler(this.btnEnviarOrdem_Click);
            // 
            // btnEnviarUsuario
            // 
            this.btnEnviarUsuario.Enabled = false;
            this.btnEnviarUsuario.Location = new System.Drawing.Point(166, 171);
            this.btnEnviarUsuario.Name = "btnEnviarUsuario";
            this.btnEnviarUsuario.Size = new System.Drawing.Size(140, 35);
            this.btnEnviarUsuario.TabIndex = 23;
            this.btnEnviarUsuario.Text = "4. Enviar Usuário";
            this.btnEnviarUsuario.UseVisualStyleBackColor = true;
            this.btnEnviarUsuario.Click += new System.EventHandler(this.btnEnviarUsuario_Click);
            // 
            // btnAtualizarStatus
            // 
            this.btnAtualizarStatus.Enabled = false;
            this.btnAtualizarStatus.Location = new System.Drawing.Point(312, 171);
            this.btnAtualizarStatus.Name = "btnAtualizarStatus";
            this.btnAtualizarStatus.Size = new System.Drawing.Size(140, 35);
            this.btnAtualizarStatus.TabIndex = 24;
            this.btnAtualizarStatus.Text = "5. Atualizar Status";
            this.btnAtualizarStatus.UseVisualStyleBackColor = true;
            this.btnAtualizarStatus.Click += new System.EventHandler(this.btnAtualizarStatus_Click);
            // 
            // frmVivaMoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnAtualizarStatus);
            this.Controls.Add(this.btnEnviarUsuario);
            this.Controls.Add(this.btnEnviarOrdem);
            this.Controls.Add(this.btnEnviarEmpresa);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.LabelUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtbaseUrl);
            this.Controls.Add(this.btnInicializar);
            this.Controls.Add(this.labelBaseURL);
            this.Name = "frmVivaMoto";
            this.Text = "Teste VivaMoto API Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBaseURL;
        private System.Windows.Forms.Button btnInicializar;
        private System.Windows.Forms.TextBox txtbaseUrl;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label LabelUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnEnviarEmpresa;
        private System.Windows.Forms.Button btnEnviarOrdem;
        private System.Windows.Forms.Button btnEnviarUsuario;
        private System.Windows.Forms.Button btnAtualizarStatus;
    }
}