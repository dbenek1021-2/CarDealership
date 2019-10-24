namespace GuildCars.Migrations
{
    using GuildCars.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCars.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Disabled"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Disabled" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Sales"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Sales" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Test Ing"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Test Ing", Email = "testadmin@test.com" };

                manager.Create(user, "Test123!");
                context.Users.Add(user);
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
