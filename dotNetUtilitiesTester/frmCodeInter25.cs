using CSharpUtil.Services;
using System;
using System.Windows.Forms;
using CSharpUtil.Validation;

namespace dotNetUtilitiesTester
{
    public partial class frmCodeInter25 : Form
    {
        public frmCodeInter25()
        {
            InitializeComponent();
            txtCodeInter25.Text = @"23796702300000840001787060000000000100296090";
            txtDestinationPath.Text = @"C:\JONATAS\CODBARRA";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtResult.Text = new CodeInter25().Generate(txtCodeInter25.Text, txtDestinationPath.Text);
            imgCodeInter25.ImageLocation = txtResult.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = txtDestinationPath.Text;
            AssertConsern.AssertArgumentValidateFileName(ref filePath, "JPEG",".Jpg","Teste de Validação","Janela de Teste");
            txtDestinationPath.Text = filePath;
        }
    }
}
