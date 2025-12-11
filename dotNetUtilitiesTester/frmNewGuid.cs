using System;
using System.Windows.Forms;

namespace dotNetUtilitiesTester
{
    public partial class frmNewGuid : Form
    {
        public frmNewGuid()
        {
            InitializeComponent();
        }

        private void btnNewGuid_Click(object sender, EventArgs e)
        {
            txtGuid.Text = Guid.NewGuid().ToString();
        }
    }
}
