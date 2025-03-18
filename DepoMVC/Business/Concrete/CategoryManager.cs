using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void CategoryDelete(Category c)
		{
			_categoryDal.Delete(c);
		}

		public void CategoryInsert(Category c)
		{
			_categoryDal.Insert(c);
		}

		public List<Category> Categoryliste()
		{
			return _categoryDal.liste();
		}

		public void CategoryUpdate(Category c)
		{
			_categoryDal.Update(c);
		}

		public Category GetById(int id)
		{
			return _categoryDal.Get(x => x.CategoryID == id);
		}
	}
}
