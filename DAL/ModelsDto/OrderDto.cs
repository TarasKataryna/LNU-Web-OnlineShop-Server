using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ModelsDto
{
    public  class OrderDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public double TotalSum { get; set; }

        public DateTime Date { get; set; }
    }
}
