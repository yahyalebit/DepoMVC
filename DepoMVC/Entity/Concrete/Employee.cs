using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class Employee
	{
		public int EmployeeId { get; set; }
		public string EmployeeFirstName { get; set; }
		public string EmployeeLastName { get; set; }

		public List<Order> Orders { get; set; }
	}
}
