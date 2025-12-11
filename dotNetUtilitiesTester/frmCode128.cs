using CSharpUtil.Services;
using System;
using System.Windows.Forms;

namespace dotNetUtilitiesTester
{
    public partial class frmCode128 : Form
    {
        public frmCode128()
        {
            InitializeComponent();
            txtCode128.Text = @"23796702300000840001787060000000000100296090";
            txtDestinationPath.Text = @"C:\JONATAS\CODBARRA";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtResult.Text = new Code128().Generate(txtCode128.Text, txtDestinationPath.Text);
            imgCode128.ImageLocation = txtResult.Text;
        }

     }
}
