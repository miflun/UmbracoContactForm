using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            builder.Services.AddSingleton<IEmailSender, IEmailSender>();
        }
    }
}
