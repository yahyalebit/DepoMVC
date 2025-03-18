using Business.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DepoMvcKatmanlıMimariProjectUI.Controllers
{
	public class CustomerController : Controller
	{
		CustomerManager cm = new CustomerManager(new EfCustomerDal());

		public ActionResult Index()
		{
			var customers = cm.Customerliste();
			return View(customers);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Customer customer)
		{
			if (ModelState.IsValid)
			{
				cm.CustomerInsert(customer);
				return RedirectToAction("Index");
			}
			return View(customer);
		}

		public ActionResult Edit(int id)
		{
			var customer = cm.GetById(id);
			if (customer == null)
				return HttpNotFound("Müşteri bulunamadı!");

			return View(customer);
		}

		[HttpPost]
		public ActionResult Edit(Customer customer)
		{
			if (ModelState.IsValid)
			{
				cm.CustomerUpdate(customer);
				return RedirectToAction("Index");
			}
			return View(customer);
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var customer = cm.GetById(id);
			if (customer == null)
				return HttpNotFound();
			return View(customer);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			var customer = cm.GetById(id);
			if (customer != null)
			{
				cm.CustomerDelete(customer);
			}
			return RedirectToAction("Index");
		}
	}
}
