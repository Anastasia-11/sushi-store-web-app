using System.Linq;
using CourseProject.Database;
using CourseProject.Models;

namespace CourseProject.Services
{
    public class ProductService : IProductService
    {
        private ApplicationContext _context;

        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }
    }
}