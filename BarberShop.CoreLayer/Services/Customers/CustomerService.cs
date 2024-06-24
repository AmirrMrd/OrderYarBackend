using BarberShop.CoreLayer.DTOs.Customers;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.CoreLayer.Services.Customers
{
	public class CustomerService : ICustomerService
	{
		public async Task<string> LoginCustomer(CustomerDto customer)
		{
			var msg = "";
			return msg;
		}
	}
}
