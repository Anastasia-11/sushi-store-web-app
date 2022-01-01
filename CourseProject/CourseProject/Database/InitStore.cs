using System.Collections.Generic;
using System.IO;
using System.Linq;
using CourseProject.Models;
using CourseProject.Models.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CourseProject.Database
{
    public static class InitStore
    {
        public static void AddProducts(IApplicationBuilder app)
        {
            ApplicationContext context = app.ApplicationServices.GetRequiredService<ApplicationContext>();
            context.Database.Migrate();
            if (context.Products.Any()) return;
            
            context.Products.AddRange(
                new Product {
                    Name = "Филадельфия", 
                    Description = "Тунец, лосось, морской окунь, сливочный сыр",
                    Price = (decimal)15.90,
                    Category = Category.Sushi, 
                },
                new Product
                {
                    Name = "Бонито маки", 
                    Description = "Лосось, сливочный сыр, авокадо, стружка тунца",
                    Price = (decimal)12.90,
                    Category = Category.Sushi, 
                },
                new Product
                {
                    Name = "Хот Унаги маки", 
                    Description = "Угорь, огурец, сливочный сыр, икра летучей рыбы, соус Унаги",
                    Price = (decimal)15.90,
                    Category = Category.Sushi, 
                },
                new Product
                {
                    Name = "Парадайз маки", 
                    Description = "Лосось, сливочный сыр, авокадо, груша, соус Блю Чиз, кунжут",
                    Price = (decimal)14.90,
                    Category = Category.Sushi, 
                }
            );
            context.SaveChanges();
        }
        
        public static void AddProductsJson(IApplicationBuilder app)
        {
            ApplicationContext context = app.ApplicationServices.GetRequiredService<ApplicationContext>();
            context.Database.Migrate();
            if (context.Products.Any()) return;

            StreamReader streamReader = new StreamReader(@"Database\Data\products.json", true);
            string jsonString =streamReader.ReadToEnd();
            streamReader.Dispose();
            
            var products = new List<Product>();
            dynamic data = JsonConvert.DeserializeObject(jsonString);

            for (int i = 0; i < data.Sushi.Count; i++)
            {
                products.Add(new Product());
                products[^1].Id = data.Sushi[i].Id;
                products[^1].Name = data.Sushi[i].Name;
                products[^1].Description = data.Sushi[i].Description;
                products[^1].Price = data.Sushi[i].Price;
                products[^1].Category = data.Sushi[i].Category;
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}