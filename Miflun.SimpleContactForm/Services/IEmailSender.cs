
namespace Miflun.SimpleContactForm.Services
{
    /// <summary>
    /// Email sender
    /// </summary>
    public partial interface IEmailSender
    {
        /// <summary>
        /// Sends email
        /// </summary>
        /// <param name="smtpAccount"></param>
        /// <param name="toAddress"></param>
        /// <param name="toName"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public bool SendEmail(SmtpAccount smtpAccount, string toAddress, string toName, string subject, string body);
    }
}
