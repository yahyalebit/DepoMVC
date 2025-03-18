using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class OrderDetail
	{
		public int OrderDetailId { get; set; }
		public int OrderID { get; set; }
		public int ProductID { get; set; }
		public Order Order { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}
