﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class User:IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
