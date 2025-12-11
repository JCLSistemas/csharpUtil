using System;
using CSharpUtil.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace CSharpUtil.Services
{
    public class Email
    {
        protected MailMessage Mail = new MailMessage();

        public bool Send(string fromName, string from, string to, string cc, string bcc, string subject, string body,
                         string attachments, string user, string password, string smtpHost, 
                         int port, int autentication, int enableSsl, int useDefaultCredentials)
        {
            try
            {

                if (!AssertConsern.AssertArgumentIsNullorEmpty(from.Trim(),
                    "Por favor informe o e-mail do remetente!", "Envio de Email")) return false;
                if (!AssertConsern.AssertArgumentIsNullorEmpty(password,
                        "Por favor informe a senha do e-mail do remetente!", "Envio de Email")) return false;
                if (!AssertConsern.AssertArgumentIsNullorEmpty(smtpHost,
                        "Por favor informe DNS do provedor SMTP/IMAP do e-mail do remetente!", "Envio de Email")) return false;
                if (!AssertConsern.AssertArgumentIsNullorEmpty(port,
                        "Por favor informe a porta do provedor SMTP/IMAP do e-mail do remetente!", "Envio de Email")) return false;
                if (!AssertConsern.AssertArgumentIsNullorEmpty(new object[] { to, cc, bcc },
                        "Por favor informe o e-mail do destinatário!", "Envio de Email")) return false;

                //ServicePointManager.ServerCertificateValidationCallback =
                //                 delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                //                 { return true; };

                Mail.From = new MailAddress(from.Trim(), fromName.Trim());
                ToEmailAdd(to.Trim());
                CcEmailAdd(cc.Trim());
                BccEmailAdd(bcc.Trim());

                Mail.Subject = subject.Trim();
                Mail.SubjectEncoding = System.Text.Encoding.UTF8;
                Mail.Body = body.Trim();
                Mail.BodyEncoding = System.Text.Encoding.UTF8;
                //Mail.IsBodyHtml = true;
                Mail.Priority = MailPriority.Normal;

                if (!string.IsNullOrEmpty(attachments.Trim()))
                {
                    char[] characters = new[] { ';', ',' };

                    foreach (var attachment in attachments.Split(characters))
                    {
                        if (!File.Exists(attachment.Trim())) continue;

                        FileStream fileStream = new FileStream(attachment.Trim(), FileMode.Open, FileAccess.Read);
                        Attachment data = new Attachment(fileStream, Path.GetFileName(attachment));
                        Mail.Attachments.Add(data);
                    }
                }

                var smtpClient = new SmtpClient();
                smtpClient.Host = smtpHost;
                smtpClient.Port = port;
                smtpClient.EnableSsl = (enableSsl == 1 ? true : false);
                smtpClient.UseDefaultCredentials = (useDefaultCredentials == 1 ? true : false);
                smtpClient.Credentials = new NetworkCredential(user.Trim(), password.Trim(), smtpHost.Trim());
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.Send(Mail);

                return true;

            }
            catch (SmtpFailedRecipientException ex)
            {
                MessageBox.Show("Falha na tentativa de criação do e-mail! \n\n" + ex.Message, "Envio de E-mail");
                return false;
            }

            catch (SmtpException ex)
            {
                MessageBox.Show("Falha na tentativa de envio do e-mail! " +
                                "Verifique as configurações e tente novamente!\n\n" + ex.Message, "Envio de E-mail");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha na tentativa de criação/envio do e-mail! " +
                                "Verifique o problema e tente novamente!\n\n" + ex.Message, "Envio de E-mail");
                return false;
            }

        }

        private void ToEmailAdd(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                foreach (var sTo in email.Split(';')
                    .Where(sTo => sTo != null && email.Trim() != ""))
                    Mail.To.Add(sTo);
            }
        }
        private void CcEmailAdd(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                foreach (var sCc in email.Split(';')
                    .Where(sCc => sCc != null && email.Trim() != ""))
                    Mail.CC.Add(sCc);
            }
        }
        private void BccEmailAdd(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                foreach (var sBcc in email.Split(';')
                    .Where(sBcc => sBcc != null && email.Trim() != ""))
                    Mail.Bcc.Add(sBcc);
            }
        }

    }
}