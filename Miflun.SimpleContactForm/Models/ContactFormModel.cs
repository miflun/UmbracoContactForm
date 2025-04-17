
namespace Miflun.SimpleContactForm.Models
{
    public class ContactFormModel
    {
        /// <summary>
        /// Sets a Name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Sets email address
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Sets phone number
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets message
        /// </summary>
        public required string Message { get; set; }


        /// <summary>
        /// Gets or set error message
        /// </summary>
        public string? errMsg { get; set; }

        /// <summary>
        /// Gets or sets recaptch site key
        /// </summary>
        public string? RecaptchaSiteKey { get; set; }

        /// <summary>
        /// Gets or sets email to address
        /// Need this as couldn't figure out how to get values from macro parameters programatically
        /// </summary>
        public required string EmailToAddress { get; set; }

        /// <summary>
        /// Gets or sets email subject
        /// Need this as couldn't figure out how to get values from macro parameters programatically
        /// </summary>
        public required string EmailSubject { get; set; }
    }
}
