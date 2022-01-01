using System.Linq;
using CourseProject.Models;

namespace CourseProject.Services
{
    public interface IProductService
    {
        IQueryable<Product> GetAll();
    }
}