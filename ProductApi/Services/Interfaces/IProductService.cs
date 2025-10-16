using ProductApi.DTOs;
using ProductApi.Models;
using ProductApi.Models.Enums;

namespace ProductApi.Services.Interfaces
{
    public interface IProductService
    {
        Product? Add(ProductRequest request);
        bool Delete(int id);
        List<Product> GetAll();
        List<Product> GetAll(ProductCategory? category, string? name);
        Product? GetById(int id);
        bool Update(int id, ProductRequest request);
    }
}
