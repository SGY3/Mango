using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Mango.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedInUsaer());
        }

        public async Task<IActionResult> Remove(int cartDetailsid)
        {
            ResponseDto? reponse = await _cartService.RemoveFromCartAsync(cartDetailsid);

            if (reponse != null && reponse.IsSuccess)
            {
                TempData["success"] = "Cart Updated Successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(CartDto cartDto)
        {
            ResponseDto? reponse = await _cartService.ApplyCouponAsync(cartDto);

            if (reponse != null && reponse.IsSuccess)
            {
                TempData["success"] = "Cart Updated Successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RemoveCoupon(CartDto cartDto)
        {
            cartDto.CartHeader.CouponCode = "";
            ResponseDto? reponse = await _cartService.ApplyCouponAsync(cartDto);

            if (reponse != null && reponse.IsSuccess)
            {
                TempData["success"] = "Cart Updated Successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }
        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUsaer()
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? reponse = await _cartService.GetCartByUserIdAsync(userId);

            if (reponse != null && reponse.IsSuccess)
            {
                CartDto cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(reponse.Result));
                return cartDto;
            }
            return new CartDto();
        }
    }
}
