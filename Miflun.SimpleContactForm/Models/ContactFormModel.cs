using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// </summary>
        public required string EmailToAddress { get; set; }

        /// <summary>
        /// Gets or sets email subject
        /// </summary>
        public required string EmailSubject { get; set; }
    }
}
