
namespace OuistigoProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OuistigoProject.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<OuistigoProject.Models.OuistigoProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OuistigoProject.Models.OuistigoProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        //    context.Users.AddOrUpdate(
        //        u => u.IdUser, new User { IdUser = 1, Id_connexion = "azerty@gmail.com", Name = "Azerty" })
        //   ;
        }
    }
}
