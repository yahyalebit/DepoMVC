using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class Product
	{
		public int ProductID { get; set; }
		[Required]
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductImage { get; set; }
		public int Stock { get; set; }
		public int CategoryID { get; set; }
		public Category Category { get; set; }
		public ICollection<OrderDetail> OrderDetails { get; set; }

	}
}
