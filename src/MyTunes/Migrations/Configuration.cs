namespace MyTunes.Migrations
{
    using IdentitySample.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentitySample.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IdentitySample.Models.ApplicationDbContext";
        }

        protected override void Seed(IdentitySample.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context));
            const string name = "admin@example.com";
            const string password = "Admin@123456";


            roleManager.Create(new IdentityRole("Cliente"));
            roleManager.Create(new IdentityRole("Admin"));

            var user = new ApplicationUser { UserName = name, Email = name };
            var result = userManager.Create(user, password);
            result = userManager.SetLockoutEnabled(user.Id, false);

            result = userManager.AddToRole(user.Id, "Admin");
        }
    }
}
