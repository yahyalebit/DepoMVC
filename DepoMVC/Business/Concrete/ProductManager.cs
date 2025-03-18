using Business.Abstract;
using Data.Abstract;
using Data.EntityFramework;
using Entity;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productdal;

		public ProductManager(IProductDal productdal)
		{
			_productdal = productdal;
		}

		public Product GetById(int id)
		{
			return _productdal.Get(x => x.ProductID == id);
		}

		public void ProductDelete(Product p)
		{
			_productdal.Delete(p);
		}

		public void ProductInsert(Product p)
		{
			_productdal.Insert(p);
		}

		public List<Product> Productliste()
		{
			return _productdal.liste(x => x.Category != null);
		}

		public void ProductUpdate(Product p)
		{
			_productdal.Update(p);
		}
		public List<Product> liste(Expression<Func<Product, bool>> filter)
		{
			return _productdal.liste(filter);
		}
	}
}
