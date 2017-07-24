namespace Pantelejci_1._1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Web.Configuration;

    internal sealed class Configuration : DbMigrationsConfiguration<Pantelejci_1._1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        public object WebApiConfigurationManager { get; private set; }
        public string Email { get; private set; }
        public string UserName { get; private set; }

        protected override void Seed(Pantelejci_1._1.Models.ApplicationDbContext context)
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

            //create roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
                        if (!roleManager.RoleExists(Roles.KORISNIK))
                          {
                roleManager.Create(new IdentityRole(Roles.KORISNIK));
                          }

                         if (!roleManager.RoleExists(Roles.ADMIN))
                         {
                roleManager.Create(new IdentityRole(Roles.ADMIN));
                            }

//       //     var adminEmail = WebConfigurationManager.AppSettings["AdminEmail"];

//            if (!context.Users.Any(x => x.Email == adminEmail))
///////////////////////////////////////////////
//                var admin = new ApplicationUser;
//            {
//                Email = adminEmail;
//                UserName = adminEmail;

//            }  //
        }
    }
}
