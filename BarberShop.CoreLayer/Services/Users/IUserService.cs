using BarberShop.CoreLayer.DTOs.Users;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.CoreLayer.Services.Users
{
	public interface IUserService
	{
		Task<OperationResult> RegisterUser(UserRegisterDto registerDto);
		Task<OperationResult> LoginUser(UserLoginDto loginDto);
	}
}
