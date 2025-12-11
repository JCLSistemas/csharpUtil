using System;
using System.Windows.Forms;

namespace dotNetUtilitiesTester
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnPDFGenerator_Click(object sender, EventArgs e)
        {
            new frmPDFGenerator().Show();
        }

        private void btnExcelGenerator_Click(object sender, EventArgs e)
        {
            new frmExcelGenerator().Show();
        }

        private void btnEmailSender_Click(object sender, EventArgs e)
        {
            new frmEmailSender().Show();
        }

        private void btnCode128_Click(object sender, EventArgs e)
        {
            new frmCode128().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmCodeInter25().Show();
        }

        private void btnGuid_Click(object sender, EventArgs e)
        {
            new frmNewGuid().Show();
        }

        private void btnFileManager_Click(object sender, EventArgs e)
        {
            new frmFileManager().Show();
        }

        private void btnWebBrowser_Click(object sender, EventArgs e)
        {
            new frmWebBrowser().Show();
        }

        private void btnGoogleMaps_Click(object sender, EventArgs e)
        {
            new frmGoogleMaps().Show();
        }
    }
}
