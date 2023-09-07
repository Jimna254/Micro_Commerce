using Micro_Commerce_Products.Models;

namespace Micro_Commerce_Products.Services.IServices
{
    public interface IProductInterface
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(Guid id);

        Task<string> AddProductAsync(Product product);

        Task<string> DeleteProductAsync(Product product);

        Task<string> UpdateProductAsync(Product product);
    }
}
