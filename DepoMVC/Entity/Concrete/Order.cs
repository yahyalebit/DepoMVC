﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class Order
	{
		public int OrderId { get; set; }
		public int? CustomerId { get; set; }
		public int EmployeeId { get; set; }
		public DateTime OrderDate { get; set; }
		public virtual Employee Employee { get; set; }
	}
}
