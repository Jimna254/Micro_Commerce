using AutoMapper;
using theJituCommerce_Auth.Models;
using theJituCommerce_Auth.Models.DTOs;

namespace theJituCommerce_Auth.Profiles
{
    public class AuthProfiles : Profile
    {
        public AuthProfiles()
        {
            CreateMap<RegisterRequestDTO, ApplicationUser>().ForMember(dest=> dest.UserName, u=>u.MapFrom(reg=>reg.Email));
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();

        }

    }
}
