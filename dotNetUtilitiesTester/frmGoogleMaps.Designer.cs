namespace dotNetUtilitiesTester
{
    partial class frmGoogleMaps
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
            this.txtToken = new System.Windows.Forms.TextBox();
            this.lblToken = new System.Windows.Forms.Label();
            this.btnGetLatitudeLongitudeByAddress = new System.Windows.Forms.Button();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblReturn = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnGetGeoLocalizationByCEP = new System.Windows.Forms.Button();
            this.lblCEP = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.btnGetAddressByCEP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(179, 15);
            this.txtToken.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(436, 22);
            this.txtToken.TabIndex = 1;
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(19, 15);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(48, 17);
            this.lblToken.TabIndex = 0;
            this.lblToken.Text = "Token";
            // 
            // btnGetLatitudeLongitudeByAddress
            // 
            this.btnGetLatitudeLongitudeByAddress.Location = new System.Drawing.Point(351, 82);
            this.btnGetLatitudeLongitudeByAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetLatitudeLongitudeByAddress.Name = "btnGetLatitudeLongitudeByAddress";
            this.btnGetLatitudeLongitudeByAddress.Size = new System.Drawing.Size(264, 36);
            this.btnGetLatitudeLongitudeByAddress.TabIndex = 4;
            this.btnGetLatitudeLongitudeByAddress.Text = "Get Latitude Longitude By Address";
            this.btnGetLatitudeLongitudeByAddress.UseVisualStyleBackColor = true;
            this.btnGetLatitudeLongitudeByAddress.Click += new System.EventHandler(this.btnGetLatitudeLongitudeByAddress_Click);
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(19, 45);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(69, 17);
            this.lblEndereco.TabIndex = 2;
            this.lblEndereco.Text = "Endereço";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(179, 45);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(436, 22);
            this.txtEndereco.TabIndex = 3;
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.Location = new System.Drawing.Point(29, 264);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(132, 17);
            this.lblReturn.TabIndex = 5;
            this.lblReturn.Text = "GoogleMaps Result";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(189, 261);
            this.txtResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(436, 96);
            this.txtResult.TabIndex = 6;
            // 
            // btnGetGeoLocalizationByCEP
            // 
            this.btnGetGeoLocalizationByCEP.Location = new System.Drawing.Point(351, 146);
            this.btnGetGeoLocalizationByCEP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetGeoLocalizationByCEP.Name = "btnGetGeoLocalizationByCEP";
            this.btnGetGeoLocalizationByCEP.Size = new System.Drawing.Size(264, 36);
            this.btnGetGeoLocalizationByCEP.TabIndex = 7;
            this.btnGetGeoLocalizationByCEP.Text = "Get Geo Localization By CEP";
            this.btnGetGeoLocalizationByCEP.UseVisualStyleBackColor = true;
            this.btnGetGeoLocalizationByCEP.Click += new System.EventHandler(this.btnGetGeoLocalizationByCEP_Click);
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(19, 146);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(35, 17);
            this.lblCEP.TabIndex = 13;
            this.lblCEP.Text = "CEP";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(179, 146);
            this.txtCEP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(148, 22);
            this.txtCEP.TabIndex = 12;
            // 
            // btnGetAddressByCEP
            // 
            this.btnGetAddressByCEP.Location = new System.Drawing.Point(351, 199);
            this.btnGetAddressByCEP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetAddressByCEP.Name = "btnGetAddressByCEP";
            this.btnGetAddressByCEP.Size = new System.Drawing.Size(264, 36);
            this.btnGetAddressByCEP.TabIndex = 14;
            this.btnGetAddressByCEP.Text = "Get Address By CEP";
            this.btnGetAddressByCEP.UseVisualStyleBackColor = true;
            this.btnGetAddressByCEP.Click += new System.EventHandler(this.btnGetAddressByCEP_Click);
            // 
            // frmGoogleMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 382);
            this.Controls.Add(this.btnGetAddressByCEP);
            this.Controls.Add(this.lblCEP);
            this.Controls.Add(this.txtCEP);
            this.Controls.Add(this.btnGetGeoLocalizationByCEP);
            this.Controls.Add(this.lblReturn);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.btnGetLatitudeLongitudeByAddress);
            this.Controls.Add(this.lblToken);
            this.Controls.Add(this.txtToken);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmGoogleMaps";
            this.Text = "Web Services";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.Button btnGetLatitudeLongitudeByAddress;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnGetGeoLocalizationByCEP;
        private System.Windows.Forms.Label lblCEP;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Button btnGetAddressByCEP;
    }
}