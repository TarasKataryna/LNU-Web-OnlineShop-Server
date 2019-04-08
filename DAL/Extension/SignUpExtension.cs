using System;
using System.Collections.Generic;
using System.Text;
using DAL.ModelsDto;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Extension
{
    public static class SignUpExtension
    {
        public static User ToUser(this SignUpDto model)
        {
            var toReturn = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = model.Password,
                UserName = model.Email
            };

            return toReturn;
        }
    }
}
