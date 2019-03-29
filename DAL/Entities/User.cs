using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class User:IdentityUser<int>
    {
        public List<Order> Orders { get; set; }
    }
}
