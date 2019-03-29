using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public enum Hoodies
    {
        Sweatshirt,
        Bomber,
        Hoody
    }

    public class Hoody : Product
    {
        public int Id { get; set; }

        public string Size { get; set; }

        public double Price { get; set; }

        public double Count { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public Hoodies Type { get; set; }

        public Color Color { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
