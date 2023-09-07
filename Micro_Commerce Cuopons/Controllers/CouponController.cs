using AutoMapper;
using Micro_Commerce_Cuopons.Models;
using Micro_Commerce_Cuopons.Models.DTOs;
using Micro_Commerce_Cuopons.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micro_Commerce_Cuopons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize]
    public class CouponController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICouponInterface _couponInterface;

        // Don't Inject just Instatiate the DTO
        private readonly ResponseDTO _responseDTO;
        public CouponController(IMapper mapper, ICouponInterface couponInterface)
        {
            _couponInterface = couponInterface;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
            
        }
        [HttpGet("Get All Coupons")]
        public async Task<ActionResult<ResponseDTO>> GetAllCoupons()
        {
            var coupons = await _couponInterface.GetCouponsAsync();
            if (coupons == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = "Error Occured";
                return BadRequest(_responseDTO);
            }

            _responseDTO.Result = coupons;

            return Ok(_responseDTO);
        }

        [HttpPost]

        public async Task<ActionResult<ResponseDTO>> AddCoupon(CouponRequestDTO couponRequest)
        {
            var newCoupon = _mapper.Map<Coupon>(couponRequest);
            var response = await _couponInterface.AddCouponAsync(newCoupon);
            if (string.IsNullOrWhiteSpace(response))
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = "Error Occured";
                return BadRequest(_responseDTO);
            }

           
            return Ok(_responseDTO);
            // to do create coupons in Stripe
          
        }

        [HttpGet("GetByName/{code}")]
        public async Task<ActionResult<ResponseDTO>> GetCoupon(string code)
        {
            var coupon = await _couponInterface.GetCouponByNameAsync(code);
            if (coupon == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = "Error Occured";
                return BadRequest(_responseDTO);
            }

            _responseDTO.Result = coupon;
            return Ok(_responseDTO);
        }

        [HttpPut]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDTO>> UpdateCoupon(Guid id, CouponRequestDTO couponRequestDto)
        {
            var coupon = await _couponInterface.GetCouponByIdAsync(id);
            if (coupon == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = "Error Occured";
                return BadRequest(_responseDTO);
            }

            //update if coupon is valid
            var updated = _mapper.Map(couponRequestDto, coupon);
            var response = await _couponInterface.UpdateCouponAsync(updated);
            _responseDTO.Result = response;
            return Ok(_responseDTO);
        }
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDTO>> DeleteCoupon(Guid id)
        {
            var coupon = await _couponInterface.GetCouponByIdAsync(id);
            if (coupon == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = "Error Occured";
                return BadRequest(_responseDTO);
            }
            
            var response = await _couponInterface.DeleteCouponAsync(coupon);
            _responseDTO.Result = response;
            return Ok(_responseDTO);
        }






    }
}
