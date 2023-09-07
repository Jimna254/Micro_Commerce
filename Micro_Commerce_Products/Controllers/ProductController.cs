using AutoMapper;
using Micro_Commerce_Products.Data.DTOs;
using Micro_Commerce_Products.Models;
using Micro_Commerce_Products.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Micro_Commerce_Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductInterface _productInterface;

        //Dont inject the response DTO ...just initialize
        private readonly ResponseDTO _responseDto;
        public ProductController(IMapper mapper , IProductInterface productInterface)
        {
            _mapper = mapper;
            _productInterface = productInterface;
            
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllProducts()
        {

            var products = await _productInterface.GetProductsAsync();
            if (products == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);
            }

            _responseDto.Result = products;


            return Ok(_responseDto);
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDTO>> AddCoupon(ProductRequestDTO productRequestDto)
        {
            try
            {
                var newProduct = _mapper.Map<Product>(productRequestDto);
                var response = await _productInterface.AddProductAsync(newProduct);
                if (string.IsNullOrWhiteSpace(response))
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Error Occured";
                    return BadRequest(_responseDto);
                }

                _responseDto.Result = response;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                return BadRequest(_responseDto);
            }

            return Ok(_responseDto);
        }
        [HttpGet("GetById({Id})")]
        public async Task<ActionResult<ResponseDTO>> GetCoupon(Guid Id)
        {
            try
            {
                var product = await _productInterface.GetProductByIdAsync(Id);
                if (product == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Error Occured";
                    return BadRequest(_responseDto);
                }

                _responseDto.Result = product;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                return BadRequest(_responseDto);
            }

            return Ok(_responseDto);
        }

        [HttpDelete]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDTO>> DeleteProduct(Guid id)
        {
            try
            {
                var product = await _productInterface.GetProductByIdAsync(id);
                if (product == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Error Occured";
                    return BadRequest(_responseDto);
                }
                //delete
                var response = await _productInterface.DeleteProductAsync(product);
                _responseDto.Result = response;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                return BadRequest(_responseDto);

            }
            return Ok(_responseDto);
        }

    }
}
