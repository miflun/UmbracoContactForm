using Microsoft.Extensions.Options;
using Miflun.SimpleContactForm.Domain;
using Newtonsoft.Json;

namespace Miflun.SimpleContactForm.Services
{
    public class ReCaptchaService : IReCaptchaService
    {
        private readonly IOptions<GoogleRecaptchaSettings> _googleRecaptchaSettings;

        public ReCaptchaService(IOptions<GoogleRecaptchaSettings> googleRecaptchaSettings)
        {
            _googleRecaptchaSettings = googleRecaptchaSettings;
        }

        public async Task<ReCaptchaResponse?> ValidateCaptchaV2(string recaptchaCode)
        {
            using (var httpClient = new HttpClient())
            {
                //prepare URL to request
                var url = string.Format(_googleRecaptchaSettings.Value.GoogleReCaptchaFormattedUri,
                    _googleRecaptchaSettings.Value.RecaptchaSecret, recaptchaCode);

                //get response
                var response = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ReCaptchaResponse>(response);
            }
        }
    }
}
