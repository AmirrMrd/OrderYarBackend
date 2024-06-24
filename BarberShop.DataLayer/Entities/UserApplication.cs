using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.DataLayer.Entities
{
	public class UserApplication : BaseEntity
	{
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public ICollection<Order> Orders { get; set; }
        public UserRole Role { get; set; }
    }

	public enum UserRole
	{
		Admin,
		User
	}
}
