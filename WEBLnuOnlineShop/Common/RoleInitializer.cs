using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DAL.Entities;

namespace WEBLnuOnlineShop.Common
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("Admin"));
            }
            if (await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("User"));
            }
            var user = await userManager.FindByEmailAsync("tarikkataryna1999@gmail.com");

           await userManager.AddToRoleAsync(user, "Admin");  
        }
    }
}
