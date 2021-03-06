namespace ConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApplication1.DataAccessLayer.BloggingContext>
    {
        public Configuration()
        {
            //自动迁移按钮是否为可用
            AutomaticMigrationsEnabled = true;
            ContextKey = "ConsoleApplication1.DataAccessLayer.BloggingContext";
        }

        protected override void Seed(ConsoleApplication1.DataAccessLayer.BloggingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
