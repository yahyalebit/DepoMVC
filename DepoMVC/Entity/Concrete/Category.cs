﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Category
    {
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public string CategoryDescription { get; set; }
		public bool CategoryStatus { get; set; }
		public List<Product> Products { get; set; }
	}
}
