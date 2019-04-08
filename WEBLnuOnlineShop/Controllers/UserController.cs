using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

using DAL.UnitOfWork;
using DAL.ModelsDto;
using WEBLnuOnlineShop.Attributes;
using DAL.Extension;
using WEBLnuOnlineShop.Common;

namespace WEBLnuOnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public UserController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        [ValidateModel]
        [HttpPost("[action]")]
        public IActionResult SignUp([FromBody] SignUpDto model)
        {
            var user = this.UnitOfWork.UserManager.FindByEmailAsync(model.Email).GetAwaiter().GetResult();
            if (user == null)
            {
                var userToCreate = model.ToUser();
                var hasher = this.UnitOfWork.UserManager.PasswordHasher;
                userToCreate.PasswordHash = hasher.HashPassword(userToCreate, userToCreate.PasswordHash);
                var a = this.UnitOfWork.UserManager.CreateAsync(userToCreate).GetAwaiter().GetResult();
                this.UnitOfWork.UserManager.AddToRoleAsync(userToCreate, "User").GetAwaiter().GetResult();
                this.UnitOfWork.Save();

                var userRoles = this.UnitOfWork.UserManager.GetRolesAsync(userToCreate).Result;
                var token = JwtManager.GenerateToken(userToCreate, userRoles);

                return Ok(token);
            }
            else
            {
                return BadRequest("Username is already exist.");
            }


        }

        [ValidateModel]
        [HttpPost("[action]")]
        public IActionResult LogIn([FromBody] LogInDto model)
        {
            var user = this.UnitOfWork.UserManager.FindByEmailAsync(model.Email).Result;

            if (user == null)
            {
                return BadRequest("Your email or password is invalid");
            }

            if (!this.UnitOfWork.UserManager.CheckPasswordAsync(user, model.Password).Result)
            {
                return BadRequest("Your email or password is invalid");
            }

            var userRoles = this.UnitOfWork.UserManager.GetRolesAsync(user).Result;
            var token = JwtManager.GenerateToken(user,userRoles);

            return Ok(token);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public IActionResult AddUserToRole(AddToRoleDto model)
        {
            var user = UnitOfWork.UserManager.FindByEmailAsync(model.Email).GetAwaiter().GetResult();
            UnitOfWork.UserManager.AddToRoleAsync(user, model.Role).GetAwaiter().GetResult();

            return Ok();
        }

    }
}