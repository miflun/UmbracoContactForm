
using Umbraco.Cms.Infrastructure.Packaging;

namespace Miflun.SimpleContactForm.Migrations
{
    /// <summary>
    /// Ship a package that only installs the schema and the content you chose
    /// https://docs.umbraco.com/umbraco-cms/13.latest/extending/packages/creating-a-package#package-migration
    /// </summary>
    internal class PackageMigrationPlan : AutomaticPackageMigrationPlan
    {
        public PackageMigrationPlan() : base("Simple Contact Form With Macro")
        {
            //Automatic Migration
        }
    }
}
