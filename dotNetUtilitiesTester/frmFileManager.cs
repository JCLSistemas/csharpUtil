using CSharpUtil.Services;
using System;
using System.Windows.Forms;

namespace dotNetUtilitiesTester
{
    public partial class frmFileManager : Form
    {
        public frmFileManager()
        {
            InitializeComponent();
        }

        private void btnNewGuid_Click(object sender, EventArgs e)
        {
            if (DosFiles.FileExists(txtPathFileExists.Text)){
                MessageBox.Show(@"Arquivo Encontrado");
            }
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            int allDirectories = chkAllDirectories.Checked == true ? 1: 0;
            var result = DosFiles.GetFiles(txtDirectoryGetFiles.Text, txtSearchGetFiles.Text, allDirectories);
            txtGetFilesResult.Text = result;
        }

        private void btnDirectoryExists_Click(object sender, EventArgs e)
        {
            lblStatusDirectoryExists.Text = 
                DosFiles.DirectoryExists(txtPathDirectoryExists.Text) ? @"Diretorio Existe" : @"Diretorio não Existe";
        }

        private void btnDirectoryDelete_Click(object sender, EventArgs e)
        {
            int deleteFilesAndSubDirectories = chkDeleteFilesAndSubFolders.Checked == true ? 1 : 0;
            lblStatusDirectoryDelete.Text = 
                DosFiles.DirectoryDelete(txtPathDirectoryDelete.Text, deleteFilesAndSubDirectories) ? @"Diretorio Excluido" : @"Diretorio não Excluido";

        }
    }
}
