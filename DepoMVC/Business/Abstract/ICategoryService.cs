using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
		List<Category> Categoryliste();
		void CategoryInsert(Category c);
		void CategoryUpdate(Category c);
		void CategoryDelete(Category c);
		Category GetById(int id);
	}
}
