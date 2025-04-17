
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Miflun.SimpleContactForm.Models;
using Miflun.SimpleContactForm.Services;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Miflun.SimpleContactForm.Controllers
{
    public partial class ContactFormController : SurfaceController
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ContactFormController> _logger;
        private readonly SmtpAccount _smtpAccount;

        public ContactFormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, 
            AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider,
            IEmailSender emailSender, ILogger<ContactFormController> logger, IOptions<SmtpAccount> smtpAccount) 
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _emailSender = emailSender;
            _logger = logger;
            _smtpAccount = smtpAccount.Value;
        }

        public IActionResult Index(string emailToAddress, string emailSubject)
        {
            var model = new ContactFormModel()
            {
                EmailSubject = emailSubject,
                EmailToAddress = emailToAddress,
                Email = string.Empty, Message = string.Empty, Name = string.Empty
            };
            return View("~/Views/Partials/ContactForm/Index.cshtml", model);
        }

        [HttpPost]
        public IActionResult Submit(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                //Compose body
                var body = string.Format("Name: {0} \n\rEmail: {1} \n\rTelephone: {2}\n\rMessage: {3}", model.Name, model.Email, model.Phone, model.Message);

                //send email
                if (_emailSender.SendEmail(_smtpAccount, model.EmailToAddress, model.EmailToAddress, model.EmailSubject, body))
                {
                    TempData["IsEmailSent"] = true;
                    return RedirectToCurrentUmbracoPage();
                }
                else
                {
                    TempData["IsError"] = true;
                    return CurrentUmbracoPage();
                }
            }
            else
            {
                //Log any model errors
                var modelErrors = new List<string>();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Add(modelError.ErrorMessage);
                    }
                }
                _logger.LogInformation(string.Join(", ", modelErrors));
            }

            TempData["IsError"] = true;
            return CurrentUmbracoPage();
        }
    }
}
