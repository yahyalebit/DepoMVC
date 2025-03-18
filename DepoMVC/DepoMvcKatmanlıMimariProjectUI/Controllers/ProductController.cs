using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.EntityFramework;
using DepoMvcKatmanlıMimariProjectUI.Models;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepoMvcKatmanlıMimariProjectUI.Controllers
{
    public class ProductController : Controller
    {
		ProductManager pm = new ProductManager(new EfProductDal());
		CategoryManager cm = new CategoryManager(new EfCategoryDal());
		public ActionResult Index()
		{
			var products = (from p in pm.Productliste()
							join c in cm.Categoryliste() on p.CategoryID equals c.CategoryID
							where c.CategoryStatus == true 
							select new ProductViewModel
							{
								ProductID = p.ProductID,
								ProductName = p.ProductName,
								ProductPrice = p.ProductPrice,
								ProductImage = p.ProductImage,
								Stock = p.Stock,
								CategoryName = c.CategoryName
							}).ToList();

			return View(products);
		}

		[HttpGet]
		public ActionResult Create()
		{
			var categoryList = cm.Categoryliste()
								 .Where(c => c.CategoryStatus)
								 .Select(c => new SelectListItem
								 {
									 Value = c.CategoryID.ToString(),
									 Text = c.CategoryName
								 }).ToList();

			ViewBag.Categories = categoryList;
			return View();
		}

		[HttpPost]
		public ActionResult Create(Product product)
		{
			if (ModelState.IsValid)
			{
				pm.ProductInsert(product);
				return RedirectToAction("Index");
			}

			var categoryList = cm.Categoryliste()
								 .Where(c => c.CategoryStatus)
								 .Select(c => new SelectListItem
								 {
									 Value = c.CategoryID.ToString(),
									 Text = c.CategoryName
								 }).ToList();

			ViewBag.Categories = categoryList;
			return View(product);
		}

		public ActionResult Edit(int id)
		{
			var categoryList = cm.Categoryliste()
								 .Where(c => c.CategoryStatus) 
								 .Select(c => new SelectListItem
								 {
									 Value = c.CategoryID.ToString(),
									 Text = c.CategoryName
								 }).ToList();

			ViewBag.Categories = categoryList;

			var sonuc = pm.GetById(id);
			if (sonuc == null)
				return HttpNotFound("Hatalı seçim..");

			return View(sonuc);
		}

		[HttpPost]
		public ActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				pm.ProductUpdate(product);
				return RedirectToAction("Index");
			}

			var categoryList = cm.Categoryliste()
								 .Where(c => c.CategoryStatus) 
								 .Select(c => new SelectListItem
								 {
									 Value = c.CategoryID.ToString(),
									 Text = c.CategoryName
								 }).ToList();

			ViewBag.Categories = categoryList;
			return View(product);
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var sonuc = pm.GetById(id);
			if (sonuc == null)
				return HttpNotFound();
			return View(sonuc);
		}
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			var product = pm.GetById(id);
			if (product != null)
			{
				pm.ProductDelete(product);
			}
			return RedirectToAction("Index");
		}
	}
}