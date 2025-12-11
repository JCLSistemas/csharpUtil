using System;
using System.Windows.Forms;
using CSharpUtil.Services;

namespace dotNetUtilitiesTester
{
    public partial class frmEmailSender : Form
    {
        public frmEmailSender()
        {
            InitializeComponent();

            //txtFromName.Text = "Jonatas Leonis";
            //txtFrom.Text = "jcleonissss@gmail.com";
            //txtTo.Text = "jonatas@jclsistemas.com.br";
            //txtSubject.Text = "Teste e-mail de e-mail SSL/TLS";
            //txtBody.Text = "<h1>TESTE DE E-MAIL COM GMAIL<h1>";
            //txtAttachments.Text = "";
            //txtUser.Text = "jcleonissss@gmail.com";
            //txtPassword.Text = "jojobmx30";
            //txtSMTPHost.Text = "smtp.gmail.com";
            //txtPort.Text = "465";
            //chkAutentication.Checked = true;
            //chkEnableSSL.Checked = true;

            txtFromName.Text = "Avantti combustiveis";
            txtFrom.Text = "nfe@asstam.com.br";
            txtTo.Text = "jonatas@jclsistemas.com.br";
            txtSubject.Text = "Teste e-mail de e-mail SSL/TLS";
            txtBody.Text = "<h1>TESTE DE E-MAIL<h1>";
            txtAttachments.Text = "";
            txtUser.Text = "asstam";
            txtPassword.Text = "mmiVLWZD2119";
            txtSMTPHost.Text = "smtplw.com.br";
            txtPort.Text = "587";
            chkAutentication.Checked = true;
            chkEnableSSL.Checked = false;

            //txtFromName.Text = "Avantti combustiveis";
            //txtFrom.Text = "nfe@asstam.com.br";
            //txtTo.Text = "jonatas@jclsistemas.com.br";
            //txtSubject.Text = "Teste e-mail de e-mail SSL/TLS";
            //txtBody.Text = "<h1>TESTE DE E-MAIL<h1>";
            //txtAttachments.Text = "";
            //txtUser.Text = "nfe@asstam.com.br";
            //txtPassword.Text = "astc1510";
            //txtSMTPHost.Text = "smtp.com.br";
            //txtPort.Text = "587";
            //chkAutentication.Checked = true;
            //chkEnableSSL.Checked = true;

            //txtFromName.Text = "Jonatas C. Leonis";
            //txtFrom.Text = "jonatas@jclsistemas.com.br";
            //txtTo.Text = "jcleonis@gmail.com.br";
            //txtCc.Text = "jcleonis@hotmail.com";
            //txtCo.Text = "";
            //txtSubject.Text = "Teste e-mail";
            //txtBody.Text = "<h1>TESTE DE E-MAIL<h1>";
            //txtAttachments.Text = "";
            //txtUser.Text = "jonatas@jclsistemas.com.br";
            //txtPassword.Text = "jojobmx25$";
            //txtSMTPHost.Text = "mail.jclsistemas.com.br";
            //txtPort.Text = "587";
            //chkAutentication.Checked = false;

        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (new Email().Send(txtFromName.Text, txtFrom.Text, txtTo.Text, txtCc.Text, txtBcc.Text, txtSubject.Text,
                txtBody.Text, txtAttachments.Text, txtUser.Text, txtPassword.Text, txtSMTPHost.Text, 
                Convert.ToInt32(txtPort.Text), Convert.ToInt32(chkAutentication.CheckState), 
                Convert.ToInt32(chkEnableSSL.CheckState), Convert.ToInt32(chkUseDefaultCredentials.CheckState)))
            {
                MessageBox.Show("Email enviado com sucesso!");
            }
        }
    }
}
