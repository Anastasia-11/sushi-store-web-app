using CourseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; } 
    }
}