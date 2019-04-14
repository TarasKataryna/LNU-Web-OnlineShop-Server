using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.ModelsDto
{
    public class HoodyDto
    {
        public int Id { get; set; }

        public string Size { get; set; }

        public double Price { get; set; }

        public double Count { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public Hoodies Type { get; set; }

        public Color Color { get; set; }

        public int ImageId { get;set; }

        public double? CountToBuy { get; set; }
    }
}
