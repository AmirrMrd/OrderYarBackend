using BarberShop.CoreLayer.DTOs.Users;
using BarberShop.DataLayer.Context;
using BarberShop.DataLayer.Entities;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.CoreLayer.Services.Users
{
	public class UserService : IUserService
	{
		private readonly BarberShopContext _context;
		public UserService(BarberShopContext context)
		{
			_context = context;
		}

		public async Task<OperationResult> LoginUser(UserLoginDto loginDto)
		{
			var passHash = loginDto.Password.EncodeToMd5();
			var res = await _context.Users.FirstOrDefaultAsync(x => x.Mobile == loginDto.Mobile && x.Password == passHash);
			if(res != null)
			{
				return OperationResult.Success("احراز هویت به درستی تایید شد");
			}
			else
			{
				return OperationResult.NotFound("کاربری با این مشخصات وجود ندارد");
			}
		}

		public async Task<OperationResult> RegisterUser(UserRegisterDto registerDto)
		{
			var res = await _context.Users.AnyAsync(x => x.Username == registerDto.UserName && x.Mobile == registerDto.Mobile);
			if (res)
			{
				return OperationResult.Error("کاربری با این مشخصات وجود دارد");
			}
			var passwordHash = registerDto.Password.EncodeToMd5();
			var user = new UserApplication()
			{
				Username = registerDto.UserName,
				Password = passwordHash,
				Mobile = registerDto.Mobile,
				CreationDate = DateTime.Now,
				IsDelete = false,
				Role = UserRole.Admin
			};
			var s = await _context.Users.AddAsync(user);
			var a = await _context.SaveChangesAsync();
			return OperationResult.Success("کاربر با موفقیت ایجاد شد");

		}
	}
}
