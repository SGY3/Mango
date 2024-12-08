using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseservice;

        public CouponService(IBaseService service)
        {
            _baseservice = service;
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = couponDto,
                ApiUrl = SD.CouponAPIBase + "/api/Coupon"

            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                ApiUrl = SD.CouponAPIBase + "/api/Coupon/" + id

            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/Coupon"

            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/Coupon/GetByCode/" + couponCode

            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/Coupon/" + id

            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseservice.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = couponDto,
                ApiUrl = SD.CouponAPIBase + "/api/Coupon"

            });
        }
    }
}
