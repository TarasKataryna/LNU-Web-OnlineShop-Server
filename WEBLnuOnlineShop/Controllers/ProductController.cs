using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using DAL.UnitOfWork;
using System.IO;
using DAL.Entities;
using System.Net.Http.Headers;

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


        [HttpGet("[action]")]
        public IActionResult GetAllTShirts()
        {
            return Ok(UnitOfWork.TShirts.GetAllEntities());
        }

        [HttpGet("[action]")]
        public IActionResult GetAllMaleTShirts()
        {
            return Ok(UnitOfWork.TShirts.GetAllEntitiesByFilter(sh=>sh.Gender == Gender.Male));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllFemaleTShirts()
        {
            return Ok(UnitOfWork.TShirts.GetAllEntitiesByFilter(sh => sh.Gender == Gender.Female));
        }

        [HttpGet("[action]/{color}")]
        public IActionResult GetAllTShirtsByColor(string color)
        {
            return Ok(UnitOfWork.TShirts.GetAllEntitiesByFilter(sh => sh.Color.ToString("G").ToLower() == color));
        }

        [HttpGet("[action]/{type}")]
        public IActionResult GetAllTShirtsByType(string type)
        {
            return Ok(UnitOfWork.TShirts.GetAllEntitiesByFilter(sh => sh.Type.ToString("G").ToLower() == type));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllHoodies()
        {
            return Ok(UnitOfWork.Hoodies.GetAllEntities());
        }

        [HttpGet("[action]/{color}")]
        public IActionResult GetAllHoodiesByColor(string color)
        {
            return Ok(UnitOfWork.Hoodies.GetAllEntitiesByFilter(sh => sh.Color.ToString("G").ToLower() == color));
        }

        [HttpGet("[action]/{type}")]
        public IActionResult GetAllHoodiesByType(string type)
        {
            return Ok(UnitOfWork.Hoodies.GetAllEntitiesByFilter(sh => sh.Type.ToString("G").ToLower() == type));
        }

        [HttpPost("[action]")]
        public IActionResult BuyProducts()
        {
            return Ok();
        }
    }
}