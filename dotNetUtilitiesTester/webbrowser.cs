using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotNetUtilitiesTester
{
    public partial class frmWebBrowser : Form
    {
        public frmWebBrowser()
        {
            InitializeComponent();
            WebBrowser1.AllowNavigation = true;

            WebBrowser1.Navigate("http://www.google.com.br");
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            WebBrowser1.AllowNavigation = true;
            WebBrowser1.Navigate(txtURL.Text.Trim());
        }
    }
}
