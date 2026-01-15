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
            this.txtbaseUrl = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.LabelUsuario = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpJsonManual = new System.Windows.Forms.GroupBox();
            this.btnLimparJson = new System.Windows.Forms.Button();
            this.btnEnviarJsonManual = new System.Windows.Forms.Button();
            this.cboTipoEnvio = new System.Windows.Forms.ComboBox();
            this.lblTipoEnvio = new System.Windows.Forms.Label();
            this.txtJsonManual = new System.Windows.Forms.TextBox();
            this.lblJsonManual = new System.Windows.Forms.Label();
            this.grpJsonManual.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelBaseURL
            // 
            this.labelBaseURL.AutoSize = true;
            this.labelBaseURL.Location = new System.Drawing.Point(13, 16);
            this.labelBaseURL.Name = "labelBaseURL";
            this.labelBaseURL.Size = new System.Drawing.Size(47, 13);
            this.labelBaseURL.TabIndex = 0;
            this.labelBaseURL.Text = "Base Url";
            // 
            // txtbaseUrl
            // 
            this.txtbaseUrl.Location = new System.Drawing.Point(64, 12);
            this.txtbaseUrl.Name = "txtbaseUrl";
            this.txtbaseUrl.Size = new System.Drawing.Size(237, 20);
            this.txtbaseUrl.TabIndex = 2;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtResult.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtResult.Location = new System.Drawing.Point(12, 473);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(880, 176);
            this.txtResult.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 455);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Resultado da Consulta";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(368, 13);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(236, 20);
            this.txtUsuario.TabIndex = 15;
            // 
            // LabelUsuario
            // 
            this.LabelUsuario.AutoSize = true;
            this.LabelUsuario.Location = new System.Drawing.Point(321, 17);
            this.LabelUsuario.Name = "LabelUsuario";
            this.LabelUsuario.Size = new System.Drawing.Size(46, 13);
            this.LabelUsuario.TabIndex = 16;
            this.LabelUsuario.Text = "Usuário:";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(672, 13);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(220, 20);
            this.txtSenha.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(625, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Senha:";
            // 
            // grpJsonManual
            // 
            this.grpJsonManual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpJsonManual.Controls.Add(this.btnLimparJson);
            this.grpJsonManual.Controls.Add(this.btnEnviarJsonManual);
            this.grpJsonManual.Controls.Add(this.cboTipoEnvio);
            this.grpJsonManual.Controls.Add(this.lblTipoEnvio);
            this.grpJsonManual.Controls.Add(this.txtJsonManual);
            this.grpJsonManual.Controls.Add(this.lblJsonManual);
            this.grpJsonManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpJsonManual.Location = new System.Drawing.Point(12, 42);
            this.grpJsonManual.Name = "grpJsonManual";
            this.grpJsonManual.Size = new System.Drawing.Size(880, 403);
            this.grpJsonManual.TabIndex = 25;
            this.grpJsonManual.TabStop = false;
            this.grpJsonManual.Text = "Teste Manual - JSON";
            // 
            // btnLimparJson
            // 
            this.btnLimparJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimparJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparJson.Location = new System.Drawing.Point(643, 367);
            this.btnLimparJson.Name = "btnLimparJson";
            this.btnLimparJson.Size = new System.Drawing.Size(110, 30);
            this.btnLimparJson.TabIndex = 5;
            this.btnLimparJson.Text = "Limpar";
            this.btnLimparJson.UseVisualStyleBackColor = true;
            this.btnLimparJson.Click += new System.EventHandler(this.btnLimparJson_Click);
            // 
            // btnEnviarJsonManual
            // 
            this.btnEnviarJsonManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarJsonManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarJsonManual.Location = new System.Drawing.Point(759, 367);
            this.btnEnviarJsonManual.Name = "btnEnviarJsonManual";
            this.btnEnviarJsonManual.Size = new System.Drawing.Size(110, 30);
            this.btnEnviarJsonManual.TabIndex = 4;
            this.btnEnviarJsonManual.Text = "Enviar JSON";
            this.btnEnviarJsonManual.UseVisualStyleBackColor = true;
            this.btnEnviarJsonManual.Click += new System.EventHandler(this.btnEnviarJsonManual_Click);
            // 
            // cboTipoEnvio
            // 
            this.cboTipoEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoEnvio.FormattingEnabled = true;
            this.cboTipoEnvio.Items.AddRange(new object[] {
            "Empresas (/api/v1/sync/empresas)",
            "Ordens (/api/v1/sync/ordens)",
            "Usuários (/api/v1/sync/usuarios)",
            "Status (/api/v1/sync/status)"});
            this.cboTipoEnvio.Location = new System.Drawing.Point(90, 24);
            this.cboTipoEnvio.Name = "cboTipoEnvio";
            this.cboTipoEnvio.Size = new System.Drawing.Size(280, 23);
            this.cboTipoEnvio.TabIndex = 3;
            // 
            // lblTipoEnvio
            // 
            this.lblTipoEnvio.AutoSize = true;
            this.lblTipoEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoEnvio.Location = new System.Drawing.Point(7, 27);
            this.lblTipoEnvio.Name = "lblTipoEnvio";
            this.lblTipoEnvio.Size = new System.Drawing.Size(67, 15);
            this.lblTipoEnvio.TabIndex = 2;
            this.lblTipoEnvio.Text = "Tipo Envio:";
            // 
            // txtJsonManual
            // 
            this.txtJsonManual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJsonManual.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJsonManual.Location = new System.Drawing.Point(10, 54);
            this.txtJsonManual.Multiline = true;
            this.txtJsonManual.Name = "txtJsonManual";
            this.txtJsonManual.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtJsonManual.Size = new System.Drawing.Size(859, 307);
            this.txtJsonManual.TabIndex = 1;
            this.txtJsonManual.WordWrap = false;
            // 
            // lblJsonManual
            // 
            this.lblJsonManual.AutoSize = true;
            this.lblJsonManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJsonManual.Location = new System.Drawing.Point(553, 28);
            this.lblJsonManual.Name = "lblJsonManual";
            this.lblJsonManual.Size = new System.Drawing.Size(312, 15);
            this.lblJsonManual.TabIndex = 0;
            this.lblJsonManual.Text = "JSON (cole aqui o JSON para enviar diretamente à API):";
            // 
            // frmVivaMoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 661);
            this.Controls.Add(this.grpJsonManual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.LabelUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtbaseUrl);
            this.Controls.Add(this.labelBaseURL);
            this.MinimumSize = new System.Drawing.Size(920, 700);
            this.Name = "frmVivaMoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teste VivaMoto API Service";
            this.grpJsonManual.ResumeLayout(false);
            this.grpJsonManual.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBaseURL;
        private System.Windows.Forms.TextBox txtbaseUrl;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label LabelUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpJsonManual;
        private System.Windows.Forms.Button btnEnviarJsonManual;
        private System.Windows.Forms.ComboBox cboTipoEnvio;
        private System.Windows.Forms.Label lblTipoEnvio;
        private System.Windows.Forms.TextBox txtJsonManual;
        private System.Windows.Forms.Label lblJsonManual;
        private System.Windows.Forms.Button btnLimparJson;
    }
}