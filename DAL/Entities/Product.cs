using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public enum Color
    {
        Black,
        White,
        Yellow,
        Blue,
        Red,
        Orange,
        Grey,
        Green
    }

    public interface Product
    {
        string Size { get; set; }

        double Price { get; set; }

        double Count { get; set; }

        string Name { get; set; }

        string Brand { get; set; }

        Color Color { get; set; } 

    }
}
