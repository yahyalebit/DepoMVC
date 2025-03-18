using Data.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;


namespace DepoMvcKatmanlıMimariProjectUI.Models
{
	public class StockOutViewModel : IValidatableObject
	{
		private readonly Context _context;

		public StockOutViewModel()
		{
			_context = new Context(); 
		}

		[Required(ErrorMessage = "Ürün seçimi zorunludur.")]
		public int ProductID { get; set; }

		[Required(ErrorMessage = "Müşteri seçimi zorunludur.")]
		public int CustomerID { get; set; }

		[Required(ErrorMessage = "Personel seçimi zorunludur.")]
		public int EmployeeID { get; set; }

		[Required(ErrorMessage = "Çıkartılacak miktar zorunludur.")]
		[Range(1, int.MaxValue, ErrorMessage = "Çıkartılacak miktar 1 veya daha büyük olmalıdır.")]
		public int Quantity { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var product = _context.Products.FirstOrDefault(p => p.ProductID == ProductID);

			if (product != null && Quantity > product.Stock)
			{
				yield return new ValidationResult($"Stok Yetersiz! Mevcut stok: {product.Stock} adet.", new[] { "Quantity" });
			}
		}
	}
}
