using Miflun.SimpleContactForm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miflun.SimpleContactForm.Services
{
    public interface IReCaptchaService
    {
        public Task<ReCaptchaResponse?> ValidateCaptchaV2(string recaptchaCode);
    }
}
