using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.UnitOfWork;
using DAL.ModelsDto;

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

        [HttpPost("action")]
        public IActionResult SignUp([FromBody] SignUpDto model)
        {
            return Ok();
        }

        public IActionResult LogIn([FromBody] LogInDto model)
        {
            return Ok();
        } 
    }
}