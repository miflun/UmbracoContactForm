using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;
using Miflun.SimpleContactForm.Domain;

namespace Miflun.SimpleContactForm.TagHelpers
{
    /// <summary>
    /// Google ReCaptcha tag helper
    /// </summary>
    [HtmlTargetElement("mif-captcha", TagStructure = TagStructure.WithoutEndTag)]
    public class GoogleReCaptchaTagHelper : TagHelper
    {
        private readonly GoogleRecaptchaSettings _captchaSettings;

        /// <summary>
        /// ViewContext
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="captchaSettings"></param>
        public GoogleReCaptchaTagHelper(IHtmlHelper htmlHelper, IOptions<GoogleRecaptchaSettings> captchaSettings)
        {
            _captchaSettings = captchaSettings.Value;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            IHtmlContent captchaHtmlContent;

            if (!string.IsNullOrEmpty(_captchaSettings.ReCaptchaSiteKey))
            {
                var captchaDiv = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };
                captchaDiv.Attributes.Add("class", "g-recaptcha");
                captchaDiv.Attributes.Add("data-sitekey", _captchaSettings.ReCaptchaSiteKey);
                captchaDiv.Attributes.Add("data-callback", "reCaptchaCallBack");

                var captchaCodeHidden = new TagBuilder("input") { TagRenderMode = TagRenderMode.Normal };
                captchaCodeHidden.Attributes.Add("id", "recaptchaCode");
                captchaCodeHidden.Attributes.Add("name", "recaptchaCode");
                captchaCodeHidden.Attributes.Add("value", "");
                captchaCodeHidden.Attributes.Add("type", "hidden");

                //generate reCAPTCHA Control
                var scriptCallbackTag = new TagBuilder("script") { TagRenderMode = TagRenderMode.Normal };
                scriptCallbackTag.InnerHtml.AppendHtml($"var reCaptchaCallBack = function(response) {{console.log(response);$(\"#recaptchaCode\").val(response);}}");

                //google reCAPTCHA Script
                var scriptGoogleReCaptchApi = new TagBuilder("script") { TagRenderMode = TagRenderMode.Normal };
                scriptGoogleReCaptchApi.Attributes.Add("src", _captchaSettings.GoogleReCaptchApiUrl);
                scriptGoogleReCaptchApi.Attributes.Add("async", null);
                scriptGoogleReCaptchApi.Attributes.Add("defer", null);

                var contentBuilder = new HtmlContentBuilder();
                contentBuilder.AppendHtml(captchaDiv);
                contentBuilder.AppendHtml(captchaCodeHidden);
                contentBuilder.AppendHtml(scriptCallbackTag);
                contentBuilder.AppendHtml(scriptGoogleReCaptchApi);

                captchaHtmlContent = contentBuilder;

            }
            else
            {
                var ptag = new TagBuilder("p") { TagRenderMode = TagRenderMode.Normal };
                ptag.InnerHtml.Append("Please check ReCaptcha settings");
                captchaHtmlContent = ptag;
            }

            //Setup the wrapper div
            output.Attributes.Add("class", "recaptcha-wrapper");

            //tag details
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetHtmlContent(captchaHtmlContent);
        }
    }
}
