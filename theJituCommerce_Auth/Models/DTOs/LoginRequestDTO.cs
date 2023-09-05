using System.ComponentModel.DataAnnotations;

namespace theJituCommerce_Auth.Models.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        
    }
}
