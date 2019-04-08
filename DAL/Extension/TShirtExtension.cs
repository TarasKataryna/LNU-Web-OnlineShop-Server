using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.ModelsDto;

namespace DAL.Extension
{
    public static class TShirtExtension
    {
        public static TShirt ToShirt(this TShirtDto model)
        {
            var shirt = new TShirt()
            {
                Id = model.Id,
                Size = model.Size,
                Price = model.Price,
                Count = model.Count,
                Name = model.Name,
                Brand =  model.Brand,
                Color = model.Color,
                Type = model.Type,
                Gender = model.Gender,
                OrderId = model.OrderId,
                ImageId = model.ImageId
            };
            return shirt;
        }

        public static void ToDto(this TShirtDto model, TShirt shirt)
        {
            model.Id = shirt.Id;
            model.Size = shirt.Size;
            model.Price = shirt.Price;
            model.Count = shirt.Count;
            model.Name = shirt.Name;
            model.Brand = shirt.Brand;
            model.Color = shirt.Color;
            model.Type = shirt.Type;
            model.Gender = shirt.Gender;
            model.OrderId = shirt.OrderId;
            model.ImageId = shirt.ImageId;
        }
    }
}
