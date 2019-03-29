using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using DAL.Entities;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserManager<IdentityUser<int>> UserManager { get; set; }

        RoleManager<IdentityRole<int>> RoleManager { get; set; }

        IRepository<Order> Orders { get; set; }

        IRepository<Hoody> Hoodies { get; set; }

        IRepository<TShirt> TShirts { get; set; }

        void Save();
    }
}
