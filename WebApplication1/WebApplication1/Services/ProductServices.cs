using WebApplication1.Data;
using WebApplication1.DTOS;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _db;
        public ProductServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Product> GetAll()
        {
            var AllProducts = _db.Products.ToList();
            return AllProducts;
        }
        public Product GetById(int Id)
        {
            var IfExixtProduct = _db.Products.Any(x => x.Id == Id);
            if (!IfExixtProduct)
            {
                throw new ExeptionNotFound();
            }
            var SingleProduct = _db.Products.Find(Id);
            return SingleProduct;
        }
        public Product AddNewProductServices(CreateNewProductDTO dto)
        {
            var IsDublicatedProduct = _db.Products.Any(x=>x.Name==dto.Name);
            if (IsDublicatedProduct)
            {
                throw new ExceptionDublicateProduct();
            }
            if(dto.Cost>dto.Price)
            {
                throw new ExceptionPriceLessCost();
            }
            var NewProduct = new Product() { 
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                Cost = dto.Cost
            };
            _db.Products.Add(NewProduct);
            _db.SaveChanges();
            if (!(_db.Products.Any(x => x.Id == NewProduct.Id)))
            {
                throw new NotSaveChangeInDataBase();
            }
            return NewProduct;



        }
        public Product UpdateProduct(UpdateProductDTO dto)
        {
            var IsExistProduct = _db.Products.Any( x => x.Id==dto.Id);
            if(!IsExistProduct)
            {
                throw new ExeptionNotFound();
            }
            var productWantUpdate = _db.Products.Find(dto.Id);
            productWantUpdate.Name= dto.Name;
            productWantUpdate.Description= dto.Description;
            productWantUpdate.Cost= dto.Cost;
            productWantUpdate.Price= dto.Price;
            _db.Products.Update(productWantUpdate);
            _db.SaveChanges();
            if (!(_db.Products.Any(x => x == productWantUpdate)))
            {
                throw new NotSaveChangeInDataBase();
            }
            return productWantUpdate;
        }
        public string DeleteProduct(int Id)
        {
            var IsExistProduct = _db.Products.Any(x=>x.Id==Id);
            if (!IsExistProduct)
            {
                throw new ExeptionNotFound();
            }
            var ProductWantDeleted = _db.Products.Find(Id);
            _db.Products.Remove(ProductWantDeleted);
            _db.SaveChanges();
            return $"Success Remove{IsExistProduct}";
        }
    }
}
