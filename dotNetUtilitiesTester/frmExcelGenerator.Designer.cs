namespace dotNetUtilitiesTester
{
    partial class frmExcelGenerator
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
            this.chkOpenExcel = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblReportName = new System.Windows.Forms.Label();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtImagesPath
            // 
            this.txtImagesPath.Location = new System.Drawing.Point(162, 49);
            this.txtImagesPath.Name = "txtImagesPath";
            this.txtImagesPath.Size = new System.Drawing.Size(436, 22);
            this.txtImagesPath.TabIndex = 1;
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Location = new System.Drawing.Point(162, 143);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(436, 22);
            this.txtDestinationPath.TabIndex = 5;
            // 
            // lblImagensPath
            // 
            this.lblImagensPath.AutoSize = true;
            this.lblImagensPath.Location = new System.Drawing.Point(29, 49);
            this.lblImagensPath.Name = "lblImagensPath";
            this.lblImagensPath.Size = new System.Drawing.Size(98, 17);
            this.lblImagensPath.TabIndex = 0;
            this.lblImagensPath.Text = "File TXT Path:";
            // 
            // lblDestinationPath
            // 
            this.lblDestinationPath.AutoSize = true;
            this.lblDestinationPath.Location = new System.Drawing.Point(29, 145);
            this.lblDestinationPath.Name = "lblDestinationPath";
            this.lblDestinationPath.Size = new System.Drawing.Size(116, 17);
            this.lblDestinationPath.TabIndex = 4;
            this.lblDestinationPath.Text = "Destination Path:";
            // 
            // chkOpenExcel
            // 
            this.chkOpenExcel.AutoSize = true;
            this.chkOpenExcel.Location = new System.Drawing.Point(162, 183);
            this.chkOpenExcel.Name = "chkOpenExcel";
            this.chkOpenExcel.Size = new System.Drawing.Size(102, 21);
            this.chkOpenExcel.TabIndex = 6;
            this.chkOpenExcel.Text = "Open Excel";
            this.chkOpenExcel.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(466, 244);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(132, 50);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 244);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(357, 50);
            this.txtResult.TabIndex = 7;
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(29, 77);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(92, 17);
            this.lblReportName.TabIndex = 2;
            this.lblReportName.Text = "Report Name";
            // 
            // txtReportName
            // 
            this.txtReportName.Location = new System.Drawing.Point(162, 77);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(436, 22);
            this.txtReportName.TabIndex = 3;
            // 
            // frmExcelGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 306);
            this.Controls.Add(this.lblReportName);
            this.Controls.Add(this.txtReportName);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.chkOpenExcel);
            this.Controls.Add(this.lblDestinationPath);
            this.Controls.Add(this.lblImagensPath);
            this.Controls.Add(this.txtDestinationPath);
            this.Controls.Add(this.txtImagesPath);
            this.Name = "frmExcelGenerator";
            this.Text = "Excel Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImagesPath;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Label lblImagensPath;
        private System.Windows.Forms.Label lblDestinationPath;
        private System.Windows.Forms.CheckBox chkOpenExcel;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.TextBox txtReportName;
    }
}