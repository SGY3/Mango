using AutoMapper;
using Mango.Services.ShoppingCartAPI.Data;
using Mango.Services.ShoppingCartAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartAPIController : ControllerBase
    {
        private ResponseDto _response;
        private IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public CartAPIController(ResponseDto response, IMapper mapper, ApplicationDbContext context)
        {
            _response = response;
            _mapper = mapper;
            _context = context;
        }
        [HttpPost("CartUpsert")]
        public async Task<ResponseDto> CartUpsert(CartDto cartDto)
        {
            try
            {
                var cartHearderFromDb = await _context.CartHeaders.FirstOrDefaultAsync(u => u.UserId == cartDto.CartHeader.UserId);
                if (cartHearderFromDb == null)
                {
                    //create header and details
                }
                else
                {
                    //if header is not null
                    //check if details has some product
                    var cartDetailsFromDb=await _context.CartDetails.FirstOrDefaultAsync(
                        u=> u.ProductId==cartDto.CartDetails.First().ProductId &&
                        u.CartHeaderId==cartHearderFromDb.CardHeaderId);
                    if (cartDetailsFromDb == null)
                    {
                        //create cardDetails
                    }
                    else
                    {
                        //update count in cart details
                    }
                }
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
        }
    }
}
