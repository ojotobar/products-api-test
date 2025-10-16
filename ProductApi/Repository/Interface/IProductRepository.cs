using ProductApi.Models;

namespace ProductApi.Repository.Interface
{
    public interface IProductRepository
    {
        Product Add(Product product);
        bool Delete(int id);
        List<Product> GetAll();
        Product? GetById(int id);
        bool Update(Product product);
    }
}
