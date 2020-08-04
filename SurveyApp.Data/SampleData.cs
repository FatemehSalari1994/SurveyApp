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
    //public class SampleData
    //{
    //    public static void Initialize(IServiceProvider serviceProvider)
    //    {
    //        var context = serviceProvider.GetService<UnitOfWork>();

    //        string[] roles = new string[] { "Coordinator", "Respondent" };

    //        foreach (string role in roles)
    //        {
    //            var roleStore = new RoleStore<IdentityRole>(context);

    //            if (!context.Roles.Any(r => r.Name == role))
    //            {
    //                roleStore.CreateAsync(new IdentityRole(role));
    //            }
    //        }


     


    //        if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
    //        {
    //            var user = new IdentityUser
    //            {
    //                Email = "admin@gmail.com",
    //                NormalizedEmail = "ADMIN@GMAIL.COM",
    //                UserName = "admin",
    //                NormalizedUserName = "ADMIN",
    //                PhoneNumber = "+111111111111",
    //                EmailConfirmed = true,
    //                PhoneNumberConfirmed = true,
    //                SecurityStamp = Guid.NewGuid().ToString("D")
    //            };
    //            var password = new PasswordHasher<IdentityUser>();
    //            var hashed = password.HashPassword(user, "123456");
    //            user.PasswordHash = hashed;

    //            var userStore = new UserStore<IdentityUser>(context);
    //            var result = userStore.CreateAsync(user);
    //            AssignRoles(serviceProvider, user.Email, roles[0]);
    //            context.SaveChangesAsync();

    //        }


    //        if (!context.Users.Any(u => u.UserName == "user@gmail.com"))
    //        {
    //            var user = new IdentityUser
    //            {
    //                Email = "user@gmail.com",
    //                NormalizedEmail = "USER@GMAIL.COM",
    //                UserName = "user",
    //                NormalizedUserName = "USER",
    //                PhoneNumber = "+111111111111",
    //                EmailConfirmed = true,
    //                PhoneNumberConfirmed = true,
    //                SecurityStamp = Guid.NewGuid().ToString("D")
    //            };
    //            var password = new PasswordHasher<IdentityUser>();
    //            var hashed = password.HashPassword(user, "123456");
    //            user.PasswordHash = hashed;

    //            var userStore = new UserStore<IdentityUser>(context);
    //            var result = userStore.CreateAsync(user);
    //            AssignRoles(serviceProvider, user.Email, roles[1]);
    //            context.SaveChangesAsync();

    //        }




    //    }

    //    public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string role)
    //    {
    //        UserManager<IdentityUser> _userManager = services.GetService<UserManager<IdentityUser>>();
    //        IdentityUser user = await _userManager.FindByEmailAsync(email);
    //        var result = await _userManager.AddToRoleAsync(user, role);

    //        return result;
    //    }

    //}
}
