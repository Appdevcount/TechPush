namespace TechPush.Infrastructure.Migrations.Blog
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class BlogConfig : DbMigrationsConfiguration<TechPush.Infrastructure.CMS.BlogDBContext>
    {
        public BlogConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Blog";

            //  enable-migrations  -MigrationsDirectory Migrations\Blog -ContextTypeName BlogDBContext 
            //  Manually rename the config file 
            //  Add-Migration -ConfigurationTypeName BlogConfig Initial

            //  Update-Database -ConfigurationTypeName BlogConfig -script 
        }

        protected override void Seed(TechPush.Infrastructure.CMS.BlogDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
