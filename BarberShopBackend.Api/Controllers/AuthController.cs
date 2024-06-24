using BarberShop.CoreLayer.DTOs.Users;
using BarberShop.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberShopBackend.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserService _userService;
		public AuthController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
		[Route("Register")]
		public async Task<string> Register(UserRegisterDto registerDto)
		{
			var res = await _userService.RegisterUser(registerDto);
			return res.Message;
		}

		[HttpPost]
		[Route("Login")]
		public async Task<string> Login(UserLoginDto loginDto)
		{
			if (loginDto == null)
			{
				var msg = "اطلاعات به درستی وارد نشده است";
				return msg;
			}
			else
			{
				var res = await _userService.LoginUser(loginDto);
				return res.Message;
			}

		}
	}
}
