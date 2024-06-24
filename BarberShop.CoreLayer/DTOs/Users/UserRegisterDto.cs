using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.CoreLayer.DTOs.Users
{
	public class UserRegisterDto
	{
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
