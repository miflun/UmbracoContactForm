# Simple Contact Form With Macro

A simple contact form with macro package for the Umbraco v13 CMS is intended to be used by developers. It can also be used by other users who has access to Umbraco Settings and
are familiar with Html, Css, Javascript. 

This package is still under development, further refinements will be carried out after inital feedback. 

## Summary
Simple Contact Form with Macro provides a way to add a form with 4 fields (name, email, phonenumber and message) using a Macro
You can add macro within Rich Text Editor as well. 

## Download
You can add the package using following .NET CLI Command

>dotnet add package Miflun.SimpleContactForm --version 1.0.1-beta (please note that version will be changing as upgrades are done to source code)

You can also download and install package using Visual Studio Manage Nuget Packages for Solution...

Once the package installation is completed you will find following 
- Macro (ContactFormWrapper)
- Macro Partial View (~/Views/MacroPartials/ContactFormWrapper.cshtml)
- Contact Form View (~/Views/Partials/ContactForm/Index.cshtml)

Additionally if you don't have javascript then you will have to include https://code.jquery.com/jquery-3.7.1.min.js, ideally to your layout template

### SMTP Settings
<b>Add SMTP settings</b> to you AppSettings.json file so that the emails are sent out, please follow this documentation to add your SMTP
https://docs.umbraco.com/umbraco-cms/extending/health-check/guides/smtp


## Usage
You could use this form by placing ContactFormWrapper Macro in your content pages.
Alternatively you can include them in template/partial views by adding 
@{
	await Html.RenderPartialAsync("~/Views/Partials/ContactForm/Index.cshtml", new SimpleContactForm.Models.ContactFormModel());
 }

 ## Source code and example
 Source code for this package along with example is available on GitHub repository. We strongly advice you to go through this repository before installing the package
 https://github.com/miflun/UmbracoContactForm.git