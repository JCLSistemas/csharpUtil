using System;
using System.Windows.Forms;
using CSharpUtil.Services;

namespace dotNetUtilitiesTester
{
    public partial class frmPDFGenerator : Form
    {
        public frmPDFGenerator()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtResult.Text = Pdf.Generate(txtImagesPath.Text,
                   txtDestinationPath.Text, Convert.ToInt32(chkLandscape.Checked), Convert.ToInt32(chkOpenPDF.CheckState));
        }
    }
}
