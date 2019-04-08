using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace DAL.ModelsDto
{
    public class ImgDto
    {
        public IFormFile img { get; set; }
    }
}
