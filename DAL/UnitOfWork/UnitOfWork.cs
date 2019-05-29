using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        public UserManager<User> UserManager { get; set; }

        public RoleManager<IdentityRole<int>> RoleManager { get; set; }

        public IRepository<Order> Orders { get; set; }

        public IRepository<Hoody> Hoodies { get; set; }

        public IRepository<TShirt> TShirts { get; set; }

        public IRepository<Image> Images { get; set; }

        private ShopContext ShopContext;

        public UnitOfWork(ShopContext context,UserManager<User> manager, RoleManager<IdentityRole<int>> roleManager )
        {

            this.ShopContext = context;
            this.UserManager = manager;
            this.RoleManager = roleManager;
            Orders = new Repository<Order>(ShopContext);
            Hoodies = new Repository<Hoody>(ShopContext);
            TShirts = new Repository<TShirt>(ShopContext);
            Images = new Repository<Image>(ShopContext);

        }

        public void Save()
        {
            ShopContext.SaveChanges();
        }

    }
}
