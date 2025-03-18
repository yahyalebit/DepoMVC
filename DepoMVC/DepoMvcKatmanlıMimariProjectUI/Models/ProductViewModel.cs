using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepoMvcKatmanlıMimariProjectUI.Models
{
	public class ProductViewModel
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductImage { get; set; }
		public int Stock { get; set; }
		public string CategoryName { get; set; }
	}
}