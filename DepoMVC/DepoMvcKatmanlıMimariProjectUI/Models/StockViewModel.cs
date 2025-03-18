using System.ComponentModel.DataAnnotations;

namespace DepoMvcKatmanlıMimariProjectUI.Models
{
	public class StockViewModel
	{
		public int ProductID { get; set; }
		public int EmployeeID { get; set; }

		[Required(ErrorMessage = "Stok miktarı gereklidir.")]
		[Range(1, 200, ErrorMessage = "Stok miktarı 1 ile 200 arasında olmalıdır.")]
		public int Quantity { get; set; }
	}
}
