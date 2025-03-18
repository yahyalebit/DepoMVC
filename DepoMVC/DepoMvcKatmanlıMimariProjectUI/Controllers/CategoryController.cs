using Business.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DepoMvcKatmanlıMimariProjectUI.Controllers
{
	public class CategoryController : Controller
	{
		CategoryManager cm = new CategoryManager(new EfCategoryDal());

		public ActionResult Index()
		{
			var categories = cm.Categoryliste();
			return View(categories);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
				cm.CategoryInsert(category);
				return RedirectToAction("Index");
			}
			return View(category);
		}

		public ActionResult Edit(int id)
		{
			var category = cm.GetById(id);
			if (category == null)
				return HttpNotFound("Hatalı seçim..");

			return View(category);
		}

		[HttpPost]
		public ActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				cm.CategoryUpdate(category);
				return RedirectToAction("Index");
			}
			return View(category);
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var category = cm.GetById(id);
			if (category == null)
				return HttpNotFound();
			return View(category);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			var category = cm.GetById(id);
			if (category != null)
			{
				cm.CategoryDelete(category);
			}
			return RedirectToAction("Index");
		}
	}
}
