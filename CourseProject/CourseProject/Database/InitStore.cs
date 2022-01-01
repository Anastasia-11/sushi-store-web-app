using System.Linq;
using CourseProject.Models;
using CourseProject.Models.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                new Product
                {
                    Name = "Филадельфия", 
                    Description = "Тунец, лосось, морской окунь, сливочный сыр",
                    Price = (decimal)15.90,
                    Category = Category.Sushi, 
                }
            );
            context.SaveChanges();
        }
    }
}