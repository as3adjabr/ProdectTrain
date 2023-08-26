using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOS;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        public ProductsController (IProductServices iProductServices) { 
            _productServices = iProductServices;
        }
        public IActionResult GetAll()
        {
            return Ok(_productServices.GetAll());
        }
        public IActionResult GetById(int id)
        {
            return Ok(_productServices.GetById(id));
        }
        [HttpPost]
        public IActionResult AddNewProduct([FromBody]CreateNewProductDTO dto)
        {
            
            return Ok(_productServices.AddNewProductServices(dto));
        }
        [HttpPut]
        public IActionResult UpdateProduct([FromBody]UpdateProductDTO dto)
        {
            return Ok(_productServices.UpdateProduct(dto));
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int Id)
        {
            return Ok(_productServices.DeleteProduct(Id));
        }
    }
}
