using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace WEBLnuOnlineShop
{
    public class Seed
    {
        private readonly ShopContext _context;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole<int>> _roleManager;

        public Seed(ShopContext context, UserManager<User> um,RoleManager<IdentityRole<int>> rm) { 
            _context = context;
            _userManager = um;
            _roleManager = rm;
        }

        public void SeedUsers()
        {

            if (!_userManager.Users.Any())
            {
                var roles = new List<IdentityRole<int>>
                {
                    new IdentityRole<int>{ Name = "Admin"},
                    new IdentityRole<int>{ Name = "Manager"},
                    new IdentityRole<int>{ Name = "User" }
                };

                foreach (var item in roles)
                {
                    _roleManager.CreateAsync(item).Wait();
                }

                var admin = new User
                {
                    UserName = "tarikkatartyna1999@gmail.com",
                    FirstName = "Taras",
                    LastName = "Kataryna",
                };

                admin.Email = "tarikkatartyna1999@gmail.com";

                IdentityResult result = _userManager.CreateAsync(admin, "Qwerty123456@").Result;

                if (result.Succeeded)
                {
                    admin = _userManager.FindByNameAsync("tarikkatartyna1999@gmail.com").Result;

                    _userManager.AddToRoleAsync(admin, "Admin").Wait();

                }
            }

        }
    }
}
