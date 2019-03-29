using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public double TotalSum { get; set; }

        public DateTime Date { get; set; }

        public User User { get; set; }

    }
}
