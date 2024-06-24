using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.DataLayer.Entities
{
	public class Order : BaseEntity
	{
        public string OrderCode { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [ForeignKey("UserId")]
        public UserApplication OrderUser { get; set; }
        public DateTime OrderDoneDate { get; set; }
    }
}
