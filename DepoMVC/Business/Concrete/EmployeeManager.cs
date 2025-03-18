using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class EmployeeManager : IEmployeeService
	{
		IEmployeeDal _employeedal;

		public EmployeeManager(IEmployeeDal employeeDal)
		{
			_employeedal = employeeDal;
		}

		public void EmployeeDelete(Employee e)
		{
			_employeedal.Delete(e);
		}

		public void EmployeeInsert(Employee e)
		{
			_employeedal.Insert(e);
		}

		public List<Employee> Employeeliste()
		{
			return _employeedal.liste();
		}

		public void EmployeeUpdate(Employee e)
		{
			_employeedal.Update(e);
		}

		public Employee GetById(int id)
		{
			return _employeedal.Get(x => x.EmployeeId == id);
		}
		public List<Employee> liste(Expression<Func<Employee, bool>> filter)
		{
			return _employeedal.liste(filter);
		}
	}
}
