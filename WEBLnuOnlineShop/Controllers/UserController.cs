using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var user = this.UnitOfWork.UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                var userToCreate = model.ToUser();
                var hasher = this.UnitOfWork.UserManager.PasswordHasher;
                userToCreate.PasswordHash = hasher.HashPassword(userToCreate, userToCreate.PasswordHash);
                var a = this.UnitOfWork.UserManager.CreateAsync(userToCreate).GetAwaiter().GetResult();
                this.UnitOfWork.Save();
                return Ok();
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
            RoleInitializer.InitializeAsync(UnitOfWork.UserManager, UnitOfWork.RoleManager).GetAwaiter().GetResult();
            var user = UnitOfWork.UserManager.FindByEmailAsync(model.Email).GetAwaiter().GetResult();
            if (user == null)
            {
                return BadRequest("Your email or password is invalid");
            }
            else
            {
                if (!this.UnitOfWork.UserManager.CheckPasswordAsync(user, model.Password).Result)
                {
                    return BadRequest("Your email or password is invalid");
                }
                else
                    return Ok();
            }
        }
    }
}