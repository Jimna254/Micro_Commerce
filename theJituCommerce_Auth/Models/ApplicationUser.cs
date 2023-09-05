using Microsoft.AspNetCore.Identity;

namespace theJituCommerce_Auth.Models
{
    public class ApplicationUser : IdentityUser
    {
        //Adding own custom Collumn on top of the Identity user
        public string Name { get; set; } = string.Empty;
    }
}
