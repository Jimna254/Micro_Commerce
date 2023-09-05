using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theJituCommerce_Auth.Models.DTOs;
using theJituCommerce_Auth.Services.IServices;

namespace theJituCommerce_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private IUserService _iuserService;
        private readonly ResponseDTO _response;
        public UserController(IUserService userInterface)
        {
            _iuserService = userInterface;

            // dont inject just initialize
            _response = new ResponseDTO();
        }
        [HttpPost("register")]
        public async Task<ActionResult<ResponseDTO>> AddUSer(RegisterRequestDTO registerRequestDto)
        {
            var errorMessage = await _iuserService.RegisterUser(registerRequestDto);
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                //error
                _response.IsSuccess = false;
                _response.Message = errorMessage;

                return BadRequest(_response);
            }

            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseDTO>> LoginUser(LoginRequestDTO loginRequestDto)
        {
            var response = await _iuserService.Login(loginRequestDto);

            if (response == null)
            {
                // Error
                var errorResponse = new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Invalid Credentials"
                };

                return BadRequest(errorResponse);
            }

            // Successful login
            return Ok(response);
        }


    }
}
