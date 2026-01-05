namespace dotNetUtilitiesTester
{
    partial class frmMenu
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
            this.btnPDFGenerator = new System.Windows.Forms.Button();
            this.btnExcelGenerator = new System.Windows.Forms.Button();
            this.btnEmailSender = new System.Windows.Forms.Button();
            this.btnCode128 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGuid = new System.Windows.Forms.Button();
            this.btnFileManager = new System.Windows.Forms.Button();
            this.btnWebBrowser = new System.Windows.Forms.Button();
            this.btnVivamoto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPDFGenerator
            // 
            this.btnPDFGenerator.Location = new System.Drawing.Point(9, 10);
            this.btnPDFGenerator.Margin = new System.Windows.Forms.Padding(2);
            this.btnPDFGenerator.Name = "btnPDFGenerator";
            this.btnPDFGenerator.Size = new System.Drawing.Size(122, 47);
            this.btnPDFGenerator.TabIndex = 0;
            this.btnPDFGenerator.Text = "PDF Generator";
            this.btnPDFGenerator.UseVisualStyleBackColor = true;
            this.btnPDFGenerator.Click += new System.EventHandler(this.btnPDFGenerator_Click);
            // 
            // btnExcelGenerator
            // 
            this.btnExcelGenerator.Location = new System.Drawing.Point(136, 10);
            this.btnExcelGenerator.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcelGenerator.Name = "btnExcelGenerator";
            this.btnExcelGenerator.Size = new System.Drawing.Size(122, 47);
            this.btnExcelGenerator.TabIndex = 1;
            this.btnExcelGenerator.Text = "Excel Generator";
            this.btnExcelGenerator.UseVisualStyleBackColor = true;
            this.btnExcelGenerator.Click += new System.EventHandler(this.btnExcelGenerator_Click);
            // 
            // btnEmailSender
            // 
            this.btnEmailSender.Location = new System.Drawing.Point(262, 10);
            this.btnEmailSender.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmailSender.Name = "btnEmailSender";
            this.btnEmailSender.Size = new System.Drawing.Size(122, 47);
            this.btnEmailSender.TabIndex = 2;
            this.btnEmailSender.Text = "Email Sender";
            this.btnEmailSender.UseVisualStyleBackColor = true;
            this.btnEmailSender.Click += new System.EventHandler(this.btnEmailSender_Click);
            // 
            // btnCode128
            // 
            this.btnCode128.Location = new System.Drawing.Point(389, 10);
            this.btnCode128.Margin = new System.Windows.Forms.Padding(2);
            this.btnCode128.Name = "btnCode128";
            this.btnCode128.Size = new System.Drawing.Size(122, 47);
            this.btnCode128.TabIndex = 3;
            this.btnCode128.Text = "Code 128 Generator";
            this.btnCode128.UseVisualStyleBackColor = true;
            this.btnCode128.Click += new System.EventHandler(this.btnCode128_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 47);
            this.button1.TabIndex = 4;
            this.button1.Text = "Code Inter 2 && 5";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGuid
            // 
            this.btnGuid.Location = new System.Drawing.Point(9, 61);
            this.btnGuid.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuid.Name = "btnGuid";
            this.btnGuid.Size = new System.Drawing.Size(122, 47);
            this.btnGuid.TabIndex = 5;
            this.btnGuid.Text = "New Guid";
            this.btnGuid.UseVisualStyleBackColor = true;
            this.btnGuid.Click += new System.EventHandler(this.btnGuid_Click);
            // 
            // btnFileManager
            // 
            this.btnFileManager.Location = new System.Drawing.Point(136, 61);
            this.btnFileManager.Margin = new System.Windows.Forms.Padding(2);
            this.btnFileManager.Name = "btnFileManager";
            this.btnFileManager.Size = new System.Drawing.Size(122, 47);
            this.btnFileManager.TabIndex = 6;
            this.btnFileManager.Text = "File Manager";
            this.btnFileManager.UseVisualStyleBackColor = true;
            this.btnFileManager.Click += new System.EventHandler(this.btnFileManager_Click);
            // 
            // btnWebBrowser
            // 
            this.btnWebBrowser.Location = new System.Drawing.Point(262, 61);
            this.btnWebBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.btnWebBrowser.Name = "btnWebBrowser";
            this.btnWebBrowser.Size = new System.Drawing.Size(122, 47);
            this.btnWebBrowser.TabIndex = 7;
            this.btnWebBrowser.Text = "Web Browser";
            this.btnWebBrowser.UseVisualStyleBackColor = true;
            this.btnWebBrowser.Click += new System.EventHandler(this.btnWebBrowser_Click);
            // 
            // btnVivamoto
            // 
            this.btnVivamoto.Location = new System.Drawing.Point(389, 61);
            this.btnVivamoto.Margin = new System.Windows.Forms.Padding(2);
            this.btnVivamoto.Name = "btnVivamoto";
            this.btnVivamoto.Size = new System.Drawing.Size(122, 47);
            this.btnVivamoto.TabIndex = 8;
            this.btnVivamoto.Text = "VivaMoto";
            this.btnVivamoto.UseVisualStyleBackColor = true;
            this.btnVivamoto.Click += new System.EventHandler(this.btnVivamoto_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 114);
            this.Controls.Add(this.btnVivamoto);
            this.Controls.Add(this.btnWebBrowser);
            this.Controls.Add(this.btnFileManager);
            this.Controls.Add(this.btnGuid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCode128);
            this.Controls.Add(this.btnEmailSender);
            this.Controls.Add(this.btnExcelGenerator);
            this.Controls.Add(this.btnPDFGenerator);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu de Testes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPDFGenerator;
        private System.Windows.Forms.Button btnExcelGenerator;
        private System.Windows.Forms.Button btnEmailSender;
        private System.Windows.Forms.Button btnCode128;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGuid;
        private System.Windows.Forms.Button btnFileManager;
        private System.Windows.Forms.Button btnWebBrowser;
        private System.Windows.Forms.Button btnVivamoto;
    }
}

