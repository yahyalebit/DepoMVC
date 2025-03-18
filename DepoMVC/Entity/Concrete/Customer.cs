﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Customer
    {
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerSurName { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
