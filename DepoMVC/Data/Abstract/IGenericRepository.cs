using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IGenericRepository<T>
    {
		List<T> liste();
		List<T> liste(Expression<Func<T, bool>> filter);
		T Get(Expression<Func<T, bool>> filter);
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
