using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abatract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();

        void CategoryAddBL(Category category);

        Category GetByID(int id);
    }
}
