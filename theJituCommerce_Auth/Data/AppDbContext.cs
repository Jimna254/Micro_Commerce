using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using theJituCommerce_Auth.Models;

namespace theJituCommerce_Auth.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

     public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
