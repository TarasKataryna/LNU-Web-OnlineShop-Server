using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ModelsDto
{
    public class BuyProductsDto
    {
        public List<TShirtDto> shirts { get; set; }

        public List<HoodyDto> hoodies { get; set; }

        public  OrderDto order { get; set; }
    }
}
