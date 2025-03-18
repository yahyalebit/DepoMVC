using Data.Concrete;
using Entity.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;
using DepoMvcKatmanlıMimariProjectUI.Models;

namespace DepoMvcKatmanlıMimariProjectUI.Controllers
{
	public class StockController : Controller
	{
		private readonly Context _context = new Context();

		[HttpGet]
		public ActionResult AddStock()
		{
			ViewBag.Products = _context.Products
									   .Select(p => new SelectListItem
									   {
										   Value = p.ProductID.ToString(),
										   Text = p.ProductName
									   }).ToList();

			ViewBag.Employees = _context.Employees
										.Select(e => new SelectListItem
										{
											Value = e.EmployeeId.ToString(),
											Text = e.EmployeeFirstName + " " + e.EmployeeLastName
										}).ToList();

			return View();
		}

		[HttpPost]
		public ActionResult AddStock(StockViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Products = _context.Products
										   .Select(p => new SelectListItem
										   {
											   Value = p.ProductID.ToString(),
											   Text = p.ProductName
										   }).ToList();

				ViewBag.Employees = _context.Employees
											.Select(e => new SelectListItem
											{
												Value = e.EmployeeId.ToString(),
												Text = e.EmployeeFirstName + " " + e.EmployeeLastName
											}).ToList();

				return View(model);
			}

			var order = new Order
			{
				EmployeeId = model.EmployeeID,
				OrderDate = DateTime.Now
			};
			_context.Orders.Add(order);
			_context.SaveChanges();

			var orderDetail = new OrderDetail
			{
				OrderID = order.OrderId,
				ProductID = model.ProductID,
				Quantity = model.Quantity
			};
			Product product = _context.Products.Find(model.ProductID);
			product.Stock += model.Quantity;
			_context.Entry(product).State = System.Data.Entity.EntityState.Modified;
			_context.OrderDetails.Add(orderDetail);
			_context.SaveChanges();

			return RedirectToAction("StockHistory");
		}
		public ActionResult StockHistory()
		{
			var stockHistory = (from od in _context.OrderDetails
								join o in _context.Orders on od.OrderID equals o.OrderId
								join p in _context.Products on od.ProductID equals p.ProductID
								join e in _context.Employees on o.EmployeeId equals e.EmployeeId
								orderby o.OrderDate descending	
								select new StockHistoryViewModel
								{
									ProductName = p.ProductName,
									EmployeeName = e.EmployeeFirstName + " " + e.EmployeeLastName,
									Quantity = od.Quantity,
									DateAdded = o.OrderDate
								}).ToList();

			return View(stockHistory);
		}

		// ---------------------------- Stock Çıkarma ----------------------------

		[HttpGet]
		public ActionResult StockOut()
		{
			ViewBag.Products = _context.Products
									   .Select(p => new SelectListItem
									   {
										   Value = p.ProductID.ToString(),
										   Text = p.ProductName
									   }).ToList();

			ViewBag.Customers = _context.Customers
										.Select(c => new SelectListItem
										{
											Value = c.CustomerId.ToString(),
											Text = c.CustomerName + " " + c.CustomerSurName
										}).ToList();

			ViewBag.Employees = _context.Employees
										.Select(e => new SelectListItem
										{
											Value = e.EmployeeId.ToString(),
											Text = e.EmployeeFirstName + " " + e.EmployeeLastName
										}).ToList();

			return View();
		}

		[HttpPost]
		public ActionResult StockOut(StockOutViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Products = _context.Products
										   .Select(p => new SelectListItem
										   {
											   Value = p.ProductID.ToString(),
											   Text = p.ProductName
										   }).ToList();

				ViewBag.Customers = _context.Customers
											.Select(c => new SelectListItem
											{
												Value = c.CustomerId.ToString(),
												Text = c.CustomerName + " " + c.CustomerSurName
											}).ToList();

				ViewBag.Employees = _context.Employees
											.Select(e => new SelectListItem
											{
												Value = e.EmployeeId.ToString(),
												Text = e.EmployeeFirstName + " " + e.EmployeeLastName
											}).ToList();

				return View(model);
			}

			var order = new Order
			{
				CustomerId = model.CustomerID,
				EmployeeId = model.EmployeeID,
				OrderDate = DateTime.Now
			};
			_context.Orders.Add(order);
			_context.SaveChanges();

			var orderDetail = new OrderDetail
			{
				OrderID = order.OrderId,
				ProductID = model.ProductID,
				Quantity = model.Quantity
			};
			_context.OrderDetails.Add(orderDetail);
			_context.SaveChanges();

			var product = _context.Products.Find(model.ProductID);
			product.Stock -= model.Quantity;
			_context.SaveChanges();

			return RedirectToAction("StockOutHistory");
		}
		public ActionResult StockOutHistory()
		{
			var stockOutHistory = (from od in _context.OrderDetails
								   join o in _context.Orders on od.OrderID equals o.OrderId
								   join p in _context.Products on od.ProductID equals p.ProductID
								   join c in _context.Customers on o.CustomerId equals c.CustomerId
								   join e in _context.Employees on o.EmployeeId equals e.EmployeeId
								   orderby o.OrderDate descending
								   select new StockOutHistoryViewModel
								   {
									   ProductName = p.ProductName,
									   CustomerName = c.CustomerName + " " + c.CustomerSurName,
									   EmployeeName = e.EmployeeFirstName + " " + e.EmployeeLastName,
									   Quantity = od.Quantity,
									   DateOut = o.OrderDate
								   }).ToList();

			return View(stockOutHistory);
		}

	}
}
