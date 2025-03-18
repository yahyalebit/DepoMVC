using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepoMvcKatmanlıMimariProjectUI.Models
{
	public class StockHistoryViewModel
	{
		public string ProductName { get; set; }
		public string EmployeeName { get; set; } 
		public int Quantity { get; set; }
		public DateTime DateAdded { get; set; } 
	}
}
