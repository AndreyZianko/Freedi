namespace Freedi.DataProvider.Migrations
{
    using Freedi.DataProvider.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Freedi.DataProvider.FreediContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Freedi.DataProvider.FreediContext";
        }

        protected override void Seed(Freedi.DataProvider.FreediContext context)
        {
            
        }
    }
}
