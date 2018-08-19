using System.Data.Entity.Migrations;

namespace Freedi.DataProvider.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FreediContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Freedi.DataProvider.FreediContext";
        }

        protected override void Seed(FreediContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}