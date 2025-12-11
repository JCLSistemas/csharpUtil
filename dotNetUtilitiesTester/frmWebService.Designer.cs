namespace dotNetUtilitiesTester
{
    partial class frmWebService
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblMethod = new System.Windows.Forms.Label();
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.lblReturn = new System.Windows.Forms.Label();
            this.txtReturn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(179, 15);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(436, 22);
            this.txtUrl.TabIndex = 1;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(19, 15);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(104, 17);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "Webservice Url";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(483, 253);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(132, 36);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(19, 42);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(133, 17);
            this.lblMethod.TabIndex = 2;
            this.lblMethod.Text = "Webservice Method";
            // 
            // txtMethod
            // 
            this.txtMethod.Location = new System.Drawing.Point(179, 42);
            this.txtMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(436, 22);
            this.txtMethod.TabIndex = 3;
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.Location = new System.Drawing.Point(19, 84);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(129, 17);
            this.lblReturn.TabIndex = 5;
            this.lblReturn.Text = "Webservice Return";
            // 
            // txtReturn
            // 
            this.txtReturn.Location = new System.Drawing.Point(179, 84);
            this.txtReturn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReturn.Multiline = true;
            this.txtReturn.Name = "txtReturn";
            this.txtReturn.Size = new System.Drawing.Size(436, 152);
            this.txtReturn.TabIndex = 6;
            // 
            // frmWebService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 299);
            this.Controls.Add(this.lblReturn);
            this.Controls.Add(this.txtReturn);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.txtMethod);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtUrl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmWebService";
            this.Text = "Web Services";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.TextBox txtMethod;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.TextBox txtReturn;
    }
}