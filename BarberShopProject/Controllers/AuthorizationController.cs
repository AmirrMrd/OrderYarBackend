using BarberShopProject.Infrastructure.Entities;
using BarberShopProject.Services.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarberShopProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        [HttpGet(Name = "login")]
        public async Task<bool> Get(string model)
        {
            if (model != null)
            {
                return true;
            }
            else { return false; }
        }

        [HttpPost(Name = "register")]
        public async Task<bool> register (User model)
        {
            if (model != null)
            {
                await _authorizationService.AddUser(model);
                return true;
            }
            else { return false; }
        }
    }
}
