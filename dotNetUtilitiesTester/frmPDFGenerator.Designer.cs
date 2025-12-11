namespace dotNetUtilitiesTester
{
    partial class frmPDFGenerator
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
            this.txtImagesPath = new System.Windows.Forms.TextBox();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.lblImagensPath = new System.Windows.Forms.Label();
            this.lblDestinationPath = new System.Windows.Forms.Label();
            this.chkOpenPDF = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.chkLandscape = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtImagesPath
            // 
            this.txtImagesPath.Location = new System.Drawing.Point(162, 49);
            this.txtImagesPath.Multiline = true;
            this.txtImagesPath.Name = "txtImagesPath";
            this.txtImagesPath.Size = new System.Drawing.Size(436, 76);
            this.txtImagesPath.TabIndex = 0;
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Location = new System.Drawing.Point(162, 143);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(436, 22);
            this.txtDestinationPath.TabIndex = 1;
            // 
            // lblImagensPath
            // 
            this.lblImagensPath.AutoSize = true;
            this.lblImagensPath.Location = new System.Drawing.Point(29, 49);
            this.lblImagensPath.Name = "lblImagensPath";
            this.lblImagensPath.Size = new System.Drawing.Size(98, 17);
            this.lblImagensPath.TabIndex = 2;
            this.lblImagensPath.Text = "Imagens Path:";
            // 
            // lblDestinationPath
            // 
            this.lblDestinationPath.AutoSize = true;
            this.lblDestinationPath.Location = new System.Drawing.Point(29, 145);
            this.lblDestinationPath.Name = "lblDestinationPath";
            this.lblDestinationPath.Size = new System.Drawing.Size(116, 17);
            this.lblDestinationPath.TabIndex = 3;
            this.lblDestinationPath.Text = "Destination Path:";
            // 
            // chkOpenPDF
            // 
            this.chkOpenPDF.AutoSize = true;
            this.chkOpenPDF.Location = new System.Drawing.Point(162, 198);
            this.chkOpenPDF.Name = "chkOpenPDF";
            this.chkOpenPDF.Size = new System.Drawing.Size(96, 21);
            this.chkOpenPDF.TabIndex = 4;
            this.chkOpenPDF.Text = "Open PDF";
            this.chkOpenPDF.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(466, 244);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(132, 50);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(32, 244);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(337, 50);
            this.txtResult.TabIndex = 6;
            // 
            // chkLandscape
            // 
            this.chkLandscape.AutoSize = true;
            this.chkLandscape.Location = new System.Drawing.Point(162, 171);
            this.chkLandscape.Name = "chkLandscape";
            this.chkLandscape.Size = new System.Drawing.Size(176, 21);
            this.chkLandscape.TabIndex = 7;
            this.chkLandscape.Text = "Landscape (Paisagem)";
            this.chkLandscape.UseVisualStyleBackColor = true;
            // 
            // frmPDFGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 306);
            this.Controls.Add(this.chkLandscape);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.chkOpenPDF);
            this.Controls.Add(this.lblDestinationPath);
            this.Controls.Add(this.lblImagensPath);
            this.Controls.Add(this.txtDestinationPath);
            this.Controls.Add(this.txtImagesPath);
            this.Name = "frmPDFGenerator";
            this.Text = "PDF Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImagesPath;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Label lblImagensPath;
        private System.Windows.Forms.Label lblDestinationPath;
        private System.Windows.Forms.CheckBox chkOpenPDF;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.CheckBox chkLandscape;
    }
}