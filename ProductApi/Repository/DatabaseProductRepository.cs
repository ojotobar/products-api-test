using ProductApi.Models.Enums;
using ProductApi.Models;
using ProductApi.Repository.Interface;

namespace ProductApi.Repository
{
    public class DatabaseProductRepository : IProductRepository
    {
        private List<Product> _products = new()
        {
            new Product
            {
                Id = 1,
                Name = "HP Envy",
                Price = 575900.57M,
                Category = ProductCategory.Electronics
            },
            new Product
            {
                Id = 2,
                Name = "Fundamentals of C# Programming",
                Price = 5000,
                Category = ProductCategory.BookAndStationery
            }
        };

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public Product Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);

            return product;
        }

        public bool Update(Product product)
        {
            var clone = product;
            _products.Remove(clone);
            Add(product);
            return true;
        }

        public bool Delete(int id)
        {
            return _products.Remove(_products[id]);
        }
    }
}
