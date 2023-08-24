using Microsoft.AspNetCore.Mvc;
using Project1.DTOS;
using Project1.Services;

namespace Project1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productServices.GetAll());
        }
        [HttpGet]
        public IActionResult Get(int Id)
        {
            return Ok(_productServices.Get(Id));
        }

        [HttpPost]
        public IActionResult Create([FromBody]ProductCreateDTO dto)
        {
            return Ok(_productServices.Create(dto));
        }
        [HttpPut]
        public IActionResult Update([FromBody] ProductUpdateDTO dto)
        {
            return Ok(_productServices.Update(dto));
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _productServices.Delete(Id);
            return Ok("Done");
        }
    }
}
