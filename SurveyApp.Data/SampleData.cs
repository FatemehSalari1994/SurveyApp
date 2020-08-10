using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SurveyApp.Data.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace SurveyApp.Data
{
    public class SampleData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var scopeeee = serviceProvider.CreateScope();
            var context = scopeeee.ServiceProvider.GetService<SurveyAppDbContext>();

            string[] roles = new string[] { "Coordinator", "Respondent" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole(role));
                }
            }



            var user = new IdentityUser
            {
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var password = new PasswordHasher<IdentityUser>();
            var hashed = password.HashPassword(user, "123456");
            user.PasswordHash = hashed;

            var userStore = new UserStore<IdentityUser>(context);
            var result = await userStore.CreateAsync(user);

            //var store = new UserStore<User>(context);
            //var manager = new UserManager<User>(store);
            //manager.AddToRole(user.Id, model.RoleName);
            var UserManager = scopeeee.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var result1 = await UserManager.AddToRoleAsync(user, "Coordinator");



            //user = new IdentityUser
            //{
            //    Email = "user@gmail.com",
            //    NormalizedEmail = "USER@GMAIL.COM",
            //    UserName = "user",
            //    NormalizedUserName = "USER",
            //    PhoneNumber = "+111111111111",
            //    EmailConfirmed = true,
            //    PhoneNumberConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString("D")
            //};
            //password = new PasswordHasher<IdentityUser>();
            //hashed = password.HashPassword(user, "123456");
            //user.PasswordHash = hashed;

            //userStore = new UserStore<IdentityUser>(context);
            //result = userStore.CreateAsync(user);
            //AssignRoles(serviceProvider, user.Email, "Respondent");
            //if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
            //{


            //}


            //if (!context.Users.Any(u => u.UserName == "user@gmail.com"))
            //{


            //}




        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string role)
        {
            var scopeeee = services.CreateScope();
            UserManager<IdentityUser> _userManager = scopeeee.ServiceProvider.GetService<UserManager<IdentityUser>>();
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRoleAsync(user, role);

            return result;
        }

    }
}
