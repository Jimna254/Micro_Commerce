using Micro_Commerce_Products.Data;
using Micro_Commerce_Products.Models;
using Micro_Commerce_Products.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Micro_Commerce_Products.Services
{
    public class ProductService : IProductInterface
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public  async Task<string> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
           await _context.SaveChangesAsync();
            return "Product Added Succesfully";
        }

        public async Task<string> DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return "Product Deleted Succesfully";
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
           return await _context.Products.FirstOrDefaultAsync(p=>p.ProductId==id);

        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
          return await _context.Products.ToListAsync();
        }

        public async Task<string> UpdateProductAsync(Product product)
        {
           _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return "Product Updated Succesfully";
        }
    }
}
