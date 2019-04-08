using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    public class ShopContext:IdentityDbContext<User,IdentityRole<int>,int>
    {
        public ShopContext()
        {

        }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<TShirt> Shirts { get; set; }

        public DbSet<Hoody> Hoodies { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
