using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MimeKit;
using MailKit;
using MailKit.Net.Smtp;
using System.Collections;
using System.Windows.Forms;
using MailKit.Security;
using System.Runtime.InteropServices;

namespace CSharpUtil.Services
{
    public class EmailKit
    {
        MimeMessage message = new MimeMessage();
        public bool Send(string fromName, string from, string to, string cc, string co, string subject, string body,
                         string attachments, string user, string password, string smtpHost,
                         int port, int autentication, int enableSsl, int useDefaultCredentials)
        {
            try
            {
                message.From.Add(new MailboxAddress(fromName, from));
                ToEmailAdd(to);
                CcEmailAdd(cc);
                CoEmailAdd(co);
                message.Subject = subject.Trim();
                var bodyBuilder = new BodyBuilder();
                var characters = new [] { ';', ',' };
                foreach (var attachment in attachments.Split(characters))
                {
                    if (!DosFiles.FileExists(attachment.Trim()))
                    {
                        continue;
                    }

                    bodyBuilder.Attachments.Add(attachment.Trim());
                }

                //************************************************************//
                // IMPORTANTE                                                 //
                // O corpo do e-mail deve ser atribuido depois dos anexos     //
                // senão os anexos não são enviados junto ao e-mail           //
                //************************************************************//
                bodyBuilder.HtmlBody = body.Trim();
                message.Body = bodyBuilder.ToMessageBody();

                var smtpClient = new SmtpClient();
                smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtpClient.Connect(smtpHost.Trim(), port, (enableSsl == 1 ? true:false));
                if (autentication == 1)
                {
                    smtpClient.Authenticate(user.Trim(), password.Trim());
                }
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Message: "+ ex.Message);
            }
            return false;
        }

        private void ToEmailAdd(string email)
        {
            if (string.IsNullOrEmpty(email)) return;

            var characters = new[] { ';', ',' };

            foreach (var sTo in email.Split(characters)
                .Where(sTo => sTo != null && email.Trim() != ""))
                message.To.Add(new MailboxAddress(sTo.Trim()));
        }

        private void CcEmailAdd(string email)
        {
            if (string.IsNullOrEmpty(email)) return;

            var characters = new[] { ';', ',' };

            foreach (var sCc in email.Split(characters)
                .Where(sCc => sCc != null && email.Trim() != ""))
                message.Cc.Add(new MailboxAddress(sCc.Trim()));
        }

        private void CoEmailAdd(string email)
        {
            if (string.IsNullOrEmpty(email)) return;

            var characters = new[] { ';', ',' };

            foreach (var sCo in email.Split(characters)
                .Where(sCo => sCo != null && email.Trim() != ""))
                message.Bcc.Add(new MailboxAddress(sCo.Trim()));
        }


    }
}
