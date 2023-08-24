using Project1.Data;
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
    }
}
