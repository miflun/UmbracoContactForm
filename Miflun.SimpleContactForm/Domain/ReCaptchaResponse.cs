using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miflun.SimpleContactForm.Domain
{
    public class ReCaptchaResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "challenge_ts")]
        public string ChallengeTimeStamp { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "hostname")]
        public string? Hostname { get; set; }

        [JsonProperty(PropertyName = "apk_package_name")]
        public string? ApkPackageName { get; set; }

        [JsonProperty(PropertyName = "error-codes")]
        public List<string> Errors { get; set; }
    }
}
