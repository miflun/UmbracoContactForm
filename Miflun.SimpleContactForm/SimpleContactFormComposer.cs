
using Microsoft.Extensions.DependencyInjection;
using Miflun.SimpleContactForm.Services;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Miflun.SimpleContactForm
{
    /// <summary>
    /// Composer to register dependencies
    /// https://docs.umbraco.com/umbraco-cms/13.latest/reference/using-ioc#composer
    /// </summary>
    internal class SimpleContactFormComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            ConfigurationOptions(builder);
            RegisterServices(builder);
        }

        private static void ConfigurationOptions(IUmbracoBuilder builder)
        {
            builder.Services.AddOptions<SmtpAccount>()
                .BindConfiguration("Umbraco:CMS:Global:Smtp");
        }

        private static void RegisterServices(IUmbracoBuilder builder)
        {
            builder.Services.AddSingleton<Services.IEmailSender, EmailSender>();
        }
    }
}
