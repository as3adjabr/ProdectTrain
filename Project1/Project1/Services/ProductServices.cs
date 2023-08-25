using Project1.Data;
using Project1.DTOS;
using Project1.Exep;
using Project1.Models;

namespace Project1.Services
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
            var AllProduct = _db.Products.ToList();
            return AllProduct;
        }
        public Product Get(int Id)
        {
            var SingleProduct = _db.Products.Find(Id);
            return SingleProduct;
        }
        public void Delete(int Id)
        {
            var SingleProduct = _db.Products.Find(Id);
            _db.Products.Remove(SingleProduct);
            _db.SaveChanges();
        }
        public int Create(ProductCreateDTO dto)
        {
            var IsExistProduct = _db.Products.Any(x=>x.Name== dto.Name);
            if (IsExistProduct)
            {
                throw new ExpeptionDublicatedProduct();
            }
            if (dto.price<dto.cost)
            {
                throw new PricrLessCost();
            }
            Product product = new Product();
            product.Price = dto.price;
            product.Name = dto.Name;
            product.Cost = dto.cost;
            _db.Products.Add(product);
            _db.SaveChanges();
            return product.Id;
        }
        public int Update(ProductUpdateDTO dto)
        {
            var product = _db.Products.Find(dto.Id);
            product.Price = dto.price;
            product.Name = dto.Name;
            product.Cost = dto.cost;
            _db.Products.Update(product);
            _db.SaveChanges();
            return product.Id;
        }
    }
}
