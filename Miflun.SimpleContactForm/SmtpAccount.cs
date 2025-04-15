using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miflun.SimpleContactForm
{
    public partial class SmtpAccount
    {
        /// <summary>
        /// Gets or sets an email address
        /// </summary>
        public required string From { get; set; }

        /// <summary>
        /// Gets or sets an email host
        /// </summary>
        public required string Host { get; set; }

        /// <summary>
        /// Gets or sets an email port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets Pickup Directory Location
        /// </summary>
        public string PickupDirectoryLocation { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets an email user name
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets an email password
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets delivery method <Network(default)|SpecifiedPickupDirectory|PickupDirectoryFromIis>
        /// </summary>
        public string DeliveryMehtod { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value for Secure Socket Options <None|Auto(default)|SslOnConnect|StartTls|StartTlsWhenAvailable>
        /// </summary>
        public string SecureSocketOptions { get; set; } = string.Empty;

        
    }
}
