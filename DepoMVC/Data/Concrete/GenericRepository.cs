using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		public Context db = new Context();
		DbSet<T> _obj;

		public GenericRepository()
		{
			_obj = db.Set<T>();
		}
		public void Insert(T entity)
		{
			var sonuc = db.Entry(entity);
			sonuc.State = EntityState.Added;
			db.SaveChanges();
		}
		public void Delete(T entity)
		{

			var sonuc = db.Entry(entity);
			sonuc.State = EntityState.Deleted;
			db.SaveChanges();
		}
		public T Get(Expression<Func<T, bool>> filter)
		{
			return _obj.SingleOrDefault(filter);
		}
		public List<T> liste()
		{
			return _obj.ToList();
		}
		public List<T> liste(Expression<Func<T, bool>> filter)
		{
			return _obj.Where(filter).ToList();
		}
		public void Update(T entity)
		{
			var sonuc = db.Entry(entity);
			sonuc.State = EntityState.Modified;
			db.SaveChanges();
		}
	}
}
