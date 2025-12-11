namespace dotNetUtilitiesTester
{
    partial class frmWebBrowser
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
            this.WebBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WebBrowser1
            // 
            this.WebBrowser1.Location = new System.Drawing.Point(12, 44);
            this.WebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser1.Name = "WebBrowser1";
            this.WebBrowser1.Size = new System.Drawing.Size(1007, 606);
            this.WebBrowser1.TabIndex = 0;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(13, 18);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(957, 20);
            this.txtURL.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(976, 15);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(43, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Ir";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // frmWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 662);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.WebBrowser1);
            this.Name = "frmWebBrowser";
            this.Text = "webbrowser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebBrowser1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnGo;
    }
}