using Micro_Commerce_Products.Models;
using Microsoft.EntityFrameworkCore;

namespace Micro_Commerce_Products.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        { }
        public DbSet<Product> Products {get; set;}


    }
}
