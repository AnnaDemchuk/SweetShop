using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Step.Identity.Manager;
using Step.Identity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Step.Identity.Store
{
    public class DbInitialize : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        private async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new CustomRoleStore(context);
                var manager = new ApplicationRoleManager(store);
                var role = new AppRole { Name = "AppAdmin" };

                await manager.CreateAsync(role);

            }
            if (!context.Users.Any(u => u.UserName == "igor@gmail.com"))
            {
                var store = new CustomUserStore(context);
                var manager = new ApplicationUserManager(store);
                var user = new AppUser
                {
                    FirstName="Igor", LastName="Vasilenko",
                    UserName = "igor@gmail.com",
                    Email = "igor@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    PhoneNumberConfirmed = true
                };
                var user2 = new AppUser
                {
                    FirstName = "Irina",
                    LastName = "Vasilenko",
                    UserName = "irina@gmail.com",
                    Email = "irina@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    PhoneNumberConfirmed = true
                };

                await manager.CreateAsync(user, "Qwerty123_");
                await manager.CreateAsync(user2, "Qwerty456_");

                //Add User To Role
                await manager.AddToRoleAsync(user.Id, "AppAdmin");
                ////Add User Claims
                await manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.GivenName, "A Person"));
                await manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.Gender, "Man"));
                await manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.DateOfBirth, "01.01.2001"));

                await manager.AddToRoleAsync(user2.Id, "Admin");
                ////Add User Claims
                await manager.AddClaimAsync(user2.Id, new Claim(ClaimTypes.GivenName, "A Person"));
                await manager.AddClaimAsync(user2.Id, new Claim(ClaimTypes.Gender, "Madam"));
                //await manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.DateOfBirth, "01.01.2001"));
            }


        }


        protected override void Seed(ApplicationDbContext context)
        {

            Task.Run(async () => { await SeedAsync(context); }).Wait();

            base.Seed(context);
        }
    }
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
       
        public ApplicationDbContext()
            : base()
        {
            if (!Database.Exists())
            {
                Database.SetInitializer<ApplicationDbContext>(
                    new DbInitialize());
            }

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
