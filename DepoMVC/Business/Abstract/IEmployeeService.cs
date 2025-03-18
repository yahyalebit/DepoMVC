using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
		List<Employee> Employeeliste();
		void EmployeeInsert(Employee e);
		void EmployeeUpdate(Employee e);
		void EmployeeDelete(Employee e);
		Employee GetById(int id);
	}
}
