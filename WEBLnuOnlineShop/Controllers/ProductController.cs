using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using DAL.UnitOfWork;
using System.IO;
using DAL.Entities;

namespace WEBLnuOnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public ProductController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }


        [HttpPost("[action]")]
        public IActionResult SetImage(IFormFile file)
        {
            Image image = null;
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                byte[] img = ms.ToArray();
                image = new Image { Img = img };
            }

            UnitOfWork.Images.Create(image);
            UnitOfWork.Save();

            return Ok();
        }
    }
}