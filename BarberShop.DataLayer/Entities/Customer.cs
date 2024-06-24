using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.DataLayer.Entities
{
	public class Customer : BaseEntity
	{
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
