namespace dotNetUtilitiesTester
{
    partial class frmEmailSender
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
            this.tabDestinatario = new System.Windows.Forms.TabControl();
            this.tabRecipient = new System.Windows.Forms.TabPage();
            this.txtFromName = new System.Windows.Forms.TextBox();
            this.lblFromName = new System.Windows.Forms.Label();
            this.lblCo = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtBcc = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtCc = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblCc = new System.Windows.Forms.Label();
            this.tabEmail = new System.Windows.Forms.TabPage();
            this.txtAttachments = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblAttachments = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.chkUseDefaultCredentials = new System.Windows.Forms.CheckBox();
            this.chkEnableSSL = new System.Windows.Forms.CheckBox();
            this.chkAutentication = new System.Windows.Forms.CheckBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblSMTPHost = new System.Windows.Forms.Label();
            this.txtSMTPHost = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.tabDestinatario.SuspendLayout();
            this.tabRecipient.SuspendLayout();
            this.tabEmail.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDestinatario
            // 
            this.tabDestinatario.Controls.Add(this.tabRecipient);
            this.tabDestinatario.Controls.Add(this.tabEmail);
            this.tabDestinatario.Controls.Add(this.tabConfiguration);
            this.tabDestinatario.Location = new System.Drawing.Point(7, 6);
            this.tabDestinatario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabDestinatario.Name = "tabDestinatario";
            this.tabDestinatario.SelectedIndex = 0;
            this.tabDestinatario.Size = new System.Drawing.Size(843, 511);
            this.tabDestinatario.TabIndex = 12;
            // 
            // tabRecipient
            // 
            this.tabRecipient.Controls.Add(this.txtFromName);
            this.tabRecipient.Controls.Add(this.lblFromName);
            this.tabRecipient.Controls.Add(this.lblCo);
            this.tabRecipient.Controls.Add(this.txtFrom);
            this.tabRecipient.Controls.Add(this.txtBcc);
            this.tabRecipient.Controls.Add(this.txtTo);
            this.tabRecipient.Controls.Add(this.txtCc);
            this.tabRecipient.Controls.Add(this.lblFrom);
            this.tabRecipient.Controls.Add(this.lblTo);
            this.tabRecipient.Controls.Add(this.lblCc);
            this.tabRecipient.Location = new System.Drawing.Point(4, 25);
            this.tabRecipient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabRecipient.Name = "tabRecipient";
            this.tabRecipient.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabRecipient.Size = new System.Drawing.Size(835, 482);
            this.tabRecipient.TabIndex = 0;
            this.tabRecipient.Text = "Recipient";
            this.tabRecipient.UseVisualStyleBackColor = true;
            // 
            // txtFromName
            // 
            this.txtFromName.Location = new System.Drawing.Point(109, 7);
            this.txtFromName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFromName.Name = "txtFromName";
            this.txtFromName.Size = new System.Drawing.Size(719, 22);
            this.txtFromName.TabIndex = 14;
            // 
            // lblFromName
            // 
            this.lblFromName.AutoSize = true;
            this.lblFromName.Location = new System.Drawing.Point(11, 11);
            this.lblFromName.Name = "lblFromName";
            this.lblFromName.Size = new System.Drawing.Size(49, 17);
            this.lblFromName.TabIndex = 15;
            this.lblFromName.Text = "Name:";
            // 
            // lblCo
            // 
            this.lblCo.AutoSize = true;
            this.lblCo.Location = new System.Drawing.Point(11, 235);
            this.lblCo.Name = "lblCo";
            this.lblCo.Size = new System.Drawing.Size(35, 17);
            this.lblCo.TabIndex = 15;
            this.lblCo.Text = "Bcc:";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(109, 34);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(719, 22);
            this.txtFrom.TabIndex = 8;
            // 
            // txtBcc
            // 
            this.txtBcc.Location = new System.Drawing.Point(109, 230);
            this.txtBcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBcc.Multiline = true;
            this.txtBcc.Name = "txtBcc";
            this.txtBcc.Size = new System.Drawing.Size(719, 82);
            this.txtBcc.TabIndex = 14;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(109, 63);
            this.txtTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(719, 74);
            this.txtTo.TabIndex = 10;
            // 
            // txtCc
            // 
            this.txtCc.Location = new System.Drawing.Point(109, 143);
            this.txtCc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCc.Multiline = true;
            this.txtCc.Name = "txtCc";
            this.txtCc.Size = new System.Drawing.Size(719, 82);
            this.txtCc.TabIndex = 12;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(11, 38);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(44, 17);
            this.lblFrom.TabIndex = 9;
            this.lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(11, 68);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(29, 17);
            this.lblTo.TabIndex = 11;
            this.lblTo.Text = "To:";
            // 
            // lblCc
            // 
            this.lblCc.AutoSize = true;
            this.lblCc.Location = new System.Drawing.Point(11, 148);
            this.lblCc.Name = "lblCc";
            this.lblCc.Size = new System.Drawing.Size(28, 17);
            this.lblCc.TabIndex = 13;
            this.lblCc.Text = "Cc:";
            // 
            // tabEmail
            // 
            this.tabEmail.Controls.Add(this.txtAttachments);
            this.tabEmail.Controls.Add(this.txtBody);
            this.tabEmail.Controls.Add(this.txtSubject);
            this.tabEmail.Controls.Add(this.lblAttachments);
            this.tabEmail.Controls.Add(this.label5);
            this.tabEmail.Controls.Add(this.label6);
            this.tabEmail.Location = new System.Drawing.Point(4, 25);
            this.tabEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabEmail.Name = "tabEmail";
            this.tabEmail.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabEmail.Size = new System.Drawing.Size(835, 482);
            this.tabEmail.TabIndex = 1;
            this.tabEmail.Text = "E-mail";
            this.tabEmail.UseVisualStyleBackColor = true;
            // 
            // txtAttachments
            // 
            this.txtAttachments.Location = new System.Drawing.Point(109, 378);
            this.txtAttachments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAttachments.Multiline = true;
            this.txtAttachments.Name = "txtAttachments";
            this.txtAttachments.Size = new System.Drawing.Size(719, 24);
            this.txtAttachments.TabIndex = 12;
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(109, 39);
            this.txtBody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(719, 335);
            this.txtBody.TabIndex = 10;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(109, 12);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(719, 22);
            this.txtSubject.TabIndex = 8;
            // 
            // lblAttachments
            // 
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.Location = new System.Drawing.Point(8, 382);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Size = new System.Drawing.Size(90, 17);
            this.lblAttachments.TabIndex = 13;
            this.lblAttachments.Text = "Attachments:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "E-mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Subject:";
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.chkUseDefaultCredentials);
            this.tabConfiguration.Controls.Add(this.chkEnableSSL);
            this.tabConfiguration.Controls.Add(this.chkAutentication);
            this.tabConfiguration.Controls.Add(this.lblPort);
            this.tabConfiguration.Controls.Add(this.txtPort);
            this.tabConfiguration.Controls.Add(this.lblSMTPHost);
            this.tabConfiguration.Controls.Add(this.txtSMTPHost);
            this.tabConfiguration.Controls.Add(this.txtPassword);
            this.tabConfiguration.Controls.Add(this.txtUser);
            this.tabConfiguration.Controls.Add(this.lblPassword);
            this.tabConfiguration.Controls.Add(this.lblUser);
            this.tabConfiguration.Location = new System.Drawing.Point(4, 25);
            this.tabConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabConfiguration.Size = new System.Drawing.Size(835, 482);
            this.tabConfiguration.TabIndex = 2;
            this.tabConfiguration.Text = "Configuration";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            // 
            // chkUseDefaultCredentials
            // 
            this.chkUseDefaultCredentials.AutoSize = true;
            this.chkUseDefaultCredentials.Location = new System.Drawing.Point(109, 178);
            this.chkUseDefaultCredentials.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUseDefaultCredentials.Name = "chkUseDefaultCredentials";
            this.chkUseDefaultCredentials.Size = new System.Drawing.Size(179, 21);
            this.chkUseDefaultCredentials.TabIndex = 10;
            this.chkUseDefaultCredentials.Text = "Use Default Credentials";
            this.chkUseDefaultCredentials.UseVisualStyleBackColor = true;
            // 
            // chkEnableSSL
            // 
            this.chkEnableSSL.AutoSize = true;
            this.chkEnableSSL.Location = new System.Drawing.Point(109, 153);
            this.chkEnableSSL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkEnableSSL.Name = "chkEnableSSL";
            this.chkEnableSSL.Size = new System.Drawing.Size(104, 21);
            this.chkEnableSSL.TabIndex = 9;
            this.chkEnableSSL.Text = "Enable SSL";
            this.chkEnableSSL.UseVisualStyleBackColor = true;
            // 
            // chkAutentication
            // 
            this.chkAutentication.AutoSize = true;
            this.chkAutentication.Location = new System.Drawing.Point(109, 127);
            this.chkAutentication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAutentication.Name = "chkAutentication";
            this.chkAutentication.Size = new System.Drawing.Size(112, 21);
            this.chkAutentication.TabIndex = 8;
            this.chkAutentication.Text = "Autentication";
            this.chkAutentication.UseVisualStyleBackColor = true;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(11, 97);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(34, 17);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(109, 95);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(719, 22);
            this.txtPort.TabIndex = 6;
            // 
            // lblSMTPHost
            // 
            this.lblSMTPHost.AutoSize = true;
            this.lblSMTPHost.Location = new System.Drawing.Point(11, 69);
            this.lblSMTPHost.Name = "lblSMTPHost";
            this.lblSMTPHost.Size = new System.Drawing.Size(83, 17);
            this.lblSMTPHost.TabIndex = 5;
            this.lblSMTPHost.Text = "SMTP Host:";
            // 
            // txtSMTPHost
            // 
            this.txtSMTPHost.Location = new System.Drawing.Point(109, 66);
            this.txtSMTPHost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSMTPHost.Name = "txtSMTPHost";
            this.txtSMTPHost.Size = new System.Drawing.Size(719, 22);
            this.txtSMTPHost.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(109, 39);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(719, 22);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(109, 12);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(719, 22);
            this.txtUser.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(11, 41);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 17);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(11, 14);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(42, 17);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "User:";
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(707, 524);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(143, 39);
            this.btnSendEmail.TabIndex = 13;
            this.btnSendEmail.Text = "Send E-mail";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // frmEmailSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 569);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.tabDestinatario);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmEmailSender";
            this.Text = "frmEmailSender";
            this.tabDestinatario.ResumeLayout(false);
            this.tabRecipient.ResumeLayout(false);
            this.tabRecipient.PerformLayout();
            this.tabEmail.ResumeLayout(false);
            this.tabEmail.PerformLayout();
            this.tabConfiguration.ResumeLayout(false);
            this.tabConfiguration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDestinatario;
        private System.Windows.Forms.TabPage tabRecipient;
        private System.Windows.Forms.Label lblCo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtBcc;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtCc;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblCc;
        private System.Windows.Forms.TabPage tabEmail;
        private System.Windows.Forms.TextBox txtAttachments;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblAttachments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabConfiguration;
        private System.Windows.Forms.Label lblSMTPHost;
        private System.Windows.Forms.TextBox txtSMTPHost;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.CheckBox chkAutentication;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Label lblFromName;
        private System.Windows.Forms.TextBox txtFromName;
        private System.Windows.Forms.CheckBox chkEnableSSL;
        private System.Windows.Forms.CheckBox chkUseDefaultCredentials;
    }
}