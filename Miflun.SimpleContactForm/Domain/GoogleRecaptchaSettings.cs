using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miflun.SimpleContactForm.Domain
{
    public class GoogleRecaptchaSettings
    {
        public string? GoogleReCaptchaFormattedUri { get; set; }

        public string? ReCaptchaSiteKey { get; set; }

        /// <summary>
        /// No longer required in newer version of Google ReCaptcha
        /// </summary>
        public string? RecaptchaSecret { get; set; }

        public string? GoogleReCaptchApiUrl { get; set; }
    }
}
