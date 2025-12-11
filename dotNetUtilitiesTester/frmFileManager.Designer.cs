namespace dotNetUtilitiesTester
{
    partial class frmFileManager
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
            this.txtPathFileExists = new System.Windows.Forms.TextBox();
            this.btnFileExists = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblFileDelete = new System.Windows.Forms.Label();
            this.btnFileDelete = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblStatusFileExists = new System.Windows.Forms.Label();
            this.lblStatusFileDelete = new System.Windows.Forms.Label();
            this.lblStatusDirectoryExists = new System.Windows.Forms.Label();
            this.LblDirectoryExists = new System.Windows.Forms.Label();
            this.btnDirectoryExists = new System.Windows.Forms.Button();
            this.txtPathDirectoryExists = new System.Windows.Forms.TextBox();
            this.lblStatusDirectoryDelete = new System.Windows.Forms.Label();
            this.lblDirectoryDelete = new System.Windows.Forms.Label();
            this.btnDirectoryDelete = new System.Windows.Forms.Button();
            this.txtPathDirectoryDelete = new System.Windows.Forms.TextBox();
            this.lblGetFiles = new System.Windows.Forms.Label();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.txtDirectoryGetFiles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchGetFiles = new System.Windows.Forms.TextBox();
            this.chkAllDirectories = new System.Windows.Forms.CheckBox();
            this.chkDeleteFilesAndSubFolders = new System.Windows.Forms.CheckBox();
            this.txtGetFilesResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPathFileExists
            // 
            this.txtPathFileExists.Location = new System.Drawing.Point(167, 25);
            this.txtPathFileExists.Margin = new System.Windows.Forms.Padding(4);
            this.txtPathFileExists.Name = "txtPathFileExists";
            this.txtPathFileExists.Size = new System.Drawing.Size(464, 22);
            this.txtPathFileExists.TabIndex = 0;
            // 
            // btnFileExists
            // 
            this.btnFileExists.Location = new System.Drawing.Point(657, 25);
            this.btnFileExists.Margin = new System.Windows.Forms.Padding(4);
            this.btnFileExists.Name = "btnFileExists";
            this.btnFileExists.Size = new System.Drawing.Size(121, 28);
            this.btnFileExists.TabIndex = 1;
            this.btnFileExists.Text = "File Exists";
            this.btnFileExists.UseVisualStyleBackColor = true;
            this.btnFileExists.Click += new System.EventHandler(this.btnNewGuid_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(21, 28);
            this.lblPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(99, 17);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "Path FileExists";
            // 
            // lblFileDelete
            // 
            this.lblFileDelete.AutoSize = true;
            this.lblFileDelete.Location = new System.Drawing.Point(21, 100);
            this.lblFileDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileDelete.Name = "lblFileDelete";
            this.lblFileDelete.Size = new System.Drawing.Size(104, 17);
            this.lblFileDelete.TabIndex = 5;
            this.lblFileDelete.Text = "Path FileDelete";
            // 
            // btnFileDelete
            // 
            this.btnFileDelete.Location = new System.Drawing.Point(657, 96);
            this.btnFileDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnFileDelete.Name = "btnFileDelete";
            this.btnFileDelete.Size = new System.Drawing.Size(121, 28);
            this.btnFileDelete.TabIndex = 4;
            this.btnFileDelete.Text = "File Delete";
            this.btnFileDelete.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 96);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(464, 22);
            this.textBox1.TabIndex = 3;
            // 
            // lblStatusFileExists
            // 
            this.lblStatusFileExists.AutoSize = true;
            this.lblStatusFileExists.Location = new System.Drawing.Point(167, 53);
            this.lblStatusFileExists.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusFileExists.Name = "lblStatusFileExists";
            this.lblStatusFileExists.Size = new System.Drawing.Size(114, 17);
            this.lblStatusFileExists.TabIndex = 6;
            this.lblStatusFileExists.Text = "File Exists Status";
            // 
            // lblStatusFileDelete
            // 
            this.lblStatusFileDelete.AutoSize = true;
            this.lblStatusFileDelete.Location = new System.Drawing.Point(167, 124);
            this.lblStatusFileDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusFileDelete.Name = "lblStatusFileDelete";
            this.lblStatusFileDelete.Size = new System.Drawing.Size(119, 17);
            this.lblStatusFileDelete.TabIndex = 7;
            this.lblStatusFileDelete.Text = "File Delete Status";
            // 
            // lblStatusDirectoryExists
            // 
            this.lblStatusDirectoryExists.AutoSize = true;
            this.lblStatusDirectoryExists.Location = new System.Drawing.Point(167, 444);
            this.lblStatusDirectoryExists.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusDirectoryExists.Name = "lblStatusDirectoryExists";
            this.lblStatusDirectoryExists.Size = new System.Drawing.Size(149, 17);
            this.lblStatusDirectoryExists.TabIndex = 11;
            this.lblStatusDirectoryExists.Text = "Directory Exists Status";
            // 
            // LblDirectoryExists
            // 
            this.LblDirectoryExists.AutoSize = true;
            this.LblDirectoryExists.Location = new System.Drawing.Point(21, 420);
            this.LblDirectoryExists.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDirectoryExists.Name = "LblDirectoryExists";
            this.LblDirectoryExists.Size = new System.Drawing.Size(134, 17);
            this.LblDirectoryExists.TabIndex = 10;
            this.LblDirectoryExists.Text = "Path DirectoryExists";
            // 
            // btnDirectoryExists
            // 
            this.btnDirectoryExists.Location = new System.Drawing.Point(657, 416);
            this.btnDirectoryExists.Margin = new System.Windows.Forms.Padding(4);
            this.btnDirectoryExists.Name = "btnDirectoryExists";
            this.btnDirectoryExists.Size = new System.Drawing.Size(121, 28);
            this.btnDirectoryExists.TabIndex = 9;
            this.btnDirectoryExists.Text = "Directory Exists";
            this.btnDirectoryExists.UseVisualStyleBackColor = true;
            this.btnDirectoryExists.Click += new System.EventHandler(this.btnDirectoryExists_Click);
            // 
            // txtPathDirectoryExists
            // 
            this.txtPathDirectoryExists.Location = new System.Drawing.Point(167, 416);
            this.txtPathDirectoryExists.Margin = new System.Windows.Forms.Padding(4);
            this.txtPathDirectoryExists.Name = "txtPathDirectoryExists";
            this.txtPathDirectoryExists.Size = new System.Drawing.Size(464, 22);
            this.txtPathDirectoryExists.TabIndex = 8;
            // 
            // lblStatusDirectoryDelete
            // 
            this.lblStatusDirectoryDelete.AutoSize = true;
            this.lblStatusDirectoryDelete.Location = new System.Drawing.Point(167, 544);
            this.lblStatusDirectoryDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusDirectoryDelete.Name = "lblStatusDirectoryDelete";
            this.lblStatusDirectoryDelete.Size = new System.Drawing.Size(154, 17);
            this.lblStatusDirectoryDelete.TabIndex = 15;
            this.lblStatusDirectoryDelete.Text = "Directory Delete Status";
            // 
            // lblDirectoryDelete
            // 
            this.lblDirectoryDelete.AutoSize = true;
            this.lblDirectoryDelete.Location = new System.Drawing.Point(21, 495);
            this.lblDirectoryDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDirectoryDelete.Name = "lblDirectoryDelete";
            this.lblDirectoryDelete.Size = new System.Drawing.Size(139, 17);
            this.lblDirectoryDelete.TabIndex = 14;
            this.lblDirectoryDelete.Text = "Path DirectoryDelete";
            // 
            // btnDirectoryDelete
            // 
            this.btnDirectoryDelete.Location = new System.Drawing.Point(657, 491);
            this.btnDirectoryDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDirectoryDelete.Name = "btnDirectoryDelete";
            this.btnDirectoryDelete.Size = new System.Drawing.Size(121, 28);
            this.btnDirectoryDelete.TabIndex = 13;
            this.btnDirectoryDelete.Text = "Directory Delete";
            this.btnDirectoryDelete.UseVisualStyleBackColor = true;
            this.btnDirectoryDelete.Click += new System.EventHandler(this.btnDirectoryDelete_Click);
            // 
            // txtPathDirectoryDelete
            // 
            this.txtPathDirectoryDelete.Location = new System.Drawing.Point(167, 491);
            this.txtPathDirectoryDelete.Margin = new System.Windows.Forms.Padding(4);
            this.txtPathDirectoryDelete.Name = "txtPathDirectoryDelete";
            this.txtPathDirectoryDelete.Size = new System.Drawing.Size(464, 22);
            this.txtPathDirectoryDelete.TabIndex = 12;
            // 
            // lblGetFiles
            // 
            this.lblGetFiles.AutoSize = true;
            this.lblGetFiles.Location = new System.Drawing.Point(21, 165);
            this.lblGetFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGetFiles.Name = "lblGetFiles";
            this.lblGetFiles.Size = new System.Drawing.Size(121, 17);
            this.lblGetFiles.TabIndex = 18;
            this.lblGetFiles.Text = "Directory GetFiles";
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Location = new System.Drawing.Point(657, 159);
            this.btnGetFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(121, 28);
            this.btnGetFiles.TabIndex = 17;
            this.btnGetFiles.Text = "Get Files";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // txtDirectoryGetFiles
            // 
            this.txtDirectoryGetFiles.Location = new System.Drawing.Point(167, 162);
            this.txtDirectoryGetFiles.Margin = new System.Windows.Forms.Padding(4);
            this.txtDirectoryGetFiles.Name = "txtDirectoryGetFiles";
            this.txtDirectoryGetFiles.Size = new System.Drawing.Size(464, 22);
            this.txtDirectoryGetFiles.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 194);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Files to Search";
            // 
            // txtSearchGetFiles
            // 
            this.txtSearchGetFiles.Location = new System.Drawing.Point(167, 194);
            this.txtSearchGetFiles.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchGetFiles.Name = "txtSearchGetFiles";
            this.txtSearchGetFiles.Size = new System.Drawing.Size(464, 22);
            this.txtSearchGetFiles.TabIndex = 20;
            // 
            // chkAllDirectories
            // 
            this.chkAllDirectories.AutoSize = true;
            this.chkAllDirectories.Location = new System.Drawing.Point(167, 223);
            this.chkAllDirectories.Margin = new System.Windows.Forms.Padding(4);
            this.chkAllDirectories.Name = "chkAllDirectories";
            this.chkAllDirectories.Size = new System.Drawing.Size(117, 21);
            this.chkAllDirectories.TabIndex = 22;
            this.chkAllDirectories.Text = "All Directories";
            this.chkAllDirectories.UseVisualStyleBackColor = true;
            // 
            // chkDeleteFilesAndSubFolders
            // 
            this.chkDeleteFilesAndSubFolders.AutoSize = true;
            this.chkDeleteFilesAndSubFolders.Location = new System.Drawing.Point(167, 521);
            this.chkDeleteFilesAndSubFolders.Margin = new System.Windows.Forms.Padding(4);
            this.chkDeleteFilesAndSubFolders.Name = "chkDeleteFilesAndSubFolders";
            this.chkDeleteFilesAndSubFolders.Size = new System.Drawing.Size(203, 21);
            this.chkDeleteFilesAndSubFolders.TabIndex = 23;
            this.chkDeleteFilesAndSubFolders.Text = "All Files and SubDirectories";
            this.chkDeleteFilesAndSubFolders.UseVisualStyleBackColor = true;
            // 
            // txtGetFilesResult
            // 
            this.txtGetFilesResult.Location = new System.Drawing.Point(167, 252);
            this.txtGetFilesResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtGetFilesResult.Multiline = true;
            this.txtGetFilesResult.Name = "txtGetFilesResult";
            this.txtGetFilesResult.Size = new System.Drawing.Size(464, 135);
            this.txtGetFilesResult.TabIndex = 24;
            // 
            // frmFileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 596);
            this.Controls.Add(this.txtGetFilesResult);
            this.Controls.Add(this.chkDeleteFilesAndSubFolders);
            this.Controls.Add(this.chkAllDirectories);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchGetFiles);
            this.Controls.Add(this.lblGetFiles);
            this.Controls.Add(this.btnGetFiles);
            this.Controls.Add(this.txtDirectoryGetFiles);
            this.Controls.Add(this.lblStatusDirectoryDelete);
            this.Controls.Add(this.lblDirectoryDelete);
            this.Controls.Add(this.btnDirectoryDelete);
            this.Controls.Add(this.txtPathDirectoryDelete);
            this.Controls.Add(this.lblStatusDirectoryExists);
            this.Controls.Add(this.LblDirectoryExists);
            this.Controls.Add(this.btnDirectoryExists);
            this.Controls.Add(this.txtPathDirectoryExists);
            this.Controls.Add(this.lblStatusFileDelete);
            this.Controls.Add(this.lblStatusFileExists);
            this.Controls.Add(this.lblFileDelete);
            this.Controls.Add(this.btnFileDelete);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnFileExists);
            this.Controls.Add(this.txtPathFileExists);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFileManager";
            this.Text = "Teste FileManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPathFileExists;
        private System.Windows.Forms.Button btnFileExists;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblFileDelete;
        private System.Windows.Forms.Button btnFileDelete;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblStatusFileExists;
        private System.Windows.Forms.Label lblStatusFileDelete;
        private System.Windows.Forms.Label lblStatusDirectoryExists;
        private System.Windows.Forms.Label LblDirectoryExists;
        private System.Windows.Forms.Button btnDirectoryExists;
        private System.Windows.Forms.TextBox txtPathDirectoryExists;
        private System.Windows.Forms.Label lblStatusDirectoryDelete;
        private System.Windows.Forms.Label lblDirectoryDelete;
        private System.Windows.Forms.Button btnDirectoryDelete;
        private System.Windows.Forms.TextBox txtPathDirectoryDelete;
        private System.Windows.Forms.Label lblGetFiles;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.TextBox txtDirectoryGetFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchGetFiles;
        private System.Windows.Forms.CheckBox chkAllDirectories;
        private System.Windows.Forms.CheckBox chkDeleteFilesAndSubFolders;
        private System.Windows.Forms.TextBox txtGetFilesResult;
    }
}