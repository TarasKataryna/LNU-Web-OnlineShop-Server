using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.ModelsDto;

namespace DAL.Extension
{
    public static class HoodyExtension
    {
        public static Hoody ToHoody(this HoodyDto model)
        {
            var hoddie = new Hoody()
            {
                Id = model.Id,
                Size = model.Size,
                Price = model.Price,
                Count = model.Count,
                Name = model.Name,
                Brand = model.Brand,
                Color = model.Color,
                Type = model.Type,
                OrderId = model.OrderId,
                ImageId = model.ImageId
            };
            return hoddie;
        }

        public static void ToDto(this HoodyDto model, Hoody hoody)
        {
            model.Id = hoody.Id;
            model.Size = hoody.Size;
            model.Price = hoody.Price;
            model.Count = hoody.Count;
            model.Name = hoody.Name;
            model.Brand = hoody.Brand;
            model.Color = hoody.Color;
            model.Type = hoody.Type;
            model.OrderId = hoody.OrderId;
            model.ImageId = hoody.ImageId;
        }
    }
}
