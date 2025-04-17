using MailKit.Net.Smtp;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;

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
            MimeMessage message = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress(smtpAccount.Host, smtpAccount.From);
            message.From.Add(mailboxAddress);
            message.To.Add(new MailboxAddress(toName, toAddress));
            message.Subject = subject;
            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.TextBody = body;
            message.Body = emailBodyBuilder.ToMessageBody();

            //SMTP could be moved to a separate service
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect(smtpAccount.Host, smtpAccount.Port);
            if (!string.IsNullOrEmpty(smtpAccount.Username) && !string.IsNullOrEmpty(smtpAccount.Password))
            {
                smtpClient.Authenticate(smtpAccount.Username, smtpAccount.Password);
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
