using Micro_Commerce_Cuopons.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Micro_Commerce_Cuopons.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)

        { }
        public DbSet <Coupon> Coupons { get; set;}
        
    }
}
