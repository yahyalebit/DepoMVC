using Business.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DepoMvcKatmanlıMimariProjectUI.Controllers
{
	public class EmployeeController : Controller
	{
		EmployeeManager em = new EmployeeManager(new EfEmployeeDal());

		public ActionResult Index()
		{
			var employees = em.Employeeliste();
			return View(employees);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Employee employee)
		{
			if (ModelState.IsValid)
			{
				em.EmployeeInsert(employee);
				return RedirectToAction("Index");
			}
			return View(employee);
		}
		public ActionResult Edit(int id)
		{
			var employee = em.GetById(id);
			if (employee == null)
				return HttpNotFound("Çalışan bulunamadı!");

			return View(employee);
		}

		[HttpPost]
		public ActionResult Edit(Employee employee)
		{
			if (ModelState.IsValid)
			{
				em.EmployeeUpdate(employee);
				return RedirectToAction("Index");
			}
			return View(employee);
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var employee = em.GetById(id);
			if (employee == null)
				return HttpNotFound();
			return View(employee);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			var employee = em.GetById(id);
			if (employee != null)
			{
				em.EmployeeDelete(employee);
			}
			return RedirectToAction("Index");
		}
	}
}
