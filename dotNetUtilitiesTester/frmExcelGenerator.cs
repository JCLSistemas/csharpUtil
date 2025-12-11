using System;
using System.Windows.Forms;
using CSharpUtil.Services;

namespace dotNetUtilitiesTester
{
    public partial class frmExcelGenerator : Form
    {
        public frmExcelGenerator()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtResult.Text = new Excel().Generate(txtImagesPath.Text, 
                    txtDestinationPath.Text, txtReportName.Text, Convert.ToInt32(chkOpenExcel.CheckState));
        }
    }
}