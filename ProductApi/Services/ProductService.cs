using ProductApi.DTOs;
using ProductApi.Models;
using ProductApi.Models.Enums;
using ProductApi.Repository.Interface;
using ProductApi.Services.Interfaces;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetAll(ProductCategory? category, string? name)
        {
            var products = _repository.GetAll();
            if (category.HasValue)
            {
                products = products.Where(p => p.Category == category.Value).ToList();
            }
            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return products;
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product? GetById(int id) =>
            _repository.GetById(id);

        public Product? Add(ProductRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name))
                return null;

            var product = new Product 
            { 
                Name = request.Name, 
                Category = request.Category,
                Price = request.Price 
            };

            
            _repository.Add(product);
            return product;
        }

        public bool Update(int id, ProductRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name))
                return false;

            var product = _repository.GetById(id);
            if (product == null) return false;

            product.Name = request.Name;
            product.Price = request.Price;
            product.Category = request.Category;

            return _repository.Update(product);
        }

        public bool Delete(int id)
        {
            var product = _repository.GetById(id);
            if(product == null) return false;

            return _repository.Delete(id);
        }
    }
}
