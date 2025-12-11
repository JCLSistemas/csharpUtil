namespace dotNetUtilitiesTester
{
    partial class frmCodeInter25
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
            this.txtCodeInter25 = new System.Windows.Forms.TextBox();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.lblImagensPath = new System.Windows.Forms.Label();
            this.lblDestinationPath = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.imgCodeInter25 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgCodeInter25)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodeInter25
            // 
            this.txtCodeInter25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeInter25.Location = new System.Drawing.Point(162, 49);
            this.txtCodeInter25.Name = "txtCodeInter25";
            this.txtCodeInter25.Size = new System.Drawing.Size(536, 22);
            this.txtCodeInter25.TabIndex = 0;
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationPath.Location = new System.Drawing.Point(162, 80);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(536, 22);
            this.txtDestinationPath.TabIndex = 1;
            // 
            // lblImagensPath
            // 
            this.lblImagensPath.AutoSize = true;
            this.lblImagensPath.Location = new System.Drawing.Point(29, 52);
            this.lblImagensPath.Name = "lblImagensPath";
            this.lblImagensPath.Size = new System.Drawing.Size(97, 17);
            this.lblImagensPath.TabIndex = 2;
            this.lblImagensPath.Text = "Code Inter 25:";
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
            this.btnGenerate.Location = new System.Drawing.Point(566, 244);
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
            this.txtResult.Location = new System.Drawing.Point(32, 244);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(528, 50);
            this.txtResult.TabIndex = 6;
            // 
            // imgCodeInter25
            // 
            this.imgCodeInter25.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgCodeInter25.BackColor = System.Drawing.Color.White;
            this.imgCodeInter25.Location = new System.Drawing.Point(32, 145);
            this.imgCodeInter25.Name = "imgCodeInter25";
            this.imgCodeInter25.Size = new System.Drawing.Size(666, 93);
            this.imgCodeInter25.TabIndex = 7;
            this.imgCodeInter25.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(597, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "Teste";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCodeInter25
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 306);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imgCodeInter25);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblDestinationPath);
            this.Controls.Add(this.lblImagensPath);
            this.Controls.Add(this.txtDestinationPath);
            this.Controls.Add(this.txtCodeInter25);
            this.Name = "frmCodeInter25";
            this.Text = "Code Inter 2 & 5";
            ((System.ComponentModel.ISupportInitialize)(this.imgCodeInter25)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodeInter25;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Label lblImagensPath;
        private System.Windows.Forms.Label lblDestinationPath;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.PictureBox imgCodeInter25;
        private System.Windows.Forms.Button button1;
    }
}