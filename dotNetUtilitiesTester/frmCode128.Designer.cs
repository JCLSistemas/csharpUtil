namespace dotNetUtilitiesTester
{
    partial class frmCode128
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
            this.txtCode128 = new System.Windows.Forms.TextBox();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.lblImagensPath = new System.Windows.Forms.Label();
            this.lblDestinationPath = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.imgCode128 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCode128)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode128
            // 
            this.txtCode128.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode128.Location = new System.Drawing.Point(162, 49);
            this.txtCode128.Name = "txtCode128";
            this.txtCode128.Size = new System.Drawing.Size(489, 22);
            this.txtCode128.TabIndex = 0;
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationPath.Location = new System.Drawing.Point(162, 80);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(489, 22);
            this.txtDestinationPath.TabIndex = 1;
            // 
            // lblImagensPath
            // 
            this.lblImagensPath.AutoSize = true;
            this.lblImagensPath.Location = new System.Drawing.Point(29, 52);
            this.lblImagensPath.Name = "lblImagensPath";
            this.lblImagensPath.Size = new System.Drawing.Size(73, 17);
            this.lblImagensPath.TabIndex = 2;
            this.lblImagensPath.Text = "Code 128:";
            // 
            // lblDestinationPath
            // 
            this.lblDestinationPath.AutoSize = true;
            this.lblDestinationPath.Location = new System.Drawing.Point(29, 82);
            this.lblDestinationPath.Name = "lblDestinationPath";
            this.lblDestinationPath.Size = new System.Drawing.Size(116, 17);
            this.lblDestinationPath.TabIndex = 3;
            this.lblDestinationPath.Text = "Destination Path:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(519, 267);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(132, 50);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(29, 267);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(484, 50);
            this.txtResult.TabIndex = 6;
            // 
            // imgCode128
            // 
            this.imgCode128.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgCode128.Location = new System.Drawing.Point(32, 136);
            this.imgCode128.Name = "imgCode128";
            this.imgCode128.Size = new System.Drawing.Size(619, 90);
            this.imgCode128.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCode128.TabIndex = 7;
            this.imgCode128.TabStop = false;
            // 
            // frmCode128Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 329);
            this.Controls.Add(this.imgCode128);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblDestinationPath);
            this.Controls.Add(this.lblImagensPath);
            this.Controls.Add(this.txtDestinationPath);
            this.Controls.Add(this.txtCode128);
            this.Name = "frmCode128Generator";
            this.Text = "Code 128 Generator";
            ((System.ComponentModel.ISupportInitialize)(this.imgCode128)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode128;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Label lblImagensPath;
        private System.Windows.Forms.Label lblDestinationPath;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.PictureBox imgCode128;
    }
}