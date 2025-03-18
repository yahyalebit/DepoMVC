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
	public class OrderManager : IOrderService
	{
		IOrderDal _orderdal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderdal = orderDal;
		}

		public Order GetById(int id)
		{
			return _orderdal.Get(x => x.OrderId == id);
		}

		public void OrderDelete(Order o)
		{
			_orderdal.Delete(o);
		}

		public void OrderInsert(Order o)
		{
			_orderdal.Insert(o);
		}

		public List<Order> Orderliste()
		{
			return _orderdal.liste();
		}

		public void OrderUpdate(Order p)
		{
			_orderdal.Update(p);
		}
		public List<Order> liste(Expression<Func<Order, bool>> filter)
		{
			return _orderdal.liste(filter);
		}
	}
}
