using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Miflun.SimpleContactForm.Services
{
    /// <summary>
    /// Email Sender
    /// </summary>
    public partial class EmailSender : IEmailSender
    {
        /// <summary>
        /// Sends email using smtpaccount
        /// </summary>
        /// <param name="smtpAccount"></param>
        /// <param name="toAddress"></param>
        /// <param name="toName"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public bool SendEmail(SmtpAccount smtpAccount, string toAddress, string toName, string subject, string body)
        {
            //Prepare the email
            MailMessage message = new MailMessage();
            message.From = new MailAddress(smtpAccount.From);
            message.To.Add(new MailAddress(toAddress));
            message.Subject = subject;
            message.Body = body;

            //SMTP could be moved to a separate service
            SmtpClient smtpClient = new SmtpClient(smtpAccount.Host, smtpAccount.Port);
            if (!string.IsNullOrEmpty(smtpAccount.Username) && !string.IsNullOrEmpty(smtpAccount.Password))
            {
                smtpClient.Credentials = new NetworkCredential(smtpAccount.Username, smtpAccount.Password);
            }
            else
            {
                smtpClient.UseDefaultCredentials = true;
            }

            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
