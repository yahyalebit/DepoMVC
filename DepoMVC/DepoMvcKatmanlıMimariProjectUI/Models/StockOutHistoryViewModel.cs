using System;

namespace DepoMvcKatmanlıMimariProjectUI.Models
{
	public class StockOutHistoryViewModel
	{
		public string ProductName { get; set; }
		public string CustomerName { get; set; }
		public string EmployeeName { get; set; }
		public int Quantity { get; set; }
		public DateTime DateOut { get; set; }
	}
}
