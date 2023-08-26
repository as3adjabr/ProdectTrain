using WebApplication1.DTOS;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IProductServices
    {
        List<Product> GetAll();
        Product GetById(int Id);
        Product AddNewProductServices(CreateNewProductDTO dto);
        Product UpdateProduct(UpdateProductDTO dto);
        string DeleteProduct(int Id);
    }
}