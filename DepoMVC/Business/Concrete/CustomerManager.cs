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
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerdal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerdal = customerDal;
		}

		public void CustomerDelete(Customer c)
		{
			_customerdal.Delete(c);
		}

		public void CustomerInsert(Customer c)
		{
			_customerdal.Insert(c);
		}

		public List<Customer> Customerliste()
		{
			return _customerdal.liste();
		}

		public void CustomerUpdate(Customer c)
		{
			_customerdal.Update(c);
		}
		public Customer GetById(int id)
		{
			return _customerdal.Get(x => x.CustomerId == id);
		}
		public List<Customer> liste(Expression<Func<Customer, bool>> filter)
		{
			return _customerdal.liste(filter);
		}
	}
}