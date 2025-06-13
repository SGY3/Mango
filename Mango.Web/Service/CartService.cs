using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseservice;

        public CartService(IBaseService service)
        {
            _baseservice = service;
        }

        public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                ApiUrl = SD.ShoppingCartAPIBase + "/api/cart/ApplyCoupon"

            });
        }
        public async Task<ResponseDto?> EmailCart(CartDto cartDto)
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                ApiUrl = SD.ShoppingCartAPIBase + "/api/cart/EmailCartRequest"

            });
        }

        public async Task<ResponseDto?> GetCartByUserIdAsync(string userid)
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.ShoppingCartAPIBase + "/api/cart/GetCart/" + userid

            });
        }

        public async Task<ResponseDto?> RemoveFromCartAsync(int cardDetailsId)
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cardDetailsId,
                ApiUrl = SD.ShoppingCartAPIBase + "/api/cart/Removecart"

            });
        }

        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                ApiUrl = SD.ShoppingCartAPIBase + "/api/cart/CartUpsert"

            });
        }
    }
}
