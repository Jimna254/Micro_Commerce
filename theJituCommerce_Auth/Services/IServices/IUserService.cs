using theJituCommerce_Auth.Models.DTOs;

namespace theJituCommerce_Auth.Services.IServices
{
    public interface IUserService
    {
        Task<string> RegisterUser(RegisterRequestDTO registerRequestDto);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);

        Task<bool> AssignUserRole(string email, string Rolename);
    }
}
