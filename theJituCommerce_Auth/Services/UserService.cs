using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using theJituCommerce_Auth.Data;
using theJituCommerce_Auth.Models;
using theJituCommerce_Auth.Models.DTOs;
using theJituCommerce_Auth.Services.IServices;

namespace theJituCommerce_Auth.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        // private readonly IJWtTokenGenerator _jwtGenerator;
        public UserService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager , IMapper mapper )
        {
            _context = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            
        }

        public Task<bool> AssignUserRole(string email, string Rolename)
        {
            throw new NotImplementedException();
        }


        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
        {
            //Get User by Username
            var user =await _context.ApplicationUsers.FirstOrDefaultAsync(u=> u.UserName.ToLower() == loginRequestDto.Username.ToLower());
            //Check if the password is valid
           
            

            var isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (!isValid || user == null) {

                new LoginResponseDTO();
            
            }
            //This if username and password are valid

            var loggeduser = new LoginResponseDTO()
            {
                User = _mapper.Map<UserDTO>(user),
                Token = "CommingSoon"

            };
            return loggeduser;

        }

        public async Task<string> RegisterUser(RegisterRequestDTO registerRequestDto)
        {
            var user = _mapper.Map<ApplicationUser>(registerRequestDto);

            try
            {
                var result = await _userManager.CreateAsync(user, registerRequestDto.Password);

                if (result.Succeeded)
                {
                    //if success return empty string

                    //var get User 
                    //var existingUser = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName.ToLower() == registerRequestDto.Email.ToLower());
                    return "";
                }

                else
                {
                    //identity Error if any
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
}
    }

