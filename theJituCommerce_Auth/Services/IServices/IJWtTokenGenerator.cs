using theJituCommerce_Auth.Models;

namespace Micro_Commerce_Auth.Services.IServices
{
    public interface IJWtTokenGenerator
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
