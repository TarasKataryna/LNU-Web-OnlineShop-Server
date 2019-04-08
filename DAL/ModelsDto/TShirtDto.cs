using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.ModelsDto
{
    public class TShirtDto
    {
        public int Id { get; set; }

        public string Size { get; set; }

        public double Price { get; set; }

        public double Count { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public Color Color { get; set; }

        public DAL.Entities.Type Type { get; set; }

        public Gender Gender { get; set; }

        public int? OrderId { get; set; }

        public int ImageId { get; set; }
    }
}
