using Mango.Services.AuthAPI.Models;

namespace Mango.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenrator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
