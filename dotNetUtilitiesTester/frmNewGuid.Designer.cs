namespace dotNetUtilitiesTester
{
    partial class frmNewGuid
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
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.btnNewGuid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtGuid
            // 
            this.txtGuid.Location = new System.Drawing.Point(25, 39);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Size = new System.Drawing.Size(529, 20);
            this.txtGuid.TabIndex = 0;
            // 
            // btnNewGuid
            // 
            this.btnNewGuid.Location = new System.Drawing.Point(479, 74);
            this.btnNewGuid.Name = "btnNewGuid";
            this.btnNewGuid.Size = new System.Drawing.Size(75, 23);
            this.btnNewGuid.TabIndex = 1;
            this.btnNewGuid.Text = "New Guid";
            this.btnNewGuid.UseVisualStyleBackColor = true;
            this.btnNewGuid.Click += new System.EventHandler(this.btnNewGuid_Click);
            // 
            // frmNewGuid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 116);
            this.Controls.Add(this.btnNewGuid);
            this.Controls.Add(this.txtGuid);
            this.Name = "frmNewGuid";
            this.Text = "Teste NewGuid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Button btnNewGuid;
    }
}