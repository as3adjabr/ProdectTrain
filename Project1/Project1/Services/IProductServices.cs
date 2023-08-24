using Project1.Models;

namespace Project1.Services
{
    public interface IProductServices
    {
        void Delete(int Id);
        Product Get(int Id);
        List<Product> GetAll();
    }
}