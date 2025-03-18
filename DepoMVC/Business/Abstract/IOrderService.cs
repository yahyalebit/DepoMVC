using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
	{
		List<Order> Orderliste();
		void OrderInsert(Order o);
		void OrderUpdate(Order o);
		void OrderDelete(Order o);
		Order GetById(int id);
	}
}
